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
    public class Queen : Piece, IChessPiece
    {
        public string Color {
            get; set;
        }

        public Queen(string color)
        {
            Color = color;
            Name = color[0] + "queen";
        }

        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color)
        {
            var hBishop = new Bishop(color);
            var hRook = new Rook(color);

            return hBishop.IsMoveCorrect(game, src, dst, color) || hRook.IsMoveCorrect(game, src, dst, color);
        }
    }
}
