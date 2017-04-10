using System.Collections.Generic;

namespace Wortfilter
{
    public class MultiFilter : IFilter
    {
        public List<IFilter> Filter { get; set; }

        public MultiFilter(List<IFilter> filter)
        {
            Filter = filter;
        }

        public string Filtern(string zuFilternderString)
        {
            foreach (var filter in Filter)
            {
                zuFilternderString = filter.Filtern(zuFilternderString);
            }
            return zuFilternderString;
        }
    }
}