using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Elf : Unit
    {
        /// <summary>
        /// Constructeur Elf
        /// </summary>
        /// <param name="coord"> coordonnées de départ </param>
        public Elf(Coordinate coord) : base(coord)
        {
            this.Points = new Points(12,4,3);
        }

        public override void addVictoryPoints()
        {
            int nbPoints;

            switch (currentTile)
            {
                case TileType.FOREST :
                    nbPoints = 3;
                    break;
                case TileType.PLAIN:
                    nbPoints = 1;
                    break;
                default :
                    nbPoints = 0;
                    break;
            }
            this.Points.victoryPoints += nbPoints;
        }

        public override bool canAttack(Coordinate tile)
        {
            int dist = this.coord.distanceFrom(tile);
            return (dist == 0 || dist == 2);
        }

        public override bool canMove(Coordinate tile)
        {
            TileType tileType = Map.getTile(coord);

            // Les elfes ne peuvent pas aller sur l'eau
            if (tileType == TileType.WATER)
                return false;

            int cost = this.coord.distanceFrom(tile);
            if (tileType == TileType.MOUNTAIN) cost *= 2;
            int movePoints = Points.movePoints;

            return movePoints > cost;
        }

        public override void looseLifePoints(int nbPoints)
        {
            base.looseLifePoints(nbPoints);
        }

        public override void move(Coordinate targetTile)
        {
            base.move(targetTile);

            int cost = this.coord.distanceFrom(targetTile);
            if (Map.getTile(coord) == TileType.MOUNTAIN) cost *= 2;
            Points.movePoints -= cost;
        }
        
    }
}
