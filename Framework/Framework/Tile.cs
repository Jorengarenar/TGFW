using System.Collections.Generic;

namespace Framework {
    public class Tile {

        public string TexturePath { get; set; }

        public List<Piece> Pieces { get; set; }
        public Coordinate coordinate { get; set; } = new Coordinate(0, 0);

        public Tile() {
            Pieces = new List<Piece>();
        }

        public void SetCoordinates (int x, int y)
        {
            coordinate.x = x;
            coordinate.y = y;
        }

        public void SetPieces (List<Piece> pieces)
        {
            Pieces = pieces;
        }
    }
}
