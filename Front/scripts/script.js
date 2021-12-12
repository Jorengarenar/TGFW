const gamesList = document.querySelector("#gamesList");

const getGamesList = () => {

    const games = [{
            name: "chess",
            img: "https://upload.wikimedia.org/wikipedia/commons/d/d5/Chess_Board.svg",
            playersAmount: 4
        },
        {
            name: "chess",
            img: "https://upload.wikimedia.org/wikipedia/commons/d/d5/Chess_Board.svg",
            playersAmount: 2
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
        titleContainer.classList.add("title");

        const gameName = document.createElement("h3");
        gameName.textContent = game.name;

        const playersAmount = document.createElement("h4")
        playersAmount.textContent = `${game.playersAmount} Players`;

        titleContainer.appendChild(gameName);
        titleContainer.appendChild(playersAmount);
        newGameEl.appendChild(img);
        newGameEl.appendChild(titleContainer);

        gamesList.appendChild(newGameEl);
    });

}

showGamesList();
