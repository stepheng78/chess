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
            return type switch
            {
                PieceType.Rook => new Rook(colour),
                PieceType.Knight => new Knight(colour),
                PieceType.Bishop => new Bishop(colour),
                PieceType.Queen => new Queen(colour),
                PieceType.King => new King(colour),
                PieceType.Pawn => new Pawn(colour),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public override string ToString()
        {
            return Symbol;
        }

        public bool CanMove(PieceMovementContext context) // Method cannot be overridden as it's not abstract or virtual
        {
            // TODO create enum to handle error code message
            if (context.ActivePlayer.PieceColour != Colour) return false;
            if (context.CurrentCoordinate == context.TargetCoordinate) return false;
            return SpecialisedMoveBehaviour(context);
        }

        public abstract bool SpecialisedMoveBehaviour(PieceMovementContext context);

        protected virtual bool CanMoveTowardsDirection(Board.MovingTowardsDirection movingTowards, Direction direction)
        {
            return true;
        }

        protected abstract bool CanMoveInDirection(PieceMovementContext direction); // *** why is this protected? // Abstract: Children must implement method. Can't have any definition in the Parent

        // Virtual: Parent provides implementation but can be overridden by child
        public virtual void HasBeenMoved() { }
    }
}
