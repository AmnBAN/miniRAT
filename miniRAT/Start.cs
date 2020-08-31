using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace miniRAT
{
    /// <summary>
    /// Display intro message and pars input arguments
    /// </summary>
    class Start
    {
        public static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Keep CALM miniRAT begins!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ResetColor();
            Console.WriteLine(ConfigurationManager.AppSettings["GUIDKEY"]);
        }
        /// <summary>
        /// Pars input arguments,
        /// </summary>
        /// <param name="args">user arguments</param>
        public static Boolean ParsInput(string [] args)
        {
            if (args.Length < 2)
               return false;

            //args= ip|URL port

            //Check port arguments
            if (int.TryParse(args[1], out int port) == false)
                return false;
            if (port < 1)
                return false;

            return true;
        }
    }
}
