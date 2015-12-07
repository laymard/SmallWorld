using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class Elf : Unit
    {
        /// <summary>
        /// Constructeur Elf
        /// </summary>
        /// <param name="coord"> coordonnées de départ </param>
        public Elf(Coordinate coord, TileType type) : base(coord,type)
        {
            this.Points = new Points(12,4,3);
        }
        public Elf()
            : base(){ }
        public static IDictionary<TileType,int> RequiredMovePoints
        {
            get
            {
                return new Dictionary<TileType, int>()
                {
                    {TileType.MOUNTAIN,2 },
                    {TileType.WATER,-1 },
                    {TileType.FOREST,1 },
                    {TileType.PLAIN,1 }

                };
            }
        }

        public override void addVictoryPoints()
        {
            switch (currentTile)
            {
                case TileType.FOREST :
                    this.Points.victoryPoints += 3;
                    break;
                case TileType.PLAIN:
                    this.Points.victoryPoints += 1;
                    break;
                default :
                    break;
            }
        }

        public override bool canAttack(Coordinate tile, TileType type)
        {
            int dist = this.coord.distanceFrom(tile);
            return (dist == 1 || dist == 2);
        }

        public override bool canMove(Coordinate tile, TileType type)
        {
            // Les elfes ne peuvent pas aller sur l'eau
            if (type == TileType.WATER)
                return false;

            double cost = (double)this.coord.distanceFrom(tile);

            if (cost < 0) 
                return false;

            if (type == TileType.MOUNTAIN) cost *= 2;
            double movePoints = this.Points.movePoints;

            return movePoints >= cost;
        }

    public override void looseLifePoints(int nbPoints)
        {
            base.looseLifePoints(nbPoints);
        }

        public override void move(Coordinate targetTile, TileType type)
        {
            base.move(targetTile,type);
        }

        public override void spendMovePoints(Coordinate targetTile, TileType type)
        {
            int cost = this.coord.distanceFrom(targetTile);
            if (type == TileType.MOUNTAIN) cost *= 2;
            Points.movePoints -= cost;
        }
    }
}
