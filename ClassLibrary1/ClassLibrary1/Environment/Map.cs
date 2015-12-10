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
        /// <summary>
        /// Caractéristiques du mode de jeu
        /// </summary>
        [XmlElement()]
        public MapSize MapSize
        {
            get;
            set;
        }

        /*[XmlIgnore()]
        public TileFactory TileFactory
        {
            get;
            set;
        }*/

        /// <summary>
        /// Matrice de la mapp associant à chaque coordonnée un type (eau,forêt,montagne,plaine)
        /// </summary>
        [XmlIgnore()]
        public Dictionary<Coordinate, TileType> matrix
        {
            get;
            set;
        }

        /// <summary>
        /// Constructeur de Map
        /// </summary>
        /// <param name="ms">Caractéristiques du mode de jeu</param>
        public Map(MapSize ms){
            this.MapSize = ms;
            //this.TileFactory = new TileFactory();
            matrix = new Dictionary<Coordinate, TileType>();
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Map() {
            this.MapSize = new StandardMap();
            //this.TileFactory = new TileFactory();
            this.matrix = new Dictionary<Coordinate, TileType>();
        }

        /// <summary>
        /// Constructeur à partir d'une sauvegarde
        /// </summary>
        /// <param name="map">sauvegarde de la map</param>
        /// <param name="ms">sauvegarde de la matrice</param>
        public Map(Map map, MatrixSaver ms)
        {
            this.MapSize = map.MapSize;
            this.matrix = new Dictionary<Coordinate,TileType>();
            foreach (Entry entry in ms.list)
            {
                this.matrix.Add(entry.Coord, entry.TileType);
            }
        }

        /// <summary>
        /// Initialisation de la map
        /// </summary>
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

        /// <summary>
        /// Type d'une case
        /// </summary>
        /// <param name="coord">Coordonnées de la case</param>
        /// <returns>retourne le type de la case à partir de ses coordonnées</returns>
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

        /// <summary>
        /// Coordonnées
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>L'objet coordinate de la map correspondant à la coordonnée (x,y)</returns>
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
