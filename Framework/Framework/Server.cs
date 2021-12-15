using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Framework {
    public abstract class Server {

        private string generalPrefix = "http://*:29173";

        public Server(string serverName) {
            generalPrefix += $"/{serverName}";
            RunHttpListener();
        }

        private void RunHttpListener() {
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
                responseString = Routing(request);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
                listener.Stop();
            }
        }

        public abstract string Routing(string request);

        public static string ToJson(object obj) { 
            return JsonSerializer.Serialize(obj);
        }
    }
}