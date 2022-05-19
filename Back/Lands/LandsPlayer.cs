/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using Framework;
using System;

namespace Lands {
    public class LandsPlayer : Player {
        
        public ConsoleColor consoleColor;
        private IUserInterface userInterface;
        private LandsGame game;

        public LandsPlayer(TurnsMediator turnsMediator, int id, string name, ConsoleColor consoleColor, IUserInterface userInterface, LandsGame game) : base(turnsMediator, id, name) {
            this.consoleColor = consoleColor;
            this.userInterface = userInterface;
            this.game = game;
        }

        public override void Move() {
            if (isRobot) {
                PlaceMeeple placeMeeple = new PlaceMeeple(game);
                PlaceTile placeTile = new PlaceTile(game);
                string command = GetRandomCommand();
                while (!placeMeeple.IsPossible(command.Split(":")[1]) && !placeTile.IsPossible(command.Split(":")[1])) {
                    command = GetRandomCommand();
                }
                turnsMediator.Notify(Id, command);
            } else {
                turnsMediator.Notify(Id, userInterface.GetCommand(this));
            }
        }

        private string GetRandomCommand() {
            Random r = new Random();
            int move = r.Next(0, 2);
            if (move == 0 && game.AvailableTiles.Count > 0) {
                return $"tile:{r.Next(0, game.AvailableTiles.Count)};{r.Next(0, game.Board.Width)};{r.Next(0, game.Board.Height)}";
            } else {
                return $"meeple:{r.Next(0, 6)};{r.Next(0, game.Board.Width)};{r.Next(0, game.Board.Height)}";
            }
        }
    }
}
