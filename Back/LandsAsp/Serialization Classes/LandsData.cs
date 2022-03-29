using Framework;
using System.Collections.Generic;
using System.Linq;

namespace LandsAsp {
    public class LandsData {

        public LandsBoard Board { get; set; }
        public List<LandsTile> AvailableTiles { get; set; }
        public int WaitingFor { get; set; }

        public LandsData(Board board, List<Lands.LandsTile> availableTiles, int waitingFor) {
            Board = new LandsBoard(board);
            AvailableTiles = availableTiles.Select(x => new LandsTile(x)).ToList();
            WaitingFor = waitingFor;
        }
    }
}
