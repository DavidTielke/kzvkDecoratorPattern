using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bestellanwendung
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("SPEISEKARTE\n");
            Console.WriteLine("1.   Pizza Mageritha");
            Console.WriteLine("2.   Pizza Salami");
            Console.WriteLine("3.   Pizza Funghi");
            Console.WriteLine("4.   Pizza Spezial");
            Console.WriteLine("5.   Spagetti Bolognese");
            Console.WriteLine("6.   Spagetti Napoli");
            Console.WriteLine("7.   Spagetti Cabonara");
            var zahl = Convert.ToInt32(Console.ReadLine());
            var kellner = Kellner.GetInstance();
            kellner.BestelleUndLiefere(3);
            IZutat pizza = SpeiseFactory.Create(zahl);
            Console.WriteLine("Ihr Gericht kostet: " + pizza.GetPreis());
            Console.WriteLine("Sie haben eine: " + pizza.GetBeschreibung() + " bestellt.");
            Console.ReadKey();
        }
    }
    public class Kellner
    {
        private static Kellner _singleton;

        private Kellner(){}

        public static Kellner GetInstance()
        {
            if (_singleton == null)
            {
                _singleton = new Kellner();
            }
            return _singleton;
        }
        public IZutat BestelleUndLiefere(int zahl)
        {
            var bestellung = SpeiseFactory.Create(zahl);
            return bestellung;
        }
    }

    public static class SpeiseFactory
    {
        public static IZutat Create(int zahl)
        {
            switch (zahl)
            {
                case 1:
                    return new Tomatensoße(new Käse(new ClassicBoden()));
                case 2:
                    return new Tomatensoße(new Käse(new Salami(new ClassicBoden())));
                case 3:
                    return new Tomatensoße(new Käse(new Schinken(new ClassicBoden())));
                case 4:
                    return new Tomatensoße(new Käse(new Schinken(new Pilz(new ClassicBoden()))));
                case 5:
                    return new Tomatensoße(new Hackfleisch(new ClassicNudeln()));
                case 6:
                    return new Tomatensoße(new ClassicNudeln());
                case 7:
                    return new Sahnesoße(new Schinken(new ClassicNudeln()));
                default:
                    throw new ArgumentException("Gericht nicht gefunden, probieren Sie es bei Burger King.");
            }
            
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

    public class ClassicNudeln : IZutat
    {
        public decimal GetPreis()
        {
            return 3.50M;
        }

        public string GetBeschreibung()
        {
            return "Klassische Nudeln mit ";
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

    public class Pilz : ZutatenDekorierer
    {
        public Pilz(IZutat innereZutat) : base(innereZutat)
        {
        }

        public override decimal GetPreis()
        {
            var price = base.GetPreis();
            price += 0.50M;
            return price;
        }
    }

    public class Hackfleisch : ZutatenDekorierer
    {
        public Hackfleisch(IZutat innereZutat) : base(innereZutat)
        {
        }

        public override decimal GetPreis()
        {
            var price = base.GetPreis();
            price += 1.50M;
            return price;
        }
    }

    public class Salami : ZutatenDekorierer
    {
        public Salami(IZutat innereZutat) : base(innereZutat)
        {
        }

        public override decimal GetPreis()
        {
            var price = base.GetPreis();
            price += 1.5M;
            return price;
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

    public class Sahnesoße : ZutatenDekorierer
    {
        public Sahnesoße(IZutat innereZutat) : base(innereZutat)
        {
        }

        public override decimal GetPreis()
        {
            var price = base.GetPreis();
            price += 1;
            return price;
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
