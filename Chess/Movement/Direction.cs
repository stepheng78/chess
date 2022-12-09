using System.Collections.Generic;
using System.Drawing;
using Chess.Coordinate;

namespace Chess
{
    public enum Direction
    {
        None,
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }

    public static class DirectionExtensions {
        public static readonly Dictionary<Direction, Point> DirectionMapping = new()
        {
            // DirectionMapping will provide the step formula for moving across tiles in a particular direction
            { Direction.North, new Point(0, -1) },
            { Direction.NorthEast, new Point(1, -1) },
            { Direction.East, new Point(1, 0) },
            { Direction.SouthEast, new Point(1, 1) },
            { Direction.South, new Point(0, 1) },
            { Direction.SouthWest, new Point(-1, 1) },
            { Direction.West, new Point(-1, 0) },
            { Direction.NorthWest, new Point(-1, -1) },
            { Direction.None, new Point(0, 0)}
        };

        public static Point Translate(this Point point, Direction direction)
        {
            var translation = DirectionMapping[direction];
            return new Point(point.X + translation.X, point.Y + translation.Y);
        }

        public static IGameCoordinate Translate(this IGameCoordinate coord, Direction direction)
        {
            var translation = DirectionMapping[direction];
            return coord.Translate(translation.X, translation.Y);
        }
    }
}