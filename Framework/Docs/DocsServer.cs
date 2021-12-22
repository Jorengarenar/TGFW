using Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Docs
{
    internal class DocsServer : Server
    {
        public DocsServer(string serverName, List<string> prefixes) : base(serverName, prefixes) { }

        public override string Routing(string request)
        {
            string responseString = "";
            if (request.Contains("docs"))
            {
                Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
                responseString = System.IO.File.ReadAllText("./assets/docs/index.html");
            }
            return responseString;
        }
    }
}


