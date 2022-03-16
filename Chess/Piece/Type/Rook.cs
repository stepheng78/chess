using System;
using System.Linq;

namespace Chess
{
    class Rook : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WR" : "BR";

        public Rook(PieceColour colour) : base(colour)
        {

        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            // Rook can move in straight line in any direction.
            // 0:[1-max(y)] or [1 - max(x)]]:0 translation
            // If move is greater than 0 on both axises then move invalid
            
            // trig check - magnitude along an axis
            var magnitude = context.MoveMagnitude();
            if (magnitude.X > 0 && magnitude.Y > 0) return false;

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
