using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable]
    public class Orc : Unit
    {
        private static Dictionary<TileType, double> requiredMovePoint = new Dictionary<TileType, double>() {
                    {TileType.MOUNTAIN,1.0 },
                    {TileType.WATER,-1.0 },
                    {TileType.FOREST,1.0 },
                    {TileType.PLAIN,0.5 }
        };

        public Orc(Coordinate coord) : base(coord)
        {
            this.Points = new Points(17,5,2);
        }

        public Dictionary<TileType, double> RequiredMovePoints
        {
            get
            {
                return requiredMovePoint;
            }
          
        }


        public override void addVictoryPoints()
        {
            throw new NotImplementedException();
        }

        public override void spendMovePoints(Coordinate targetTile)
        {
            throw new NotImplementedException();
        }

        public override bool canMove(Coordinate tile)
        {
            throw new NotImplementedException();
        }

        public override bool canAttack(Coordinate tile)
        {
            throw new NotImplementedException();
        }
    }
}
