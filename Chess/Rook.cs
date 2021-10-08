using System;

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
            if (Math.Abs(context.TargetCoordinate.X) > 0 && Math.Abs(context.TargetCoordinate.Y) > 0) return false;
            return true;
        }

        protected override bool CanMoveInDirection(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}
