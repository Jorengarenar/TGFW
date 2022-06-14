/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2022 DawidMoza
 */

using Framework;
using Lands;
using System.Collections.Generic;
using System.Linq;

namespace LandsAsp {
    public class LandsTile {

        public List<LandsPiece> Pieces { get; set; }

        public LandsTile(Tile tile) {
            Pieces = tile.Pieces.Select(x => (LandsPiece) x).ToList();
        }
    }
}
