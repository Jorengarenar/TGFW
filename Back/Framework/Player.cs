/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

namespace Framework
{
    public abstract class Player {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool isRobot = false;

        protected TurnsMediator turnsMediator;

        public Player(TurnsMediator turnsMediator, int id, string name)
        {
            this.turnsMediator = turnsMediator;
            this.Id = id;
            this.Name = name;
        }

        public abstract void Move();
    }
}
