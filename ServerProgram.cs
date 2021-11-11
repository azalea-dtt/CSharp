using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeComm
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            var server = new NamedPipeServerStream("PipesOfPiece");
            Console.WriteLine("Server waiting...");
            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            while (true)
            {
                var line = reader.ReadLine();
                Console.WriteLine(line);
                writer.WriteLine(String.Join("", line.Reverse()));
                writer.Flush();
            }
        }
    }
}
