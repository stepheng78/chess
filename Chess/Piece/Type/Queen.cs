using System;

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
            //Queen can move diagonally or in a straight line. A 1:1 xy translation or 0:[1-max(y)] or [1 - max(x)]]:0 X:Y translation.
            if ((Math.Abs(context.TargetCoordinate.Rank) - Math.Abs(context.TargetCoordinate.File) != 0) &&
                (Math.Abs(context.TargetCoordinate.Rank) > 0 && Math.Abs(context.TargetCoordinate.File) > 0)) return false;
            return true;
        }

        protected override bool CanMoveInDirection(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}