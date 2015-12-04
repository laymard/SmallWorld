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
            get;
            set;
        }

        /// <summary>
        /// point de mouvement nécessaire à ce mouvement
        /// </summary>
        public int cost
        {
            get;
            set;
        }

        /// <summary>
        /// position avant le mouvement
        /// </summary>
        public Coordinate lastCoord
        {
            get;
            set;
        }

        /// <summary>
        /// Exectue le mouvement et l'enregistre pour pouvoir le undo
        /// </summary>
        public void execute()
        {
            //TO DO
        }

        public void redo() : base Command{ }
    }
}