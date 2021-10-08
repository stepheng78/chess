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
            throw new System.NotImplementedException();
        }

        protected override bool CanMoveInDirection(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}