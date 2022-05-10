using System.Linq;

namespace Chess
{
    public class King : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WK" : "BK";

        public King(PieceColour colour) : base(colour)
        {

        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            //King can move diagonally or in a straight line but only one tile at a time.
            //A 1:1 X:Y translation or a 0:[1-max(y)] or [1-max(x)]]:0 X:Y translation.
            //Plus a max magnitude of 1
            var magnitude = context.MoveMagnitude;
            if (
                //Check movement only one tile
                (magnitude.X > 1 || magnitude.Y > 1) 
                ||
                (
                  //Check movement is straight or diagonal //TOD0 should this comment be part of a summary for  "MoveMagnitude"
                  (magnitude.X > 0 && magnitude.Y > 0) && 
                  (magnitude.X - magnitude.Y != 0) 
                )
               ) return false;

            // any piece in the way
            foreach (var tile in context.TilesOnLine.Take(context.TilesOnLine.Count - 1))
            {
                if (tile.Piece != null) return false;
            }

            // if targeting piece can we take it
            if (context.TilesOnLine.Last().Piece?.Colour == Colour) return false;

            return true;
        }

        protected override bool CanMoveInDirection(PieceMovementContext direction)
        {
            throw new System.NotImplementedException();
        }
    }
}