using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    [Serializable(), XmlInclude(typeof(StandardMap)), XmlInclude(typeof(DemoMap)), XmlInclude(typeof(SmallMap))]
    public abstract class MapSize
    {
        /// <summary>
        /// Number of tiles by side (square maps)
        /// </summary>
        [XmlAttribute()]
        public int NbTiles
        {
            get;
            set;
        }

        /// <summary>
        /// Number of Turns
        /// </summary>
        [XmlAttribute()]
        public int NbTurns
        {
            get;
            set;
        }

        /// <summary>
        /// Number of units per player
        /// </summary>
        [XmlAttribute()]
        public int NbUnits
        {
            get;
            set;
        }

        /// <summary>
        /// Number of Players
        /// </summary>
        [XmlAttribute()]
        public int NbPlayers
        {
            get;
            set;
        }
    }
}
