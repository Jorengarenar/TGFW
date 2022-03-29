using Framework;
using System;
using System.Collections.Generic;

namespace Lands.UserInterfaces {
    public class WebUserInterface : IUserInterface {
        public void DrawAvailableTiles(List<LandsTile> tiles) {}

        public void DrawBoard(Board board) {}

        public void DrawResults(List<int> results, List<Player> players) {}

        public void DrawRound(Board board, List<LandsTile> tiles) {}

        public int GetBoardHeight() {
            return 0;
        }

        public int GetBoardWidth() {
            return 0;
        }

        public string GetCommand(LandsPlayer player) {
            return "";
        }

        public List<LandsPlayerData> GetPlayersData() {
            return null;
        }
    }
}
