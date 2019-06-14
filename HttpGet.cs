using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Wololo2
{
    class HttpGet : IData
    {
        public async Task<string> GetData(string ID)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string token = Environment.GetEnvironmentVariable("CANVAS_API_TOKEN");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string response = await client.GetStringAsync("https://byui.instructure.com/api/v1/courses/" + ID + "/modules?include[]=items&per_page=32");
                    return response;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e);
                    return e.ToString();
                }
            }
        }
    }
}