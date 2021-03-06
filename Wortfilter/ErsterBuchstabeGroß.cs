namespace Wortfilter
{
    class ErsterBuchstabeGroß : FilterDekorierer
    {
        public override string Filtern(string filter)
        {
            filter = base.Filtern(filter);
            var substring = filter.Substring(1);
            var stringGefiltert = filter[0].ToString().ToUpper();
            var erg = stringGefiltert + substring;
            return erg;
        }

        public ErsterBuchstabeGroß(IFilter innerFilter) : base(innerFilter)
        {
        }

        public ErsterBuchstabeGroß() :base(null)
        {
            
        }
    }
}