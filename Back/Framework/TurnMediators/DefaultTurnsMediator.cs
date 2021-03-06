/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

namespace Framework
{
    public class DefaultTurnsMediator : TurnsMediator
    {
        public DefaultTurnsMediator(Handler handler, IsWon isWon, Won won)
        {
            this.handler = handler;
            this.isWon = isWon;
            this.won = won;
        }

        public override void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public override void Start()
        {
            players[waitingFor].Move();
        }

        public override void Notify(int id, string content)
        {
            if (id == waitingFor) {
                waitingFor = (waitingFor + 1) % players.Count;
                handler(id, content);
                if (isWon()) {
                    won();
                    return;
                }
                players[waitingFor].Move();
            }
        }
    }
}
