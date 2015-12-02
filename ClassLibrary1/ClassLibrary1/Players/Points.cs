using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Points
    {

        public int attackPoints
        {
            get;
            set;
        }

        public int defencePoints
        {
            get;
            set;
        }

        public int lifePoints
        {
            get;
            set;
        }

        public int initialLifePoints;

        public int movePoints
        {
            get;
            set;
        }

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
