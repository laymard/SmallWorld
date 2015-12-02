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

        public Tile currentTile
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


        public void move(Coordinate targetTile)
        {
            coord = targetTile;
        }

        public void attack(Unit adverseUnit)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// set victory points according to the current tile
        /// </summary>
        public void addVictoryPoints()
        {}

 
        public Unit createUnit(Race race)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// spendMovePoints(int x,int y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int spendMovePoints(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public int getRatioLifePoints()
        {
            return Points.getRatioLifePoints();
        }

        public void looseLifePoints(int nbPoints)
        {
            Points.lifePoints -= nbPoints;
        }

        public Boolean canMove(Coordinate tile)
        {
            throw new System.NotImplementedException();
        }

        public bool canAttack(Coordinate tile)
        {
            throw new System.NotImplementedException();
        }

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
