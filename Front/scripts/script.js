const gamesList = document.querySelector("#gamesList");

const getGamesList = () => {

    const games = [{
            name: "Chess",
            img: "https://upload.wikimedia.org/wikipedia/commons/d/d5/Chess_Board.svg",
            playersAmount: 4
        },
        {
            name: "Mensch ärgere Dich nicht",
            img: "https://upload.wikimedia.org/wikipedia/commons/9/91/Menschenaergern.svg",
            playersAmount: "2-4"
        }
    ]

    return games;
}

const showGamesList = () => {
    const games = getGamesList();

    games.forEach(game => {
        const newGameEl = document.createElement("li");
        newGameEl.classList.add("gamesBar__game");

        const img = document.createElement("img");
        img.src = game.img;

        const titleContainer = document.createElement("div");

        const gameTitle = document.createElement("b");
        gameTitle.textContent = game.name;
        gameTitle.classList.add("title");

        const playersAmount = document.createElement("i")
        playersAmount.textContent = `${game.playersAmount} Players`;

        titleContainer.appendChild(gameTitle);
        titleContainer.appendChild(playersAmount);
        newGameEl.appendChild(img);
        newGameEl.appendChild(titleContainer);

        gamesList.appendChild(newGameEl);
    });

}

showGamesList();
