/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

namespace Lands {
    public class Meeple {
        public LandsPlayer Owner { get; set; }

        public Meeple(LandsPlayer owner) {
            this.Owner = owner;
        }
    }
}
