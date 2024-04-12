using CleverenceTestTasks.Task3;
using System.Diagnostics;
using System.Threading;

namespace CleverenceTestTasks
{
    internal class TestTask3
    {
        private List<Thread> ClientEmulatorThreads = new List<Thread>();

        private int _readers, _writers, _both;
        public TestTask3(int readers, int writers, int both)
        {
            _readers = readers;
            _writers = writers;
            _both = both;
        }

        public void StartSimulation()
        {
            for (int i = 0; i < _readers; i++) CreateClientThread(ClientActions.Read);
            for (int i = 0; i < _writers; i++) CreateClientThread(ClientActions.Write);
            for (int i = 0; i < _both; i++) CreateClientThread(ClientActions.ReadWrite);
        }

      
        void CreateClientThread(ClientActions actions)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ClientEmulator));
            ClientEmulatorThreads.Add(thread);
            thread.Start(actions);
        }
        void ClientEmulator(object actions)
        {
            ClientActions acts = (ClientActions)actions;
            while (true)
            {
                if(acts == ClientActions.Read)
                    Thread.Sleep(200);
                else
                    Thread.Sleep(100);



                if (acts == ClientActions.Read)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} thread has read value: {Server.GetCount().Result}");
                    
                }

                if(acts == ClientActions.Write)
                {
                    Server.AddToCount(1);
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} thread has written value");
                }

                if(acts == ClientActions.ReadWrite)
                {
                    Random rnd = new Random();
                    var random = rnd.Next(0,10);
                    if(random < 5)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} thread has read value: {Server.GetCount()}");
                    }
                    else
                    {
                        Server.AddToCount(1);
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} thread has written value");
                    }
                }
            }
        }

        enum ClientActions
        {
            Read,
            Write,
            ReadWrite
        }
    }
}
