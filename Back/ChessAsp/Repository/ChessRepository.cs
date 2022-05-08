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

        public string VisualisePosition (ChessGame game)
        {
            string position = "";

            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    Tile temp = game.Board.GetTile(i, j);
                    if (temp.Pieces.Count > 0)
                    {
                        position += temp.Pieces[0].Name.Substring(0, 2);
                    } else
                    {
                        position += "  ";
                    }
                }

                position += "\n";
            }

            return position;
        }

        public MoveResult MakeMove (int id, int srcx, int srcy, int dstx, int dsty)
        {
            var game = Get(id) as ChessGame;
            IChessPiece piece = game.Board.GetPieceByCoords(srcx, srcy) as IChessPiece;
            Coordinate src = new Coordinate(srcx, srcy);
            Coordinate dst = new Coordinate(dstx, dsty);
            if (piece != null && piece.IsMoveCorrect(game, src, dst, piece.Color) && !King.IsInCheck(game, piece.Color) && piece.Color == game.turn)
            {
                IChessPiece dstPiece = game.Board.GetPieceByCoords(dstx, dsty) as IChessPiece;
                bool didCapture = false;
                if (dstPiece != null)
                {
                    didCapture = true;
                }

                UpdateBoard(game, src, dst);
                UpdateGameTurn(game);
                return new MoveResult(true, didCapture);
            }

            return new MoveResult (false, false);
        }

        public void UpdateBoard (ChessGame game, Coordinate src, Coordinate dst)
        {
            game.Board.UpdatePiecesOnPosition(src, dst);
        }

        public void UpdateGameTurn(ChessGame game)
        {
            if (game.turn == "black")
            {
                game.turn = "white";
            } else
            {
                game.turn = "black";
            }
        }

        public string ConvertIntoFEN (ChessGame game)
        {
            string result = "";
            
            for (int y = 7; y >= 0; y --)
            {
                int empty = 0;
                for (int x = 0; x < 8; x ++)
                {
                    var piece = game.Board.GetPieceByCoords(x, y);
                    if (piece == null)
                    {
                        empty++;
                    } else if (empty == 0)
                    {
                        result += ConvertToShortName(piece.Name);
                    } else
                    {
                        result += empty;
                        result += ConvertToShortName(piece.Name);
                        empty = 0;
                    }
                }

                if (empty != 0)
                {
                    result += empty;
                }

                if (y != 0)
                {
                    result += "/";
                } else
                {
                    result += " " + game.turn.Substring(0, 1);
                }
            }
            
            return result;
        }

        public string ConvertToShortName (string name)
        {
            string color = name.Substring(0, 1);
            string piece = name.Substring(1);
            string result;
            switch (piece)
            {
                case "rook":
                    result = "r";
                    break;
                case "knight":
                    result = "n";
                    break;
                case "bishop":
                    result = "b";
                    break;
                case "queen":
                    result = "q";
                    break;
                case "king":
                    result = "k";
                    break;
                //pawn
                default:
                    result = "p";
                    break;
            }

            if (color == "w") {
                return result.ToUpper();
            }

            return result;
        }

        public ChessGame LoadFromFEN(string FEN, int id)
        {
            var game = ConvertFENToGame(FEN);
            games[id] = game;
            return game;
        }

        public ChessGame ConvertFENToGame(string FEN)
        {
            int currX = 0;
            int currY = 7;

            var loadedGame = new ChessGame();

            for (int i = 0; i < FEN.Length; i ++)
            {
                char curr = FEN[i];

                if (curr == '/')
                {
                    currX = 0;
                    currY = currY - 1;
                }

                else if (Char.IsDigit(curr))
                {
                    int x = curr - '0';
                    currX += x;
                }

                else if (curr == ' ')
                {
                    char color = FEN[i + 1];
                    if (color == 'w')
                    {
                        loadedGame.turn = "white";
                    } else
                    {
                        loadedGame.turn = "black";
                    }
                    break;
                }

                else
                {
                    var piece = ConvertToPiece(Char.ToString(curr)) as Piece;
                    loadedGame.Board.GetTileByCoords(currX, currY).SetPieces(new List<Piece>() { piece });
                    currX += 1;
                }



            }

            return loadedGame;
        }

        public IChessPiece ConvertToPiece (string shortName)
        {
            string color = "black";
            if (shortName == shortName.ToUpper())
            {
                color = "white";
            }

            shortName = shortName.ToUpper();

            switch (shortName)
            {
                case "R":
                    return new Rook(color);
                case "N":
                    return new Knight(color);
                case "B":
                    return new Bishop(color);
                case "Q":
                    return new Queen(color);
                case "K":
                    return new King(color);
                //pawn
                default:
                    return new Pawn(color);
            }

        }
    }
}
