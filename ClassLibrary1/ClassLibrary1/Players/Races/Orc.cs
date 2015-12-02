using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Orc : Unit
    {
        public Orc(Coordinate coord) : base(coord)
        {
            this.Points = new Points(17,5,2);
        }

        public Boolean canMove(Coordinate tile)
        {
            throw new System.NotImplementedException();
        }

        public void move(Tile targetTile)
        {
            throw new System.NotImplementedException();
        }

        public void attack(Unit adverseUnit)
        {
            throw new System.NotImplementedException();
        }

        public int spendMovePoints(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
