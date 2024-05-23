using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace _02Uzduotis
{
    public class DarbasSuTextu
    {
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private readonly string _failoVieta;

        public DarbasSuTextu( string failoVieta)
        {
            _failoVieta = failoVieta;
        }


        public void KlientaiIFaila(List<Klientas> sarasas)
        {
            _streamWriter = new StreamWriter(_failoVieta);
            foreach (Klientas klientas in sarasas)
            {
                _streamWriter.WriteLine($"{klientas.GetVardas()},{klientas.GetID()}");
            }
            _streamWriter.Close();
        }

        public List<Klientas> KlientaiISFailo()
        {
            List<Klientas> newSarasas = new List<Klientas>();

            if (!File.Exists(_failoVieta))
            {
                Console.WriteLine("Failas nerastas. Grąžinamas tuščias sąrašas.");
                return newSarasas;
            }

            _streamReader = new StreamReader(_failoVieta);
            string eilute;

            while ((eilute = _streamReader.ReadLine()) != null)
            {
                string[] reiksmes = eilute.Split(',');
                newSarasas.Add(new Klientas(reiksmes[0], int.Parse(reiksmes[1])));
            }
            _streamReader.Close();
            return newSarasas;
        }


        public void AutomobiliaiIFaila(List<Automobilis> sarasas)
        {
            _streamWriter = new StreamWriter(_failoVieta);
            foreach (Automobilis auto in sarasas)
            {
                _streamWriter.WriteLine($"{auto.GetVin()},{auto.GetModelis()},{auto.GetMarke()},{auto.GetMetai()}");
            }
            _streamWriter.Close();
        }


        public List<Automobilis> AutomobiliaiISFailo()
        {
            List<Automobilis> newSarasas = new List<Automobilis>();

            if (!File.Exists(_failoVieta))
            {
                Console.WriteLine("Failas nerastas. Grąžinamas tuščias sąrašas.");
                return newSarasas;
            }

            _streamReader = new StreamReader(_failoVieta);
            string eilute;

            while ((eilute = _streamReader.ReadLine()) != null)
            {
                string[] reiksmes = eilute.Split(',');
                newSarasas.Add(new Automobilis(reiksmes[0], reiksmes[1], reiksmes[2], int.Parse(reiksmes[3])));
            }
            _streamReader.Close();
            return newSarasas;
        }


        public void NuomaIFaila(List<Nuoma> sarasas)
        {
            _streamWriter = new StreamWriter(_failoVieta);
            foreach (Nuoma objektas in sarasas)
            {
                string automobilisInfo = $"{objektas.GetAutomobilis().GetVin()},{objektas.GetAutomobilis().GetMarke()},{objektas.GetAutomobilis().GetModelis()},{objektas.GetAutomobilis().GetMetai()}";
                string klientasInfo = $"{objektas.GetKlientas().GetVardas()},{objektas.GetKlientas().GetID()}";
                string nuomosPradzia = objektas.GetNuomosPradzia().ToString("yyyy-MM-dd");
                string nuomosPabaiga = objektas.GetNuomosPabaiga().ToString("yyyy-MM-dd");

                _streamWriter.WriteLine($"{automobilisInfo},{objektas.GetIsnumotas()},{nuomosPradzia},{nuomosPabaiga},{klientasInfo}");
            }
            _streamWriter.Close();
        }


        public List<Nuoma> NuomaISFailo()
        {
            List<Nuoma> newSarasas = new List<Nuoma>();

            if (!File.Exists(_failoVieta))
            {
                Console.WriteLine("Failas nerastas. Grąžinamas tuščias sąrašas.");
                return newSarasas;
            }

            _streamReader = new StreamReader(_failoVieta);
            string eilute;
            while ((eilute = _streamReader.ReadLine()) != null)
            {
                string[] reiksmes = eilute.Split(',');

                string[] automobilioInfo = reiksmes[0].Split('|');
                Automobilis automobilis = new Automobilis(automobilioInfo[0], automobilioInfo[1], automobilioInfo[2], int.Parse(automobilioInfo[3]));

                bool isnumotas = bool.Parse(reiksmes[1]);

                DateTime nuomosPradzia = DateTime.ParseExact(reiksmes[2], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime nuomosPabaiga = DateTime.ParseExact(reiksmes[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                string[] klientoInfo = reiksmes[4].Split('|');
                Klientas klientas = new Klientas(klientoInfo[0], int.Parse(klientoInfo[1]));

                Nuoma nuoma = new Nuoma(automobilis, isnumotas, nuomosPradzia, nuomosPabaiga, klientas);
                newSarasas.Add(nuoma);
            }
            _streamReader.Close();
            return newSarasas;
        }
    }
}
