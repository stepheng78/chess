﻿using System.Collections.Generic;

namespace Chess
{
    public interface IPiece
    {
        PieceColour Colour { get; }

        bool CanMove(PieceMovementContext context);

        bool SpecialisedMoveBehaviour(PieceMovementContext context);

        void HasBeenMoved();
    }
}
