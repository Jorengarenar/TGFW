using Framework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ChessAsp.Repository;
using ChessAsp.Pieces;

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
        public int Post()
        {
            repository.Add(new ChessGame());
            return repository.Count() - 1;
        }

        [HttpGet("{id}/reset")]
        public bool Reset(int id)
        {
            return repository.ResetPosition(id);
        }

        [HttpPost("move/{id}/{srcx}/{srcy}/{dstx}/{dsty}")]
        public MoveResult Move(int id, int srcx, int srcy, int dstx, int dsty)
        {
            return repository.MakeMove(id, srcx, srcy, dstx, dsty);
        }
    }
}
