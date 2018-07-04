using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BInary_Academy_DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();
            Console.ReadLine();
        }
    }
}
