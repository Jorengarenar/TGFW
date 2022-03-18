using Framework;
using Lands;
using Lands.UserInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LandsAsp.Controllers {

    [Route("lands")]
    [ApiController]
    public class Controller : ControllerBase {

        private static readonly Repository repository = new Repository();

        [HttpGet("get")]
        public LandsGame Get(string id) {
            return (LandsGame) repository.Get(id);
        }

        [HttpGet("waiting")]
        public int WaitingFor(string id) {
            LandsGame game = (LandsGame) repository.Get(id);
            return game.turnsMediator.waitingFor;
        }

        [HttpPost("create")]
        public string Create(string firstName, string secondName, int width, int height) {
            IUserInterface userInterface = new WebUserInterface();
            List<LandsPlayerData> players = new List<LandsPlayerData>() { new LandsPlayerData(firstName), new LandsPlayerData(secondName)};
            return repository.Add(new LandsGame(width, height, players, userInterface, TurnsMediator.Mediators.Web));
        }

        [HttpPost("tile")]
        public string PlaceTile(string id, int player, int availableTileIndex, int tileX, int tileY) {
            LandsGame game = (LandsGame) repository.Get(id);
            game.turnsMediator.Notify(player, $"tile:{availableTileIndex};{tileX};{tileY}");
            return "ok";
        }

        [HttpPost("meeple")]
        public string PlaceMeeple(string id, int player, int pieceIndex, int tileX, int tileY) {
            LandsGame game = (LandsGame) repository.Get(id);
            game.turnsMediator.Notify(player, $"meeple:{pieceIndex};{tileX};{tileY}");
            return "ok";
        }
    }
}
