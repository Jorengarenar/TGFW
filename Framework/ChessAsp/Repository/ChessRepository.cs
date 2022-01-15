using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework;

namespace ChessAsp.Repository
{
    public class ChessRepository
    {
        private List<Game> games = new List<Game>();

        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        public Game Get(int id)
        {
            try
            {
                var game = games[id];
                return game;
            } catch
            {
                return null;
            }
        }

        public Game Add(Game item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            games.Add(item);
            return item;
        }
    }
}
