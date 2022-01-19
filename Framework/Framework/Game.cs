/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System.Collections.Generic;
using System.Text.Json;

namespace Framework {
    public class Game {
        public Board Board { get; set; }

        public TurnsMediator turnsMediator;

        public string GameJSON() {
            return JsonSerializer.Serialize(this);
        }
    }
}
