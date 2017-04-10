using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wortfilter
{
    abstract class FilterDekorierer : IFilter
    {
        protected IFilter InnerFilter { get; set; }

        public FilterDekorierer(IFilter innerFilter)
        {
            InnerFilter = innerFilter;
        }

        public virtual string Filtern(string text)
        {
            if (InnerFilter != null)
            {
                return InnerFilter.Filtern(text);
            }
            return text;
        }
    }
}
