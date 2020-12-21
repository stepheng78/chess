namespace Chess
{
    public class Bishop : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WB" : "BB";

        public Bishop(PieceColour colour) : base(colour)
        {

        }
    }
}