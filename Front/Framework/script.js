/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 Jorengarenar
 * Copyright      2021 dolidius
 */

class TGFW {
  constructor(game, serverUrl) {
    this.GAME = game;
    this.SERVER_URL = serverUrl;
    this.GAME_ID;
    this.CLICKED_TILE = null;
  }

  updateGameId(id) {
    if (!id) {
      return false;
    }
    this.GAME_ID = id;
    document.querySelector("#gameId").textContent = `Game ID: ${id}`;
    return true;
  }

  async drawBoard() {
    const res = await fetch(`${this.SERVER_URL}/${this.GAME}/${this.GAME_ID}`)
    const data = await res.json();

    const boardDiv = document.querySelector("#board");
    boardDiv.innerHTML = "";
    boardDiv.style = `grid-template-columns: repeat(${data.board.width}, 75px)`;

    const cmpTiles = (a, b) => {
      if (a.coordinate.y === b.coordinate.y) {
        return a.coordinate.x - b.coordinate.x;
      }
      return b.coordinate.y - a.coordinate.y;
    };

    data.board.tiles.sort(cmpTiles).forEach((tileData) => {
      const bar = document.createElement("div");

      const tile = document.createElement("img");
      tile.src = tileData.texturePath;
      tile.dataset.x = tileData.coordinate.x;
      tile.dataset.y = tileData.coordinate.y;

      // deno-lint-ignore no-this-alias
      const that = this;
      tile.onclick = function() {
        if (!that.CLICKED_TILE) {
          if (this.parentElement.dataset.piece) {
            that.CLICKED_TILE = this;
          }
          return;
        }
        const X = this.dataset.x;
        const Y = this.dataset.y;
        const x = that.CLICKED_TILE.dataset.x;
        const y = that.CLICKED_TILE.dataset.y;
        this.CLICKED_TILE = null;
        fetch(`${that.SERVER_URL}/${that.GAME}/move/${that.GAME_ID}/${x}/${y}/${X}/${Y}`, {
          method: "POST"
        });
        that.drawBoard();
      }

      if (tileData.pieces.length) {
        bar.dataset.piece = tileData.pieces[0].name;
      }

      bar.appendChild(tile);
      boardDiv.appendChild(bar);
    });
  }

  async resetGame() {
    const res = await fetch(`${this.SERVER_URL}/${this.GAME}/${this.GAME_ID}/reset`);
    const data = await res.json();
    if (data) {
      this.drawBoard();
    }
  }

  async newGame() {
    const res = await fetch(`${this.SERVER_URL}/${this.GAME}`, {
      method: "POST"
    });
    if (this.updateGameId(await res.json())) {
      this.drawBoard();
    }
  }

  joinGame() {
    if (this.updateGameId(prompt("Type game ID:"))) {
      this.drawBoard();
    }
  }
}

// vim: fdl=1
