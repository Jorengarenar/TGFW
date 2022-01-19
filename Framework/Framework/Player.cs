/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

namespace Framework {
    public abstract class Player {

        protected TurnsMediator turnsMediator;

        public int id;
        public string name;

        public Player(TurnsMediator turnsMediator, int id, string name) {
            this.turnsMediator = turnsMediator;
            this.id = id;
            this.name = name;
        }

        public abstract void Move();
    }
}
