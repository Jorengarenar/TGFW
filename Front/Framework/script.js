/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 Jorengarenar
 * Copyright      2021 dolidius
 */

let GAME_ID;
let CLICKED_TILE = null;

const SERVER_URL = "http://localhost:5000"
const GAME = "chess"

function updateGameId(id) {
  if (!id) {
    return false;
  }
  GAME_ID = id;
  document.querySelector("#gameId").textContent = `Game ID: ${id}`;
  return true;
}

async function drawBoard() {
  const res = await fetch(`${SERVER_URL}/${GAME}/${GAME_ID}`)
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

    tile.onclick = function() {
      if (!CLICKED_TILE) {
        if (this.parentElement.dataset.piece) {
          CLICKED_TILE = this;
        }
        return;
      }
      const X = this.dataset.x;
      const Y = this.dataset.y;
      const x = CLICKED_TILE.dataset.x;
      const y = CLICKED_TILE.dataset.y;
      CLICKED_TILE = null;
      fetch(`${SERVER_URL}/${GAME}/move/${GAME_ID}/${x}/${y}/${X}/${Y}`, {
        method: "POST"
      });
      drawBoard();
    }

    if (tileData.pieces.length) {
      bar.dataset.piece = tileData.pieces[0].name;
    }

    bar.appendChild(tile);
    boardDiv.appendChild(bar);
  });
}

async function resetGame() {
  const res = await fetch(`${SERVER_URL}/${GAME}/${GAME_ID}/reset`);
  const data = await res.json();
  if (data) {
    drawBoard();
  }
}

async function newGame() {
  const res = await fetch("${SERVER_URL}/${GAME}", {
    method: "POST"
  });
  if (updateGameId(await res.json())) {
    drawBoard();
  }
}

function joinGame() {
  if (updateGameId(prompt("Type game ID:"))) {
    drawBoard();
  }
}
