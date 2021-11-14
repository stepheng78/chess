using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MoveInput;

namespace Chess.Coordinate
{
    public struct ChessCoordinate
    {
        public int Rank { get; }
        public int File { get; }

        public ChessCoordinate(string rank, string file)
        {
            if (ChessMoveInput.RankConverter.TryGetValue(rank, out var rankValue))
            {
                Rank = Math.Clamp(rankValue, 0, 7);
            }
            else
            {
                throw new ArgumentException("Rank could not be parsed.");
            }

            if (ChessMoveInput.FileConverter.TryGetValue(file, out var fileValue))
            {
                File = Math.Clamp(fileValue, 0, 7);
            }
            else
            {
                throw new ArgumentException("File could not be parsed.");
            }


        }
    }
}
