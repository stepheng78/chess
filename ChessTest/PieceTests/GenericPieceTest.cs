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
    public class GenericPieceTest
    {
        
        [Theory]
        [InlineData(PieceType.Bishop, true)]
        [InlineData(PieceType.Rook, false)]
        [InlineData(PieceType.Queen, true)]
        public void BasicPieceMoveValid(PieceType pieceType, bool shouldPass)
        {
            // Arrange
            var chessBoard = new Board();
            var piece = Piece.Create(PieceColour.White, pieceType);
            var targetCoordinate = new ChessCoordinate("B", "1");
            var currentCoordinate = new ChessCoordinate("A", "2");

            List<ITile> tilesOnLine = chessBoard.TilesOnMovementLine(currentCoordinate, targetCoordinate).ToList();

            var pieceMovementDetail = new PieceMovementContext
            {
                TargetCoordinate = targetCoordinate,
                CurrentCoordinate = currentCoordinate,
                TilesOnLine = tilesOnLine
            };

            // Act
            var canMove = piece.SpecialisedMoveBehaviour(pieceMovementDetail);

            // Assert
            Assert.Equal(shouldPass, canMove);
        }
    }
}
