using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    [Serializable()]
    public enum Race
    {
        [XmlEnum("Human")]
        Human,
        [XmlEnum("Elf")]
        Elf,
        [XmlEnum("Orc")]
        Orc,
    }
}
