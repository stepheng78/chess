using System;

namespace Chess
{
    public class Pawn : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WP" : "BP";

        public Pawn(PieceColour colour) : base(colour)
        {

        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            // Pawn can move only towards opponents side of the board in straight line
            // unless it is taking a piece. Then is can move diagonally. Except for its 
            // first move, where it can move 2 spaces, it is restricted to moving 1 space per move

            //Checks: 1. If move is first move is it 2 spaces or less?
            // 2. If move not first then move only allowed to be 1 space from current tile?
            // 3. Is direction of movement forward
            // 4. If move is diagonally is there a piece on the target tile? If not move invalid.
            // 
            //if (Math.Abs(context.TargetCoordinate.X) > 0 && Math.Abs(context.TargetCoordinate.Y) > 0) return false;
            return true;
            //throw new System.NotImplementedException();
        }

        protected override bool CanMoveInDirection(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}