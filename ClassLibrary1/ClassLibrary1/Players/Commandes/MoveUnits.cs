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
        void Command.execute()
        {
 	        throw new NotImplementedException();
        }

        void Command.redo()
        {
 	        throw new NotImplementedException();
        }

        void Command.undo()
        {
 	        throw new NotImplementedException();
        }

        void Command.canDo()
        {
 	        throw new NotImplementedException();
        }

        void Command.done()
        {
 	        throw new NotImplementedException();
        }
    }
}