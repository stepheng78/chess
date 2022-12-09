using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Chess.Coordinate;
using Chess.Exceptions;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Board chessBoard = new();
            chessBoard.GeneratePlayers();
            chessBoard.GenerateChessPieces();
            chessBoard.DisplayBoard();

            foreach (var activePlayer in chessBoard.GetNextActivePlayer())
            {
                var moveMade = false;
                while (!moveMade)
                {
                    Console.Write($"{activePlayer.PieceColour} - Enter location of piece to move (e.g. A1): ");
                    var pieceLocation = String.Concat((Console.ReadLine()).Where(c => !Char.IsWhiteSpace(c)));

                    if (pieceLocation == "exit") return;

                    try
                    {
                        var playerPieceLocation = new ChessCoordinate(pieceLocation);

                        if (!chessBoard.TryFindPiece(activePlayer, playerPieceLocation, out IPiece pieceToMove))
                        {
                            Console.WriteLine($"Sorry, no {activePlayer.PieceColour} piece can be found at {pieceLocation}!\r\n");
                            chessBoard.DisplayBoard();
                            continue;
                        }

                        Console.Write($"{activePlayer.PieceColour} - Enter your move (e.g. C3): ");
                        var nextMove = String.Concat((Console.ReadLine()).Where(c => !Char.IsWhiteSpace(c)));

                        if (nextMove == "exit") return;

                        var chessMove = new ChessCoordinate(nextMove);
                        var opponent = chessBoard.GetOpponentPlayer(activePlayer);

                        if (!chessBoard.MovePiece(activePlayer, opponent, pieceToMove, playerPieceLocation, chessMove))
                        {
                            Console.WriteLine("Sorry, that's an invalid move!\r\n");
                            chessBoard.DisplayBoard();
                            continue;
                        }

                        moveMade = true;
                        chessBoard.DisplayBoard();
                    }
                    catch (ChessCoordinateNotValidException chessCoordEx )
                    {
                        Console.WriteLine(chessCoordEx.Message);
                        moveMade = false;
                    }
                }
            }
        }
    }
}