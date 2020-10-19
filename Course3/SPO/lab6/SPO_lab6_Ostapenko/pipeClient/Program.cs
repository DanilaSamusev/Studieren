using System.IO;
using System.IO.Pipes;

namespace pipeClient
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				using (PipeStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, args[0]))
				{
					using (var pipeClientOut = new AnonymousPipeClientStream(PipeDirection.Out, args[1]))
					{
						string temp;

						using (var sr = new StreamReader(pipeClient))
						{
							do
							{
								temp = sr.ReadLine();
							}while (!temp.StartsWith(args[2]));
						}

						string[] stroke;
						stroke=temp.Split(',');
						int min = int.Parse(stroke[1]);

						for(int i=1;i<stroke.Length;i++)
						{
							if (int.Parse(stroke[i]) < min)
								min = int.Parse(stroke[i]);
						}

						using (var bw = new StreamWriter(pipeClientOut))
						{
							bw.AutoFlush = true;
							bw.WriteLine(min);
							pipeClientOut.WaitForPipeDrain();
						}
					}
				}
			}
		}
	}
}