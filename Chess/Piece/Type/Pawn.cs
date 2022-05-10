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
            //What is allowed inside a constructor?
        }

        public override bool SpecialisedMoveBehaviour(PieceMovementContext context)
        {
            // Pawn can move only towards opponents side of the board in straight line
            // unless it is taking a piece. Then is can move diagonally. Except for its 
            // first move, where it can move 2 spaces, it is restricted to moving 1 space per move

            //Checks: 1. If move is first move is it 2 spaces or less?
            // 2. If move not first then move only allowed to be 1 space from current tile?
            // 3. Is direction of movement towards opponent
            // 4. If move is diagonally is there a piece on the target tile? If not move invalid.
            var magnitude = context.MoveMagnitude;

            // Check direction of movement is towards opponent
            if (!CanMoveInDirection(context)) { return false; }

            // Check magnitude of movement is correct for the current move
            if (magnitude.X > 0 || magnitude.Y > 1) //generic behaviour. all pawns must adhere to this movement rule
            {
                if (!(IsFirstMove && magnitude.X == 0 && magnitude.Y == 2)) //specialised move
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
            
            /*
            foreach (var tile in context.TilesOnLine.Take(context.TilesOnLine.Count - 1))
            {
                if (tile.Piece != null) return false;
            }

            return true;
            */
            
            
        }

        protected override bool CanMoveInDirection(PieceMovementContext direction)
        {
            var bearing = direction.CurrentCoordinate.DirectionOf(direction.TargetCoordinate);

            if (direction.ActivePlayer.PieceColour == PieceColour.White)
            {
                if (bearing == Direction.South || bearing == Direction.SouthEast || bearing == Direction.SouthWest)
                {
                    return true;
                }
                
                return false;
            }
            
            if (bearing == Direction.North || bearing == Direction.NorthEast || bearing == Direction.NorthWest)
            {
                return true;
            }

            return false;
        }

        public override void HasBeenMoved()
        {
            IsFirstMove = false;
        }
    }
}