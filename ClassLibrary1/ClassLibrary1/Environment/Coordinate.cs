﻿using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable()]
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinate() { }

        [XmlAttribute()]
        public int X
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return (X+1) ^ (Y+1);
        }

        public override bool Equals(object b)
        {
            if (!(b is Coordinate) || b == null)
                return false;

            if (this == b)
                return true;

            var c2 = (Coordinate)b;
            return X == c2.X && Y == c2.Y;
        }
        

        public override string ToString()
        {
            return "Coord : " + X + " , " + Y;
        }
        
        [XmlAttribute()]
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

        public bool isNearTo(Coordinate tile)
        {
            return (X == tile.X && (Y == tile.Y - 1 || Y == tile.Y + 1)) ||
                    (Y == tile.Y && (X == tile.X - 1 || X == tile.X - 1));
        }
    }
}
