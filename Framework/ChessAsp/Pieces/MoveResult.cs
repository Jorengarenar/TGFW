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
