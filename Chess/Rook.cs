namespace Chess
{
    class Rook : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WR" : "BR";

        public Rook(PieceColour colour) : base(colour)
        {

        }
    }
}
