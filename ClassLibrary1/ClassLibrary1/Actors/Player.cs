using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class Player
    {
        [XmlAttribute()]
        public String Name
        {
            get;
            set;
        }

        [XmlAttribute()]
        public int VictoryPoints
        {
            get;
            set;
        }

        /*[XmlIgnore()]
        public double MovePoints
        {
            get;
            set;
        }*/

        [XmlIgnore()]
        public Stack<Command> Actions
        {
            get;
            set;
        }

        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public List<Unit> Units
        {
            get;
            set;
        }

        [XmlAttribute()]
        public int NbUnits
        {
            get;
            set;
        }

        [XmlIgnore()]
        public Unit CurrentUnit
        {
            get;
            set;
        }

        [XmlIgnore()]
        public Command Command
        {
            get;
            set;
        }

        [XmlAttribute()]
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
            this.Units = new List<Unit>(nbUnits);
            this.VictoryPoints = 0;
            this.Name = name;
            this.Actions = new Stack<Command>();
        }

        public Player()
        {
            this.VictoryPoints = 0;
        }



        /// <summary>
        /// create a unit of the player's race
        /// </summary>
        public void createUnit(Coordinate coord, TileType type) 
        {
            switch (this.Race)
            {
                case (Race.Orc) :
                    if (Orc.canBeOn(type))
                        CreateOrc(coord,type);
                    break;

                case Race.Human:
                    if (Human.canBeOn(type)) 
                        CreateHuman(coord, type);
                    break;

                case Race.Elf:
                    if (Elf.canBeOn(type))
                        CreateElf(coord,type);
                    break;
            }
        }
        /// <summary>
        /// create an Elf unit and add it to its a list
        /// </summary>
        public void CreateElf(Coordinate coord, TileType type)
        {
            Elf elf = new Elf(coord,type);
            this.Units.Add(elf);
        }

        /// <summary>
        /// create a Human unit and add it to its a list
        /// </summary>
        public void CreateHuman(Coordinate coord, TileType type)
        {
            Human human = new Human(coord,type);
            this.Units.Add(human);
        }

        /// <summary>
        /// create an Orc unit and add it to its a list
        /// </summary>
        public void CreateOrc(Coordinate coord, TileType type)
        {
            Orc orc = new Orc(coord,type);
            this.Units.Add(orc);
        }

        /// <summary>
        /// sélectionne l'unité choisie par le joueur.
        /// </summary>
        public void selectUnit(Unit u)
        {
            CurrentUnit = u;
        }

        public void undoLastCommand()
        {
            this.Actions.Pop().undo();
        }

        /// <summary>
        /// méthode appelée quand le joueur a fin ses mouvements. Ordre donné manuellement par le joueur courant
        /// </summary>
        public void finishMoves()
        {
            // remettre deux points de mouvements à chaque Unités
            foreach (var unit in this.Units)
            {
                unit.Points.MovePoints = 2;
                this.VictoryPoints += unit.VictoryPoints[unit.currentTile];
            }

        }

        public void addAttackCommand(int cost, Coordinate tile)
        {
            throw new System.NotImplementedException();
        }

        public void move (Coordinate target, TileType targetType)
        {
            double requiredMovePoints = CurrentUnit.RequiredMovePoints[targetType];

            if (CurrentUnit.canMove(target, targetType))
            {
                this.addMoveCommand(target, requiredMovePoints);
                this.CurrentUnit.move(target, targetType);
            }
        }

        public void addMoveCommand(Coordinate target,double cost)
        {
            MoveUnits mu = new MoveUnits(CurrentUnit,target, cost);
            this.Actions.Push(mu);
        }

        /// <summary>
        /// retourne les unités du joueur présentes sur la case tile
        /// </summary>
        public List<Unit> getUnitsOnTile(Coordinate tile) {
            List<Unit> res = new List<Unit>();
            foreach (Unit u in this.Units)
            {
                if (u.coord.Equals(tile)) res.Add(u);
            }
             return res;
        }
        internal void setMovePoints()
        {
            foreach (Unit u in Units)
            {
                u.Points.MovePoints = 2;
            }
        }

        public bool IsDead()
        {
            foreach(Unit u in this.Units)
            {
                if (!(u.isDead())) return false;
            }
            return true;
        }

    }
}
