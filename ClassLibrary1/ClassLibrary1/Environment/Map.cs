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


        public static IDictionary<Coordinate, TileType> matrix
        {
            get;
            set;
        }

        public Map(MapSize ms){
            this.MapSize = ms;
            this.TileFactory = new TileFactory();
            matrix = new Dictionary<Coordinate, TileType>(ms.NbTiles * ms.NbTiles);
            this.setEmptyMatrix(ms.NbTiles);
        }

        public void initialiseTiles()
        {
            ClassLibrary1.Map.Algo algo = new ClassLibrary1.Map.Algo();

        }

        public void setEmptyMatrix(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Coordinate coord = new Coordinate(i, j);
                    matrix.Add(coord,TileType.DEFAULT);
                }
            }
        }

        /// <summary>
        /// return type tile of coord
        /// </summary>
        public static TileType getTile(Coordinate coord)
        {
            return matrix[coord];
        }

        public static Coordinate getCoord(int x, int y)
        {
            Coordinate coord = null;
            foreach (Coordinate c in Map.matrix.Keys)
            {
                if (c.X == x && c.Y == y)
                {
                    coord = c;
                }
            }
            return coord;
        }
    }
}
