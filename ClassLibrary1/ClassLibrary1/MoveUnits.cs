using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class MoveUnits : Command
    {
        public Unit Unit
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
        /// point de mouvement nécessaire à ce mouvement
        /// </summary>
        public int cost
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
        /// position avant le mouvement
        /// </summary>
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
        /// Exectue le mouvement et l'enregistre pour pouvoir le undo
        /// </summary>
        public void execute()
        {
            throw new System.NotImplementedException();
        }
    }
}