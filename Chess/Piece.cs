using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Chess
{
    public abstract class Piece : IPiece
    {
        public virtual string Symbol => "X";
        public PieceColour Colour { get; set; }
        
        //public int StartLocation { get; set; }
        //public IDictionary<string, string> AllowedMovements = new Dictionary<string, string>(); //<string, string> == <Movement Direction , Movement Limit>

        public Piece(PieceColour colour)
        {
            Colour = colour;
        }

        public static IPiece Create(PieceColour colour, PieceType type)
        {
            switch (type)
            {
                case PieceType.Rook:
                    return new Rook(colour);
                case PieceType.Knight:
                    return new Knight(colour); 
                case PieceType.Bishop:
                    return new Bishop(colour); 
                case PieceType.Queen:
                    return new Queen(colour); 
                case PieceType.King:
                    return new King(colour); 
                case PieceType.Pawn:
                    return new Pawn(colour);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public override string ToString()
        {
            return Symbol;
        }

    }
}
