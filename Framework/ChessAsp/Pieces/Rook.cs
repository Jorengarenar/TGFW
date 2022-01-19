/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;

namespace ChessAsp.Pieces
{
    public class Rook: Piece, IChessPiece
    {
        public string Color { get; set; }

        public Rook(string color)
        {
            Color = color;
            Name = color[0] + "rook";
        }

        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color)
        {
            string prefix = "w";
            if (color == "black") prefix = "b";
            bool result = false;
            //up
            for (int i = src.y + 1; i < 8; i++)
            {
                if (src.x == dst.x && i == dst.y && game.Board.GetPieceByCoords(dst.x, i) != null && !game.Board.GetPieceByCoords(dst.x, i).Name.StartsWith(prefix))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(dst.x, i) != null)
                {
                    break;
                }

                if (src.x == dst.x && i == dst.y)
                {
                    result = true;
                    break;
                }
            }

            //down
            for (int i = src.y - 1; i >= 0; i--)
            {
                if (src.x == dst.x && i == dst.y && game.Board.GetPieceByCoords(dst.x, i) != null && !game.Board.GetPieceByCoords(dst.x, i).Name.StartsWith(prefix))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(dst.x, i) != null)
                {
                    break;
                }

                if (src.x == dst.x && i == dst.y)
                {
                    result = true;
                    break;
                }
            }

            //left
            for (int i = src.x - 1; i >= 0; i--)
            {
                if (src.y == dst.y && i == dst.x && game.Board.GetPieceByCoords(i, dst.y) != null && !game.Board.GetPieceByCoords(i, dst.y).Name.StartsWith(prefix))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(i, dst.y) != null)
                {
                    break;
                }

                if (src.y == dst.y && i == dst.x)
                {
                    result = true;
                    break;
                }
            }

            //right
            for (int i = src.x + 1; i < 8; i++)
            {
                if (src.y == dst.y && i == dst.x && game.Board.GetPieceByCoords(i, dst.y) != null && !game.Board.GetPieceByCoords(i, dst.y).Name.StartsWith(prefix))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(i, dst.y) != null)
                {
                    break;
                }

                if (src.y == dst.y && i == dst.x)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
