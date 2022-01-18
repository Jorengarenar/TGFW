using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;

namespace ChessAsp.Pieces
{
    public class King: Piece, IChessPiece

    {

        public string Color { get; set; }

        public King (string color)
        {
            Color = color;
            Name = color[0] + "king";
        }

        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color)
        {
            string prefix = "w";
            if (color == "black") prefix = "b";
            if (   ((src.x == dst.x && (src.y + 1 == dst.y || src.y - 1 == dst.y)) 
                || (src.y == dst.y && (src.x + 1 == dst.x || src.x - 1 == dst.x)) 
                || (src.x - 1 == dst.x && src.y + 1 == dst.y)
                || (src.x + 1 == dst.x && src.y + 1 == dst.y)
                || (src.x + 1 == dst.x && src.y - 1 == dst.y)
                || (src.x - 1 == dst.x && src.y - 1 == dst.y))
                && (game.Board.GetPieceByCoords(dst.x, dst.y) == null || !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith(prefix))
                )
            {
                return true;
            }

            return false;
        }

        static public bool AreCoordsOutOfBoard (int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return true;
            }


            return false;
        }

        static public bool IsPawnChecking (Coordinate Coordinates, ChessGame Game, string Color)
        {
            bool result = false;
            var checkPossibilities = new List<Coordinate>();

            string checkingPiece = "bknight";

            if (Color == "white")
            {
                checkPossibilities.Add(new Coordinate(Coordinates.x - 1, Coordinates.y + 1));
                checkPossibilities.Add(new Coordinate(Coordinates.x + 1, Coordinates.y + 1));
            }

            if (Color == "black")
            {
                checkingPiece = "wknight";
                checkPossibilities.Add(new Coordinate(Coordinates.x - 1, Coordinates.y + 1));
                checkPossibilities.Add(new Coordinate(Coordinates.x + 1, Coordinates.y + 1));
            }

            foreach (var checkPossibility in checkPossibilities)
            {
                if (AreCoordsOutOfBoard(checkPossibility.x, checkPossibility.y))
                {
                    continue;
                }

                var tile = Game.Board.GetTileByCoords(checkPossibility.x, checkPossibility.y);

                if (tile.Pieces.Count == 1 && tile.Pieces[0].Name == checkingPiece)
                {
                    result = true;
                }
            }

            return result;
        }

        static public bool IsKnightChecking (Coordinate Coordinates, ChessGame Game, string Color)
        {
            bool result = false;
            var checkPossibilities = new List<Coordinate>();

            string checkingPiece = "bknight";

            if (Color == "black") checkingPiece = "wknight";

            checkPossibilities.Add(new Coordinate(Coordinates.x - 2, Coordinates.y + 1));
            checkPossibilities.Add(new Coordinate(Coordinates.x - 1, Coordinates.y + 2));
            checkPossibilities.Add(new Coordinate(Coordinates.x + 1, Coordinates.y + 2));
            checkPossibilities.Add(new Coordinate(Coordinates.x + 2, Coordinates.y + 2));
            checkPossibilities.Add(new Coordinate(Coordinates.x - 2, Coordinates.y - 1));
            checkPossibilities.Add(new Coordinate(Coordinates.x - 1, Coordinates.y - 2));
            checkPossibilities.Add(new Coordinate(Coordinates.x + 1, Coordinates.y - 2));
            checkPossibilities.Add(new Coordinate(Coordinates.x + 2, Coordinates.y - 1));

            foreach (var checkPossibility in checkPossibilities)
            {
                if (AreCoordsOutOfBoard(checkPossibility.x, checkPossibility.y))
                {
                    continue;
                }

                var tile = Game.Board.GetTileByCoords(checkPossibility.x, checkPossibility.y);

                if (tile.Pieces.Count == 1 && tile.Pieces[0].Name == checkingPiece)
                {
                    result = true;
                }
            }

            return result;
        }

        static public bool IsRookQueenChecking(Coordinate Coordinates, ChessGame Game, string Color)
        {

            bool result = false;

            string[] checkingPieces = new string[] { "brook", "bqueen" };

            if (Color == "black") checkingPieces = new string[] { "wrook", "wqueen" };

            //up
            for (int i = Coordinates.y + 1; i < 8; i ++)
            {
                var tile = Game.Board.GetTileByCoords(Coordinates.x, i);

                if (tile.Pieces.Count == 1 && checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    result = true;
                    break;
                }

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    break;
                }
            }

            //down
            for (int i = Coordinates.y - 1; i >= 0; i--)
            {
                var tile = Game.Board.GetTileByCoords(Coordinates.x, i);

                if (tile.Pieces.Count == 1 && checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    result = true;
                    break;
                }

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    break;
                }
            }

            //left
            for (int i = Coordinates.x - 1; i >= 0; i--)
            {
                var tile = Game.Board.GetTileByCoords(i, Coordinates.y);

                if (tile.Pieces.Count == 1 && checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    result = true;
                    break;
                }

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    break;
                }
            }

            //right
            for (int i = Coordinates.x + 1; i < 8; i++)
            {
                var tile = Game.Board.GetTileByCoords(Coordinates.x, i);

                if (tile.Pieces.Count == 1 && checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    result = true;
                    break;
                }

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    break;
                }
            }

            return result;
        }

        static public bool IsBishopQueenChecking (Coordinate Coordinates, ChessGame Game, string Color)
        {
            bool result = false;

            string[] checkingPieces = new string[] { "bbishop", "bqueen" };

            if (Color == "black") checkingPieces = new string[] { "wbishop", "wqueen" };

            //right bottom
            for (int x = Coordinates.x + 1, y = Coordinates.y - 1; x < 8 && y >= 0; x ++, y --)
            {
                var tile = Game.Board.GetTileByCoords(x, y);

                if (tile.Pieces.Count == 1 && checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    result = true;
                    break;
                }

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    break;
                }
            }

            //right left
            for (int x = Coordinates.x - 1, y = Coordinates.y - 1; x < 8 && y >= 0; x--, y--)
            {
                var tile = Game.Board.GetTileByCoords(x, y);

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    result = true;
                    break;
                }

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    break;
                }
            }

            //right top
            for (int x = Coordinates.x + 1, y = Coordinates.y + 1; x < 8 && y >= 0; x++, y++)
            {
                var tile = Game.Board.GetTileByCoords(x, y);

                if (tile.Pieces.Count == 1 && checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    result = true;
                    break;
                }

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    break;
                }
            }

            //right bottom
            for (int x = Coordinates.x - 1, y = Coordinates.y + 1; x < 8 && y >= 0; x--, y++)
            {
                var tile = Game.Board.GetTileByCoords(x, y);

                if (tile.Pieces.Count == 1 && checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    result = true;
                    break;
                }

                if (tile.Pieces.Count == 1 && !checkingPieces.Contains(tile.Pieces[0].Name))
                {
                    break;
                }
            }

            return result;

        }

        static public bool IsInCheck (ChessGame game, string color)
        {
            var kingCoords = GetKingCoords(game, color);
            return IsPawnChecking(kingCoords, game, color) && IsKnightChecking(kingCoords, game, color) && IsRookQueenChecking(kingCoords, game, color) && IsBishopQueenChecking(kingCoords, game, color);
        }

        static Coordinate GetKingCoords (ChessGame game, string Color)
        {
            string prefix = "w";
            if (Color == "black") prefix = "b";

            foreach (var tile in game.Board.Tiles)
            {
                if (tile.Pieces.Count == 1 && tile.Pieces[0].Name == prefix + "king")
                {
                    return tile.coordinate;
                }
            }

            return null;
        }

    }
}

