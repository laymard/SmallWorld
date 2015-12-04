using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable]
    public class Points
    {
        [XmlAttribute]
        public int attackPoints
        {
            get;
            set;
        }

        [XmlAttribute]
        public int defencePoints
        {
            get;
            set;
        }

        [XmlAttribute]
        public int lifePoints
        {
            get;
            set;
        }

        [XmlAttribute]
        public int initialLifePoints;

        [XmlAttribute]
        public int movePoints
        {
            get;
            set;
        }

        [XmlAttribute]
        public int victoryPoints
        {
            get;
            set;
        }

        public int getRatioLifePoints()
        {
            return lifePoints/initialLifePoints;
        }

        public Points(int life, int attack, int defence)
        {
            initialLifePoints = life;
            lifePoints = life;
            attackPoints = attack;
            defencePoints = defence;
            victoryPoints = 0;
        }
    }
}
