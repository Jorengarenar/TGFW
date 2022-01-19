using Framework;
using ChessAsp.Pieces;

namespace ChessAsp {
    public class ChessGame : Game {

        public ChessGame() {
            this.Board = new Board(8, 8);
            InitializeBoard();
            SetDefaultPosition();
        }

        public void InitializeBoard ()
        {
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    Tile temp = this.Board.GetTile(i, j);
                    if ((i + j) % 2 == 0)
                    {
                        temp.TexturePath = "img/chess/darkTile.png";
                    }
                    else
                    {
                        temp.TexturePath = "img/chess/lightTile.png";
                    }

                    temp.SetCoordinates(i, j);
                }
            }
        }

        public void SetDefaultPosition ()
        {
            SetOneColorPieces(false);
            SetOneColorPieces(true);
        }

        private void SetOneColorPieces (bool isBlack)
        {
            int piecesIndex = 0;
            int pawnsIndex = 1;
            string color = "white";

            if (isBlack)
            {
                piecesIndex = 7;
                pawnsIndex = 6;
                color = "black";
            }

            this.Board.GetTile(0, piecesIndex).Pieces.Add(new Rook(color));
            this.Board.GetTile(1, piecesIndex).Pieces.Add(new Knight(color));
            this.Board.GetTile(2, piecesIndex).Pieces.Add(new Bishop(color));
            this.Board.GetTile(3, piecesIndex).Pieces.Add(new Queen(color));
            this.Board.GetTile(4, piecesIndex).Pieces.Add(new King(color));
            this.Board.GetTile(5, piecesIndex).Pieces.Add(new Bishop(color));
            this.Board.GetTile(6, piecesIndex).Pieces.Add(new Knight(color));
            this.Board.GetTile(7, piecesIndex).Pieces.Add(new Rook(color));

            for (int i = 0; i < 8; i++)
            {
                this.Board.GetTile(i, pawnsIndex).Pieces.Add(new Pawn(color));
            }
        }

    }
}
