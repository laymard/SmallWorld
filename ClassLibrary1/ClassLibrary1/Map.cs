using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Map
    {

        public MapSize MapSize
        {
            get;
            set;
        }

        public TileFactory TileFactory
        {
            get;
            
            
            set;

        }

        

        public IDictionary<Coordinate, Tile> matrix
        {
            get;
            set;
        }

        public Map(MapSize ms){
            this.MapSize = ms;
            this.TileFactory = new TileFactory();
            this.matrix = new Dictionary<Coordinate, Tile>(ms.NbTiles * ms.NbTiles);
            this.setEmptyMatrix(ms.NbTiles);
        }

        public void initialiseTiles()
        {
            // appel à la librairie C++
            
        }

        /// <summary>
        /// return type tile of coord
        /// </summary>
        public Tile getTileType(Coordinate coord)
        {
            throw new System.NotImplementedException();
        }

        public void setEmptyMatrix(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Coordinate coord = new Coordinate(i, j);
                    this.matrix.Add(coord,null);
                }
            }
        }
    }
}
