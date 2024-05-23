using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Uzduotis
{
    public class Automobilis
    {
        string VIN {  get; set; }
        string Marke { get; set; }
        string Modelis { get; set; }    

        int Metai { get; set; }



        public Automobilis() 
        {

        }
        public Automobilis(string vin, string marke, string modelis, int metai)
        {
            VIN = vin;
            Marke = marke;
            Modelis = modelis;
            Metai = metai;
        }

        public string GetVin()
        {
            return VIN;
        }
        public string GetMarke()
        {
            return Marke;
        }

        public void SetMarke (string marke)
        {
            Marke = marke;
        }

        public string GetModelis()
        {
            return Modelis;
        }

        public void SetModelis (string modelis)
        {
            Modelis = modelis;
        }

        public int GetMetai()
        {
            return Metai;
        }
        public void SetMetai(int metai)
        {
            Metai = metai;
        }


        public override string ToString()
        {
            return $"VIN: {VIN} | Marke: {Marke} | Modelis: {Modelis} | Metai: {Metai}";
        }

    }
}
