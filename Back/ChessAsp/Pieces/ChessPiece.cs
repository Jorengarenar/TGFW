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
    public interface IChessPiece
    {
        public string Color {
            get; set;
        }

        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color);
    }
}
