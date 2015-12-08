using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class Orc : Unit
    {
        public Orc(Coordinate coord, TileType type)
            : base(coord, type)
        {
            this.Points = new Points(17, 5, 2);
        }
        public Orc()
            : base() { }

        public override void addVictoryPoints()
        {
             switch (this.currentTile)
            {
                case TileType.PLAIN :
                    this.Points.victoryPoints++;
                    break;
                case TileType.FOREST:
                    this.Points.victoryPoints++;
                    break;
                case TileType.MOUNTAIN:
                    this.Points.victoryPoints+=2;
                    break;
                default :
                    break;
            }
        }

        /*public override void spendMovePoints(Coordinate tile, TileType type)
        {
            double cost = (double)this.coord.distanceFrom(tile);
            if (type == TileType.PLAIN) cost *= 0.5;
            Points.movePoints -= cost;
        }*/

        /*public override bool canMove(Coordinate tile, TileType type)
        {
            // Les orcs ne peuvent pas aller sur l'eau
            if (type == TileType.WATER)
                return false;

            double cost = this.coord.distanceFrom(tile);

            if (cost < 0)
                return false;

            if (type == TileType.PLAIN) cost *= 0.5;
            double movePoints = (double)Points.movePoints;

            return movePoints >= cost;
        }*/

        public override bool canAttack(Coordinate tile, TileType type)
        {
            int dist = this.coord.distanceFrom(tile);
            return ((currentTile == TileType.MOUNTAIN && dist == 2) || dist == 1);
        }

        /*public override Dictionary<TileType, double> RequiredMovePoints
        {
            get;
        }*/
        public static Dictionary<TileType, double> RequiredMovePoints()
        {
            return new Dictionary<TileType, double>()
                {
                    {TileType.MOUNTAIN, 1},
                    {TileType.WATER, -1},
                    {TileType.FOREST, 1},
                    {TileType.PLAIN, 0.5}
                };
        }
        public override bool canMove(Coordinate tile, TileType type, double movePoints)
        {
            double requiredMovePoints = Orc.RequiredMovePoints()[type];
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
