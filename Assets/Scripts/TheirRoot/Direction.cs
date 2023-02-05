using System;
using System.Numerics;

namespace TheirRoot
{
    public enum Direction
    {
        NorthWest,
        NorthEast,
        East,
        SouthEast,
        SouthWest,
        West
    }

    public abstract class DirectionValues
    {

        public static Direction GetInverseDirection(Direction direction)
        {
            return direction switch
            {
                Direction.NorthWest => Direction.SouthEast,
                Direction.NorthEast => Direction.SouthWest,
                Direction.East => Direction.West,
                Direction.SouthEast => Direction.NorthWest,
                Direction.SouthWest => Direction.NorthEast,
                Direction.West => Direction.East,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
        
        public static int[] GetOffSet(Direction direction)
        {
            return direction switch
            {
                Direction.NorthWest => new[]{-1, 1},
                Direction.NorthEast => new[]{1, 1},
                Direction.East => new[]{1, 0},
                Direction.SouthEast => new[]{1, -1},
                Direction.SouthWest => new[]{-1, -1},
                Direction.West => new[]{-1, 0},
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}