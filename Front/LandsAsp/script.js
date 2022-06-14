/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2022 Jorengarenar
 */

class TgfwLands extends TGFW {
  async checkPlayer() {
    if (!this.ONLINE) { return true; }

    const res = await fetch(`${this.SERVER_URL}/${this.GAME}/get?id=${this.GAME_ID}`)
    const data = await res.json();
    const flag = (this.PLAYER_NUM == Number(data.waitingFor));

    return flag;
  }

  addPlayerColorToDom() {
    const pl = document.createElement("div");
    pl.dataset.num = this.PLAYER_NUM;
    pl.classList.add("player-color");
    this.CONTAINER.querySelector("#gameStats").appendChild(pl);

    this.CONTAINER.querySelector("#current-player").classList.add("player-color");
  }

  async drawBoard() {
    const res = await fetch(`${this.SERVER_URL}/${this.GAME}/get?id=${this.GAME_ID}`)
    const data = await res.json();

    const player = data.waitingFor;
    this.CONTAINER.querySelector("#current-player").dataset.num = player;

    const boardDiv = this.CONTAINER.querySelector("#board");
    const piecesDiv = this.CONTAINER.querySelector("#pieces");

    const createPiece = (pieceData) => {
      const piece = document.createElement("div");
      piece.classList.add("piece");

      let fragId = 0;
      pieceData.pieces.filter(f => f.type).forEach((fragmentData) => {
        const frg = document.createElement("div");
        frg.classList.add("fragment");
        frg.dataset.id = fragId++;
        frg.dataset.type = fragmentData.type;
        switch (fragmentData.type) {
          case 15:
            frg.textContent = "C";
            break;
          case 10:
            frg.textContent = "R";
            break;
          case 3:
            frg.textContent = "G";
            break;
        }

        if (fragmentData.meeple) {
          frg.dataset.owner = fragmentData.meeple.owner.id;
        }

        piece.appendChild(frg);
      });

      if (piece.childNodes.length == 0) {
        return null;
      }

      return piece;
    }

    // board {{{
    boardDiv.innerHTML = "";
    boardDiv.style = `grid-template-columns: repeat(${data.board.width}, 75px)`;

    let x = 0;
    let y = 0;

    // deno-lint-ignore no-this-alias
    const that = this;

    data.board.tiles.forEach((tileData) => {
      const tile = document.createElement("div");
      tile.classList.add("tile");

      tile.dataset.x = x++;
      tile.dataset.y = y;

      if (x >= data.board.width) {
        x = 0;
        ++y;
      }

      tile.onclick = async function() {
        if (!await that.checkPlayer()) { return; }

        const selected = piecesDiv.querySelector(".selected");

        if (!selected) { return; }

        const X = this.dataset.x;
        const Y = this.dataset.y;
        const availableTileIndex = selected.dataset.id;

        const url = `${that.SERVER_URL}/${that.GAME}/tile?`
          + `id=${that.GAME_ID}&`
          + `player=${player}&`
          + `availableTileIndex=${availableTileIndex}&`
          + `tileX=${X}&`
          + `tileY=${Y}`;
        fetch(url, { method: "POST" });

        that.drawBoard();
      }

      const piece = createPiece(tileData);
      if (piece) {
        piece.classList.add("enabled");

        piece.childNodes.forEach(frg => {
          if (frg.dataset.owner) { return; }
          frg.onclick = async function() {
            if (!await that.checkPlayer()) { return; }

            const tile = piece.parentElement;
            const X = tile.dataset.x;
            const Y = tile.dataset.y;
            const id = this.dataset.id;

            const url = `${that.SERVER_URL}/${that.GAME}/meeple?`
              + `id=${that.GAME_ID}&`
              + `player=${player}&`
              + `pieceIndex=${id}&`
              + `tileX=${X}&`
              + `tileY=${Y}`;
            fetch(url, { method: "POST" });

            that.drawBoard();
          };
        });
        tile.appendChild(piece);
      }

      boardDiv.appendChild(tile);
    });
    // }}}

    // pieces {{{
    piecesDiv.innerHTML = "";
    let id = 0;

    data.availableTiles.forEach((pieceData) => {
      const piece = createPiece(pieceData);
      piece.dataset.id = id++;

      piece.onclick = async function() {
        if (!await that.checkPlayer()) { return; }

        if (!piece.classList.contains("enabled")) {
          piecesDiv.querySelector(".selected")?.classList.remove("selected");
          piece.classList.add("selected");
        }
      }

      piecesDiv.appendChild(piece);
    });
    // }}}

    /* check if end of game */ {
      const res = await fetch(`${this.SERVER_URL}/${this.GAME}/results?id=${this.GAME_ID}`)
      const data = await res.text();

      if (data) {
        const results = eval(data);
        let winner = "draw";
        if (results[0] > results[1]) {
          winner = "player one";
        } else if (results[0] < results[1]) {
          winner = "player two";
        }
        alert("End of game!\n\nWinner: " + winner + "\nScores: " + data);
      }
    }

    if (this.ONLINE) {
      if (!await this.checkPlayer() && !this.REFRESHING) {
        this.REFRESHING = setInterval(function() {
          if (that.checkPlayer()) {
            clearInterval(that.REFRESHING);
            that.REFRESHING = null;
          }
          that.drawBoard();
        }, 500);
      }
    }
  }

  async newGame() {
    this.ONLINE = Number(prompt("Online? [0/1] "));
    this.PLAYER_NUM = 0;

    const numOfPlayers = this.ONLINE ? 2 : Number(prompt("Number of players [1-2]: "));
    const width = prompt("Board width: ");
    const height = prompt("Board height: ");

    let url = `${this.SERVER_URL}/${this.GAME}/`;
    if (numOfPlayers === 1) {
      url += "createsingle?";
    } else {
      const firstName = "0"; // prompt("First player: ");
      const secondName = "1"; // prompt("Second player: ");
      url += "create?"
        + `firstName=${firstName}&`
        + `secondName=${secondName}&`
    }
    url += `width=${width}&height=${height}`;

    await super.newGame(url);
    this.addPlayerColorToDom();
  }

  joinGame() {
    this.PLAYER_NUM = 1;
    this.ONLINE = true;
    super.joinGame();
    this.addPlayerColorToDom();
  }
}

new TgfwLands("lands", "http://localhost:5000");
