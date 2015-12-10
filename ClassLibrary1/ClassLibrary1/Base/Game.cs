using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class Game
    {
        /// <summary>
        /// Liste des joueurs (au moins deux)
        /// </summary>

        [XmlArray("players")]
        [XmlArrayItem("player")]
        public List<Player> Players
        {
            get;
            set;
        }


        /// <summary>
        /// Indice du joueur courant dans la liste des joueurs Players.
        /// </summary>
        [XmlAttribute()]
        public int CurrentPlayerIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Joueur courant.
        /// </summary>
        [XmlIgnore()]
        public Player CurrentPlayer
        {
            get
            {
                return this.Players[CurrentPlayerIndex];
            }
        }

        /// <summary>
        /// Joueur vainqueur.
        /// </summary>
        public Player Champion { get; set; }

        /// <summary>
        /// Carte du jeu.
        /// </summary>
        [XmlElement()]
        public Map Map
        {
            get;
            set;
        }


        /// <summary>
        /// Unité attaquée.
        /// </summary>
        [XmlIgnore()]
        public Unit AttackedUnit
        {
            get;
            set;
        }

        /// <summary>
        /// Dernière case sélectionnée (pour attaque ou déplacement).
        /// </summary>
        [XmlIgnore()]
        public Coordinate SelectedTile
        {
            get;
            set;
        }



        /// <summary>
        /// Nombre de tours restant.
        /// </summary>
        [XmlAttribute()]
        public int TurnsLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Constructeur par défaut de la classe Game.
        /// </summary>
        public Game()
        {
            this.AttackedUnit = null;
            this.Map = new Map();
            this.Players = new List<Player>();
        }

        public Game(GameSaver gs)
        {
            this.Players = gs.Game.Players;
            this.CurrentPlayerIndex = gs.Game.CurrentPlayerIndex;
            this.Map = new Map(gs.Game.Map, gs.Matrix);
            this.TurnsLeft = gs.Game.TurnsLeft;
        }

        public void AddPlayer(Race race, String name, int nbUnits)
        {
            Player p = new Player(race, name, nbUnits);
            if (checkRaces(p.Race))
            {
                Players.Add(p);
            }
        }

        /// <summary>
        /// Initialisation et positionnement des unités sur la carte.
        /// </summary>
        public void StartGame()
        {
            Random rnd = new Random();
            foreach (Player p in Players)
            {
                int x = rnd.Next(0, Map.MapSize.NbTiles - 1);
                int y = rnd.Next(0, Map.MapSize.NbTiles - 1);
                Coordinate coord = Map.getCoord(x, y);

                if (!otherRaceOnTile(coord, p))
                {
                    while (p.Units.Count != p.Units.Capacity)
                    {
                    // creation de l'unit si la case n'est pas occupée par un autre joueur
                        p.createUnit(coord, this.Map.getTile(coord));
                    }
                }
            }
            setFirstPlayer();
        }

        /// <summary>
        /// Vérifie s'il y a un autre joueur que player sur la case coord
        /// </summary>
        /// <param name="coord"></param>
        /// <param name="player"></param>
        /// <returns>true si un autre joueur est présent, faux sinon.</returns>
        public bool otherRaceOnTile(Coordinate coord, Player player)
        {
            bool res = false;
            foreach (Player p in Players)
            {
                if (!p.Equals(player) && p.getUnitsOnTile(coord).Count > 0)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// initialise le premier joueur de manière aléatoire
        /// </summary>
        public void setFirstPlayer()
        {
            Random rnd = new Random();
            this.CurrentPlayerIndex = rnd.Next(0, Players.Count - 1);
        }

        /// <summary>
        /// Changement de joueur : remplace le joueur courant par le joueur suivant dans la liste Players.
        /// </summary>
        public void EndTurn()
        {
            // Le jeu est-il fini ?
            if (TurnsLeft == 0 || Victory())
                this.end();

            // Changement de joueur
            else
            {
                this.CurrentPlayerIndex = (CurrentPlayerIndex + 1) % (Map.MapSize.NbPlayers + 1);
            }
        }

        /// <summary>
        /// Vérifie s'il y a un vainqueur
        /// </summary>
        /// <returns></returns>
        private bool Victory()
        {
            List<Player> alive = new List<Player>();
            foreach (Player p in Players)
            {
                if (!p.IsDead()) { alive.Add(p); }
            }
            //return (alive.Count == 1);
            if (alive.Count == 1)
            {
                this.Champion = alive[0];
                return true;
            }
            else return false;

        }

        /// <summary>
        /// Fin du jeu.
        /// </summary>
        public void end()
        {
            if (TurnsLeft == 0)
            {
                Player champion = new Player();
                foreach (Player p in Players)
                {
                    if (p.VictoryPoints > champion.VictoryPoints)
                    {
                        champion = p;
                    }
                }

                this.Champion = champion;
            }

            this.TurnsLeft = 0;
        }

        /// <summary>
        /// Vérifie que la Race race n'a pas déjà été choisie par un autre joueur lors de l'initialisation de la partie. Retourne faux si la race a déjà été selectionnée. Vrai, sinon.
        /// </summary>
        public bool checkRaces(Race race)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Race.Equals(race))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Selectionne la case tile et si des unités sont présentes sur la cases alors la meilleure unité est choisie pour l'attaque.
        /// </summary>
        public void selectTile(Coordinate tile)
        {
            SelectedTile = tile;
            if (selectBestDefender(tile))
            {
                attack();
            }
        }

        /// <summary>
        /// Attaque d'une unité par l'unité courante.
        /// </summary>
        public void attack()
        {
            TileType type = this.Map.getTile(SelectedTile);
            if (CurrentPlayer.CurrentUnit.canAttack(SelectedTile, type))
            {
                // choix du vainqueur de l'attaque
                bool winner = this.chooseWinner(AttackedUnit);

                // nombre de points perdus généré aléatoirement
                Random rnd = new Random();
                int lost = rnd.Next(1, 4);
                if (winner)
                {
                    AttackedUnit.looseLifePoints(lost);
                    if (AttackedUnit.isDead())
                    {
                        CurrentPlayer.CurrentUnit.move(AttackedUnit.coord, AttackedUnit.currentTile);
                    }
                }
                else
                {
                    CurrentPlayer.CurrentUnit.looseLifePoints(lost);
                    CurrentPlayer.CurrentUnit.spendMovePoints(type);
                }
            }
        }


        public void move(Coordinate coord)
        {
            TileType type = Map.getTile(coord);
            CurrentPlayer.CurrentUnit.move(coord, type);
        }

        public void move(int x, int y)
        {
            Coordinate coord = Map.getCoord(0, 0);
            TileType type = Map.getTile(coord);
            CurrentPlayer.CurrentUnit.move(coord, type);
        }
        /// <summary>
        /// Algorithme de décision du vainqueur entre les unités CurrentUnit et opponentUnit
        /// </summary>
        public Boolean chooseWinner(Unit opponentUnit)
        {
            double defender = opponentUnit.getRatioDefender();
            double attacker = CurrentPlayer.CurrentUnit.getRatioAttacker();

            Random r = new Random();
            double rnd = r.Next(0, 1);

            return (rnd > defender / (attacker + attacker));
        }

        /// <summary>
        /// Si des unités sont présentes sur la cases alors la meilleure unité est choisie pour l'attaque.
        /// retourne true si une unité est attaquée, false sinon
        /// </summary>
        public bool selectBestDefender(Coordinate tile)
        {
            List<Unit> units = this.getUnitsOnTile(tile);

            // s'il n'y a pas d'unité sur la case
            if ((units.Count == 0)) return false;

            // s'il y a au moins une unité sur la case
            else
            {
                Unit best = units[0];
                foreach (Unit u in units)
                {
                    if (u.betterDefence(best))
                    {
                        best = u;
                    }
                }
                AttackedUnit = best;
                return true;
            }
        }

        /// <summary>
        /// Retourne la liste des unités présentes sur la case coord
        /// </summary>
        public List<Unit> getUnitsOnTile(Coordinate coord)
        {
            List<Unit> units = new List<Unit>();
            foreach (Player p in Players)
            {
                foreach (Unit u in p.Units)
                {
                    units.Add(u);
                }
            }
            return units;
        }

        public void saveGame(String path)
        {
            GameSaver gs = new GameSaver(this);
            gs.SaveGame(path);
        }
    }
}
