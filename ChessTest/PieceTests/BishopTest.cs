using Chess;
using Chess.Coordinate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChessTest.PieceTests
{
    public class BishopTest
    {
        [Fact]
        public void BasicBishopMoveValid()
        {
            // Arrange
            var chessBoard = new Board();
            var bishop = new Bishop(PieceColour.White);
            var targetCoordinate = new ChessCoordinate("B", "1");
            var currentCoordinate = new ChessCoordinate("A", "2");

            chessBoard.GenerateTiles();
            List<ITile> tilesOnLine = chessBoard.TilesOnMovementLine(currentCoordinate, targetCoordinate).ToList();

            var pieceMovementDetail = new PieceMovementContext
            {
                TargetCoordinate = targetCoordinate,
                CurrentCoordinate = currentCoordinate,
                TilesOnLine = tilesOnLine
            };

            // Act
            var canMove = bishop.SpecialisedMoveBehaviour(pieceMovementDetail);

            // Assert
            Assert.True(canMove);
        }

        [Fact]
        public void BasicBishopMoveInvalid()
        {
            // Arrange
            var chessBoard = new Board();
            var bishop = Piece.Create(PieceColour.White, PieceType.Bishop);  //new Bishop(PieceColour.White);
            var targetCoordinate = new ChessCoordinate("B", "1");
            var currentCoordinate = new ChessCoordinate("B", "3");

            chessBoard.GenerateTiles();
            List<ITile> tilesOnLine = chessBoard.TilesOnMovementLine(currentCoordinate, targetCoordinate).ToList();

            var pieceMovementDetail = new PieceMovementContext
            {
                TargetCoordinate = targetCoordinate,
                CurrentCoordinate = currentCoordinate,
                TilesOnLine = tilesOnLine
            };

            // Act
            var canMove = bishop.SpecialisedMoveBehaviour(pieceMovementDetail);

            // Assert
            Assert.False(canMove);
        }
    }
}
