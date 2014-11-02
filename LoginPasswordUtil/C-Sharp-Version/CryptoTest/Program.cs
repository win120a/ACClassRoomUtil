using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPU_Crypt_API;

namespace TestCrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            MixCrypt mc = new MixCrypt();
            String cs = mc.encrypt(".", "C8MG2");
            Console.WriteLine(cs);
            Console.WriteLine(mc.decrypt(cs, "C8MG2"));
            Console.ReadLine();
        }
    }
}
