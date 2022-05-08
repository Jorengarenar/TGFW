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
    public class Bishop : Piece, IChessPiece
    {
        public string Color {
            get; set;
        }

        public Bishop(string color)
        {
            Color = color;
            Name = color[0] + "bishop";
        }

        public bool IsMoveCorrect(ChessGame game, Coordinate src, Coordinate dst, string color)
        {
            string prefix = "w";
            if (color == "black") { prefix = "b"; }
            bool result = false;

            for (int x = src.x + 1, y = src.y + 1; x < 8 && y < 8; x++, y++)
            {
                if (x == dst.x && y == dst.y && (game.Board.GetPieceByCoords(dst.x, dst.y) == null || !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith(prefix)))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(x, y) != null)
                {
                    break;
                }
            }

            for (int x = src.x + 1, y = src.y - 1; x < 8 && y >= 0; x++, y--)
            {
                if (x == dst.x && y == dst.y && (game.Board.GetPieceByCoords(dst.x, dst.y) == null || !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith(prefix)))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(x, y) != null)
                {
                    break;
                }
            }

            for (int x = src.x - 1, y = src.y + 1; x >= 0 && y < 8; x--, y++)
            {
                if (x == dst.x && y == dst.y && (game.Board.GetPieceByCoords(dst.x, dst.y) == null || !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith(prefix)))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(x, y) != null)
                {
                    break;
                }
            }

            for (int x = src.x - 1, y = src.y - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (x == dst.x && y == dst.y && (game.Board.GetPieceByCoords(dst.x, dst.y) == null || !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith(prefix)))
                {
                    result = true;
                    break;
                }

                if (game.Board.GetPieceByCoords(x, y) != null)
                {
                    break;
                }
            }

            return result;
        }
    }
} // namespace ChessAsp.Pieces
