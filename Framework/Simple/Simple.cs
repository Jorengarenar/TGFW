/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using Framework;
using System;

namespace Simple {
    internal class Simple : Game {

        internal Simple() {
            this.turnsMediator = new TurnsMediator(Handler);
            this.turnsMediator.AddPlayer(new Player1(this.turnsMediator, 0));
            this.turnsMediator.AddPlayer(new Player2(this.turnsMediator, 1));
            this.turnsMediator.Start();
        }

        private void Handler(int id, string content) {
            Console.WriteLine($"{id}: {content}");
        }
    }
}
