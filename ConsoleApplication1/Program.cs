using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizza = new Käse(new Schinken(new SoßeHollandaise(new ClassicBoden())));

            Console.WriteLine("Kostet: "+pizza.GetPreis());
            Console.WriteLine("Beschreibung: "+pizza.GetBeschreibung());

            Console.ReadKey();
        }
    }

    public interface IZutat
    {
        decimal GetPreis();
        string GetBeschreibung();
    }

    public class ClassicBoden : IZutat
    {
        public decimal GetPreis()
        {
            return 4;
        }

        public string GetBeschreibung()
        {
            return "Klassische Pizza mit ";
        }
    }

    public abstract class ZutatenDekorierer : IZutat
    {
        protected IZutat _innereZutat;

        protected ZutatenDekorierer(IZutat innereZutat)
        {
            _innereZutat = innereZutat;
        }

        public virtual decimal GetPreis()
        {
            return _innereZutat?.GetPreis() ?? 0;
        }

        public virtual string GetBeschreibung()
        {
            return _innereZutat?.GetBeschreibung() ?? "";
        }
    }

    public class Tomatensoße : ZutatenDekorierer
    {
        public Tomatensoße(IZutat innereZutat) : base(innereZutat)
        {
        }

        public override decimal GetPreis()
        {
            var price = base.GetPreis();
            price += 1;
            return price;
        }

        public override string GetBeschreibung()
        {
            var beschreibung = base.GetBeschreibung();
            beschreibung += " Tomatensoße,";
            return beschreibung;
        }
    }
    public class SoßeHollandaise : ZutatenDekorierer
    {
        public SoßeHollandaise(IZutat innereZutat) : base(innereZutat)
        {
        }

        public override decimal GetPreis()
        {
            var price = base.GetPreis();
            price += 1;
            return price;
        }

        public override string GetBeschreibung()
        {
            var beschreibung = base.GetBeschreibung();
            beschreibung += " Hollandaise,";
            return beschreibung;
        }
    }

    public class Käse : ZutatenDekorierer
    {
        public Käse(IZutat innereZutat) : base(innereZutat)
        {
        }

        public override decimal GetPreis()
        {
            var price = base.GetPreis();
            price += 2;
            return price;
        }

        public override string GetBeschreibung()
        {
            var beschreibung = base.GetBeschreibung();
            beschreibung += " Käse,";
            return beschreibung;
        }
    }
    public class Schinken : ZutatenDekorierer
    {
        public Schinken(IZutat innereZutat) : base(innereZutat)
        {
        }

        public override decimal GetPreis()
        {
            var price = base.GetPreis();
            price += 2;
            return price;
        }

        public override string GetBeschreibung()
        {
            var beschreibung = base.GetBeschreibung();
            beschreibung += " Schinken,";
            return beschreibung;
        }
    }
}
