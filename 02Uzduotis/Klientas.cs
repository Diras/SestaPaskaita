using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Uzduotis
{
    public class Klientas
    {
        int Id { get; set; }
        public string Vardas { get; set; }


        public Klientas() 
        {
        
        }

        public Klientas(string vardas, int id)
        {
            Vardas = vardas;
            Id = id;
        }

        public string GetVardas()
        {
            return Vardas;
        }

        public int GetID()
        {
           return Id;
        }

        public override string ToString()
        {
            return $"Klientas: {Vardas} | ID: {Id}";
        }
    }
}
