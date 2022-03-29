/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Coordinate
    {
        public int x {
            get; set;
        }

        public int y {
            get; set;
        }

        public Coordinate(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }
}
