using System;
using System.IO;
using System.IO.Pipes;

namespace Lab6_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                if (args.Length > 0)
                {
                    using (PipeStream pipeClient =
                        new AnonymousPipeClientStream(PipeDirection.In, args[0]))
                    {
                        using (var pipeClientOut = new AnonymousPipeClientStream(PipeDirection.Out, args[1]))
                        {
                            try
                            {
                                pipeClient.ReadMode = PipeTransmissionMode.Message;
                            }
                            catch (NotSupportedException e)
                            {
                            }
                            
                            string temp;

                            using (StreamReader sr = new StreamReader(pipeClient))
                            {
                                while ((temp = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine("Клиент говорит: " + temp);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}