﻿using Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess {
    internal class ChessServer : Server {

        private List<Game> games = new List<Game>();

        public ChessServer(string serverName) : base(serverName) {}

        public override string Routing(string request) {
            string responseString = "";
            Console.WriteLine(request);
            if (request.Contains("get")) {
                string lastPart = request.Split('/').Last();
                Console.WriteLine(lastPart);
                responseString = games[int.Parse(lastPart)].GameJSON();
            } else if (request.Contains("create")) {
                games.Add(new ChessGame());
                responseString = (games.Count - 1).ToString();
            }
            return responseString;
        }
    }
}
