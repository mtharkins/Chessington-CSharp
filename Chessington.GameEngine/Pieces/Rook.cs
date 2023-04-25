using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces;

public class Rook : Piece
{
    public Rook(Player player)
        : base(player)
    {
    }

    public override IEnumerable<Square> GetAvailableMoves(Board board)
    {
        var currentSquare = board.FindPiece(this);
        var result = new List<Square>();

            {   for(int i = 0; i < 8; i++)
                {
                    if(currentSquare.Col != i)
                    {
                        result.Add(Square.At(currentSquare.Row, i));
                    } 
                    if(currentSquare.Row != i)
                    {
                        result.Add(Square.At(i, currentSquare.Col));
                    } 
                }
            }
        return result;
    }
}