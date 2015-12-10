using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace ClassLibrary1
{
    [Serializable()]
    public class Map
    {
        [XmlElement()]
        public MapSize MapSize
        {
            get;
            set;
        }

        [XmlIgnore()]
        public TileFactory TileFactory
        {
            get;
            set;
        }

        [XmlIgnore()]
        public Dictionary<Coordinate, TileType> matrix
        {
            get;
            set;
        }

        public Map(MapSize ms){
            this.MapSize = ms;
            this.TileFactory = new TileFactory();
            matrix = new Dictionary<Coordinate, TileType>();
            //this.initialiseTiles();
        }

        public Map() { }

        public Map(Map map, MatrixSaver ms)
        {
            this.MapSize = map.MapSize;
            this.matrix = new Dictionary<Coordinate,TileType>();
            foreach (Entry entry in ms.list)
            {
                this.matrix.Add(entry.Coord, entry.TileType);
            }
        }

        public void initialiseTiles()
        {
            Algo algo = new Algo();
            var size = MapSize.NbTiles;
            var map=algo.CreateMap(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix.Add(new Coordinate(i, j), map[i * size + j]);
                }
            }
            


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
        public TileType getTile(Coordinate coord)
        {
            if (matrix.Keys.Contains(coord))
            {
                return matrix[coord];
            }
            else
            {
                return TileType.DEFAULT;
            }
            
        }

        public Coordinate getCoord(int x, int y)
        {
            Coordinate coord = null;
            bool found = false;
            Coordinate c;
            int i = 0;
            while(!found){
                 c = matrix.Keys.ElementAt(i);
                if (c.X == x && c.Y == y)
                {
                    coord = c;
                    found = true;
                }
                i++;
            }
            return coord;
        }
    }
}
