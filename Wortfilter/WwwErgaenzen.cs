using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wortfilter
{
    class WwwErgaenzen : FilterDekorierer
    {
        public WwwErgaenzen(IFilter innerFilter) : base(innerFilter)
        {
        }

        public override string Filtern(string text)
        {
            text = base.Filtern(text);
            text = "www." + text + ".de";
            return text;
        }

        public WwwErgaenzen() : base(null) { }
    }
}
