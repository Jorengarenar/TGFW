/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 Jorengarenar
 */

class TgfwChess extends TGFW {
  async drawBoard() {
    const res = await fetch(`${this.SERVER_URL}/${this.GAME}/${this.GAME_ID}`)
    const data = await res.json();

    const boardDiv = this.CONTAINER.querySelector("#board");
    boardDiv.innerHTML = "";
    boardDiv.style = `grid-template-columns: repeat(${data.board.width}, var(--tile-size))`;

    this.CONTAINER.querySelector("#gameStats #current-player").innerHTML = `Turn: ${data.turn}`;

    const cmpTiles = (a, b) => {
      if (a.coordinate.y === b.coordinate.y) {
        return a.coordinate.x - b.coordinate.x;
      }
      return b.coordinate.y - a.coordinate.y;
    };

    data.board.tiles.sort(cmpTiles).forEach((tileData) => {
      const tile = document.createElement("div");
      tile.classList.add("tile");

      tile.dataset.x = tileData.coordinate.x;
      tile.dataset.y = tileData.coordinate.y;

      // tile.dataset.bg = tileData.texturePath;
      if (tileData.texturePath.includes("dark")) {
        tile.classList.add("dark");
      } else {
        tile.classList.add("light");
      }

      if (tileData.pieces.length) {
        const piece = document.createElement("img");
        piece.src = `img/${tileData.pieces[0].name}.svg`;
        tile.appendChild(piece);
        tile.dataset.piece = tileData.pieces[0].name;
      }

      // deno-lint-ignore no-this-alias
      const that = this;
      tile.onclick = function() {
        let selected = that.CONTAINER.querySelector(".tile.selected");

        if (!selected) {
          this.classList.add("selected")
          selected = this;
        } else if (this === selected) {
          this.classList.remove("selected");
          return;
        } else {
          const X = this.dataset.x;
          const Y = this.dataset.y;
          const x = selected.dataset.x;
          const y = selected.dataset.y;
          that.CLICKED_TILE = null;
          fetch(`${that.SERVER_URL}/${that.GAME}/move/${that.GAME_ID}/${x}/${y}/${X}/${Y}`, {
            method: "POST"
          });
          that.drawBoard();
        }
      }

      boardDiv.appendChild(tile);
    });
  }
}

new TgfwChess("chess", "http://localhost:5000");
