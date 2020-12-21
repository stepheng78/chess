namespace Chess
{
    public class King : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WK" : "BK";

        public King(PieceColour colour) : base(colour)
        {

        }
    }
}