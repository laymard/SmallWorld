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

        public override bool canAttack(Coordinate tile, TileType type)
        {
            int dist = this.coord.distanceFrom(tile);
            bool distance = ((currentTile == TileType.MOUNTAIN && dist == 2) || dist == 1);
            bool points = Orc.requiredMovePoints[type] < this.Points.MovePoints;
            return (points && distance);
        }

        private static Dictionary<TileType, double> requiredMovePoints = new Dictionary<TileType, double>()
                {
                    {TileType.MOUNTAIN, 1},
                    {TileType.WATER, -1},
                    {TileType.FOREST, 1},
                    {TileType.PLAIN, 0.5}
                };

        private static Dictionary<TileType, int> victoryPoints = new Dictionary<TileType, int>()
        {
            {TileType.FOREST,1 },
            {TileType.MOUNTAIN,2 },
            {TileType.PLAIN,1 },
        };

        public override Dictionary<TileType, double> RequiredMovePoints
        {
            get
            {
                return Orc.requiredMovePoints;
            }
        }

        public override Dictionary<TileType,int> VictoryPoints
        {
            get
            {
                return Orc.victoryPoints;
            }
        }

        public override bool canMove(Coordinate tile, TileType type)
        {
            double requiredMovePoints = Orc.requiredMovePoints[type];
            if (requiredMovePoints == -1 || !this.coord.isNearTo(tile) || Points.MovePoints - requiredMovePoints < 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        /// <summary>
        /// Vérifie que l'unité peut être placée sur une case type (placement initial sur la map)
        /// </summary>
        /// <param name="type">type de case</param>
        /// <returns></returns>
        public static bool canBeOn(TileType type)
        {
            return Orc.requiredMovePoints[type] != -1;
        }
    }
}
