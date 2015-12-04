using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable]
    public class Orc : Unit
    {
        public Orc(Coordinate coord, TileType type)
            : base(coord, type)
        {
            this.Points = new Points(17, 5, 2);
        }


        public override void addVictoryPoints()
        {
            throw new NotImplementedException();
        }

        public override void spendMovePoints(Coordinate targetTile, TileType type)
        {
            throw new NotImplementedException();
        }

        public override bool canMove(Coordinate tile, TileType type)
        {
            throw new NotImplementedException();
        }

        public override bool canAttack(Coordinate tile, TileType type)
        {
            throw new NotImplementedException();
        }
    }
}
