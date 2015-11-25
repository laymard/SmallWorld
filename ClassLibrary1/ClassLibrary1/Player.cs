using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Player
    {

        public String Name
        {
            get;
            set;
        }

        public int VictoryPoints
        {
            get;
            set;
        }

        public Stack<Command> Actions
        {
            get;
            set;
        }

        public List<Unit> Units
        {
            get;
            set;
        }

        public int NbUnits
        {
            get;
            set;
        }

        public Command Command
        {
            get;
            set;
        }

        public Race Race
        {
            get;
            set;
        }

        /// <summary>
        /// create an Elf unit and add it to its a list
        /// </summary>
        public Player(Race race, String name, int nbUnits)
        {
            this.Race = race;
            this.NbUnits = nbUnits;
            initializeUnits();
        }

        public void initializeUnits()
        {
            this.Units = new List<Unit>(NbUnits);
            for (int i = 0; i < NbUnits - 1; i++)
            {
                createUnits();
            }

        }

        /// <summary>
        /// create a unit of the player's race
        /// </summary>
        public void createUnits() 
        {
            switch (this.Race)
            {
                case (Race.Orc) :
                    CreateOrc();
                    break;

                case Race.Human:
                    CreateHuman();
                    break;

                case Race.Elf:
                    CreateElf();
                    break;
            }
        }
        /// <summary>
        /// create an Elf unit and add it to its a list
        /// </summary>
        public void CreateElf()
        {
            Elf elf = new Elf();
            this.Units.Add(elf);
            this.NbUnits++;
        }

        /// <summary>
        /// create a Human unit and add it to its a list
        /// </summary>
        public void CreateHuman()
        {
            Human human = new Human();
            this.Units.Add(human);
            this.NbUnits++;

        }

        /// <summary>
        /// create an Orc unit and add it to its a list
        /// </summary>
        public void CreateOrc()
        {
            Orc orc = new Orc();
            this.Units.Add(orc);
            this.NbUnits++;
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

        /// <summary>
        /// retourne les unités du joueur présentes sur la case tile
        /// </summary>
        public List<Unit> getUnitsOnTile(Coordinate tile) {
            List<Unit> res = new List<Unit>();
            foreach (Unit u in this.Units)
            {
                if (u.currentTile.Equals(tile)) res.Add(u);
            }
             return res;
        }
    }
}
