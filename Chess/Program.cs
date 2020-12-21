using System;
using System.Collections.Generic;
using System.Text;

/*
 * Program simply makes a couple of calls to run the chess game 
 * 1. Generate required tiles of board
 * 2. DisplayBoard
 *
*/

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Board chessBoard = new Board();
            chessBoard.GenerateTiles();

            chessBoard.GenerateChessPieces();

            chessBoard.DisplayBoard();
        }
    }
}
