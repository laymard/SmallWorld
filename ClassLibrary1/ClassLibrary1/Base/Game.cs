﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibrary1
{
    [Serializable]
    public class Game
    {
        private List<Player> players;
        /// <summary>
        /// Liste des joueurs (au moins deux)
        /// </summary>
        public List<Player> Players
        {
            get
            {
                return this.players;
            }
            set
            {
                if (value.Count > 1) this.players = value;
            }
        }

        [XmlAttribute]
        /// <summary>
        /// Indice du joueur courant dans la liste des joueurs Players.
        /// </summary>
        private int currentPlayer;

        /// <summary>
        /// Joueur courant.
        /// </summary>
        public Player CurrentPlayer
        {
            get
            {
                return this.Players[currentPlayer];
            }
        }

        /// <summary>
        /// Carte du jeu.
        /// </summary>
        public Map Map
        {
            get;
            set;
        }

        /// <summary>
        /// Unité choisie par le joueur courant.
        /// </summary>
        public Unit CurrentUnit
        {
            get;
            set;
        }

        /// <summary>
        /// Unité attaquée.
        /// </summary>
        public Unit AttackedUnit
        {
            get;
            set;
        }

        /// <summary>
        /// Dernière case sélectionnée (pour attaque ou déplacement).
        /// </summary>
        public Coordinate SelectedTile
        {
            get;
            set;
        }



        /// <summary>
        /// Nombre de tours restant.
        /// </summary>
        [XmlAttribute]
        public int TurnsLeft
        {
            get;
            set;
        }


        /// <summary>
        /// Constructeur de la classe Game.
        /// </summary>
        public Game(MapSize ms, List<Player> players)
        {
            this.CurrentUnit = null;
            this.AttackedUnit = null;
            initializeMap(ms);

            this.Players = players;

            this.initializeUnits();
            setFirstPlayer();
        }

        /// <summary>
        /// Constructeur de la classe Game.
        /// </summary>
        public Game()
        {
            this.CurrentUnit = null;
            this.AttackedUnit = null;
            initializeMap(new StandardMap());

            this.Players = new List<Player>();
        }

        /// <summary>
        /// Initialisation de la carte à partir des caractéristiques du mode de jeu contenues dans la MapSize ms.
        /// </summary>
        public void initializeMap(MapSize ms)
        {
            this.Map = new Map(ms);
            this.Players = new List<Player>(ms.NbPlayers);
            this.TurnsLeft = ms.NbTurns;
        }


        /// <summary>
        /// Initialisation et positionnement des unités sur la carte.
        /// </summary>
        public void initializeUnits()
        {
            foreach (Player p in Players) 
            {
                for (int i = 0; i < p.NbUnits - 1; i++)
                {
                    Random rndx = new Random();
                    int x = rndx.Next(0, Map.MapSize.NbTiles -1);
                    int y = rndx.Next(0, Map.MapSize.NbTiles - 1);
                    Coordinate coord = this.Map.getCoord(x,y);
                    p.createUnit(coord,this.Map.getTile(coord));
                }
            }
        }

        /// <summary>
        /// initialise le premier joueur de manière aléatoire
        /// </summary>
        public void setFirstPlayer()
        {
            Random rnd = new Random();
            this.currentPlayer = rnd.Next(0, Players.Count - 1);
        }

        /// <summary>
        /// Changement de joueur : remplace le joueur courant par le joueur suivant dans la liste Players.
        /// </summary>
        public void changePlayer()
        {
            this.currentPlayer = (currentPlayer + 1) % Map.MapSize.NbPlayers; 
        }

        /// <summary>
        /// Fin du jeu.
        /// </summary>
        public void end()
        {
            this.TurnsLeft = 0;
        }

        /// <summary>
        /// Vérifie que la Race race n'a pas déjà été choisie par un autre joueur lors de l'initialisation de la partie.
        /// </summary>
        public void checkRaces(Race race)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Race.Equals(race))
                {
                    // traiter le cas du choix d'une race déjà sélectionnée
                }
            }
        }

        public void saveGame()
        {
            // TO DO
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
        /// Affiche les unités présentes sur la case tile et sélectionne l'unité choisie par le joueur.
        /// </summary>
        public void selectUnit(Coordinate tile)
        {
            List<Unit> playerUnits = CurrentPlayer.getUnitsOnTile(tile);
            if (!(playerUnits.Count == 0))
            {
                // affichage des unités et demande au joueur d'en sélectionner une.
                //CurrentUnit = unit;
            }

           
        }

        /// <summary>
        /// Attaque d'une case par l'unité courante.
        /// </summary>
        public void attack()
        {
            TileType type = this.Map.getTile(SelectedTile);
            if (CurrentUnit.canAttack(SelectedTile,type))
            {
                // choix du vainqueur de l'attaque
                bool winner = this.chooseWinner(AttackedUnit);

                // nombre de points perdus généré aléatoirement
                Random rnd = new Random();
                int lost = rnd.Next(1, 4);
                if (winner)
                {
                    AttackedUnit.looseLifePoints(lost);
                }
                else
                {
                    CurrentUnit.looseLifePoints(lost);
                }
            }
        }

        /// <summary>
        /// Algorithme de décision du vainqueur entre les unités currentUnit et defender
        /// </summary>
        public Boolean chooseWinner(Unit opponentUnit)
        {
            // TO DO : algo de décision du vainqueur entre les unités currentUnit et defender
            // retourne true si currentUnit a gagné, false sinon
            int DefenderLife = opponentUnit.getRatioLifePoints();
            int AttackerLife = CurrentUnit.getRatioLifePoints();
            return true;
            
        }

        /// <summary>
        /// Si des unités sont présentes sur la cases alors la meilleure unité est choisie pour l'attaque.
        /// retourne true si une unité est attaquée, false sinon
        /// </summary>
        public bool selectBestDefender(Coordinate tile)
        {
            int i = 0;
            bool found = false;

            while (!found && i < Players.Count)
            {
                List<Unit> p_units = Players[i].getUnitsOnTile(tile);
                if (!(p_units.Count == 0)) // si le joueur a au moins une unité sur la case
                {
                    // le joueur présent sur la case tile est trouvé
                    found = true;

                    Unit best = p_units[0];
                    foreach (Unit u in p_units)
                    {
                        if (u.betterDefence(best))
                        {
                            best = u;
                        }
                    }
                    AttackedUnit = best;
                }
            }
            // pas d'unité sur cette case.
            return found;
        }

        public void SaveGame(string path)
        {
            XmlSerializer game_serializer = new XmlSerializer(typeof(Game));
            StreamWriter writer = new StreamWriter(path,false);
            game_serializer.Serialize(writer, this);
            writer.Close();
        }
    }
}
