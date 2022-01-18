using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;

namespace ChessAsp.Pieces
{
    public class Bishop: Piece, IChessPiece 
    {
        public string Color { get; set; }

        public Bishop (string color)
        {
            Color = color;
            Name = color[0] + "bishop";
        }

        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color)
        {
            string prefix = "w";
            if (color == "black") prefix = "b";
            bool result = false;

            //right bottom
            for (int x = src.x + 1, y = src.y - 1; x < 8 && y >= 0; x++, y--)
            {
                if (x == dst.x && y == dst.y && game.Board.GetPieceByCoords(x, y) != null && !game.Board.GetPieceByCoords(x, y).Name.StartsWith(prefix))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(x, y) != null)
                {
                    break;
                }

                if (x == dst.x && y == dst.y)
                {
                    result = true;
                    break;
                }
            }

            //right left
            for (int x = src.x - 1, y = src.y - 1; x < 8 && y >= 0; x--, y--)
            {
                if (x == dst.x && y == dst.y && game.Board.GetPieceByCoords(x, y) != null && !game.Board.GetPieceByCoords(x, y).Name.StartsWith(prefix))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(x, y) != null)
                {
                    break;
                }

                if (x == dst.x && y == dst.y)
                {
                    result = true;
                    break;
                }
            }

            //right top
            for (int x = src.x + 1, y = src.y + 1; x < 8 && y >= 0; x++, y++)
            {
                if (x == dst.x && y == dst.y && game.Board.GetPieceByCoords(x, y) != null && !game.Board.GetPieceByCoords(x, y).Name.StartsWith(prefix))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(x, y) != null)
                {
                    break;
                }

                if (x == dst.x && y == dst.y)
                {
                    result = true;
                    break;
                }
            }

            //right bottom
            for (int x = src.x - 1, y = src.y + 1; x < 8 && y >= 0; x--, y++)
            {
                if (x == dst.x && y == dst.y && game.Board.GetPieceByCoords(x, y) != null && !game.Board.GetPieceByCoords(x, y).Name.StartsWith(prefix))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(x, y) != null)
                {
                    break;
                }

                if (x == dst.x && y == dst.y)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
