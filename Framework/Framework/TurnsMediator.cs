/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System.Collections.Generic;

namespace Framework {
    public abstract class TurnsMediator {

        public int waitingFor = 0;
        public readonly List<Player> players = new List<Player>();

        public delegate void Handler(int id, string content);
        public delegate void Won();
        public delegate bool IsWon();

        public Handler handler;
        public IsWon isWon;
        public Won won;

        public abstract void AddPlayer(Player player);

        public abstract void Start();

        public abstract void Notify(int id, string content);
    }
}
