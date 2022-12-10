using System;
using NetMQ;
using NetMQ.Sockets;

static class Program
{
    public static void Main()
    {
        BeginPingPongDemo();

        Console.WriteLine("Demo was finished");

        Console.ReadKey();
    }

    private static void BeginPingPongDemo()
    {
        using (var requester = new RequestSocket())
        {
            requester.Connect("tcp://localhost:5555");

            for (int requestNumber = 0; requestNumber != 10; requestNumber++)
            {
                Console.WriteLine($"Sending Ping on {requestNumber} lap");
                requester.SendFrame("Ping");
                string str = requester.ReceiveFrameString();
                Console.WriteLine($"Received {str} on {requestNumber} lap");
                Console.WriteLine("\n");

                Thread.Sleep(1000);
            }
        }
    }
}
