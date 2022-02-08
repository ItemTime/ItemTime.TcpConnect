// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Diagnostics;


namespace ItemTime.TcpConnect;
class Program
{
    static void Main(string[] args) 
    {
        var client = new TestTaskClient();
        client.Run();
    }   
}