using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Game
    {
        /// <summary>
        /// Liste des joueurs (au moins deux)
        /// </summary>
        public List<Player> Players
        {
            get;
            set
            {
                if (value.Count > 1) this.Players = value;
            }
        }

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
        /// Dernière case sélectionnée (pour attaque ou déplacement).
        /// </summary>
        public Coordinate selectedTile
        {
            get;
            set;
        }



        /// <summary>
        /// Nombre de tours restant.
        /// </summary>
        public int TurnsLeft
        {
            get;
            set;
        }


        /// <summary>
        /// Constructeur de la classe Game.
        /// </summary>
        public Game()
        {

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

        public void initializePlayer()
        {
            throw new System.NotImplementedException();
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

        /// <summary>
        /// initialise le premier joueur de manière aléatoire
        /// </summary>
        public void setFirstPlayer()
        {
            Random rnd = new Random();
            this.currentPlayer = rnd.Next(0, Players.Count);
        }

        public void saveGame()
        {
            // TO DO
        }

        public void selectTile(Coordinate tile)
        {
            selectedTile = tile;
        }

        public void selectUnit(Coordinate tile)
        {
            List<Unit> playerUnits = CurrentPlayer.getUnitsOnTile(tile);
            if (!(playerUnits.Count == 0))
            {
                // affichage des unités et demande au joueur d'en sélectionner une.
                //CurrentUnit = unit;
            }

           
        }


        public void attack(Coordinate tile)
        {
            if (CurrentUnit.canAttack(tile))
            {
                Unit defender = selectBestDefender(tile);
                
                bool winner = this.chooseWinner(defender);
                // nombre de points perdus généré aléatoirement
                Random rnd = new Random();
                int lost = rnd.Next(1, 4);
                if (winner)
                {
                    defender.looseLifePoints(lost);
                }
                else
                {
                    CurrentUnit.looseLifePoints(lost);
                }
            }
        }

        public Boolean chooseWinner(Unit opponentUnit)
        {
            // TO DO : algo de décision du vainqueur entre les unités currentUnit et defender
            // retourne true si currentUnit a gagné, false sinon
            int DefenderLife = opponentUnit.getRatioLifePoints();
            int AttackerLife = CurrentUnit.getRatioLifePoints();
            return true;
            
        }

        public Unit selectBestDefender(Coordinate tile)
        {
            int i = 0;
            bool found = false;
            Unit res;

            // Pour chaque joueur (en supposant qu'il puisse y en avoir plus de 2) on ajoute sa meilleure unité à la liste des defenseurs possibles
            while(!found && i<Players.Count)
            {
                List<Unit> p_units = Players[i].getUnitsOnTile(tile);
                if (!(p_units.Count == 0)) // si le joueur a au moins une unité sur la case
                {
                    found = true;

                    Unit best = p_units[0];
                    foreach(Unit u in p_units)
                    {
                        if(u.betterDefence(best))
                        {
                            best = u;
                        }
                    }
                    return best;
                }
            }

            return null;
        }
    }
}
