using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            chessBoard.GeneratePlayers();
            chessBoard.GenerateChessPieces();
            chessBoard.DisplayBoard();

            foreach (var activePlayer in chessBoard.GetNextActivePlayer())
            {
                var moveMade = false;
                while (!moveMade)
                {
                    Console.WriteLine($"{activePlayer.PieceColour} - please enter a piece to be moved:");
                    var piece = Console.ReadLine();

                    if (piece == "exit") return; //break just exited current iteration of loop not the program

                    Console.WriteLine("Enter your move (e.g. 0,2):");
                    var nextMove = Console.ReadLine();

                    if (nextMove == "exit") return;

                    if (chessBoard.MovePiece(activePlayer, piece, nextMove))
                    {
                        moveMade = true;
                        chessBoard.DisplayBoard();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that's an invalid move!\r\n");
                        chessBoard.DisplayBoard();
                    }
                }
            }
        }
    }
}
