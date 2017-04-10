namespace Wortfilter
{
    class ErsterBuchstabeGro� : FilterDekorierer
    {
        public override string Filtern(string filter)
        {
            filter = base.Filtern(filter);
            var substring = filter.Substring(1);
            var stringGefiltert = filter[0].ToString().ToUpper();
            var erg = stringGefiltert + substring;
            return erg;
        }

        public ErsterBuchstabeGro�(IFilter innerFilter) : base(innerFilter)
        {
        }

        public ErsterBuchstabeGro�() :base(null)
        {
            
        }
    }
}