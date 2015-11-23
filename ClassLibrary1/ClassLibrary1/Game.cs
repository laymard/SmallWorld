using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Game
    {
        private Map map;
        private int currentPlayer;

        public Map Map
        {
            get { return map; }
            set { map = value; }
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
            this.currentPlayer = (currentPlayer + 1) % map.MapSize.NbPlayers; 
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
        /// initialise le premier joueur
        /// </summary>
        public void setFirstPlayer()
        {
            throw new System.NotImplementedException();
        }

        public void saveGame()
        {
            throw new System.NotImplementedException();
        }

        public void selectTile(Coordinate tile)
        {
            throw new System.NotImplementedException();
        }

        public void selectUnit(Unit unit)
        {
            throw new System.NotImplementedException();
        }

        public void attack(Coordinate tile)
        {
            throw new System.NotImplementedException();
        }

        public Boolean currentPlayerWin(Unit opponentUnit)
        {
            throw new System.NotImplementedException();
        }

        public Unit selectBestDefender(Array<AttackUnits> unitsOnAttackedTile)
        {
            throw new System.NotImplementedException();
        }
    }
}
