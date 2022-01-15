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
        private int count = 0;

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
            count++;
            return item;
        }

        public int Count()
        {
            return count;
        }
    }
}
