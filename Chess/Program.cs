using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

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
                    /*
                    Console.WriteLine($"{activePlayer.PieceColour} - please enter a piece to be moved:");
                    var piece = Console.ReadLine();

                    if (piece == "exit") return; //break just exited current iteration of loop not the program
                    */
                    Console.WriteLine($"{activePlayer.PieceColour} - Enter current location of piece to be moved (e.g. A1):");
                    var pieceLocation = Console.ReadLine();

                    if (pieceLocation == "exit") return;

                    Console.WriteLine($"{activePlayer.PieceColour} - Enter your move (e.g. C3):");
                    var nextMove = Console.ReadLine();

                    if (nextMove == "exit") return;

                    if (chessBoard.MovePiece(activePlayer, pieceLocation, nextMove))
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
