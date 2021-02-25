using System;
using System.Collections.Generic;
using System.Text;

/*
 * Program simply makes a couple of calls to run the chess game 
 * 1. Generate required tiles of board
 * 2. Create chess pieces
 * 3. DisplayBoard
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

            String nextMove = "";
            string Piece = ";";

            do
            {
                Console.WriteLine("Enter Piece to be moved:");
                Piece = Console.ReadLine();
                Console.WriteLine("Enter your move (e.g. 0,2):");
                nextMove = Console.ReadLine();

                chessBoard.MovePiece(Piece, nextMove);

                chessBoard.DisplayBoard();
            } while (nextMove != "exit");
            //} while ((Piece != "exit" | Piece != "e") | (nextMove != "exit" | nextMove != "e"));
        }
    }
}
