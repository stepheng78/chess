namespace Chess.Coordinate
{
    public interface IGameCoordinate
    {
        int X { get; }
        int Y { get; }

        IGameCoordinate Translate(int byX, int byY);

        bool IsValid { get; }
    }
}