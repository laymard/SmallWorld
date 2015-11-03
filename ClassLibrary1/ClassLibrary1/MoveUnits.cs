using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class MoveUnits : Command
    {
        /// <summary>
        /// Exectue le mouvement et l'enregistre pour pouvoir le undo
        /// </summary>
        public void @do(int moveToX, int moveToY, Unit unit)
        {
            throw new System.NotImplementedException();
        }
    }
}