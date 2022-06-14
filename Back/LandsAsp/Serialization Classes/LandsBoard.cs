/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2022 DawidMoza
 */

using Framework;
using System.Collections.Generic;
using System.Linq;

namespace LandsAsp {
    public class LandsBoard {

        public List<LandsTile> Tiles {
            get; set;
        }
        public int Width {
            get; set;
        }
        public int Height {
            get; set;
        }

        public LandsBoard(Board board) {
            Tiles = board.Tiles.Select(x => new LandsTile(x)).ToList();
            Width = board.Width;
            Height = board.Height;
        }
    }
}
