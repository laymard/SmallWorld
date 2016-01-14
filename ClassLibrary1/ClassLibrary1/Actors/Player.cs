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
        /// <summary>
        /// Nom du joueur
        /// </summary>
        [XmlAttribute()]
        public String Name
        {
            get;
            set;
        }

        /// <summary>
        /// Points de victoire
        /// </summary>
        [XmlAttribute()]
        public int VictoryPoints
        {
            get;
            set;
        }

        /// <summary>
        /// Pile des actions
        /// </summary>
        [XmlIgnore()]
        public Stack<Command> Actions
        {
            get;
            set;
        }

        /// <summary>
        /// Liste des unités
        /// </summary>
        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public List<Unit> Units
        {
            get;
            set;
        }

        /// <summary>
        /// Nombre d'unités
        /// </summary>
        [XmlAttribute()]
        public int NbUnits
        {
            get;
            set;
        }

        /// <summary>
        /// Unité en cours de jeu
        /// </summary>
        [XmlIgnore()]
        public Unit CurrentUnit
        {
            get;
            set;
        }

        /// <summary>
        /// Race des unités
        /// </summary>
        [XmlAttribute()]
        public Race Race
        {
            get;
            set;
        }

        /// <summary>
        /// Constructeur de Player
        /// </summary>
        /// <param name="race">Race des unités</param>
        /// <param name="name">Nom du joueur</param>
        /// <param name="nbUnits">Nombre d'unités</param>
        public Player(Race race, String name, int nbUnits)
        {
            this.Race = race;
            this.NbUnits = nbUnits;
            this.Units = new List<Unit>(nbUnits);
            this.VictoryPoints = 0;
            this.Name = name;
            this.Actions = new Stack<Command>();
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Player()
        {
            this.VictoryPoints = 0;
        }



        /// <summary>
        /// Crée une unité de la race du joueur
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
        /// Crée une unité d'elfes et l'ajoute à la liste des unités
        /// </summary>
        public void CreateElf(Coordinate coord, TileType type)
        {
            Elf elf = new Elf(coord,type);
            this.Units.Add(elf);
        }

        /// <summary>
        /// Crée une unité d'humains et l'ajoute à la liste des unités
        /// </summary>
        public void CreateHuman(Coordinate coord, TileType type)
        {
            Human human = new Human(coord,type);
            this.Units.Add(human);
        }

        /// <summary>
        /// Crée une unité d'orques et l'ajoute à la liste des unités
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

        /// <summary>
        /// Annule la dernière commande
        /// </summary>
        public void undoLastCommand()
        {
            this.Actions.Pop().undo();
        }

        /// <summary>
        /// Ajout d'une commande de déplacement à la pile des commandes
        /// </summary>
        /// <param name="target">Coordonnées cible</param>
        /// <param name="cost">Coût du déplacement</param>
        public void addMoveCommand(Coordinate target, double cost)
        {
            MoveUnits mu = new MoveUnits(CurrentUnit, target, cost);
            this.Actions.Push(mu);
        }

        /// <summary>
        /// Ajout d'une commande d'attaque à la pile des commandes
        /// </summary>
        /// <param name="cost">Coût du déplacement</param>
        /// <param name="tile">Coordonnées cible</param>
        public void addAttackCommand(int cost, Coordinate tile)
        {
            throw new System.NotImplementedException();
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


        /// <summary>
        /// Déplace l'unité courante 
        /// </summary>
        /// <param name="target">Coordonnées de la case cible</param>
        /// <param name="targetType">Type de case</param>
        public void move (Coordinate target, TileType targetType)
        {
            double requiredMovePoints = CurrentUnit.RequiredMovePoints[targetType];

            if (CurrentUnit.canMove(target, targetType))
            {
                this.addMoveCommand(target, requiredMovePoints);
                this.CurrentUnit.move(target, targetType);
            }
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

        /// <summary>
        /// Supprime les unités mortes vérifie que le joueur a toujours des unités en vie
        /// </summary>
        /// <returns>true si toutes les unités sont mortes, false sinon</returns>
        public bool IsDead()
        {
            foreach(Unit u in this.Units)
            {
                if (!(u.isDead())) return false;
                else
                {
                    Units.Remove(u);
                }
            }
            return true;
        }
    }
}
