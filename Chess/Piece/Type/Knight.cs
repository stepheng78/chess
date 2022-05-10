namespace Chess
{
    public class Knight : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WN" : "BN";

        public Knight(PieceColour colour) : base(colour)
        {

        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            // Knight can move in a 1:2 or 2:1 L shaped movement
            // Can also jump pieces
            throw new System.NotImplementedException();
        }

        protected override bool CanMoveInDirection(PieceMovementContext direction)
        {
            throw new System.NotImplementedException();
        }
    }
}