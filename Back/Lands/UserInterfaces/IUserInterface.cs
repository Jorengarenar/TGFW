/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using Framework;
using System.Collections.Generic;

namespace Lands {
    public interface IUserInterface {
        public List<LandsPlayerData> GetPlayersData();
        public int GetBoardWidth();
        public int GetBoardHeight();
        public string GetCommand(LandsPlayer player);
        public void DrawRound(Board board, List<LandsTile> tiles);
        public void DrawAvailableTiles(List<LandsTile> tiles);
        public void DrawBoard(Board board);
        public void DrawResults(List<int> results, List<Player> players);
    }
}
