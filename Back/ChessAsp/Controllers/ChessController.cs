/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

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
        public ChessGame Get(int id)
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

        [HttpGet("{id}/position")]
        public string VisualizePosition(int id)
        {
            var game = repository.Get(id);
            return repository.VisualisePosition((ChessGame)game);
        }

        [HttpGet("{id}/save")]
        public string SavePosition(int id)
        {
            var game = repository.Get(id);
            return repository.ConvertIntoFEN((ChessGame)game);
        }

        [HttpPost("{id}/load")]
        public Game LoadPosition(int id, [FromBody] FENFormat FEN)
        {
            return repository.LoadFromFEN(FEN.FEN, id);
        }   
    }
}
