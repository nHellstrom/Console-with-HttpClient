using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Console;
using System.Text.Json;
using System.Text;

namespace ConsoleHttpCaller
{
    internal class Program
    {
        private static readonly HttpClient httpClient = new();

        static async Task Main(string[] args)
        {
            await Handler();
        }

        private static async Task ProcessRepositories(string input)
        {
            try
            {
                //httpClient.DefaultRequestHeaders.Accept.Clear();
                var stringTask = httpClient.GetStringAsync($"https://swapi.py4e.com/api/people/{input}");

                var deserMsg = JsonSerializer.Deserialize<Hero>((string?)await stringTask);
                WriteLine(deserMsg.ToString());
            }
            catch (HttpRequestException e)
            {
                WriteLine("404 cant find! Try a lower number!");
            }
        }

        private static async Task Handler()
        {
            bool continuePick = true;
            string? inpContinue = null;
            int round = 1;

            while(continuePick == true)
            {
                WriteLine($"Round {round++}!");
                string input;

                if (inpContinue is null)
                {
                    WriteLine("Pick a hero (number 1 - ?)!");
                    input = ReadLine();
                }
                else
                {
                    input = inpContinue;
                }
                WriteLine(" - - Processing - -");

                await ProcessRepositories(input);

                WriteLine("\nWrite \"q\" to quit, or a number to continue!");
                inpContinue = ReadLine();

                if(inpContinue == "q")
                {
                    continuePick = false;
                }
                WriteLine("");
            }
        }
    }
}