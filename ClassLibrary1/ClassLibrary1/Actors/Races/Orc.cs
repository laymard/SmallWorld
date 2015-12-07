using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class Orc : Unit
    {
        private static Dictionary<TileType, double> movePoints = new Dictionary<TileType, double>()
        {
            {TileType.MOUNTAIN,1 },
            {TileType.FOREST,1 },
            {TileType.WATER,-1 },
            {TileType.PLAIN,0.5 }
        };

        public Orc(Coordinate coord, TileType type)
            : base(coord, type)
        {
            this.Points = new Points(17, 5, 2);
        }



        public Orc()
            : base() { }


        public new Dictionary<TileType, double> RequiredMovePoints
        {
            get
            {
                return movePoints;
            }

            set
            {
                movePoints = value;
            }
        }

        public override void addVictoryPoints()
        {
            throw new NotImplementedException();
        }

        public override void spendMovePoints(Coordinate targetTile, TileType type)
        {
            throw new NotImplementedException();
        }

        public bool canMove(Coordinate tile, TileType type)
        {
            throw new NotImplementedException();
        }

        public override bool canAttack(Coordinate tile, TileType type)
        {
            throw new NotImplementedException();
        }
    }
}
