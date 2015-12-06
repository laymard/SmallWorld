using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    [Serializable()]
    public enum TileType
    {
        [XmlEnum(Name = "Plain")]
        PLAIN,
        [XmlEnum(Name = "Water")]
        WATER,
        [XmlEnum(Name = "Mountain")]
        MOUNTAIN,
        [XmlEnum(Name = "Forest")]
        FOREST,
        [XmlEnum(Name = "Default")]
        DEFAULT
    }
}
