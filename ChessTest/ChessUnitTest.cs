using System.Linq;
using Xunit;
using Chess;
using Chess.Coordinate;

namespace ChessTest
{
    public class ChessUnitTest
    {
        //TODO: Use the SETUP functionality to replace lines 11 - 18. This setup should happen before each test. 
        //public ITile[,] Tiles = new ITile[8, 8];
        public Board board;

        public ChessUnitTest()
        {
            board = new Board();
            board.GenerateTiles();
        }

        [Fact]
        public void GenerateTiles_ShouldEqual()
        {
            Assert.Equal(64, board.Tiles.Length);
        }

        [Fact(Skip = "Need to confirm tiles to be matched")]
        public void TilesOnMovementLine_ShouldMatch_TilesBetweenCoordinates()
        {
            //setup 
            var board = new Board();
            board.GenerateTiles();

            //action
            var tiles = board.TilesOnMovementLine(new ChessCoordinate("B", "1"), new ChessCoordinate("A", "2")).ToList();
            
           //Investigate environment
            Assert.Equal(board.Tiles[3, 3], tiles[0]);
            Assert.Equal(board.Tiles[4, 4], tiles[1]);
        }

        [Fact]
        public void MovePiece_CanNonJumpingWhitePieceMove()
        {
            IPiece pieceToMove = Piece.Create(PieceColour.White, PieceType.Queen);
            
            Player activePlayer = new Player(PieceColour.White, Player.MovingTowardsDirection.Down);
            Player opponent = new Player(PieceColour.Black, Player.MovingTowardsDirection.Up);
            
            ChessCoordinate pieceTile = new ChessCoordinate("D1");
            ChessCoordinate targetTile = new ChessCoordinate("D4");

            var result = board.MovePiece(activePlayer, opponent, pieceToMove, pieceTile, targetTile);

            Assert.True(result);
        }

        [Fact]
        public void MovePiece_CanBlackKnightMove()
        {
            IPiece pieceToMove = Piece.Create(PieceColour.Black, PieceType.Knight);

            Player activePlayer = new Player(PieceColour.Black, Player.MovingTowardsDirection.Up);
            Player opponent = new Player(PieceColour.White, Player.MovingTowardsDirection.Down);

            ChessCoordinate pieceTile = new ChessCoordinate("B8");
            ChessCoordinate targetTile = new ChessCoordinate("C6");

            var result =  board.MovePiece(activePlayer, opponent, pieceToMove, pieceTile, targetTile);

            Assert.True(result);
        }

        [Theory]
        [InlineData("A2","A3")]
        [InlineData("A2", "A4")]
        //[InlineData("A2", "B3")] //This should actually be another test. CanPawnTakePiece. Needs to have the capacity to have a piece on the target tile to test. More setup needed. 

        public void MovePiece_CanPawnPieceMove(string pieceTileString, string targetTileString)
        {
            IPiece pieceToMove = Piece.Create(PieceColour.White, PieceType.Pawn);

            Player activePlayer = new Player(PieceColour.White, Player.MovingTowardsDirection.Down);
            Player opponent = new Player(PieceColour.Black, Player.MovingTowardsDirection.Up);

            ChessCoordinate pieceTile = new ChessCoordinate(pieceTileString);
            ChessCoordinate targetTile = new ChessCoordinate(targetTileString);

            var result = board.MovePiece(activePlayer, opponent, pieceToMove, pieceTile, targetTile);

            Assert.True(result);
        }

        [Theory]
        [InlineData("A2", "A7")]
        [InlineData("A2", "C4")]

        public void MovePiece_CanPawnMakeInvalidStandardMove(string pieceTileString, string targetTileString)
        {
            IPiece pieceToMove = Piece.Create(PieceColour.White, PieceType.Pawn);

            Player activePlayer = new Player(PieceColour.White, Player.MovingTowardsDirection.Down);
            Player opponent = new Player(PieceColour.Black, Player.MovingTowardsDirection.Up);

            ChessCoordinate pieceTile = new ChessCoordinate(pieceTileString);
            ChessCoordinate targetTile = new ChessCoordinate(targetTileString);

            var result = board.MovePiece(activePlayer, opponent, pieceToMove, pieceTile, targetTile);

            Assert.False(result);
        }

        public ITile[,] Tiles = new ITile[8, 8];

        [Theory]
        [InlineData("A2", "B3")] //This should actually be another test. CanPawnTakePiece. Needs to have the capacity to have a piece on the target tile to test. More setup needed. 

        public void MovePiece_CanPawnTakePiece(string pieceTileString, string targetTileString)
        {
            board.GenerateTiles();
            IPiece pieceToMove = Piece.Create(PieceColour.White, PieceType.Pawn);
            IPiece pieceToTake = Piece.Create(PieceColour.Black, PieceType.Pawn);

            Player activePlayer = new Player(PieceColour.White, Player.MovingTowardsDirection.Down);
            Player opponent = new Player(PieceColour.Black, Player.MovingTowardsDirection.Up);

            ChessCoordinate pieceTile = new ChessCoordinate(pieceTileString);
            ChessCoordinate targetTile = new ChessCoordinate(targetTileString);

            // Put a black piece on targetTile so white pawn can make a legitimate move. 
            //Tiles[targetTile.File, targetTile.Rank].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[4,0].SetPiece(pieceToTake);
            var result = board.MovePiece(activePlayer, opponent, pieceToMove, pieceTile, targetTile);

            Assert.True(result);
        }
    }

}