using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Game
    {
        private Map map;

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
            get;
            set;
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
            this.Map = new Map();
            this.Players = new List<Player>(ms.nbPlayers);
            this.TurnsLeft = ms.nbTurns;


        }

        public void initializePlayer()
        {
            throw new System.NotImplementedException();
        }

        public void changePlayer()
        {
            throw new System.NotImplementedException();
        }

        public void end()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// vérifie que les deux joueurs ont choisi deux races différentes.
        /// </summary>
        public void checkRaces()
        {
            throw new System.NotImplementedException();
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
