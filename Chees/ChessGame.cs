using TurnGamesFramework;

namespace Chess {
    public class ChessGame : Game {

        public ChessGame() {
            board = new Board(8, 8);
            for (int i = 0; i < 8; ++i) {
                for (int j = 0; j < 8; ++j) { 
                    Tile temp = board.GetTile(i, j);
                    if ((i * 8 + j) % 2 == 0) {
                        temp.texturePath = "img/chess/lightTile.png";
                    } else {
                        temp.texturePath = "img/chess/darkTile.png";
                    }
                }
            }
        }
    }
}
