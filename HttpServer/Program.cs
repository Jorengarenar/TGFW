using System;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;

namespace TurnGamesFramework {
    class Program {
        
        static void Main(string[] args) {
            string generalPrefix = "http://*:29173";
            //RunHttpListener(generalPrefix, SimpleHello);
            RunHttpListener($"{generalPrefix}/available_games/", AvailableGames);
        }

        delegate string Responser(HttpListenerContext httpListenerContext);

        static string SimpleHello(HttpListenerContext httpListenerContext) {
            return "Hello, Your query was: " + httpListenerContext.Request.Url;
        }

        static string AvailableGames(HttpListenerContext httpListenerContext) {
            return JsonSerializer.Serialize(new List<string>() { "Chees", "Checkers" });
        }

        static void RunHttpListener(string prefix, Responser responser) {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(prefix);
            listener.Start();
            Console.WriteLine("Listening...");
            HttpListenerContext context = listener.GetContext();
            HttpListenerResponse response = context.Response;
            string responseString = responser(context);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            listener.Stop();
            RunHttpListener(prefix, responser);
        }
    }
}
