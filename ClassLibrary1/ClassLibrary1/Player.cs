using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Player
    {

        public String name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Array<ClassLibrary1.Unit> units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int victoryPoints
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Stack<Command> Command
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
        /// create an Elf unit and add it to its a list
        /// </summary>
        public void CreateElf()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// create a Human unit and add it to its a list
        /// </summary>
        public void CreateHuman()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// create an Orc unit and add it to its a list
        /// </summary>
        public void CreateOrc()
        {
            throw new System.NotImplementedException();
        }

        public void chooseRace(Unit race)
        {
            throw new System.NotImplementedException();
        }

        public void undoLastCommand()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// méthode appelée quand le joueur a fin ses mouvements. Ordre donné manuellement par le joueur courant
        /// </summary>
        public void finishMoves()
        {
            throw new System.NotImplementedException();
        }

        public void addAttackCommand(int cost, Coordinate tile)
        {
            throw new System.NotImplementedException();
        }
    }
}
