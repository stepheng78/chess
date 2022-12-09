using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Chess.Coordinate;

namespace Chess
{
    public sealed class Rook : Piece
    {
        public override string Symbol => Colour == PieceColour.White ? "WR" : "BR";

        public Rook(PieceColour colour) : base(colour)
        {

        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            // Need to deal with castling 
            var magnitude = context.MoveMagnitude;
            if (magnitude.X > 0 && magnitude.Y > 0) return false;

            // any piece in the way
            foreach (var tile in context.TilesOnLine.Take(context.TilesOnLine.Count - 1))
            {
                if (tile.Piece != null) return false;
            }

            // if targeting piece can we take it
            if (context.TilesOnLine.Last().Piece?.Colour == Colour) return false;

            return true;
        }

        protected override bool CanMoveInDirection(PieceMovementContext direction)
        {
            throw new System.NotImplementedException();
        }

        protected override IList<List<IGameCoordinate>> ThreatenedCoordinates(IGameCoordinate currentCoordinate)
        {
            var toReturn = new List<List<IGameCoordinate>>
            {
                WalkCoordinates(currentCoordinate, Direction.North),
                WalkCoordinates(currentCoordinate, Direction.West),
                WalkCoordinates(currentCoordinate, Direction.South),
                WalkCoordinates(currentCoordinate, Direction.East)
            };

            return toReturn.Where(x => x.Any()).ToList();
        }
    }
}
