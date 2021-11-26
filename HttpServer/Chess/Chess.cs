using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGamesFramework.Chess {
    internal class Chess : Game {

        internal Chess() {
            board = new Board(8, 8);
        }
    }
}
