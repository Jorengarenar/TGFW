using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using TurnGamesFramework;

namespace AccessPoint {
    public class Server {

        private const string generalPrefix = "http://*:29173";
        private static readonly string[] avaiableGames = { "Chess" };

        private List<Game> games = new List<Game>();

        public Server() {
            RunHttpListener();
        }

        void RunHttpListener() {
            while (true) {
                string responseString = "";
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add($"{generalPrefix}/available_games/");
                listener.Prefixes.Add($"{generalPrefix}/get/");
                listener.Prefixes.Add($"{generalPrefix}/chess_create/");
                listener.Start();
                HttpListenerContext context = listener.GetContext();
                HttpListenerResponse response = context.Response;
                string request = context.Request.RawUrl.ToString();
                Console.WriteLine(request);
                if (request.Contains("available_games")) {
                    responseString = JsonSerializer.Serialize(avaiableGames);
                } else if (request.Contains("get")) {
                    string lastPart = request.Split('/').Last();
                    Console.WriteLine(lastPart);
                    responseString = games[int.Parse(lastPart)].GameJSON();
                } else if (request.Contains("chess_create")) {
                    games.Add(new ChessGame());
                    responseString = (games.Count - 1).ToString();
                }
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
                listener.Stop();
            }
        }
    }
}
