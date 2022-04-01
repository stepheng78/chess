using System;
using System.Linq;

namespace Chess
{
    public class Queen : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WQ" : "BQ";

        public Queen(PieceColour colour) : base(colour)
        {

        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            //Queen can move diagonally or in a straight line. A 1:1 X:Y translation or
            //a 0:[1-max(y)] or [1-max(x)]]:0 X:Y translation.
            var magnitude = context.MoveMagnitude();
            if ((magnitude.X > 0 && magnitude.Y > 0) && (magnitude.X - magnitude.Y != 0)) return false;

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