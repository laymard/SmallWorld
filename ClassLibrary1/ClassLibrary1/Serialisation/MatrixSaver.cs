using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable()]
    public class Entry
    {
        public Entry(){}
        public Entry(Coordinate coord, TileType tp) {
            this.Coord = coord;
            this.TileType = tp;
        }
        [XmlElement("Coordinate")]
        public Coordinate Coord
        {
            get;
            set;
        }

       [XmlElement("TileType")]
        public TileType TileType
        {
            get;
            set;
        }
    }

    [Serializable()]
    public class MatrixSaver
    {
        public MatrixSaver(Dictionary<Coordinate, TileType> dictionary)
        {
            this.list = new List<Entry>();
            foreach (Coordinate c in dictionary.Keys)
            {
                this.list.Add(new Entry(c, dictionary[c]));
            }
        }

        public MatrixSaver() { }

        [XmlArray("matrix")]
        [XmlArrayItem("coordinates")]
        public List<Entry> list { get; set; }
    }

}
