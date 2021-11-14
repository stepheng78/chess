using Chess.MoveInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;


namespace Chess
{
    public class Board
    {
        private int Height = 8;
        private int Width = 8;

        private bool _isGameFinished = false;

        private List<Player> _players = new(); //*** was it right to initialise this field??

        public ITile[,] Tiles = new ITile[8, 8];

        public bool IsCurrentGameFinished => _isGameFinished; 
        //what is the purpose of this line (30/08/2021)? expose the private member _isGameFinished 
        //would this get updated on check mate?

        public IEnumerable<Player> GetNextActivePlayer()
        {
            while (!_isGameFinished)
            {
                for (var i = 0; i < _players.Count && !_isGameFinished; i++)
                {
                    yield return _players[i];
                }
            }
        }

        public ITile[,] GenerateTiles()
        {
            for (int m = 0; m < Height; m++)
            {
                for (int n = 0; n < Width; n++)
                {
                    Tiles[m, n] = new Tile();
                }
            }

            return Tiles;
        }

        public void GeneratePlayers()
        {
            _players.Add(new Player(PieceColour.White, Player.MovingTowardsDirection.Down));  
            _players.Add(new Player(PieceColour.Black, Player.MovingTowardsDirection.Up));
        }

        public void GenerateChessPieces()
        {
            //Setup White Pieces
            Tiles[0, 0].SetPiece(Piece.Create(PieceColour.White, PieceType.Rook));
            Tiles[0, 1].SetPiece(Piece.Create(PieceColour.White, PieceType.Knight));
            Tiles[0, 2].SetPiece(Piece.Create(PieceColour.White, PieceType.Bishop));
            Tiles[0, 3].SetPiece(Piece.Create(PieceColour.White, PieceType.Queen));
            Tiles[0, 4].SetPiece(Piece.Create(PieceColour.White, PieceType.King));
            Tiles[0, 5].SetPiece(Piece.Create(PieceColour.White, PieceType.Bishop));
            Tiles[0, 6].SetPiece(Piece.Create(PieceColour.White, PieceType.Knight));
            Tiles[0, 7].SetPiece(Piece.Create(PieceColour.White, PieceType.Rook));
/*
            Tiles[1, 0].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 1].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 2].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 3].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 4].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 5].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 6].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 7].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
*/
            //Setup Black Pieces
            Tiles[7, 0].SetPiece(Piece.Create(PieceColour.Black, PieceType.Rook));
            Tiles[7, 1].SetPiece(Piece.Create(PieceColour.Black, PieceType.Knight));
            Tiles[7, 2].SetPiece(Piece.Create(PieceColour.Black, PieceType.Bishop));
            Tiles[7, 3].SetPiece(Piece.Create(PieceColour.Black, PieceType.Queen));
            Tiles[7, 4].SetPiece(Piece.Create(PieceColour.Black, PieceType.King));
            Tiles[7, 5].SetPiece(Piece.Create(PieceColour.Black, PieceType.Bishop));
            Tiles[7, 6].SetPiece(Piece.Create(PieceColour.Black, PieceType.Knight));
            Tiles[7, 7].SetPiece(Piece.Create(PieceColour.Black, PieceType.Rook));
/*
            Tiles[6, 0].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 1].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 2].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 3].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 4].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 5].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 6].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 7].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
*/


        }

        // QUESTION(S): 
        //1. Was this function to help validate the move of a piece (e.g. restricted movement of pawn)?
        //2. How do I determine the direction I am heading towards? Is it based on my movement line through the tile array?
        public enum MovingTowardsDirection
        {
            Error = 0,
            Up = 1,
            Down = 2
        }

        public bool TryFindPiece(Player activePlayer, string currentLocation,  out) 
        {
            Point pieceLocation = new Point();
            var convertPlayerInput = new ChessMoveInput();
            convertPlayerInput.TryParse(currentLocation, out pieceLocation);

            var pieceOnLocation = Tiles[pieceLocation.Y, pieceLocation.X].Piece;
            if (pieceOnLocation != null && pieceOnLocation.Colour == activePlayer.PieceColour )
            {
                Console.WriteLine($"Found the piece [{pieceOnLocation.ToString()}] at position [{pieceLocation.Y}, {pieceLocation.X}]");
                return pieceLocation;
            }

            pieceLocation = default; // TODO Can't return default value. Must come up with another approach
            return pieceLocation;
        }

        public bool MovePiece(Player activePlayer, string currentLocation, string newLocation)
        {
            // Identify location of piece to be moved. 
            var pieceLocation = FindPiece(activePlayer, currentLocation);

            // Convert player move into index values
            var targetLocation = new Point();
            var moveInput = new ChessMoveInput();
            moveInput.TryParse(newLocation, out targetLocation);
 
            var clampedY = Math.Clamp(targetLocation.Y, 0, 7);
            var clampedX = Math.Clamp(targetLocation.X, 0, 7);
           
            //Generate list of all tiles on movement line to check if another piece is in the way
            Point newTile = new Point(clampedX, clampedY);
            List<ITile> tilesOnLine = TilesOnMovementLine(pieceLocation, newTile).ToList();

            // Setup the movement context of player's piece
            PieceMovementContext currentPieceMovementContext = new PieceMovementContext
            {
                ActivePlayer = activePlayer,
                CurrentCoordinate = pieceLocation,
                TargetCoordinate = newTile,
                TilesOnLine = tilesOnLine
            };

            var pieceToMove = Tiles[pieceLocation.Y, pieceLocation.X].Piece;

            if (pieceToMove.CanMove(currentPieceMovementContext))
            {
                // Valid Move
                Tiles[pieceLocation.Y, pieceLocation.X].SetPiece(null); 
                Tiles[clampedY, clampedX].SetPiece(pieceToMove);
                return true; 
            }
            else
            {
                // Invalid Move
                Console.WriteLine( $"[{pieceToMove.ToString()}] can't make that move");
                return false;
            }

        }

        public bool CheckForPieceOnTile(IEnumerable<ITile> tiles)
        {
            return tiles.Any(x => x.Piece != null);
        }

        public static Dictionary<Direction, Point> DirectionMapping = new Dictionary<Direction, Point>
        {
            // DirectionMapping will provide the step formula for moving across tiles in a particular direction
            { Direction.North, new Point(0, -1) },
            { Direction.NorthEast, new Point(1, -1) },
            { Direction.East, new Point(1, 0) },
            { Direction.SouthEast, new Point(1, 1) },
            { Direction.South, new Point(0, 1) },
            { Direction.SouthWest, new Point(-1, 1) },
            { Direction.West, new Point(-1, 0) },
            { Direction.NorthWest, new Point(-1, -1) }
        };

        public IEnumerable<ITile> TilesOnMovementLine(Point a, Point b)
        {
            int dx = b.X - a.X;
            int dy = a.Y - b.Y;  // Needs to be flipped, as we have an inverse-Y plane.

            int adx = Math.Abs(dx);
            int ady = Math.Abs(dy);
            var distance = Math.Max(adx, ady);

            var bearing = a.DirectionOf(b);

             var translationVector = DirectionMapping[bearing];

            var currentCoordinate = a;

            for (var i = 0; i < distance; i++)
            {
                currentCoordinate.Offset(translationVector);
                yield return Tiles[currentCoordinate.X, currentCoordinate.Y];
            }
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"{Tiles[i, j]} ");
                }
                Console.WriteLine("");

            }
        }
    }
}
