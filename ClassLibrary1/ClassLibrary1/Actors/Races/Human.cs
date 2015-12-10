using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class Human : Unit
    {
        public Human(Coordinate coord, TileType type)
            : base(coord, type)
        {
            this.Points = new Points(15, 6, 3);
        }
        public Human()
            : base() { }

        public override void addVictoryPoints()
        {
            switch (this.currentTile)
            {
                case TileType.PLAIN:
                    this.Points.victoryPoints += 2;
                    break;
                case TileType.FOREST:
                    this.Points.victoryPoints += 1;
                    break;
                case TileType.MOUNTAIN:
                    this.Points.victoryPoints += 1;
                    break;
                default:
                    break;
            }
        }

        public override bool canAttack(Coordinate tile, TileType type)
        {
            int dist = this.coord.distanceFrom(tile);
            bool distance = (dist == 1);
            bool points = Human.requiredMovePoints[type] < this.Points.MovePoints;

            return (points && distance);
        }


        private static Dictionary<TileType, double> requiredMovePoints = new Dictionary<TileType, double>()
                {
                    {TileType.MOUNTAIN,1 },
                    {TileType.WATER,1 },
                    {TileType.FOREST,1 },
                    {TileType.PLAIN,1 }
                };

        public override Dictionary<TileType, double> RequiredMovePoints
        {
            get
            {
                return Human.requiredMovePoints;
            }
        }


        public override bool canMove(Coordinate tile, TileType type)
        {
            double requiredMovePoints = Human.requiredMovePoints[type];
            if (requiredMovePoints == -1 || !this.coord.isNearTo(tile) || Points.MovePoints - requiredMovePoints < 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public static bool canBeOn(TileType type)
        {
            return Human.requiredMovePoints[type] != -1;
        }
    }
}
