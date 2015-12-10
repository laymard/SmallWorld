using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class Elf : Unit
    {
        /// <summary>
        /// Constructeur Elf
        /// </summary>
        /// <param name="coord"> coordonnées de départ </param>
        /// <param name="type"> type de case </param>
        public Elf(Coordinate coord, TileType type) : base(coord,type)
        {
            this.Points = new Points(12,4,3);
        }
        /// <summary>
        /// Constructeur Elf par défaut
        /// </summary>
        public Elf()
            : base(){ }


        private static Dictionary<TileType, double> requiredMovePoints = new Dictionary<TileType, double>()
        {
                    {TileType.MOUNTAIN,2 },
                    {TileType.WATER,-1 },
                    {TileType.FOREST,1 },
                    {TileType.PLAIN,1 }
                };

        public override  Dictionary<TileType, double> RequiredMovePoints
        {
            get
            {
                return Elf.requiredMovePoints;
            }
        }


        private static Dictionary<TileType, int> victoryPoints = new Dictionary<TileType, int>()
        {
            {TileType.FOREST,3 },
            {TileType.MOUNTAIN,0 },
            {TileType.PLAIN,1 }
        };

        public override Dictionary<TileType, int> VictoryPoints
        {
            get
            {
                return Elf.victoryPoints;
            }
        }


        public override void addVictoryPoints()
        {
                this.Points.victoryPoints += Elf.victoryPoints[currentTile];
        }


        public override bool canAttack(Coordinate tile, TileType type)
        {
            int dist = this.coord.distanceFrom(tile);
            bool distance =  (dist == 1 || dist == 2);
            bool points = Elf.requiredMovePoints[type] < this.Points.MovePoints;
            
            return (points && distance);
        }


    public override void looseLifePoints(int nbPoints)
        {
            base.looseLifePoints(nbPoints);
        }

    public override bool canMove(Coordinate tile, TileType type)
    {
        double requiredMovePoints = Elf.requiredMovePoints[type];
        if (requiredMovePoints == -1 || !this.coord.isNearTo(tile) || Points.MovePoints - requiredMovePoints < 0)
        {
            return false;
        }

        else
        {
            return true;
        }
    }
    
        /// <summary>
        /// Vérifie que l'unité peut être placée sur une case type (placement initial sur la map)
        /// </summary>
        /// <param name="type">type de case</param>
        /// <returns></returns>
    public static bool canBeOn(TileType type)
    {
        return Elf.requiredMovePoints[type] != -1;
    }
    }
}
