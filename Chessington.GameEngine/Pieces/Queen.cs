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

        var directions = new List<Square>
            {
                Square.At(1, 0),
                Square.At(-1, 0),
                Square.At(0, 1),
                Square.At(0, -1),
                Square.At(1, 1),
                Square.At(-1, 1),
                Square.At(1, -1),
                Square.At(-1, -1)
            };

        foreach (var direction in directions)
        {
            for (int i = 1; i <= 7; i++)
            {
                var square = Square.At(currentSquare.Row + i * direction.Row, currentSquare.Col + i * direction.Col);
                if (square.Row > 7 || square.Row < 0 || square.Col > 7 || square.Col < 0)
                {
                    break;
                }

                var pieceAtSquare = board.GetPiece(square);
                if (pieceAtSquare != null)
                {
                    if (pieceAtSquare.Player != Player)
                    {
                        result.Add(square);
                    }
                    break;
                }

                result.Add(square);
            }
        }

        return result;
    }
}
