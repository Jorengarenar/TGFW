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

        public LandsPlayer(TurnsMediator turnsMediator, int id, string name, ConsoleColor consoleColor, IUserInterface userInterface) : base(turnsMediator, id, name) {
            this.consoleColor = consoleColor;
            this.userInterface = userInterface;
        }

        public override void Move() {
            turnsMediator.Notify(id, userInterface.GetCommand(this));
        }
    }
}
