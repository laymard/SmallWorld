using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Human : Unit
    {
        public Human(Coordinate coord) : base(coord)
        {
            this.Points = new Points(15,6,3);
        }

        public Boolean canMove(Coordinate tile)
        {
            throw new System.NotImplementedException();
        }

        public void move(TileType targetTile)
        {
            throw new System.NotImplementedException();
        }

        public void attack(Unit adverseUnit)
        {
            throw new System.NotImplementedException();
        }

    }
}
