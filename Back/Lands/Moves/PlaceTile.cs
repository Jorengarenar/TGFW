/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using Framework;

namespace Lands {
    //tile:availableTileIndex;tileX;tileY
    public class PlaceTile : Move {
        public PlaceTile(Game game) : base(game) {}

        public override void Make(string command) {
            string[] content = command.Split(';');
            LandsGame lands = (LandsGame) game;
            int tileIndex = int.Parse(content[0]);
            int x = int.Parse(content[1]);
            int y = int.Parse(content[2]);
            if (x >= 0 && x < game.Board.GetWidth() && y >= 0 && y < game.Board.GetHeight()) {
                if (lands.Board.GetTile(x, y) == lands.blank) {
                    lands.Board.SetTile(lands.AvailableTiles[tileIndex], x, y);
                    lands.AvailableTiles.RemoveAt(tileIndex);
                }
            }
        }

        public override bool IsPossible(string command) {
            throw new System.NotImplementedException();
        }
    }
}
