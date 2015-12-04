using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable]
    public class Human : Unit
    {
        public Human(Coordinate coord) : base(coord)
        {
            this.Points = new Points(15,6,3);
        }

        public static IDictionary<TileType, int> RequiredMovePoints
        {
            get
            {
                return new Dictionary<TileType, int>()
                {
                    {TileType.MOUNTAIN,1 },
                    {TileType.WATER,1 },
                    {TileType.FOREST,1 },
                    {TileType.PLAIN,1 }

                };
            }
        }

        public override void addVictoryPoints()
        {
            throw new NotImplementedException();
        }

        public override void spendMovePoints(Coordinate targetTile)
        {
            throw new NotImplementedException();
        }

        public override bool canMove(Coordinate tile)
        {
            throw new NotImplementedException();
        }

        public override bool canAttack(Coordinate tile)
        {
            throw new NotImplementedException();
        }
    }
}
