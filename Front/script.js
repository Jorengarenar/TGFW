let game_id;

async function newGame() {
  const res = await fetch("http://localhost:5000/chess", {
    method: "POST"
  });
  game_id = await res.json();
}

function showId() {
  console.log(game_id)
}
