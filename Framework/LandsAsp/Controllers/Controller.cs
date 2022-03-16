using Framework;
using Microsoft.AspNetCore.Mvc;

namespace LandsAsp.Controllers {

    [Route("lands")]
    [ApiController]
    public class Controller : ControllerBase {

        private Repository repository = new Repository();
    }
}
