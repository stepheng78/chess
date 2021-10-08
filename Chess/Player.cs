namespace Chess
{
    public class Player
    {
        public enum MovingTowardsDirection
        {
            Error = 0,
            Up = 1,
            Down = 2
        }

        public PieceColour PieceColour { get; }
        public MovingTowardsDirection MovingTowards { get; }

        public Player(PieceColour pieceColour, MovingTowardsDirection movingTowards)
        {
            PieceColour = pieceColour;
            MovingTowards = movingTowards;
        }
    }
}