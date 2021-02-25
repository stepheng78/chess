using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;


namespace Chess
{
    class Board
    {

        private int Height = 8;
        private int Width = 8;
        public ITile[,] Tiles = new ITile[8,8]; 

        public ITile[,] GenerateTiles()
        {
            for (int m = 0; m < Height; m++)
            {
                for (int n = 0; n < Width; n++)
                {
                    Tiles[m,n] = new Tile();
                }
            }
            return Tiles;
        }

        public void GenerateChessPieces()
        {
            //Setup White Pieces
            Tiles[0, 0].SetPiece(Piece.Create(PieceColour.White, PieceType.Rook));
            Tiles[0, 1].SetPiece(Piece.Create(PieceColour.White, PieceType.Knight));
            Tiles[0, 2].SetPiece(Piece.Create(PieceColour.White, PieceType.Bishop));
            Tiles[0, 3].SetPiece(Piece.Create(PieceColour.White, PieceType.Queen));
            Tiles[0, 4].SetPiece(Piece.Create(PieceColour.White, PieceType.King));
            Tiles[0, 5].SetPiece(Piece.Create(PieceColour.White, PieceType.Bishop));
            Tiles[0, 6].SetPiece(Piece.Create(PieceColour.White, PieceType.Knight));
            Tiles[0, 7].SetPiece(Piece.Create(PieceColour.White, PieceType.Rook));

            Tiles[1, 0].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 1].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 2].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn)); ;
            Tiles[1, 3].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 4].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 5].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 6].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));
            Tiles[1, 7].SetPiece(Piece.Create(PieceColour.White, PieceType.Pawn));


            //Setup Black Pieces
            Tiles[7, 0].SetPiece(Piece.Create(PieceColour.Black, PieceType.Rook));
            Tiles[7, 1].SetPiece(Piece.Create(PieceColour.Black, PieceType.Knight));
            Tiles[7, 2].SetPiece(Piece.Create(PieceColour.Black, PieceType.Bishop));
            Tiles[7, 3].SetPiece(Piece.Create(PieceColour.Black, PieceType.Queen));
            Tiles[7, 4].SetPiece(Piece.Create(PieceColour.Black, PieceType.King));
            Tiles[7, 5].SetPiece(Piece.Create(PieceColour.Black, PieceType.Bishop));
            Tiles[7, 6].SetPiece(Piece.Create(PieceColour.Black, PieceType.Knight));
            Tiles[7, 7].SetPiece(Piece.Create(PieceColour.Black, PieceType.Rook));
                                                          
            Tiles[6, 0].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 1].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 2].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn)); 
            Tiles[6, 3].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 4].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 5].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 6].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
            Tiles[6, 7].SetPiece(Piece.Create(PieceColour.Black, PieceType.Pawn));
        }

        public void MovePiece(string playerPiece, string newLocation)
        {
            for (int m = 0; m < Height; m++)
            {
                for (int n = 0; n < Width; n++)
                {
                    if ((Tiles[m, n]).ToString() == playerPiece)
                    {
                        
                        Console.WriteLine($"Found the piece [{playerPiece}] at position [{m}, {n}]");
                        Console.WriteLine($"{Tiles[m, n]}");
                        
                        // Grab the playerPiece from its current tile then reset tile to default
                        var currentLocationPiece = Tiles[m, n].Piece;
                        Tiles[m, n].SetPiece(null);

                        // Split the newLocation Parameter so it can be used to find the correct index location 
                        // in the array to move the playerPiece too.
                        string[] newLocationArray = newLocation.Split(',');
                        var newX = int.Parse(newLocationArray[1]);
                        var newY = int.Parse(newLocationArray[0]);

                        // Move the playerPiece by setting the piece on the new location tile to be the currentLocationPiece
                        Console.WriteLine($"Players piece [{playerPiece}] moved to position [{newY}, {newX}]");
                        Tiles[newY, newX].SetPiece(currentLocationPiece);

                    }
                }
            }
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"{Tiles[i, j]} ");
                }
                Console.WriteLine("");
            }
        }
    }
}
