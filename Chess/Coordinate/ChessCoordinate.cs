using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Chess.MoveInput;

namespace Chess.Coordinate
{
    public class ChessCoordinate
    {
        public static readonly Regex ChessRegex = new Regex("^([a-hA-H])([1-8])$");
        public static readonly Dictionary<string, int> RankConverter = MakeRankConverter();
        public static readonly Dictionary<string, int> FileConverter = MakeFileConverter();

        private static Dictionary<string, int> MakeFileConverter()
        {
            var toReturn = new Dictionary<string, int>();

            for (var i = 0; i < 8; i++)
            {
                toReturn[(i + 1).ToString()] = i;
            }

            return toReturn;
        }

        private static Dictionary<string, int> MakeRankConverter()
        {
            var toReturn = new Dictionary<string, int>();

            var arr = new[]
            {
                "A", "B", "C", "D", "E", "F", "G", "H"
            };

            var counter = 0;
            foreach (var rank in arr)
            {
                toReturn[rank] = counter;
                toReturn[rank.ToLower()] = counter;
                counter++;
            }

            return toReturn;
        }

        public int Rank { get; private set; }
        public int File { get; private set; }

        /// <summary>
        /// Constructs a chess coordinate from a valid rank and file string.
        /// </summary>
        /// <param name="input">A string in the format of "A1" - "H8"</param>
        public ChessCoordinate(string input)
        {
            var match = ChessRegex.Match(input);
            if (!match.Success)
            {
                //TODO: make this just a message back to the user rather than it fail the app. Good idea or not??
                throw new ArgumentException("Entered string is not a valid chess coordinate.");
            }

            var rank = match.Groups[1].Value;
            var file = match.Groups[2].Value;

            ValidateRankAndFile(rank, file);
        }

        public ChessCoordinate(string rank, string file)
        {
            ValidateRankAndFile(rank, file);
        }

        public ChessCoordinate(int rank, int file)
        {
             Rank = Math.Clamp(rank, 0, 7); 
             File = Math.Clamp(file, 0, 7); 
        }

        public static ChessCoordinate operator +(ChessCoordinate a, Point b)
        {
            var rank = a.Rank + b.X;
            var file = a.File + b.Y;
            return new ChessCoordinate(rank, file) ;
        }

        /// <summary>
        /// Validates that the supplied rank and file strings fit in the board parameters. On 
        /// successfull validation returns the converted value for them.
        /// </summary>
        /// <param name="rank">A string in the format of "A" - "H"</param>
        /// <param name="file">A string in the format of "1" - "8"</param>
        private void ValidateRankAndFile(string rank, string file)
        {
            if (RankConverter.TryGetValue(rank, out var rankValue))
            {
                Rank = Math.Clamp(rankValue, 0, 7);
            }
            else
            {
                throw new ArgumentException("Rank value could not be parsed.");
            }

            if (FileConverter.TryGetValue(file, out var fileValue))
            {
                File = Math.Clamp(fileValue, 0, 7);
            }
            else
            {
                throw new ArgumentException("File value could not be parsed.");
            }
        }
    }
}

