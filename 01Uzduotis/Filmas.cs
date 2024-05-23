using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Uzduotis
{
    internal class Filmas
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public int Reitingas { get; set; }

        public Filmas() 
        {
        
        }

        public Filmas(int id, string pavadinimas, int reitingas)
        {
            Id = id;
            Pavadinimas = pavadinimas;
            Reitingas = reitingas;
        }
        

        public override string ToString()
        {
            return $"Id: {Id}, pavadinimas: {Pavadinimas}, reitingas: {Reitingas}";
        }
    }
}
