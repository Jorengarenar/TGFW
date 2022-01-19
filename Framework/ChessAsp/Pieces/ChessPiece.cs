using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;

namespace ChessAsp.Pieces
{
    public interface IChessPiece
    {
        public string Color { get; set; }
        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color);
    }
}
