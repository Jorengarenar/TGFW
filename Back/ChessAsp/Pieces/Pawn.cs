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
    public class Pawn : Piece, IChessPiece
    {
        public string Color {
            get; set;
        }

        public Pawn(string color)
        {
            Color = color;
            Name = color[0] + "pawn";
        }

        public bool IsMoveCorrect (ChessGame game, Coordinate src, Coordinate dst, string color)
        {
            if (color == "white")
            {

                // move forward 2 positions from starting
                if (src.y == 1 && src.x == dst.x &&
                   (dst.y == src.y + 2 && game.Board.GetPieceByCoords(dst.x, dst.y) == null && game.Board.GetPieceByCoords(dst.x, dst.y - 1) == null))
                {
                    return true;
                }

                //single move forward
                if (src.x == dst.x 
                    && src.y + 1 == dst.y 
                    && game.Board.GetPieceByCoords(dst.x, dst.y) == null)
                {
                    return true;
                }

                if (src.x - 1 == dst.x && src.y + 1 == dst.y && game.Board.GetPieceByCoords(dst.x, dst.y) != null && !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith("w"))
                {
                    //capture left
                    return true;
                }

                if (src.x + 1 == dst.x && src.y + 1 == dst.y && game.Board.GetPieceByCoords(dst.x, dst.y) != null && !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith("w"))
                {
                    //capture right
                    return true;
                }
            }

            if (color == "black")
            {
                // move forward 2 positions from starting
                if (src.y == 6 && src.x == dst.x &&
                    (dst.y == src.y - 2 && game.Board.GetPieceByCoords(dst.x, dst.y) == null && game.Board.GetPieceByCoords(dst.x, dst.y + 1) == null))
                {
                    return true;
                }

                //single move forward
                if (src.x == dst.x 
                    && src.y - 1 == dst.y 
                    && game.Board.GetPieceByCoords(dst.x, dst.y) == null)
                {
                    return true;
                }

                if (src.x - 1 == dst.x && src.y - 1 == dst.y && game.Board.GetPieceByCoords(dst.x, dst.y) != null && !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith("b"))
                {
                    //capture left
                    return true;
                }

                if (src.x + 1 == dst.x && src.y - 1 == dst.y && game.Board.GetPieceByCoords(dst.x, dst.y) != null && !game.Board.GetPieceByCoords(dst.x, dst.y).Name.StartsWith("b"))
                {
                    //capture right
                    return true;
                }
            }

            return false;
        }
    }
}
