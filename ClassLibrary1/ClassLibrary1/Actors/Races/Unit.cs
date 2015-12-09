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
        /// <summary>
        /// Points de l'unité
        /// </summary>
        [XmlElement()]
        public Points Points
        {
            get;
            set;
        }

        /// <summary>
        /// Type de la case courante
        /// </summary>
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
        /// Constructeur de la classe Unit
        /// </summary>
        /// <param name="coord">Coordonnées de départ</param>
        /// <param name="type">Type de case</param>
        public Unit(Coordinate coord, TileType type)
        {
            this.coord = coord;
            this.currentTile = type;
        }

        /// <summary>
        /// Constructeur par défaut de la classe Unit
        /// </summary>
        public Unit() { }


        /// <summary>
        /// Déplacement de l'unité
        /// </summary>
        /// <param name="targetTile">Coordonnées de la case cible</param>
        /// <param name="type">Type de case</param>
        public void  move(Coordinate targetTile, TileType type)
        {
                coord = targetTile;
                currentTile = type;
                this.addVictoryPoints();
        }

        /// <summary>
        /// Attribue le nombre de points de victoire selon le type de case
        /// </summary>
        public abstract void addVictoryPoints();

        /// <summary>
        /// Retire des points de vie à l'unité
        /// </summary>
        /// <param name="nbPoints">Nombre de points de vie perdus.</param>
        public virtual void looseLifePoints(int nbPoints)
        {
            Points.lifePoints -= nbPoints;
        }

        /// <summary>
        ///  Evalue si l'unité peut se déplacer sur une case.
        /// </summary>
        /// <param name="tile">Coordonnées de la case cible</param>
        /// <param name="type">Type de la case cible</param>
        /// <param name="movePoints">Nombre de points de mouvement</param>
        /// <returns>Retourne true si l'unité peut se déplacer sur la case sélectionnée, false sinon.</returns>
        public abstract bool canMove(Coordinate tile, TileType type, double movePoints);

        /// <summary>
        /// Evalue si l'unité peut attaquer une case
        /// </summary>
        ///<param name="tile">Coordonnées de la case cible</param>
        /// <param name="type">Type de la case cible</param>
        /// <returns>Retourne true si l'unité peut attaquer une unité située sur la case cible, false sinon.</returns>
        public abstract bool canAttack(Coordinate tile, TileType type);

        /// <summary>
        /// Compare les points de défense de deux unités
        /// </summary>
        /// <param name="unit">Unité à comparer</param>
        /// <returns>retourne true si l'unité à la meilleure défense,false sinon.</returns>
        public bool betterDefence(Unit unit)
        {
            return this.Points.defencePoints > unit.Points.defencePoints;
        }

        /// <summary>
        /// Evalue si l'unité est morte
        /// </summary>
        /// <returns>True si l'unité n'a plus de points de vie, false sinon.</returns>
        internal bool isDead()
        {
            return this.Points.lifePoints <= 0;
        }

        /// <summary>
        /// Calcule le ratio de points de vie
        /// </summary>
        /// <returns>Retourne le ratio de points de vie.</returns>
         public double getRatioLifePoints()
        {
            return this.Points.getRatioLifePoints();
        }
    }
}
