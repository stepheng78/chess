using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Tile : ITile {
        public IPiece Piece { get; set; }
        
        public bool SetPiece(IPiece piece)
        {
            Piece = piece;
            return true;
        }

        public override string ToString()
        {
            return Piece?.ToString() ?? "__";
        }
    }
}