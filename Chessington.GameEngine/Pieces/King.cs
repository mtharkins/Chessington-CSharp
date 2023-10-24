using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces;

public class King : Piece
{
    public King(Player player)
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
                var square = Square.At(currentSquare.Row + direction.Row, currentSquare.Col + direction.Col);
                if (square.Row > 7 || square.Row < 0 || square.Col > 7 || square.Col < 0)
                {
                    continue;
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
        return result;
    }
}
