/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;

namespace ChessAsp.Pieces
{
    public class Knight : Piece, IChessPiece
    {
        public string Color {
            get; set;
        }

        public Knight(string color)
        {
            Color = color;
            Name = color[0] + "knight";
        }

        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color)
        {
            string prefix = "w";
            if (color == "black") { prefix = "b"; }
            if (((src.x - 2 == dst.x && src.y + 1 == dst.y)
                 || (src.x - 1 == dst.x && src.y + 2 == dst.y)
                 || (src.x + 1 == dst.x && src.y + 2 == dst.y)
                 || (src.x + 2 == dst.x && src.y + 1 == dst.y)
                 || (src.x + 2 == dst.x && src.y - 1 == dst.y)
                 || (src.x + 1 == dst.x && src.y - 2 == dst.y)
                 || (src.x - 1 == dst.x && src.y - 2 == dst.y)
                 || (src.x - 2 == dst.x && src.y - 1 == dst.y))
                && (game.Board.GetPieceByCoords(dst.x, dst.y) == null || !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith(prefix))
            )
            {
                return true;
            }

            return false;
        }
    }
}
