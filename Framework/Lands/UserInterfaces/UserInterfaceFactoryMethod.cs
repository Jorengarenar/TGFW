/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

namespace Lands.UserInterfaces {
    internal class UserInterfaceFactoryMethod {
        public static IUserInterface CreateUserInterface(string interfaceType) {
            return interfaceType switch {
                "console" => new ConsoleUserInterface(),
                "web" => new WebUserInterface(),
                _ => null,
            };
        }
    }
}
