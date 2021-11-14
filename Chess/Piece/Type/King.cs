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
            throw new System.NotImplementedException();
        }

        protected override bool CanMoveInDirection(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}