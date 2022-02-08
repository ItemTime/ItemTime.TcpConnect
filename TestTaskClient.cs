// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Diagnostics;

namespace ItemTime.TcpConnect;
class TestTaskClient
{
    TcpClient? client;
    NetworkStream? ttStream;
    public List<string>? MessageList { get; set; } = new List<string>();
    public TestTaskClient() => Init();
    private void Init()
    {
        client = new TcpClient("88.212.241.115", 2013);
        ttStream = client.GetStream();
        var enc = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(enc); 
    } 
    public void Run()
    {
        for (int i = 1; i < 2019; i++) 
        {
            string? ans;
            do
            {
                Write<int>(i);
                ans = Read();
                System.Console.Write(ans);
            } while (!ans.Contains("\n"));
        }
        System.Console.WriteLine("END");
        Console.ReadLine();
    }
    private void Write<T>(T value)
    {
        byte[] buff;
        buff = Encoding.GetEncoding(20866).GetBytes(value!.ToString() + "\n");
        //buff = Encoding.GetEncoding(20866).GetBytes(num.ToString() + "\n");
        ttStream!.Write(buff, 0, buff.Length);
    }
    private string Read()
    {
        // byte[] buff = new byte[4096];
        string message = string.Empty;
        Span<byte> buff = new Span<byte>(new byte[8192]);
        // do 
        // {
        //     int size = ttStream!.Read(buff, 0, buff.Length);
        //     message += Encoding.GetEncoding(20866).GetString(buff, 0, size);
        //     //message += Encoding.GetEncoding(20866).GetString(buff, 0, size);
        // }
        // while (ttStream.DataAvailable);
        // return message;
        ttStream!.Read(buff);
        message = Encoding.GetEncoding(20866).GetString(buff);
        return message;
    }

}