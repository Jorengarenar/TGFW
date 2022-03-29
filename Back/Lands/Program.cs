/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using Lands.UserInterfaces;

namespace Lands {
    internal class Program {
        static void Main(string[] args) {
            IUserInterface userInterface = UserInterfaceFactoryMethod.CreateUserInterface("console");
            new LandsGame(userInterface.GetBoardWidth(), userInterface.GetBoardHeight(), userInterface.GetPlayersData(), userInterface, Framework.TurnsMediator.Mediators.Default);
        }
    }
}
