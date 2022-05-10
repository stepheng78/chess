using System;
using System.Collections.Generic;
using System.Drawing;
using Chess.Coordinate;

namespace Chess
{
    public class PieceMovementContext
    {
        public Player ActivePlayer { get; set; }

        public Player Opponent { get; set; }

        public ChessCoordinate CurrentCoordinate { get; set;  }
        public ChessCoordinate TargetCoordinate { get; set;  }

        public List<ITile> TilesOnLine { get; set; } // this is a pair of accessor methods

        public Point MoveMagnitude => new(Math.Abs(TargetCoordinate.Rank - CurrentCoordinate.Rank),
                                                Math.Abs(CurrentCoordinate.File - TargetCoordinate.File)); //expression bodied property
    }
}