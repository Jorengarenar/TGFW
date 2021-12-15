using Framework;
using System;

namespace Simple {
    internal class Player1 : Player {
        public Player1(TurnsMediator turnsMediator, int id) : base(turnsMediator, id) {}

        public override void Move() {
            Console.WriteLine("Hello I'm 1");
            turnsMediator.Notify(id, Console.ReadLine());
        }
    }
}
