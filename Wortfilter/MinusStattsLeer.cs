using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wortfilter
{
    class MinusStattsLeer : FilterDekorierer
    {
        public override string Filtern(string filter)
        {
            filter = base.Filtern(filter);
            var op = filter.Replace(" ", "-");
            return op;
        }

        public MinusStattsLeer(IFilter innerFilter) : base(innerFilter)
        {
        }

        public MinusStattsLeer() : base(null) { }
    }
}
