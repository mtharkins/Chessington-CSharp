using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var result = new List<Square>();
            if (Player == Player.Black)
            {
                // Black pawns move down (increase the row number).
                Square squarePlusOne = Square.At(currentSquare.Row + 1, currentSquare.Col);
                if (board.GetPiece(squarePlusOne) == null)
                {
                    result.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                }

                if (currentSquare.Row == 1) // Initial move for black pawns.
                {
                    Square squarePlusTwo = Square.At(currentSquare.Row + 2, currentSquare.Col);
                    if (board.GetPiece(squarePlusTwo) == null && board.GetPiece(squarePlusOne) == null)
                    {
                        result.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
                    }
                }
            }
            else
            {
                // White pawns move up (decrease the row number).
                Square squarePlusOne = Square.At(currentSquare.Row - 1, currentSquare.Col);
                if (board.GetPiece(squarePlusOne) == null)
                {
                    result.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                }

                if (currentSquare.Row == 6) // Initial move for white pawns.
                {
                    Square squarePlusTwo = Square.At(currentSquare.Row - 2, currentSquare.Col);
                    if (board.GetPiece(squarePlusTwo) == null && board.GetPiece(squarePlusOne) == null)
                    {
                        result.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
                    }
                }
            }
            return result;
        }
    }
}
