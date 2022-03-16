using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Chess.Coordinate;

namespace Chess
{
    public class PieceMovementContext
    {
        public Player ActivePlayer { get; set; }

        public ChessCoordinate CurrentCoordinate { get; set;  }
        public ChessCoordinate TargetCoordinate { get; set;  }

        public List<ITile> TilesOnLine { get; set; }

        public Point MoveMagnitude() //TODO determine if this method is needed now ChessCoordinate's are been used 
        {
            return new Point(Math.Abs(TargetCoordinate.Rank - CurrentCoordinate.Rank),
                Math.Abs(CurrentCoordinate.File - TargetCoordinate.File));
        }
    }
}