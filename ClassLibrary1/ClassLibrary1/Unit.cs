using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public abstract class Unit
    {

        public Points Points
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Tile currentTile
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int x
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int y
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void move(Tile targetTile)
        {
            throw new System.NotImplementedException();
        }

        public void attack(Unit adverseUnit)
        {
            throw new System.NotImplementedException();
        }

        public void setPosition(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// initialise points according to the Race of the unit
        /// </summary>
        public void initialisePoints()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// set victory points according to the current tile
        /// </summary>
        public void setVictoryPoints()
        {
            throw new System.NotImplementedException();
        }

        public Unit createUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}
