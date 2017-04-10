using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Wortfilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var eingabe = "hallo Welt";
            var filter = new WwwErgaenzen(2new ErsterBuchstabeGroß(new AllesKleinFilter(new MinusStattsLeer())));
            eingabe = filter.Filtern(eingabe);

            Console.WriteLine(eingabe);
            Console.ReadKey();
        }
    }
}
