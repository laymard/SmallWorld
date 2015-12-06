using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace ClassLibrary1
{
    [Serializable()]
    public class MapSaver
    {
        public MapSaver(Map map){
            this.MapSize = map.MapSize;
            this.matrix = new MatrixSaver(map.matrix);
        }
     
        [XmlElement("MapSize")]
        private MapSize MapSize
        {
            get;
            set;
        }

        [XmlElement("Matrix")]
        public MatrixSaver matrix
        {
            get;
            set;
        }

     
    }
}
