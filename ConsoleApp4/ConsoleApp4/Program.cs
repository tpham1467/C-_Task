using System.Net;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Task t = new Task(async () =>
            {
                using var httpClient = new HttpClient();
                string url = @"http://localhost:80";
                // Thiết lập các Header nếu cần
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                // Thực hiện truy vấn GET
                HttpResponseMessage response = await httpClient.GetAsync(url);
        string htmltext = await response.Content.ReadAsStringAsync();
        Console.WriteLine(htmltext);
    });
        t.Start();
            await t;
       await Task.Delay(500);

        }
    }
}