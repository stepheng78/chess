using System;
using System.Linq;
using System.Reflection;

namespace Chess
{
    public class Pawn : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WP" : "BP";
        public bool IsFirstMove { get; private set; } = true;

        public Pawn(PieceColour colour) : base(colour)
        {
          
        }

        // TODO: Deal with Pawn changing into another piece 
        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            var magnitude = context.MoveMagnitude;

            // Check direction of movement is towards opponent
            if (!CanMoveInDirection(context)) { return false; }

            // Check magnitude of movement is correct for the current move
            if (magnitude.X > 0 || magnitude.Y > 1) // if either of these conditions are met then pawn is not performing its generic behaviour so drop into specialized behaviour
            {
                if (!IsFirstMove && (magnitude.X == 0 && magnitude.Y == 2)) //Specialised First Move
                {
                    return false;
                }

                // Check if movement is diagonal. If true then check an opponent piece is on target tile
                if (magnitude.X == 1 && magnitude.Y == 1 && context.TilesOnLine.Last().Piece?.Colour == Colour)
                {
                    return false;
                }
            }

            // any piece in the way
            return context.TilesOnLine.Take(context.TilesOnLine.Count - 1).All(tile => tile.Piece == null);
        }

        protected override bool CanMoveInDirection(PieceMovementContext direction) // TODO Write unit tests for method (5 minimum)
        {
            var bearing = direction.CurrentCoordinate.DirectionOf(direction.TargetCoordinate);

            switch (bearing)
            {
                case Direction.North:
                case Direction.NorthEast:
                case Direction.NorthWest:
                    return direction.ActivePlayer.MovingTowards == Player.MovingTowardsDirection.Up;

                case Direction.East:
                case Direction.West:
                    return false;

                case Direction.South:
                case Direction.SouthEast:
                case Direction.SouthWest:
                    return direction.ActivePlayer.MovingTowards == Player.MovingTowardsDirection.Down;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void HasBeenMoved()
        {
            IsFirstMove = false;
        }
    }
}