/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessAsp.Pieces
{
    public class MoveResult
    {
        public bool IsCorrect { get; set; }
        public bool IsCapture { get; set; }

        public MoveResult (bool isCorrect, bool isCapture)
        {
            IsCorrect = isCorrect;
            IsCapture = isCapture;
        }

    }
}
