using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Game
    {
        private int currentPlayer;

        public Map Map
        {
            get;
            set;
        }


        public List<Player> Players
        {
            get;
            set;
        }

        public int TurnsLeft
        {
            get;
            set;
        }

        public Player CurrentPlayer
        {
            get {
                return this.Players[currentPlayer];
                }
        }

        public Unit CurrentUnit
        {
            get;
            set;
        }

        public Coordinate selectedTile
        {
            get;
            set;
        }
        public Game()
        {

        }

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

        public void changePlayer()
        {
            this.currentPlayer = (currentPlayer + 1) % Map.MapSize.NbPlayers; 
        }

        public void end()
        {
            this.TurnsLeft = 0;
        }

        /// <summary>
        /// vérifie que les deux joueurs ont choisi deux races différentes.
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
            this.currentPlayer = rnd.Next(0, 1);
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
