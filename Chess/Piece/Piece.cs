using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Chess.Coordinate;

namespace Chess
{
    public abstract class Piece : IPiece
    {
        public virtual string Symbol => "X"; 
        public PieceColour Colour { get; set; }

        public Piece(PieceColour colour)
        {
            Colour = colour;
        }

        public static IPiece Create(PieceColour colour, PieceType type)
        {
            return type switch
            {
                PieceType.Rook => new Rook(colour),
                PieceType.Knight => new Knight(colour),
                PieceType.Bishop => new Bishop(colour),
                PieceType.Queen => new Queen(colour),
                PieceType.King => new King(colour),
                PieceType.Pawn => new Pawn(colour),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public override string ToString()
        {
            return Symbol;
        }

        public bool CanMove(PieceMovementContext context) // Method cannot be overridden as it's not abstract or virtual
        {
            if (context.ActivePlayer.PieceColour != Colour) return false;

            // no objects in TilesOnLine most likely means current tile has been chosen as destination which is an invalid move
            // todo: return a custom message. potentially using a new message class
            if (context.TilesOnLine.Count == 0) return false;

            // if targeting piece can we take it
            if (context.TilesOnLine.Last().Piece?.Colour == Colour) return false;

            if (this is not IJumpOver) 
            {
                var tilesToCheck = context.TilesOnLine.Take(context.TilesOnLine.Count - 1);
                if (tilesToCheck.Any(x => x.Piece != null)) return false;
            }

            return context.CurrentCoordinate != context.TargetCoordinate && SpecialisedMoveBehaviour(context);
        }

        public abstract bool SpecialisedMoveBehaviour(PieceMovementContext context);

        protected virtual bool CanMoveTowardsDirection(Board.MovingTowardsDirection movingTowards, Direction direction)
        {
            return true;
        }

        // Abstract: Children must implement method. Can't have any definition in the Parent
        protected abstract bool CanMoveInDirection(PieceMovementContext direction); // *** why is this protected? 

        // Virtual: Parent provides implementation but can be overridden by child
        public virtual void HasBeenMoved() { }

        protected abstract IList<List<IGameCoordinate>> ThreatenedCoordinates(IGameCoordinate currentCoordinate);

        protected List<IGameCoordinate> WalkCoordinates(IGameCoordinate coord, Direction direction, int limit = Int32.MaxValue)
        {
            var list = new List<IGameCoordinate>();

            var walkCount = 0;

            for (var nextCoord = coord.Translate(direction); nextCoord.IsValid && walkCount < limit; nextCoord = nextCoord.Translate(direction), walkCount++)
            {
                list.Add(nextCoord);
            }

            return list;
        } 
    }
}
