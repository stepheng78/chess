﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Board
    {

        private int Height = 8;
        private int Width = 8;
        public ITile[,] Tiles;

        public ITile[,] GenerateTiles()
        {
            for (int m = 1; m < Height; m++)
            {
                for (int n = 1; n < Width; n++)
                {
                    Console.WriteLine($"Variables: m ={m} n ={n}");
                    Tiles[m,n] = new Tile();
                }
            }

            return Tiles;
        }

        public void GenerateChessPieces()
        {

        }

        public void DisplayBoard()
        {
            for (int i = 1; i < Height; i++)
            {
                for (int j = 1; j < Width; j++)
                {
                    Console.Write(Tiles[i, j]);
                    Console.WriteLine("");
                }
            }
        }
    }
}
