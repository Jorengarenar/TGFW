/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2022 dolidius
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;

namespace ChessAsp.Pieces
{
    public class Castle
    {
        public bool isPossible { get; set; }
        public Coordinate kingCoordinates { get; set; }
        public Coordinate rookCoordinates { get; set; }

        public Castle(bool IsPossible)
        {
            isPossible = IsPossible;
        }

        public Castle(bool IsPossible, Coordinate KingCoordinates, Coordinate RookCoordinates)
        {
            isPossible = IsPossible;
            kingCoordinates = KingCoordinates;
            rookCoordinates = RookCoordinates;
        }
    }
}
