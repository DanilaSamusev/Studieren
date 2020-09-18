using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace Lab6_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Process pipeClient = new Process();
            pipeClient.StartInfo.FileName = @"F:\MyWorks\Учёба\Studieren\Course3\SPO\lab6\Lab6_Samusev\Lab6\Lab6_Client\bin\Debug\netcoreapp3.0\Lab6_Client.exe";
            using (AnonymousPipeServerStream pipeServer =
                new AnonymousPipeServerStream(PipeDirection.Out,
                    HandleInheritability.Inheritable))
            {
                using (var pipeServerIn =
                    new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable))
                {
                    try
                    {
                        pipeServer.ReadMode = PipeTransmissionMode.Message;
                    }
                    catch (NotSupportedException e)
                    {
                    }
                    
                    pipeClient.StartInfo.Arguments =
                        pipeServer.GetClientHandleAsString() + " " + pipeServerIn.GetClientHandleAsString();
                    pipeClient.StartInfo.UseShellExecute = false;
                    pipeClient.Start();
                    pipeServer.DisposeLocalCopyOfClientHandle();
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(pipeServer))
                        {
                            sw.AutoFlush = true;
                            
                            while (true)
                            {
                                Console.WriteLine("Enter your message: ");
                                var message = Console.ReadLine();
                                sw.WriteLine(message);
                                Thread.Sleep(300);
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("[SERVER] Error: {0}", e.Message);
                    }
                }
            }

            pipeClient.WaitForExit();
            pipeClient.Close();
        }
    }
}