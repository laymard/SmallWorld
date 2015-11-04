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
        /// vecteur x de mouvement
        /// </summary>
        public int x
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
        /// vecteur y de mouvement
        /// </summary>
        public int y
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
        public void @do()
        {
            throw new System.NotImplementedException();
        }
    }
}