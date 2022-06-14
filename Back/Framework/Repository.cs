/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2022 DawidMoza
 */

using System;
using System.Collections.Generic;

namespace Framework {
    public class Repository {

        private Dictionary<string, Game> games = new Dictionary<string, Game>();

        public Game Get(string id) {
            if (id != null && games.ContainsKey(id)) {
                return games[id];
            }
            return null;
        }

        public string Add(Game item) {
            if (item == null) {
                throw new ArgumentNullException("item");
            }
            string id = Utils.GetRandomString(8);
            while (games.ContainsKey(id)) {
                id = Utils.GetRandomString(8);
            }
            games.Add(id, item);
            return id;
        }
    }
}
