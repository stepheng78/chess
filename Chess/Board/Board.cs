using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using Chess.Coordinate;
using Chess.MoveInput;


namespace Chess
{
    public class Board
    {
        private int Height = 8;
        private int Width = 8;

        private bool _isGameFinished = false;

        private List<Player> _players = new(); 

        public ITile[,] Tiles = new ITile[8, 8];

        public bool IsCurrentGameFinished => _isGameFinished; //would this get updated on check mate?

        public Board()
        {
            GenerateTiles();
        }

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

        public Player GetOpponentPlayer(Player activePlayer)
        {
            return _players.First(player => player.PieceColour != activePlayer.PieceColour);
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

            Tiles[1, 0].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 1].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 2].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 3].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 4].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 5].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 6].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 7].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));

            //Setup Black Pieces
            Tiles[7, 0].SetPiece(Piece.Create(PieceColour.Black, PieceType.Rook));
            Tiles[7, 1].SetPiece(Piece.Create(PieceColour.Black, PieceType.Knight));
            Tiles[7, 2].SetPiece(Piece.Create(PieceColour.Black, PieceType.Bishop));
            Tiles[7, 3].SetPiece(Piece.Create(PieceColour.Black, PieceType.Queen));
            Tiles[7, 4].SetPiece(Piece.Create(PieceColour.Black, PieceType.King));
            Tiles[7, 5].SetPiece(Piece.Create(PieceColour.Black, PieceType.Bishop));
            Tiles[7, 6].SetPiece(Piece.Create(PieceColour.Black, PieceType.Knight));
            Tiles[7, 7].SetPiece(Piece.Create(PieceColour.Black, PieceType.Rook));

            Tiles[6, 0].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 1].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 2].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 3].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 4].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 5].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 6].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 7].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
        }

        public enum MovingTowardsDirection
        {
            Error = 0,
            Up = 1,
            Down = 2
        }

        public bool TryFindPiece(Player activePlayer, ChessCoordinate currentCoordinate,  out IPiece pieceToMove) 
        {
            pieceToMove = Tiles[currentCoordinate.File, currentCoordinate.Rank].Piece;
            
            if (pieceToMove != null && pieceToMove.Colour == activePlayer.PieceColour)
            {
                Console.WriteLine($"Found the piece [{pieceToMove}]");
                return true;
            }

            return false;
        }

        public bool MovePiece(Player activePlayer, Player opponent, IPiece currentPiece, ChessCoordinate pieceTile, ChessCoordinate targetTile)  
        {
            List<ITile> tilesOnLine = TilesOnMovementLine(pieceTile, targetTile).ToList();

            PieceMovementContext currentPieceMovementContext = new()
            {
                ActivePlayer = activePlayer,
                Opponent = opponent,
                CurrentCoordinate = pieceTile,
                TargetCoordinate = targetTile,
                TilesOnLine = tilesOnLine
            };

            if (currentPiece.CanMove(currentPieceMovementContext))
            {
                Tiles[pieceTile.File, pieceTile.Rank].SetPiece(null); 
                Tiles[targetTile.File, targetTile.Rank].SetPiece(currentPiece);
                currentPiece.HasBeenMoved();
                return true; 
            }

            Console.WriteLine( $"[{currentPiece}] can't make that move");
            return false;
         }

        //TODO: Decide if I need CheckForPieceOnTile Method
        public static bool CheckForPieceOnTile(IEnumerable<ITile> tiles)
        {
            return tiles.Any(x => x.Piece != null);
        }

        public IEnumerable<ITile> TilesOnMovementLine(ChessCoordinate a, ChessCoordinate b)
        {
            int dx = b.Rank - a.Rank;
            int dy = a.File - b.File;  // Needs to be flipped, as we have an inverse-Y plane.

            int adx = Math.Abs(dx);
            int ady = Math.Abs(dy);
            var distance = Math.Max(adx, ady);

            var bearing = a.DirectionOf(b); 
            // TODO: Must deal with a bearing of none. Occurs if the player enters their move
            // as the same tile their pieces is already on 

            var translationVector = DirectionExtensions.DirectionMapping[bearing];

            var currentCoordinate = a;

            for (var i = 0; i < distance; i++)
            {
                currentCoordinate += translationVector;
                yield return Tiles[currentCoordinate.File, currentCoordinate.Rank];
            }
        }

        public void DisplayBoard()
        {
            var file = 1;
            
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"{Tiles[i, j]} ");
                }
                Console.Write($"| {i + 1}");
                Console.WriteLine("");
            }

            Console.WriteLine(string.Concat(Enumerable.Repeat("\u2500", 24)));
            
            var arr = new[]
            {
                "A", "B", "C", "D", "E", "F", "G", "H"
            };

            foreach (var rank in arr)
            {
                Console.Write($"{rank} |");
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
