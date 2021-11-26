using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGamesFramework {
    internal class Board {

        List<Tile> tiles = new List<Tile>();
        int width;
        int height;

        internal Board(int width, int height) { 
            this.width = width;
            this.height = height;
            tiles = new List<Tile>(width * height);
        }

        internal Tile GetTile(int x, int y) {
            return tiles[width * x + y];
        }
    }
}
