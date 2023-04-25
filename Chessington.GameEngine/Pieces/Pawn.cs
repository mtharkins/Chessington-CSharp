using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.XPath;

namespace Chessington.GameEngine.Pieces;

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
            if(currentSquare.Row == 1) 
            {
                 result.Add(Square.At(currentSquare.Row +2, currentSquare.Col));
            }
           result.Add(Square.At(currentSquare.Row +1, currentSquare.Col));
        }

        else

        {
            if(currentSquare.Row == 7) 
            {
                 result.Add(Square.At(currentSquare.Row -2, currentSquare.Col));
            }
           result.Add(Square.At(currentSquare.Row -1, currentSquare.Col));
        }

        return result;
    }
};