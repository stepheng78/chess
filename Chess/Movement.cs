using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    class Movement
    {
        /* Movement class should:
         1. Take in a board reference to move a piece to 
         2. Take in a board reference of current position of a piece
         3. Know possible moves for all piece types
         4. Based on piece type determine if change of board reference is valid
        */


        /*
        public string Diagonal { get; set; } 
        public string Straight { get; set; }
        public string L_shaped { get; set; }

        public int Limit { get; set; }


        //legit move method

        //direction method

        public string NewLocation(string direction)
        {
            return Location
        }
        */

        public string MoveToTile { get; set; }
        public string CurrentTile { get; set; }
        public string Piece { get; set; }

        IList<string> movementDirections = new List<string> { "LShaped", "Diagonal", "Straight" };
        IList<string> movementLimit = new List<string> { "EndOfBoard", "OneSpace" };

        //IList<string> pieceTypes = new List<string> {"King","Queen","Bishop","Knight","Rook","Pawn"};
        IDictionary<int, string> pieceTypes = new Dictionary<int, string>() 
        { 
            {1,"King"}, 
            {2,"Queen"}, 
            {3,"Bishop"}, 
            {4,"Knight"}, 
            {5,"Rook"}, 
            {6,"Pawn"} 
        };

        IDictionary<int, string> pieceMoves = new Dictionary<int, string>()
        {
            {1,""  },
            {2,"" },
        };

        private bool IsValidMove()
        {
            /*
             * 1. Need to understand the desired tile destination of a piece
             * 2. Need to know the current tile location
             * 3. Verify that the combination of 1. and 2. is a valid movement for the current piece
             */
            return true;
        }

        public string GetNewLocation()
        {
            if (IsValidMove() == true)
            {
                return MoveToTile;
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
