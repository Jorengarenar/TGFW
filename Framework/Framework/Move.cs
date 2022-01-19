/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

namespace Framework {
     public abstract class Move {

        public Game game;

        public Move(Game game) {
            this.game = game;
        }

        public abstract void Make(string command);

        public abstract bool IsPossible(string command);
     }
}
