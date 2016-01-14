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

        [XmlIgnore()]
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
            this.Champion = null;
            this.Map = new Map();
            this.Players = new List<Player>();
        }

        /// <summary>
        /// Constructeur de Game à partir d'une sauvegarde
        /// </summary>
        /// <param name="gs">Jeu chargé</param>
        public Game(GameSaver gs)
        {
            this.Players = gs.Game.Players;
            this.CurrentPlayerIndex = gs.Game.CurrentPlayerIndex;
            this.Map = new Map(gs.Game.Map, gs.Matrix);
            this.TurnsLeft = gs.Game.TurnsLeft;
        }

        /// <summary>
        /// Ajoute un joueur au jeu après avoir vérifié que sa race n'a pas déjà été choisie par un autre joueur. 
        /// </summary>
        /// <param name="race">race du joueur</param>
        /// <param name="name">nom du joueur</param>
        /// <param name="nbUnits">nombre d'unités</param>
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
                      switch (p.Race)
                      {
                          case Race.Human :
                               while (p.Units.Count != p.Units.Capacity)
                          {
                    // creation de l'unit si la case n'est pas occupée par un autre joueur
                        p.createUnit(coord, this.Map.getTile(coord));
                          }
                          break;

                          default :
                               TileType tile =this.Map.getTile(coord);
                               while(tile.Equals(TileType.WATER)){
                                   x = rnd.Next(0, Map.MapSize.NbTiles - 1);
                                   y = rnd.Next(0, Map.MapSize.NbTiles - 1);
                                   coord = Map.getCoord(x, y);
                                   tile = this.Map.getTile(coord);
                               }
                                {
                                    while (p.Units.Count != p.Units.Capacity)
                                    {
                                        // creation de l'unit si la case n'est pas occupée par un autre joueur
                                        p.createUnit(coord, this.Map.getTile(coord));
                                    }
                               }
                               break;
                      }       
                }
            }
            setFirstPlayer();
        }

        /// <summary>
        /// Vérifie s'il y a un autre joueur que player sur la case coord
        /// </summary>
        /// <param name="coord">Coordonnées de la case</param>
        /// <param name="player">Joueur concerné</param>
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
                this.CurrentPlayerIndex = (CurrentPlayerIndex + 1) % (Map.MapSize.NbPlayers);
                if (this.CurrentPlayerIndex == 0)
                {
                    this.TurnsLeft--;
                    foreach(Player p in this.Players){
                        p.finishMoves();
                    }
                }
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
        /// Fin du jeu : le champion est soit le dernier joueur vivant, soit le joueur ayant le plus de points de victoire
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
        /// Vérifie que la Race race n'a pas déjà été choisie par un autre joueur lors de l'initialisation de la partie. 
        /// </summary>
        /// <param name="race">Race</param>
        /// <returns>Retourne faux si la race a déjà été selectionnée. Vrai, sinon.</returns>
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
        ///  Selectionne la case tile et si des unités sont présentes sur la cases alors la meilleure unité est choisie pour l'attaque.
        /// </summary>
        /// <param name="tile">Case à sélectionner</param>
        public void selectTile(Coordinate tile)
        {
            if (CurrentPlayer.CurrentUnit != null)
            {
                if (selectBestDefender(tile))
                {
                    attack();
                }
                else
                {
                    this.move(tile);
                }
            }

            SelectedTile = tile;
         
        }

        /// <summary>
        /// Attaque d'une unité par l'unité courante.
        /// </summary>
        public void attack()
        {
            TileType type = this.Map.getTile(AttackedUnit.coord);
            if (CurrentPlayer.CurrentUnit.canAttack(AttackedUnit.coord, type))
            {
                // choix du vainqueur de l'attaque
                bool winner = this.chooseWinner(AttackedUnit);

                // nombre de points perdus généré aléatoirement
                Random rnd = new Random();
                int lost = rnd.Next(1, 4);
                if (winner)
                {
                    String otherPlayer = Players[(CurrentPlayerIndex + 1) % (Map.MapSize.NbPlayers)].Name;
                    notify(CurrentPlayer.Name,otherPlayer,otherPlayer,lost);
                    AttackedUnit.looseLifePoints(lost);
                    if (AttackedUnit.isDead())
                    {
                        CurrentPlayer.CurrentUnit.move(AttackedUnit.coord, AttackedUnit.currentTile);
                    }
                }
                else
                {
                    String otherPlayer = Players[(CurrentPlayerIndex + 1) % (Map.MapSize.NbPlayers)].Name;
                    notify(CurrentPlayer.Name, otherPlayer, CurrentPlayer.Name, lost);
                    CurrentPlayer.CurrentUnit.looseLifePoints(lost);
                    CurrentPlayer.CurrentUnit.spendMovePoints(type);
                }
            }
        }

        /// <summary>
        /// Déplacement de l'unité courante
        /// </summary>
        /// <param name="coord">Coordonnées de la case cible</param>
        public void move(Coordinate coord)
        {
            TileType type = Map.getTile(coord);
            CurrentPlayer.CurrentUnit.move(coord, type);
        }

        /// <summary>
        /// Algorithme de décision du vainqueur entre les unités CurrentUnit et opponentUnit
        /// </summary>
        /// <param name="opponentUnit">Unité attaquée</param>
        /// <returns></returns>
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
        /// </summary>
        /// <param name="tile">Coordonnées</param>
        /// <returns> retourne true si une unité est attaquée, false sinon</returns>
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
        /// <param name="coord">Coordonnées</param>
        /// <returns></returns>
        public List<Unit> getUnitsOnTile(Coordinate coord)
        {
            List<Unit> units = new List<Unit>();
            foreach (Player p in Players)
            {
                foreach (Unit u in p.getUnitsOnTile(coord))
                {
                    units.Add(u);
                }
            }
            return units;
        }

        /// <summary>
        /// Sauvegarde du jeu
        /// </summary>
        /// <param name="path">path du fichier de sauvegarde</param>
        public void saveGame(String path)
        {
            GameSaver gs = new GameSaver(this);
            gs.SaveGame(path);
        }

        public void notify(String attackName, String defenseName, String looserName, int nbPoints)
        {
            Observer.INSTANCE.update(attackName, defenseName, looserName, nbPoints);
        }
    }
}
