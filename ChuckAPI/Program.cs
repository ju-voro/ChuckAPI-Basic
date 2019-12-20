using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ChuckAPI
{
    class Program
    {
        private static string url => "https://api.chucknorris.io/jokes/random";
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Joke joke = JsonConvert.DeserializeObject<Joke>(response);
                Console.WriteLine($"Joke: {joke.Value}");
                
            }

            Console.ReadKey();
        }
    }
}
