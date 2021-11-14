namespace Chess
{
    public interface ITile
    {
        IPiece Piece { get;}

        bool SetPiece(IPiece newPiece);
    }
}