using Framework;
using System.Linq;

namespace Chess {
    internal class Program {

        private static readonly string[] prefixes = { "create", "get" };

        static void Main(string[] args) {
            Server server = new ChessServer("chess", prefixes.ToList());
        }
    }
}
