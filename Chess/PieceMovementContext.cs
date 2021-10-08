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
    }
}