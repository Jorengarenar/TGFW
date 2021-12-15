using Framework;
using System;

namespace Simple {
    internal class Player2 : Player {
        public Player2(TurnsMediator turnsMediator, int id) : base(turnsMediator, id) {}

        public override void Move() {
            Console.WriteLine("Hello I'm 2");
            turnsMediator.Notify(id, Console.ReadLine());
        }
    }
}
