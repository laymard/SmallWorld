using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class TileFactory
    {
        public Dictionary<TileType, Tile> Tiles
        {
            get;
            set;
        }
       

        public TileFactory()
        {
            Tiles = new Dictionary<TileType, Tile>(4);
            Tiles.Add(TileType.PLAIN, new Plain());
            Tiles.Add(TileType.WATER, new Water());
            Tiles.Add(TileType.FOREST, new Forest());
            Tiles.Add(TileType.MOUNTAIN, new Mountain());

        }


        public Tile getTile(TileType tt)
        {
            return this.Tiles[tt];
        }

    }
}
