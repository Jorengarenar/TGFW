/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System;

namespace Lands {
    internal class LandsPlayerData {
        public string name;
        public ConsoleColor color;

        public LandsPlayerData(string name, ConsoleColor color) {
            this.name = name;
            this.color = color;
        }
    }
}
