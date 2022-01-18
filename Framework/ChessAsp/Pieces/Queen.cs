using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;

namespace ChessAsp.Pieces
{
    public class Queen: Piece, IChessPiece
    {

        public string Color { get; set; }

        public Queen(string color)
        {
            Color = color;
            Name = color[0] + "king";
        }

        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color)
        {
            var hBishop = new Bishop(Color);
            var hRook = new Rook(Color);

            return hBishop.IsMoveCorrect(game, src, dst, Color) || hRook.IsMoveCorrect(game, src, dst, Color);
        }
    }
}
