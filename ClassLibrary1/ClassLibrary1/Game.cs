using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Game
    {

        public Map Map
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Player> Player
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Stratege Stratege
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int turnsLeft
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int currentPlayer
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Unit currentUnit
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void initializeMap()
        {
            throw new System.NotImplementedException();
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
