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
            get;
            set;
        }

        public TileType currentTile
        {
            get;
            set;
        }

        /// <summary>
        /// position de l'unité sur la carte
        /// </summary>
        public Coordinate coord
        {
            get;
            set;
        }


        public virtual void  move(Coordinate targetTile)
        {
            if (this.canMove(targetTile))
            {
                coord = targetTile;
            }
        }

        /// <summary>
        /// set victory points according to the current tile
        /// </summary>
        public abstract virtual void addVictoryPoints();

        /// <summary>
        /// spendMovePoints(int x,int y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract virtual void spendMovePoints(int x, int y);

        public int getRatioLifePoints()
        {
            return Points.getRatioLifePoints();
        }

        public virtual void looseLifePoints(int nbPoints)
        {
            Points.lifePoints -= nbPoints;
        }

        public abstract virtual bool canMove(Coordinate tile);

        public abstract virtual bool canAttack(Coordinate tile);

        public bool betterDefence(Unit unit)
        {
            return this.Points.defencePoints > unit.Points.defencePoints;
        }

        public Unit(Coordinate coord)
        {
            this.coord = coord;
            this.currentTile = Map.getTile(coord);
        }

    }
}
