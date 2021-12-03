using System.Text.Json;

namespace TurnGamesFramework {
    public abstract class Game {

        public Board board { get; set; }

        public string GameJSON() {
            return JsonSerializer.Serialize(this);
        }
    }
}
