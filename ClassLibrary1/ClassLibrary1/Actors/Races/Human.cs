using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

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

        [XmlIgnore()]
        private static Dictionary<TileType, int> victoryPoints = new Dictionary<TileType, int>()
        {
            {TileType.FOREST,1 },
            {TileType.MOUNTAIN,1 },
            {TileType.PLAIN,2 },
            {TileType.WATER,0 }
        };

        [XmlIgnore()]
        public override Dictionary<TileType,int> VictoryPoints
        {
            get
            {
                return Human.victoryPoints;
            }
        }


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

        [XmlIgnore()]
        private static Dictionary<TileType, double> requiredMovePoints = new Dictionary<TileType, double>()
                {
                    {TileType.MOUNTAIN,1 },
                    {TileType.WATER,1 },
                    {TileType.FOREST,1 },
                    {TileType.PLAIN,1 }
                };

        [XmlIgnore()]
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

        /// <summary>
        /// Vérifie que l'unité peut être placée sur une case type (placement initial sur la map)
        /// </summary>
        /// <param name="type">type de case</param>
        /// <returns></returns>
        public static bool canBeOn(TileType type)
        {
            return Human.requiredMovePoints[type] != -1;
        }
    }
}
