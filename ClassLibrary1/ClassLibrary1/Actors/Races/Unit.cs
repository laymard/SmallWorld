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
        [XmlElement()]
        public Points Points
        {
            get;
            set;
        }

        [XmlAttribute()]
        public TileType currentTile
        {
            get;
            set;
        }

        /// <summary>
        /// position de l'unité sur la carte
        /// </summary>
        [XmlElement()]
        public Coordinate coord
        {
            get;
            set;
        }

        public virtual Dictionary<TileType, double> RequiredMovePoints
        {
            get;
            set;
        }

        public Unit(Coordinate coord, TileType type)
        {
            this.coord = coord;
            this.currentTile = type;
        }
        public Unit() { }

        public void  move(Coordinate targetTile, TileType type)
        {
                this.spendMovePoints(type);
                coord = targetTile;
                currentTile = type;
                this.addVictoryPoints();
        }

        /// <summary>
        /// set victory points according to the current tile
        /// </summary>
        public abstract void addVictoryPoints();

        public virtual void looseLifePoints(int nbPoints)
        {
            Points.lifePoints -= nbPoints;
        }

        public abstract bool canMove(Coordinate tile, TileType type);

        public abstract bool canAttack(Coordinate tile, TileType type);

        public bool betterDefence(Unit unit)
        {
            return this.Points.defencePoints > unit.Points.defencePoints;
        }

        internal bool isDead()
        {
            return this.Points.lifePoints <= 0;
        }

         public double getRatioDefender()
        {
            return this.Points.getRatioDefender();
        }

         public double getRatioAttacker()
         {
             return this.Points.getRatioAttacker();
         }

         public void spendMovePoints(TileType type)
        {
             this.Points.MovePoints -= RequiredMovePoints[type];
        }

    }
}
