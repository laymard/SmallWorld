using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable(), XmlInclude(typeof(Elf)), XmlInclude(typeof(Orc)),XmlInclude(typeof(Human))]
    public abstract class Unit
    {
        [XmlElement()]
        public Points Points
        {
            get;
            set;
        }

        [XmlAttribute()]
        public TileType currentTile
        {
            get;
            set;
        }

        /// <summary>
        /// position de l'unité sur la carte
        /// </summary>
        [XmlElement()]
        public Coordinate coord
        {
            get;
            set;
        }


        /// <summary>
        /// Map statique associant à chaque type de case le nombre de points de mouvement requis
        /// </summary>

        [XmlIgnore()]
        public virtual Dictionary<TileType, double> RequiredMovePoints
        {
            get;
            set;
        }


        /// <summary>
        /// Map statique associant à chaque type de case le nombre de points de victoire associé
        /// </summary>
        [XmlIgnore()]
        public virtual Dictionary<TileType, int> VictoryPoints
        {
            get;
            set;
        }

        /// <summary>
        /// Constructeur Unit
        /// </summary>
        /// <param name="coord">Coordonnées de départ</param>
        /// <param name="type">Type de case</param>
        public Unit(Coordinate coord, TileType type)
        {
            this.coord = coord;
            this.currentTile = type;
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Unit() { }

        /// <summary>
        /// Ajoute le nombre de points de victoire selon le type de case conquise
        /// </summary>
        public abstract void addVictoryPoints();

        /// <summary>
        /// Retire nbPoints de vie
        /// </summary>
        /// <param name="nbPoints"></param>
        public virtual void looseLifePoints(int nbPoints)
        {
            Points.lifePoints -= nbPoints;

        }

        /// <summary>
        /// Vérifie que l'unité peut se déplacer sur la case de coordonnées tile
        /// </summary>
        /// <param name="tile">Coordonnées cibles</param>
        /// <param name="type">Type de la case cible</param>
        /// <returns></returns>
        public abstract bool canMove(Coordinate tile, TileType type);

        /// <summary>
        /// Déplacement sur la case de coordonnées targetTile
        /// </summary>
        /// <param name="targetTile">Coordonnées cibles</param>
        /// <param name="type">Type de la case cible</param>
        public void move(Coordinate targetTile, TileType type)
        {
            this.spendMovePoints(type);
            coord = targetTile;
            currentTile = type;
            this.addVictoryPoints();
        }

        /// <summary>
        /// Vérifie que l'unité peut attaquer une case
        /// </summary>
        /// <param name="tile">Coordonnées</param>
        /// <param name="type">Type de case</param>
        /// <returns></returns>
        public abstract bool canAttack(Coordinate tile, TileType type);

        /// <summary>
        /// Compare les points de défense des deux unités
        /// </summary>
        /// <param name="unit">Unité adverse</param>
        /// <returns>Retourne true si l'unité appelante a une meilleure défense que l'unité passée en paramètre, false sinon.</returns>
        public bool betterDefence(Unit unit)
        {
            return (this.Points.defencePoints > unit.Points.defencePoints 
                // cas ou les deux unités ont le même nombre de points de défense
                || this.Points.attackPoints > unit.Points.attackPoints);
        }

        /// <summary>
        /// Vérifie si l'unité est morte
        /// </summary>
        /// <returns>retourne true si l'unité n'a plus de points de vie, false sinon</returns>
        internal bool isDead()
        {
            return this.Points.lifePoints <= 0;
        }

        /// <summary>
        /// Calcul le ratio des points de défense pour déterminer le vainqueur d'une bataille
        /// </summary>
        /// <returns></returns>
         public double getRatioDefender()
        {
            return this.Points.getRatioDefender();
        }

         /// <summary>
         /// Calcul le ratio des points d'attaque pour déterminer le vainqueur d'une bataille
         /// </summary>
         /// <returns></returns>
         public double getRatioAttacker()
         {
             return this.Points.getRatioAttacker();
         }

        /// <summary>
        /// Dépense les points de mouvements nécessaire au déplacement sur une case de type type
        /// </summary>
        /// <param name="type">type de la case cible</param>
         public void spendMovePoints(TileType type)
        {
             this.Points.MovePoints -= RequiredMovePoints[type];
        }

    }
}
