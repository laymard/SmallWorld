using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public struct Coordinate
    {
        /// <summary>
        /// coord x
        /// </summary>
        public int x
        {
            get;
            set;

        }

        /// <summary>
        /// coord y
        /// </summary>
        public int y
        {
            get;
            set;
        }

        public Coordinate (int i,int j){
            this.x = i;
            this.y = j;
        }
    }
}