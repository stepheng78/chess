using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Tile : ITile {
        public IPiece Piece { get; set; }

        public void SetPiece(IPiece piece)
        {
            Piece = piece;
        }

        public override string ToString()
        {
            return Piece?.ToString() ?? "X";
        }
    }
}
