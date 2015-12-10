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

        public MoveUnits(Unit unit, Coordinate target, double cost)
        {
            // TODO: Complete member initialization
            this.Unit = unit;
            this.target = target;
            this.cost = cost;
            this.lastCoord = new Coordinate(Unit.coord.X,Unit.coord.Y);
        }
        public Unit Unit
        {
            get;
            set;
        }

        /// <summary>
        /// point de mouvement nécessaire à ce mouvement
        /// </summary>
        public double cost
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
            Unit.coord.X = lastCoord.X;
            Unit.coord.Y = lastCoord.Y;

            Unit.Points.MovePoints += cost;
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