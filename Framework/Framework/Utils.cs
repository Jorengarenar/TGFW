using System;
using System.Linq;

namespace Framework {
    internal static class Utils {

        private const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

        internal static string GetRandomString(int length) { 
            return new string(Enumerable.Repeat(chars, 128).Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }
}
