using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Chess
{
    public class PieceMovementContext
    {
        public Player ActivePlayer { get; set; }

        public Point CurrentCoordinate { get; set;  }
        public Point TargetCoordinate { get; set;  }

        public List<ITile> TilesOnLine { get; set; }

        public Point MoveMagnitude()
        {
            return new Point(Math.Abs(TargetCoordinate.X - CurrentCoordinate.X),
                Math.Abs(CurrentCoordinate.Y - TargetCoordinate.Y));
        }
    }
}