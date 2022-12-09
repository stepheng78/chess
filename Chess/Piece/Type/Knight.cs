using System.Linq;

namespace Chess
{
    public class Knight : Piece, IJumpOver
    {
        public override string Symbol => Colour == PieceColour.White ? "WN" : "BN";

        public Knight(PieceColour colour) : base(colour)
        {

        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            // Knight can move in a 1:2 or 2:1 L shaped movement
            // Can also jump pieces
            var magnitude = context.MoveMagnitude;

            if (!((magnitude.X == 1 && magnitude.Y == 2) || (magnitude.X == 2 && magnitude.Y == 1)))
            {
                return false;            
            }

            // if targeting piece can we take it
            return context.TilesOnLine.Last().Piece?.Colour != Colour;
        }

        protected override bool CanMoveInDirection(PieceMovementContext direction)
        {
            throw new System.NotImplementedException();
        }
    }
}