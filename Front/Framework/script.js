/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 Jorengarenar
 * Copyright      2021 dolidius
 */

// deno-lint-ignore no-unused-vars
class TGFW {
  constructor(game, serverUrl) {
    this.GAME = game;
    this.SERVER_URL = serverUrl;
    this.GAME_ID = null;
    this.CLICKED_TILE = null;
    this.CONTAINER = null;

    window.onload = () => { this.initDom(); }
  }

  updateGameId(id) {
    if (!id) {
      return false;
    }
    this.GAME_ID = id;
    document.querySelector("#gameId").textContent = `Game ID: ${id}`;
    return true;
  }

  drawBoard() {
    console.error("[TGFW] Board not implemented!");
  }

  async resetGame() {
    const res = await fetch(`${this.SERVER_URL}/${this.GAME}/${this.GAME_ID}/reset`);
    const data = await res.json();
    if (data) {
      this.drawBoard();
    }
  }

  async newGame(url) {
    if (!url) {
      url = `${this.SERVER_URL}/${this.GAME}`;
    }

    const res = await fetch(url, { method: "POST" });
    if (this.updateGameId(await res.text())) {
      this.drawBoard();
    }
  }

  joinGame() {
    if (this.updateGameId(prompt("Type game ID:"))) {
      this.drawBoard();
    }
  }

  initDom() {
    this.CONTAINER = document.querySelector("#TGFW");

    const newEl = (tag) => document.createElement(tag);

    // nav {{{1
    const nav = newEl("nav");

    // gameIdDiv {{{2
    const gameIdDiv = newEl("div");
    gameIdDiv.id = "gameId";

    // optionsDiv {{{2
    const optionsDiv = newEl("div");
    optionsDiv.id = "options";

    // newGameBtn {{{3
    const newGameBtn = newEl("button");
    newGameBtn.id = "newGame";
    newGameBtn.onclick = () => { this.newGame() };
    newGameBtn.textContent = "Host new game";

    // joinGameBtn {{{3
    const joinGameBtn = newEl("button");
    joinGameBtn.id = "joinGame";
    joinGameBtn.onclick = () => { this.joinGame() };
    joinGameBtn.textContent = "Join game";

    // separator {{{3
    const separator = newEl("span");
    separator.classList.add("separator")

    // resetGameBtn {{{3
    const resetGameBtn = newEl("button");
    resetGameBtn.id = "resetGame";
    resetGameBtn.onclick = () => { this.resetGame() };
    resetGameBtn.textContent = "Reset game";
    // }}}3

    optionsDiv.append(newGameBtn, joinGameBtn, resetGameBtn);
    // }}}2

    nav.append(gameIdDiv, optionsDiv);

    // gameDiv {{{1
    const gameDiv = newEl("div");
    gameDiv.id = "game";

    const boardDiv = newEl("div");
    boardDiv.id = "board";

    const piecesDiv = newEl("div");
    piecesDiv.id = "pieces";

    gameDiv.append(boardDiv, piecesDiv);
    // }}}1

    this.CONTAINER.append(nav, gameDiv);

  }
}

// vim: fdl=1
