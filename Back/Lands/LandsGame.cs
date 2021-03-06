/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using Framework;
using System.Collections.Generic;
using System.Linq;
using static Lands.LandsPiece;

namespace Lands {
    public class LandsGame : Game {
        public List<LandsTile> AvailableTiles { get; set; }

        public List<int> Results { get; set; }

        internal readonly LandsTile blank = new LandsTile(PieceType.Blank, PieceType.Blank, PieceType.Blank, PieceType.Blank, PieceType.Blank);
        internal IUserInterface userInterface;

        public LandsGame(int boardWidth, int boardHeight, List<LandsPlayerData> players, IUserInterface userInterface, TurnsMediator.Mediators mediator) {
            this.userInterface = userInterface;
            switch (mediator) {
                case TurnsMediator.Mediators.Default:
                    this.turnsMediator = new DefaultTurnsMediator(Handler, IsWon, Won);
                    break;
                case TurnsMediator.Mediators.Web:
                    this.turnsMediator = new WebTurnsMediator(Handler, IsWon, Won);
                    break;
            }
            
            for (int i = 0; i < players.Count; ++i) {
                this.turnsMediator.AddPlayer(new LandsPlayer(this.turnsMediator, i, players[i].name, players[i].color, userInterface, this));
                turnsMediator.players.Last().isRobot = players[i].isRobot;
            }
            Results = turnsMediator.players.Select(x => 0).ToList();
            this.Board = new Board(boardWidth, boardHeight);
            for (int i = 0; i < Board.GetHeight() * Board.GetWidth(); ++i) {
                Board.SetTile(blank, i);
            }
            AvailableTiles = new List<LandsTile>();
            for (int i = 0; i < Board.GetHeight() * Board.GetWidth(); ++i) {
                AvailableTiles.Add(LandsTile.GenerateRandom());
            }
            this.userInterface.DrawRound(this.Board, this.AvailableTiles);
            this.turnsMediator.Start();
        }

        private void Handler(int id, string content) {
            string[] command = content.Split(':');
            try {
                switch (command[0]) {
                    case "tile":
                        new PlaceTile(this).Make(command[1]);
                        break;
                    case "meeple":
                        new PlaceMeeple(this).Make($"{command[1]};{id}");
                        break;
                }
            } catch { }
            userInterface.DrawRound(this.Board, this.AvailableTiles);
        }

        public void Won() {
            userInterface.DrawRound(this.Board, this.AvailableTiles);
            foreach (LandsTile tile in Board.Tiles) {
                foreach (LandsPiece piece in tile.Pieces) {
                    Results[piece.Meeple.Owner.Id] += (int) piece.Type;
                }
            }
            userInterface.DrawResults(Results, turnsMediator.players);
        }

        public bool IsWon() {
            foreach (LandsTile tile in Board.Tiles) {
                foreach (LandsPiece piece in tile.Pieces) {
                    if (piece.Meeple == null) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
