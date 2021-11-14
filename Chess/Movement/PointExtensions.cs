using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Chess
{
    public static class PointExtensions
    {
        private static readonly double Octile = Math.Sqrt(2.0) - 1.0;

        public static Direction DirectionOf(this Point a, Point b)
        {
            double dx = b.X - a.X;
            double dy = a.Y - b.Y; // Needs to be flipped, as we have an inverse-Y plane.
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if ((Math.Abs(dy) / Math.Abs(dx)) <= Octile)
                {
                    return dx > 0 ? Direction.East : Direction.West;
                }
                else if (dx > 0)
                {
                    return dy > 0 ? Direction.NorthEast : Direction.SouthEast;
                }
                else
                {
                    return dy > 0 ? Direction.NorthWest : Direction.SouthWest;
                }
            }
            else if (Math.Abs(dy) > 0)
            {
                if ((Math.Abs(dx) / Math.Abs(dy)) <= Octile)
                {
                    return dy > 0 ? Direction.North : Direction.South;
                }
                else if (dy > 0)
                {
                    return dx > 0 ? Direction.NorthEast : Direction.NorthWest;
                }
                else
                {
                    return dx > 0 ? Direction.SouthEast : Direction.SouthWest;
                }
            }
            else
            {
                return Direction.None;
            }
        }
    }
}
