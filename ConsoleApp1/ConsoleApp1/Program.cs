// static async Task Main(string[] args)
{
    // Đối tượng để phát đi yêu cầu dừng Task
    var tokenSource = new CancellationTokenSource();

    // Lấy token - để sử dụng bởi task, khi task thực thi
    // token.IsCancellationRequested là true nếu có phát yêu cầu dừng
    // bằng cách gọi tokenSource.Cancel
    var token = tokenSource.Token;


    // Tạo task1 có sử dụng CancellationToken
    Task task1 = new Task(
        () => {

            for (int i = 0; i < 10000; i++)
            {
                // Kiểm tra xem có yêu cầu dừng thì kết thúc task
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("TASK1 STOP");
                    token.ThrowIfCancellationRequested();
                    return;
                }

                // Chạy tiếp
                Console.WriteLine("TASK1 runing ... " + i);
                Thread.Sleep(300);
            }
        },
        token
    );


    // Tạo task1 có sử dụng CancellationToken
    Task task2 = new Task(
        () => {

            for (int i = 0; i < 10000; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("TASK2 STOP");
                    token.ThrowIfCancellationRequested();
                    return;
                }
                Console.WriteLine("TASK2 runing ... " + i);
                Thread.Sleep(300);
            }
        },
        token
    );

    // Chạy các task
    task1.Start();
    task2.Start();




    while (true)
    {
        var c = Console.ReadKey().KeyChar;

        // Nếu bấm e sẽ phát yêu cầu dừng task
        if (c == 'e')
        {
            // phát yêu cầu dừng task
            tokenSource.Cancel();
            break;
        }

    }

    Console.WriteLine("Các task đã kết thúc, bấm phím bất kỳ kết thúc chương trình");
    Console.ReadKey();
}