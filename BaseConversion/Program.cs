using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConversion
{
    class Program
    {
        static void Main(string[] args) {

            //Author : Fifo
            //Last commit : 21. March 2020


            Console.Write("Write a number to convert : ");
            string input = Console.ReadLine();

            Console.Write("Write a base from convert : ");
            int curBase = int.Parse(Console.ReadLine());

            Console.WriteLine("Output : " + BaseConvert.To10Unsigned(input, curBase));


            Console.ReadKey(true);

        }
    }
}
