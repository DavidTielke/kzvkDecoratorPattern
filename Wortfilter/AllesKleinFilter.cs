using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wortfilter
{
    class AllesKleinFilter : FilterDekorierer
    {
        public override string Filtern(string filter)
        {
            filter = base.Filtern(filter);
            var gh = filter.ToLower();
            return gh;
        }

        public AllesKleinFilter(IFilter innerFilter) : base(innerFilter)
        {
        }

        public AllesKleinFilter() : base(null)
        {
            
        }
    }
}
