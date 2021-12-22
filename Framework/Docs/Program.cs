using System;
using Framework;
using System.Linq;

namespace Docs
{
    internal class Program
    {

        private static readonly string[] prefixes = { "docs" };

        static void Main(string[] args)
        {
            Console.WriteLine("Docs server started");
            Server server = new DocsServer("swagger", prefixes.ToList());
        }
    }
}
