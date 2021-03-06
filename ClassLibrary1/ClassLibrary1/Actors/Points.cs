﻿using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class Points
    {
        [XmlAttribute()]
        public int attackPoints
        {
            get;
            set;
        }

        [XmlAttribute()]
        public int defencePoints
        {
            get;
            set;
        }


        [XmlAttribute()]
        public int lifePoints
        {
            get;
            set;
        }

        [XmlAttribute()]
        public int initialLifePoints
        {
            get;
            set;
        }

        [XmlAttribute()]
        public int victoryPoints
        {
            get;
            set;
        }

        [XmlAttribute()]
        public double MovePoints { get; set; }

        public double getRatioDefender()
        {
            return (double)defencePoints*(double)lifePoints/(double)initialLifePoints;
        }

        public double getRatioAttacker()
        {
            return (double)attackPoints * (double)lifePoints / (double)initialLifePoints;
        }

        public Points(int life, int attack, int defence)
        {
            initialLifePoints = life;
            lifePoints = life;
            attackPoints = attack;
            defencePoints = defence;
            victoryPoints = 0;
            MovePoints = 2;
        }
        public Points() { }
    }
}
