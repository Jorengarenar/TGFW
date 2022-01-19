let game_id;
let clicked_tile = null;

function updateGameId(id) {
  if (!id) {
    return false;
  }
  game_id = id;
  document.querySelector("#gameId").textContent = `Game ID: ${id}`;
  return true;
}

async function drawBoard() {
  const res = await fetch(`http://localhost:5000/chess/${game_id}`)
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
      console.log(clicked_tile);
      if (!clicked_tile) {
        clicked_tile = this;
        return;
      }
      const X = this.dataset.x;
      const Y = this.dataset.y;
      const x = clicked_tile.dataset.x;
      const y = clicked_tile.dataset.y;
      clicked_tile = null;
      fetch(`http://localhost:5000/chess/move/${game_id}/${x}/${y}/${X}/${Y}`, {
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

async function newGame() {
  const res = await fetch("http://localhost:5000/chess", {
    method: "POST"
  });
  if (updateGameId(await res.json())) {
    drawBoard();
  }
}

function joinGame() {
  if (updateGameId(prompt())) {
    drawBoard();
  }
}
