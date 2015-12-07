using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class MoveUnits : Command
    {
        private Coordinate target;
        private double cost1;

        public MoveUnits(ClassLibrary1.Unit unit, Coordinate target, double cost1)
        {
            // TODO: Complete member initialization
            this.Unit = unit;
            this.target = target;
            this.cost1 = cost1;
        }
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