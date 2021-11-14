using System;
using System.Linq;

namespace Chess
{
    public sealed class Bishop : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WB" : "BB";  

        public Bishop(PieceColour colour) : base(colour)
        {

        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            // Define the movement of this piece to determine if the current requested move is logically allowed
            // Bishop can move diagonally. A 1:1 xy translation. Bishop piece should verify if move is legal.
            // If the movement translation in not equal in both axis then move is invalid
            
            // trig check - magnitude along an axis
            var magnitude = context.MoveMagnitude();
            if (magnitude.X - magnitude.Y != 0) return false;

            // any piece in the way
            foreach (var tile in context.TilesOnLine.Take(context.TilesOnLine.Count - 1))
            {
                if (tile.Piece != null) return false;
            }

            // if targeting piece can we take it
            if (context.TilesOnLine.Last().Piece?.Colour == Colour) return false;

            return true;
        }

        protected override bool CanMoveInDirection(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}