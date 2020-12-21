namespace Chess
{
    public class Knight : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WN" : "BN";

        public Knight(PieceColour colour) : base(colour)
        {

        }
    }
}