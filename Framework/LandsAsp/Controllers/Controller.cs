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

        [HttpGet]
        public LandsGame Get(string id) {
            return (LandsGame) repository.Get(id);
        }

        [HttpPost]
        public string Post(string firstName, string secondName) {
            IUserInterface userInterface = new WebUserInterface();
            List<LandsPlayerData> players = new List<LandsPlayerData>() { new LandsPlayerData(firstName), new LandsPlayerData(secondName)};
            return repository.Add(new LandsGame(2, 2, players, userInterface, TurnsMediator.Mediators.Web));
        }
    }
}
