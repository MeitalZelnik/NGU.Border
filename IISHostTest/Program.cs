using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISHostTest
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Tester _tester = new Tester();
            _tester.SaveFingerprints();
            Console.ReadLine();
        }
    }
}
