using _01Uzduotis;
using System;

namespace SestaPaskaita
{
    public class Uzduotis01
    {
        /*
         * Užduotis: Sukurti programą, kuri leis vartotojui įvesti filmų sąrašą ir jų reitingus, o po to atliks įvairias operacijas su šiais duomenimis.
            Užduoties Aprašymas:
            Sukurkite konsolinę programą, kuri leis vartotojui įvesti n filmų pavadinimus ir jų reitingus (nuo 1 iki 10).
            Duomenis saugokite sąraše ar masyve.
            Leiskite vartotojui pasirinkti iš meniu, ką jis nori atlikti su įvestais duomenimis:
            a. Rodyti visus filmus ir jų reitingus.
            b. Rodyti tik tuos filmus, kurių reitingas didesnis nei nurodyta vertė.
            c. Rasti filmą pagal pavadinimą ir parodyti jo reitingą.
            d. Atnaujinti filmo reitingą.
            e. Ištrinti filmą iš sąrašo.
            f. Išeiti iš programos.
         * */
        public static void Main(string[] args)
        {
            Filmas filmas = new Filmas();
            List<Filmas> filmuSarasas = new List<Filmas>();

            Console.WriteLine("Filmu valdymo programa 2024 Ver 0.1");
            Console.WriteLine("Paspauskite 1, kad ivesti nauja filma.");
            Console.WriteLine("Paspauskite 2, kad parodyti visus filmus ir jų reitingus.");
            Console.WriteLine("Paspauskite 3, kad tik tuos filmus, kurių reitingas didesnis nei nurodyta vertė.");
            Console.WriteLine("Paspauskite 4, kad rasti filmą pagal pavadinimą ir parodyti jo reitingą.");
            Console.WriteLine("Paspauskite 5, kad atnaujinti filmo reitingą.");
            Console.WriteLine("Paspauskite 6, kad ištrinti filmą iš sąrašo.");
            Console.WriteLine("Paspauskite 7, kad iseiti is programos.");


            int ivedimas = CheckInput(1, 7);

            while (ivedimas != 7)
            {
                switch (ivedimas)
                {
                    case 1:
                        IvestiNaujaFilma(filmuSarasas);
                        break;

                    case 2:
                        ParodytiVisusFilmus(filmuSarasas);
                        break;

                    case 3:
                        ParodytiFilmusSuDideliuReitingu(filmuSarasas);
                        break;

                    case 4:
                        RastiFilmaPagalPavadinima(filmuSarasas);
                        break;

                    case 5:
                        AtnaujintiFilmoReitinga(filmuSarasas);
                        break;

                    case 6:
                        IstrintiFilma(filmuSarasas);
                        break;

                    default:
                        
                        break;
                }
                Console.Clear();
                Console.WriteLine("Filmu valdymo programa 2024 Ver 0.1");
                Console.WriteLine("Paspauskite 1, kad ivesti nauja filma.");
                Console.WriteLine("Paspauskite 2, kad parodyti visus filmus ir jų reitingus.");
                Console.WriteLine("Paspauskite 3, kad tik tuos filmus, kurių reitingas didesnis nei nurodyta vertė.");
                Console.WriteLine("Paspauskite 4, kad rasti filmą pagal pavadinimą ir parodyti jo reitingą.");
                Console.WriteLine("Paspauskite 5, kad atnaujinti filmo reitingą.");
                Console.WriteLine("Paspauskite 6, kad ištrinti filmą iš sąrašo.");
                Console.WriteLine("Paspauskite 7, kad iseiti is programos.");

                ivedimas = CheckInput(0, 7);
            }
        }

        

        static int CheckInput(int nuo, int iki)
        {
            
            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number) && number >= nuo && number <= iki)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Neteisingas skaičius, pabandykite dar kartą!");
                }
            }
        }

        static void IvestiNaujaFilma(List<Filmas> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------:");
            int id = sarasas.Count + 1;
            string pavadinimas;
            int reitingas;

            Console.WriteLine("Iveskite filmo pavadinima");
            pavadinimas = Console.ReadLine();

            Console.WriteLine("Iveskite filmo reitinga nuo 0 iki 10");
            reitingas = CheckInput(0, 10);

            sarasas.Add(new Filmas (id, pavadinimas, reitingas));
            Console.WriteLine("Filmas pridetas!");
            Console.WriteLine("---------------------------------:");
        }

        static void ParodytiVisusFilmus(List<Filmas> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------:");
            foreach (Filmas filmas in sarasas)
            {
                Console.WriteLine(filmas.ToString());
            }
            Console.WriteLine("---------------------------------:");
        }

        static void ParodytiFilmusSuDideliuReitingu(List<Filmas> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------:");
            Console.WriteLine("Įveskite reitingo vertę nuo 1 iki 10:");
            int reitingas = CheckInput(0, 10);

            foreach (Filmas filmas in sarasas)
            {
                if (filmas.Reitingas > reitingas)
                {
                    Console.WriteLine(filmas.ToString());
                }
            }
            Console.WriteLine("---------------------------------:");
        }

        static void RastiFilmaPagalPavadinima(List<Filmas> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------:");
            Console.WriteLine("Įveskite filmo pavadinimą:");
            string pavadinimas = Console.ReadLine();
            int rastiFilmai = 0;

            foreach (Filmas filmas in sarasas)
            {
                if (filmas.Pavadinimas.ToLower() == pavadinimas.ToLower())
                {
                    Console.WriteLine(filmas.ToString());
                    rastiFilmai++;
                }
            }
            
            if (rastiFilmai == 0)
            {
                Console.WriteLine("Filmas nerastas.");
            }
            Console.WriteLine("---------------------------------:");
        }

        static void AtnaujintiFilmoReitinga(List<Filmas> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------:");
            ParodytiVisusFilmus(sarasas);
            Console.WriteLine("---------------------------------:");
            Console.WriteLine("Iveskite filmo Id kuri norite redagoti:");

            int number = 0;
            number = CheckInput(1, sarasas.Count-1);

            Console.WriteLine("Iveskite nauja reitinga nuo 0 iki 10:");
            int reitingas = CheckInput(1, 10);

            foreach (Filmas filmas in sarasas)
            {
                if(filmas.Id == number)
                {
                    filmas.Reitingas = reitingas;
                    Console.WriteLine("Reitingas sekmingai pakeistas!");
                    Console.WriteLine("---------------------------------:");
                    break;
                }    
            }
            Console.WriteLine("---------------------------------:");

        }

        static void IstrintiFilma(List<Filmas> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------:");
            ParodytiVisusFilmus(sarasas);
            Console.WriteLine("---------------------------------:");
            Console.WriteLine("Iveskite filmo Id kuri norite istrinti:");

            int number = 0;
            number = CheckInput(1, sarasas.Count-1);

            foreach (Filmas filmas in sarasas)
            {
                if (filmas.Id == number)
                {
                    sarasas.Remove(filmas);
                    Console.WriteLine("Filmas sekmingai pasalintas!");

                    break;
                }
            }
            if (number > 0)
            {
                for (int i = number - 1; i < sarasas.Count; i++)
                {
                    sarasas[i].Id =  i + 1;
                }
            }
            Console.WriteLine("---------------------------------:");
        }
    }
}