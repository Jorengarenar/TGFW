using System;
using System.Net;
using System.Collections.Generic;

namespace TurnGamesFramework {
    class Program {
        
        static void Main(string[] args) {
            List<string> prefixes = new List<string>{ "http://*:29173/" };
            RunHttpListener(prefixes, SimpleHello);
        }

        delegate string Responser(HttpListenerContext httpListenerContext);

        static string SimpleHello(HttpListenerContext httpListenerContext) {
            return "Hello, Your query was: " + httpListenerContext.Request.Url;
        }

        static void RunHttpListener(List<string> prefixes, Responser responser) {
            HttpListener listener = new HttpListener();
            prefixes.ForEach(prefix => listener.Prefixes.Add(prefix));
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
        }
    }
}
