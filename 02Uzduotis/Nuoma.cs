using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Uzduotis
{
    public class Nuoma
    {
        Automobilis Automobilis { get; set; }
        bool Isnumotas { get; set; }
        DateTime NuomosPradzia { get; set; }
        DateTime NuomosPabaiga { get; set; }

        Klientas Klientas { get; set; }

        public Nuoma() 
        {
        
        }


        public Nuoma (Automobilis automobilis, bool isnuomotas)
        {
            Automobilis = automobilis;
            Isnumotas = isnuomotas; 
        }


        public Nuoma(Automobilis automobilis, bool isnuomotas, DateTime nuomosPradzia, DateTime nuomosPabaiga, Klientas klientas)
        {
            Automobilis = automobilis;
            Isnumotas = isnuomotas;
            NuomosPradzia = nuomosPradzia;
            NuomosPabaiga = nuomosPabaiga;
            Klientas = klientas;
        }

        public Automobilis GetAutomobilis()
        {
            return Automobilis;
        }

        public void SetAutomobilis(Automobilis automobilis)
        {
            Automobilis = automobilis;
        }

        public bool GetIsnumotas()
        {
            return Isnumotas;
        }

        public void SetIsnuomotas(bool isnumotas)
        {
            Isnumotas = isnumotas;
        }
        public DateTime GetNuomosPradzia()
        {
            return NuomosPradzia;
        }

        public void SetNuomosPradzia(DateTime nuomosPradzia)
        {
            NuomosPradzia= nuomosPradzia;
        }

        public DateTime GetNuomosPabaiga()
        {
            return NuomosPabaiga;
        }
        public void SetNuomosPabaiga(DateTime nuomosPabaiga)
        {
            NuomosPabaiga = nuomosPabaiga;
        }

        public Klientas GetKlientas()
        {
            return Klientas;
        }

        public void SetKlientas(Klientas klientas)
        {
            Klientas= klientas;
        }

        public override string ToString()
        {
            return $"{Automobilis} | Isnuomotas: {Isnumotas}";
        }

        public string ToStringSuKlientu()
        {
            return $"{Automobilis} | Isnuomotas: {Isnumotas} | Nuomos pradzia: {NuomosPradzia} | Klientas: {Klientas}";
        }
    }
}
