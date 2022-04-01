using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Chess.Coordinate;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Board chessBoard = new Board();
            chessBoard.GeneratePlayers();
            chessBoard.GenerateChessPieces();
            chessBoard.DisplayBoard();

            foreach (var activePlayer in chessBoard.GetNextActivePlayer())
            {
                var moveMade = false;
                while (!moveMade)
                {
                    Console.WriteLine(
                        $"{activePlayer.PieceColour} - Enter current location of piece to be moved (e.g. A1):");
                    var pieceLocation = Console.ReadLine();

                    if (pieceLocation == "exit") return;
                    var playerPieceLocation = new ChessCoordinate(pieceLocation);

                    if (!chessBoard.TryFindPiece(activePlayer, playerPieceLocation, out IPiece pieceToMove))
                    {
                        Console.WriteLine($"Sorry, no {activePlayer.PieceColour} piece can be found at {pieceLocation}!\r\n");
                        chessBoard.DisplayBoard();
                        continue;
                    }

                    Console.WriteLine($"{activePlayer.PieceColour} - Enter your move (e.g. C3):");
                    var nextMove = Console.ReadLine();

                    if (nextMove == "exit") return;

                    var chessMove = new ChessCoordinate(nextMove);

                    if (!chessBoard.MovePiece(activePlayer, pieceToMove, playerPieceLocation, chessMove))
                    {
                        Console.WriteLine("Sorry, that's an invalid move!\r\n");
                        chessBoard.DisplayBoard();
                        continue;
                    }

                    moveMade = true;
                    chessBoard.DisplayBoard();
                }
            }
        }
    }
}