
using System.Net;
using System.Text;

public class A
{
    public string Name { get; set; }
    public override string ToString()
    {
        return Name;
    }
}
class Program
{

    static   void Handel(HttpListenerContext  context)
    {
        Task t = new Task(async () =>
        {
            
            var respon = context.Response;
            
            var outputstream = respon.OutputStream;
            respon.Headers.Add("Content-Type", "text-html");
            var html = (new A {Name = "Pham Van Tien Truong" }).ToString();
            var bytearr = Encoding.UTF8.GetBytes(html);
            outputstream.Write(bytearr, 0, bytearr.Length);
            outputstream.Close();
            await Task.Delay(10000);
            Console.WriteLine("Da Xong");
        });
        t.Start();
        
    }
    static async Task Main(string[] args)
    {
        var server = new HttpListener();
        server.Prefixes.Add("http://+:80/");

        server.Start();
        do
        {
            var context = await server.GetContextAsync();
            Console.WriteLine("Have Client connect !!");
            Task t = new Task(() =>
            {
                Handel(context);
            }
            );
            t.Start();
            await t;

        } while (server.IsListening); 

    }
}