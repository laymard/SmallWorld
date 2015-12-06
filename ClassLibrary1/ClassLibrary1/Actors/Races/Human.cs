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

        public override void spendMovePoints(Coordinate targetTile, TileType type)
        {
            throw new NotImplementedException();
        }

        public override bool canMove(Coordinate tile, TileType type)
        {
            double cost = (double)this.coord.distanceFrom(tile);

            if (cost < 0)
                return false;

            return Points.movePoints >= cost;
        }

        public override bool canAttack(Coordinate tile, TileType type)
        {
            throw new NotImplementedException();
        }
    }
}
