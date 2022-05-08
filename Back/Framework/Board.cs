/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System.Collections.Generic;

namespace Framework
{
    public class Board
    {
        public List<Tile> Tiles {
            get; set;
        }
        public int Width {
            get; set;
        }
        public int Height {
            get; set;
        }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Tiles = new List<Tile>();
            for (int i = 0; i < width * height; ++i)
            {
                Tiles.Add(new Tile());
            }
        }

        public void SetTile(Tile tile, int index)
        {
            Tiles[index] = tile;
        }

        public void SetTile(Tile tile, int x, int y)
        {
            Tiles[(Height * y) + x] = tile;
        }

        public Tile GetTile(int x, int y)
        {
            return Tiles[(Height * y) + x];
        }

        public int GetWidth()
        {
            return Width;
        }

        public int GetHeight()
        {
            return Height;
        }

        public Tile GetTileByCoords (int x, int y)
        {
            Tile foundTile = null;

            foreach (var tile in Tiles)
            {
                if (tile.Coordinate.x == x && tile.Coordinate.y == y)
                {
                    foundTile = tile;
                }
            }

            return foundTile;
        }

        public Piece GetPieceByCoords (int x, int y)
        {
            var tile = GetTileByCoords(x, y);

            if (tile != null && tile.Pieces.Count == 1)
            {
                return tile.Pieces[0];
            }

            return null;
        }

        public void UpdatePiecesOnPosition (Coordinate src, Coordinate dst)
        {
            GetTileByCoords(dst.x, dst.y).SetPieces(new List<Piece>() {
                GetPieceByCoords(src.x, src.y)
            });
            GetTileByCoords(src.x, src.y).SetPieces(new List<Piece>() {});
        }
    }
}
