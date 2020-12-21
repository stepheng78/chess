namespace Chess
{
    public class Pawn : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WP" : "BP";

        public Pawn(PieceColour colour) : base(colour)
        {

        }
    }
}