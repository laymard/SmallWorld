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

        /*public override void spendMovePoints(Coordinate tile, TileType type)
        {
            double cost = (double)this.coord.distanceFrom(tile);
            Points.movePoints -= cost;
        }*/

        /*public override bool canMove(Coordinate tile, TileType type)
        {
            double cost = (double)this.coord.distanceFrom(tile);

            if (cost < 0)
                return false;

            return Points.movePoints >= cost;
        }*/

        public override bool canAttack(Coordinate tile, TileType type)
        {
            int dist = this.coord.distanceFrom(tile);
            return (dist == 1);
        }

        public static Dictionary<TileType, double> RequiredMovePoints()
        {
            return new Dictionary<TileType, double>()
                {
                    {TileType.MOUNTAIN,1 },
                    {TileType.WATER,1 },
                    {TileType.FOREST,1 },
                    {TileType.PLAIN,1 }

                };
        }

        public override bool canMove(Coordinate tile, TileType type, double movePoints)
        {
            double requiredMovePoints = Human.RequiredMovePoints()[type];
            if (requiredMovePoints == -1 || !this.coord.isNearTo(tile) || movePoints - requiredMovePoints < 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
