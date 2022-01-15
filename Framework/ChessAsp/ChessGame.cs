using Framework;

namespace ChessAsp {
    public class ChessGame : Game {

        public ChessGame() {
            this.Board = new Board(8, 8);
            for (int i = 0; i < 8; ++i) {
                for (int j = 0; j < 8; ++j) { 
                    Tile temp = this.Board.GetTile(i, j);
                    if ((i * 8 + j) % 2 == 0) {
                        temp.TexturePath = "img/chess/lightTile.png";
                    } else {
                        temp.TexturePath = "img/chess/darkTile.png";
                    }
                }
            }
        }
    }
}
