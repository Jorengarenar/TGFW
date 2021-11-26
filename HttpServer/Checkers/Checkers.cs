using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGamesFramework.Checkers {
    internal class Checkers : Game {

        internal Checkers() {
            board = new Board(8, 8);
        }
    }
}
