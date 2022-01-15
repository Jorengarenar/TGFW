using Framework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ChessAsp.Repository;

namespace ChessAsp.Controllers
{
    [Route("chess")]
    [ApiController]
    public class ChessController : ControllerBase
    {
        static readonly ChessRepository repository = new ChessRepository();
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return repository.Get(id);
        }

        [HttpPost]
        public Game Post()
        {
            var newGame = new ChessGame();
            repository.Add(newGame);
            return newGame;
        }
    }
}
