using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public abstract class MapSize
    {
        /// <summary>
        /// Number of tiles by side (square maps)
        /// </summary>
        public int NbTiles
        {
            get;
            set;
        }

        /// <summary>
        /// Number of Turns
        /// </summary>
        public int NbTurns
        {
            get;
            set;
        }

        /// <summary>
        /// Number of units per player
        /// </summary>
        public int NbUnits
        {
            get;
            set;
        }

        /// <summary>
        /// Number of Players
        /// </summary>
        public int NbPlayers
        {
            get;
            set;
        }
    }
}
