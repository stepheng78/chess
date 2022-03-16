using System;
using System.Drawing;
using System.Linq;
using Xunit;
using Chess;
using Chess.Coordinate;

namespace ChessTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var board = new Board();

            board.GenerateTiles();

            Assert.Equal(64, board.Tiles.Length);
        }

        [Fact]
        public void Test2()
        {
            //setup 
            var board = new Board();
            board.GenerateTiles();
            board.GenerateChessPieces();

            //action
            var tiles = board.TilesOnMovementLine(new ChessCoordinate("B", "1"), new ChessCoordinate("A", "2")).ToList();
            
           //Investigate environment
            Assert.Equal(board.Tiles[3, 3], tiles[0]);
            Assert.Equal(board.Tiles[4, 4], tiles[1]);
        }
    }

}