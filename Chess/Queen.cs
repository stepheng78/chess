namespace Chess
{
    public class Queen : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WQ" : "BQ";

        public Queen(PieceColour colour) : base(colour)
        {

        }
    }
}