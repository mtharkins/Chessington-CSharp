using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces;

public class Queen : Piece
{
    public Queen(Player player)
        : base(player)
    {
    }

    public override IEnumerable<Square> GetAvailableMoves(Board board)
    {
        var currentSquare = board.FindPiece(this);
        var result = new List<Square>();

        for (int i = currentSquare.Row + 1, k = currentSquare.Col + 1; i < 8 && k < 8; i++, k++)
        {
            result.Add(Square.At(i, k));
        }

        for (int i = currentSquare.Row + 1, k = currentSquare.Col - 1; i < 8 && k >= 0; i++, k--)
        {
            result.Add(Square.At(i, k));
        }

        for (int i = currentSquare.Row - 1, k = currentSquare.Col + 1; i >= 0 && k < 8; i--, k++)
        {
            result.Add(Square.At(i, k));
        }

        for (int i = currentSquare.Row - 1, k = currentSquare.Col - 1; i >= 0 && k >= 0; i--, k--)
        {
            result.Add(Square.At(i, k));
        }

        for (int i = 0; i < 8; i++)
        {
            if (currentSquare.Col != i)
            {
                result.Add(Square.At(currentSquare.Row, i));
            }
            if (currentSquare.Row != i)
            {
                result.Add(Square.At(i, currentSquare.Col));
            }
        }

        return result;
    }
}