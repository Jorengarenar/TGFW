/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using Framework;

namespace Lands {
    public class LandsPiece : Piece {
        public Meeple Meeple { get; set; }
        public PieceType Type { get; set; }

        public enum PieceType : int {
            City = 15,
            Road = 10,
            Grass = 3,
            Blank = 0
        }

        public LandsPiece(PieceType pieceType) {
            this.Type = pieceType;
        }

        public void SetMeeple(Meeple meeple) {
            if (this.Meeple == null) {
                this.Meeple = meeple;
            }
        }
    }
}
