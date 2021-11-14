using System.Drawing;

namespace Chess.MoveInput
{
    public interface IMoveInput
    {
        public bool TryParse(string playerInput, out Point moveInput);
    }
}