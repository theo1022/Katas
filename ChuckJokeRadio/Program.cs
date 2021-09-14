using System;
using System.Net.Http;

namespace ChuckJokeRadio
{
    class Program
    {
        // TODO plocka även ut och visa datumet för när skämtet skapades/senast uppdaterades
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            while (true)
            {
                string url = @"https://api.chucknorris.io/jokes/random";
                string json = client.GetStringAsync(url).Result;

                string startTag = "\"value\":\"";
                int start = json.IndexOf(startTag) + startTag.Length;
                int end = json.IndexOf("\"}", start);

                string joke = json.Substring(start, end - start);


                string startDateTag = "\"created_at\":\"";
                int startDate = json.IndexOf(startDateTag) + startDateTag.Length;
                int endDate = json.IndexOf(".", startDate);

                string date = json.Substring(startDate, endDate - startDate);


                Console.WriteLine(joke);
                Console.WriteLine("This joke was submitted " + date);
                Console.WriteLine();
                Console.Write("Press enter for another joke");
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
