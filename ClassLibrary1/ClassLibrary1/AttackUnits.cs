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