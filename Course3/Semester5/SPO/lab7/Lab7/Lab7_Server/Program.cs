using System;
using System.IO;
using System.IO.Pipes;

namespace Lab7_Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut))
            {
                using (NamedPipeServerStream pipeServerIn = new NamedPipeServerStream("testpipe2", PipeDirection.In))
                {
                    pipeServer.WaitForConnection();
                    pipeServerIn.WaitForConnection();

                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;

                        for (var i = 0; i < 2; i++)
                        {
                            sw.WriteLine(i);
                        }
                    }

                    using (StreamReader sr = new StreamReader(pipeServerIn))
                    {
                        int sum = 0;

                        string temp;

                        while ((temp = sr.ReadLine()) != null)
                        {
                            sum += int.Parse(temp);
                        }

                        Console.WriteLine(sum / 2.0);
                    }
                }

            }
        }
    }
}
