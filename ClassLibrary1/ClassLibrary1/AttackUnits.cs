using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class AttackUnits : Command
    {
        public Coordinate lastCoord
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// nombre de dommages infligé
        /// </summary>
        public int damageGiven
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// nmbre de dommages subits
        /// </summary>
        public int damageTaken
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// unité blessé ou tué durant la dernière attaque
        /// </summary>
        public Unit ennemyAttacked
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}