/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System.Collections.Generic;

namespace Framework
{
    public class Tile
    {
        public List<Piece> Pieces {
            get; set;
        }
        public Coordinate Coordinate {
            get; set;
        } = new Coordinate(0, 0);

        public Tile()
        {
            Pieces = new List<Piece>();
        }

        public void SetCoordinates (int x, int y)
        {
            Coordinate.x = x;
            Coordinate.y = y;
        }

        public void SetPieces (List<Piece> pieces)
        {
            Pieces = pieces;
        }
    }
}
