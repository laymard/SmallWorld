﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Map
    {

        public MapSize MapSize1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public TileFactory TileFactory
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IDictionary<Coordinate, Tile> matrix
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void initialiseTiles()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// return type tile of coord
        /// </summary>
        public Tile getTileType(Coordinate coord)
        {
            throw new System.NotImplementedException();
        }
    }
}
