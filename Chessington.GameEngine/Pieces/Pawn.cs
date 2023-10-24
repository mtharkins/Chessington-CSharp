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
                if (currentSquare.Row < 7)
                {
                    Square squarePlusOne = Square.At(currentSquare.Row + 1, currentSquare.Col);
                    if (board.GetPiece(squarePlusOne) == null)
                    {
                        result.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                    }

                    if (currentSquare.Row == 1)
                    {
                        Square squarePlusTwo = Square.At(currentSquare.Row + 2, currentSquare.Col);
                        if (board.GetPiece(squarePlusTwo) == null && board.GetPiece(squarePlusOne) == null)
                        {
                            result.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
                        }
                    }
                }
            }
            else
            {
                if (currentSquare.Row > 0)
                {
                    Square squarePlusOne = Square.At(currentSquare.Row - 1, currentSquare.Col);
                    if (board.GetPiece(squarePlusOne) == null)
                    {
                        result.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                    }

                    if (currentSquare.Row == 6)
                    {
                        Square squarePlusTwo = Square.At(currentSquare.Row - 2, currentSquare.Col);
                        if (board.GetPiece(squarePlusTwo) == null && board.GetPiece(squarePlusOne) == null)
                        {
                            result.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
                        }
                    }
                }
            }
            return result;
        }
    }
}
