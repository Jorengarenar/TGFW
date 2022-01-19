/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 DawidMoza
 * Copyright 2021-2022 dolidius
 * Copyright      2022 Jorengarenar
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Framework {
    public abstract class Server {

        private string generalPrefix = "http://*:29173";
        private List<string> prefixes;

        public Server(string serverName, List<string> prefixes) {
            generalPrefix += $"/{serverName}";
            this.prefixes = prefixes;
            RunHttpListener();
        }

        private void RunHttpListener() {
            while (true) {
                string responseString = "";
                HttpListener listener = new HttpListener();
                prefixes.ForEach(x => listener.Prefixes.Add($"{generalPrefix}/{x}/"));
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
