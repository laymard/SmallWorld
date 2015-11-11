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

        /// <summary>
        /// position de l'unité sur la carte
        /// </summary>
        public Coordinate coord
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public mapPositionTile mapPositionTile
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void move(Coordinate targetTile)
        {
            throw new System.NotImplementedException();
        }

        public void attack(Unit adverseUnit)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// set victory points according to the current tile
        /// </summary>
        public void addVictoryPoints()
        {
            throw new System.NotImplementedException();
        }

        public Unit createUnit()
        {
            throw new System.NotImplementedException();
        }

        public int spendMovePoints(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public int getRatioLifePoints()
        {
            throw new System.NotImplementedException();
        }

        public void looseLifePoints(int nbPoints)
        {
            throw new System.NotImplementedException();
        }

        public Boolean canMove(Coordinate tile)
        {
            throw new System.NotImplementedException();
        }

        public Coordinate canAttack(Boolean tile)
        {
            throw new System.NotImplementedException();
        }
    }
}
