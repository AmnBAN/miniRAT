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
            Start.Intro();
            if (Start.ParsInput(args) == false)
            {
                Console.WriteLine("Error in input args");
                Environment.Exit(0);
            }
            if(Connector.ConnectToServer(args)==true)
            {
                Console.WriteLine("after connect is OK");
            }
            
        }
    }
}
