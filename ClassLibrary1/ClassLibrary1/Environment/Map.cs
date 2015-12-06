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
            matrix = new Dictionary<Coordinate, TileType>(ms.NbTiles * ms.NbTiles);
            this.setEmptyMatrix(ms.NbTiles);
        }

        /*public Map(MapSaver ms)
        {
            this.matrix = new Dictionary<Coordinate,TileType>();
            foreach(Entry entry in ms.matrix){
                this.matrix.Add(entry.Coord, entry.TileType);
            }
        }*/

        public Map() { }

        public void initialiseTiles()
        {
            Algo algo = new Algo();
            var size = MapSize.NbTiles;
            var map=algo.CreateMap(size*size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var coord = new Coordinate(i, j);
                    matrix.Add(coord, map[i * size + j]);
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
            return matrix[coord];
        }

        public Coordinate getCoord(int x, int y)
        {
            Coordinate coord = null;
            foreach (Coordinate c in matrix.Keys)
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
