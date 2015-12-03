using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        /// <summary>
        /// Distance from this to the Coordinate tile
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>int : the distance (-1 if tile is on a diagonal </returns>
        public int distanceFrom(Coordinate tile)
        {
            if (this.Y == tile.Y)
                return Math.Abs(this.X - tile.X);

            if (this.X == tile.X)
                return Math.Abs(this.Y - tile.Y);
            else return -1;
        }
    }
}
