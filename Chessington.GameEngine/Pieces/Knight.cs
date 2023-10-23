using System;
using System.Collections.Generic;
using Chessington.GameEngine;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var result = new List<Square>();

            // Define the possible Knight move offsets.
            int[] rowOffsets = { -2, -1, 1, 2 };
            int[] colOffsets = { -2, -1, 1, 2 };

            foreach (var rowOffset in rowOffsets)
            {
                foreach (var colOffset in colOffsets)
                {
                    if (Math.Abs(rowOffset) != Math.Abs(colOffset))
                    {
                        int newRow = currentSquare.Row + rowOffset;
                        int newCol = currentSquare.Col + colOffset;

                        // Check if the new position is within the board bounds.
                        if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                        {
                            result.Add(Square.At(newRow, newCol));
                        }
                    }
                }
            }

            return result;
        }
    }
}
