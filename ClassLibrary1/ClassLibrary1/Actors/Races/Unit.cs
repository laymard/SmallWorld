using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable(), XmlInclude(typeof(Elf)), XmlInclude(typeof(Orc)),XmlInclude(typeof(Human))]
    public abstract class Unit
    {

        public Points Points
        {
            get;
            set;
        }

        [XmlAttribute]
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
                this.spendMovePoints(targetTile);
            }
        }

        /// <summary>
        /// set victory points according to the current tile
        /// </summary>
        public abstract void addVictoryPoints();

        /// <summary>
        /// spendMovePoints(int x,int y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract void spendMovePoints(Coordinate targetTile);

        public int getRatioLifePoints()
        {
            return Points.getRatioLifePoints();
        }

        public virtual void looseLifePoints(int nbPoints)
        {
            Points.lifePoints -= nbPoints;
        }

        public abstract bool canMove(Coordinate tile);

        public abstract bool canAttack(Coordinate tile);

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
