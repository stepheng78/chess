using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Chess.MoveInput
{
    public class ChessMoveInput : IMoveInput
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

        public bool TryParse(string playerInput, out Point moveInput)
        {
            var match = ChessRegex.Match(playerInput);
            if (match.Success)
            {
                moveInput = new Point(RankConverter[match.Groups[1].Value], FileConverter[match.Groups[2].Value]);
                return true;
            }

            moveInput =default;
            return false;
        }
    }
}