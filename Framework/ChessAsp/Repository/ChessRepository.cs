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
using ChessAsp.Pieces;

namespace ChessAsp.Repository
{
    public class ChessRepository
    {
        private List<ChessGame> games = new List<ChessGame>();
        private int count = 0;

        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        public Game Get(int id)
        {
            try
            {
                var game = games[id];
                return game;
            }
            catch
            {
                return null;
            }
        }

        public Game Add(ChessGame item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            games.Add(item);
            count++;
            return item;
        }

        public int Count()
        {
            return count;
        }

        public bool ResetPosition (int id)
        {
            try
            {
                var game = games[id];
                game.SetDefaultPosition();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MoveResult MakeMove (int id, int srcx, int srcy, int dstx, int dsty)
        {
            var game = Get(id) as ChessGame;
            IChessPiece piece = game.Board.GetPieceByCoords(srcx, srcy) as IChessPiece;
            Coordinate src = new Coordinate(srcx, srcy);
            Coordinate dst = new Coordinate(dstx, dsty);
            if (piece.IsMoveCorrect(game, src, dst, piece.Color) && !King.IsInCheck(game, piece.Color))
            {
                IChessPiece dstPiece = game.Board.GetPieceByCoords(dstx, dsty) as IChessPiece;
                bool didCapture = false;
                if (dstPiece != null)
                {
                    didCapture = true;
                }

                UpdateBoard(game, src, dst);
                return new MoveResult(true, didCapture);
            }

            return new MoveResult (false, false);
        }

        public void UpdateBoard (ChessGame game, Coordinate src, Coordinate dst)
        {
            game.Board.UpdatePiecesOnPosition(src, dst);
        }
    }
}
