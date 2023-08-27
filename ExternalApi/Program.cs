using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExternalApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                string apiUrl = "https://notrealapi.com/lottery/play";

                Random random = new Random();

                int customerNumber = random.Next(1000, 10000);
                int numberOfAttempts = 10;

                for (int i = 1; i <= numberOfAttempts; i++)
                {
                    try
                    {
                        int winningNumber = random.Next(1000, 10000);
                        var payload = new { customerNumber };


                        HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUrl, payload);

                        if (response.IsSuccessStatusCode)
                        {
                            int guessedNumber = Int32.Parse(await response.Content.ReadAsStringAsync());


                            if (guessedNumber == winningNumber)
                            {
                                Console.WriteLine($"winning number {winningNumber}");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Attempt {i}: API request failed with status code: {response.StatusCode}");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"Attempt {i}: API request failed. Exception: {ex.Message}");
                    }
                }
            }
        }
    }
}
