using _02Uzduotis;
using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace SestaPaskaita
{
    public class Uzduotis02
    {
        /*
         * Užduotis: Sukurti programą, kuri leis vartotojams valdyti automobilių nuomos sistemą, įskaitant automobilių pridėjimą, nuomą, grąžinimą ir paiešką.
            Užduoties Aprašymas:
            Sukurkite konsolinę programą, kurioje bus naudojami sąrašai ir masyvai automobiliams ir klientams saugoti.
            Programa turėtų leisti:
            Pridėti naują automobilį į nuomos sistemą su unikaliu automobilio identifikaciniu numeriu (VIN), marke, modeliu, metais ir bendru egzempliorių skaičiumi.
            Redaguoti automobilio informaciją (markę, modelį, metus, bendrą egzempliorių skaičių).
            Paieškoti automobilių pagal VIN, markę ar modelį.
            Rodyti visą automobilių nuomos katalogą su informacija apie kiekvieną automobilį (VIN, markė, modelis, metai, prieinamas egzempliorių skaičius).
            Nuomoti automobilį klientui (klientas turi turėti ID ir vardą).
            Grąžinti automobilį į nuomos sistemą.
            Rodyti visus nuomotus automobilius ir informaciją apie juos (kliento ID, vardą, automobilio VIN, nuomos pradžios datą).
            Ištrinti automobilį iš sistemos (tik jei automobilis nėra nuomojamas).
            Reikalavimai:
            Automobilių sąrašas turėtų būti dinamiškas (naudoti sąrašus).
            Kiekvienas automobilis turi turėti unikalų VIN.
            Nuomos metu patikrinti, ar automobilis yra prieinamas.
            Naudoti ciklus ir sąlygas duomenų tikrinimui ir operacijoms atlikti.
            Naudoti switch teiginį meniu veiksmams pasirinkti.
            Papildomi reikalavimai:
            Užtikrinti, kad vienas automobilis negali būti nuomojamas daugiau nei vienam klientui vienu metu.
            Leisti vartotojui ieškoti automobilių pagal įvairius kriterijus (VIN, markę, modelį, metus).
            Leisti atnaujinti automobilio informaciją (markę, modelį, metus, bendrą egzempliorių skaičių).
            Registruoti nuomos pradžios ir pabaigos datas.
            9:12
            Meniu pavyzdys:
            Pridėti automobilį
            Redaguoti automobilio informaciją
            Paieškoti automobilio
            Rodyti visus automobilius
            Nuomoti automobilį
            Grąžinti automobilį
            Rodyti visus nuomotus automobilius
            Ištrinti automobilį
            Išeiti iš programos
         * */
        public static void Main(string[] args)
        {
            string failoVietaKlientu = "KlientuSarasas.txt";
            string failoVietaAutomobiliu = "AutomobiliuSarasas.txt";
            string failoVietaNuomos = "NuomosSarasas.txt";

            Automobilis automobilis = new Automobilis();
            Klientas klientas = new Klientas();
            Nuoma nuoma = new Nuoma();

            List<Automobilis> automobiliuSarasas = new List<Automobilis>();
            List<Klientas> klientuSarasas = new List<Klientas>();
            List<Nuoma> nuomosSarasas = new List<Nuoma>();

            DarbasSuTextu darbasSuKlientaisText = new DarbasSuTextu(failoVietaKlientu);
            DarbasSuTextu darbasSuAutomobiliaisText = new DarbasSuTextu(failoVietaAutomobiliu);
            DarbasSuTextu darbasSuNuomaText = new DarbasSuTextu(failoVietaNuomos);
            /*
                        klientuSarasas.Add(new Klientas("Ernestas", 19900217));
                        klientuSarasas.Add(new Klientas("Vardenis", 20001224));
                        klientuSarasas.Add(new Klientas("Pavardenis", 19980325));

                        darbasSuTextu.KlientaiIFaila(klientuSarasas);
            */
            klientuSarasas = darbasSuKlientaisText.KlientaiISFailo();

            
            automobiliuSarasas = darbasSuAutomobiliaisText.AutomobiliaiISFailo();
            nuomosSarasas = darbasSuNuomaText.NuomaISFailo();



                Console.WriteLine("Automobiliu nuomos programa 2024 Ver 0.1");
            Console.WriteLine("Paspauskite 1, kad pridėti automobilį.");
            Console.WriteLine("Paspauskite 2, kad redaguoti automobilio informaciją.");
            Console.WriteLine("Paspauskite 3, kad paieškoti automobilio.");
            Console.WriteLine("Paspauskite 4, kad parodyti visus automobilius ir nuomos informacija");
            Console.WriteLine("Paspauskite 5, kad nuomoti automobilį");
            Console.WriteLine("Paspauskite 6, kad grąžinti automobilį.");
            Console.WriteLine("Paspauskite 7, kad parodyti visus nuomotus automobilius.");
            Console.WriteLine("Paspauskite 8, kad ištrinti automobilį.");
            Console.WriteLine("Paspauskite 9, kad išeiti iš programos.");


            int ivedimas = CheckInput(1, 9);

            while (ivedimas != 9)
            {
                switch (ivedimas)
                {
                    case 1:
                        PridetiAutomobili(automobiliuSarasas);
                        darbasSuAutomobiliaisText.AutomobiliaiIFaila(automobiliuSarasas);
                        break;

                    case 2:
                        RedaguotiAutomobilioInformacija(automobiliuSarasas);
                        break;

                    case 3:
                        PaieskotiAutomobilio(automobiliuSarasas);
                        break;

                    case 4:
                        ParodytiVisusAutomobiliusIrNuomosInfo(automobiliuSarasas, nuomosSarasas);
                        break;

                    case 5:
                        NuomotiAutomobili(nuomosSarasas, klientuSarasas);
                        break;

                    case 6:
                        GrazintiAutomobili(nuomosSarasas);
                        break;

                    case 7:
                        ParodytiVisusNuomotusAutomobilius(nuomosSarasas);
                        break;

                    case 8:
                        IstrintiAutomobili(nuomosSarasas, automobiliuSarasas);
                        break;

                    default:
                        
                        break;
                }


                Console.WriteLine("---------------------------------");
                Console.WriteLine("Automobiliu nuomos programa 2024 Ver 0.1");
                Console.WriteLine("Paspauskite 1, kad pridėti automobilį.");
                Console.WriteLine("Paspauskite 2, kad redaguoti automobilio informaciją.");
                Console.WriteLine("Paspauskite 3, kad paieškoti automobilio.");
                Console.WriteLine("Paspauskite 4, kad parodyti visus automobilius ir nuomos informacija");
                Console.WriteLine("Paspauskite 5, kad nuomoti automobilį");
                Console.WriteLine("Paspauskite 6, kad grąžinti automobilį.");
                Console.WriteLine("Paspauskite 7, kad parodyti visus nuomotus automobilius.");
                Console.WriteLine("Paspauskite 8, kad ištrinti automobilį.");
                Console.WriteLine("Paspauskite 9, kad išeiti iš programos.");


                ivedimas = CheckInput(1, 9);
            }
        }

        static int CheckInput()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Neteisingas skaicius, pabandykite dar karta!");
            }
            return number;
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
                    Console.WriteLine("Neteisingas skaicius, pabandykite dar karta!");
                }
            }
        }

        static void PridetiAutomobili(List<Automobilis> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Iveskite automobilio marke:");
            string marke = Console.ReadLine();
            Console.WriteLine("Iveskite automobilio modeli:");
            string modelis = Console.ReadLine();
            Console.WriteLine("Iveskite automobilio metus nuo 1900 iki 2024:");
            int metai = CheckInput(1900, 2024);
            Console.WriteLine("Iveskite automobilio VIN numeri:");
            string vin = Console.ReadLine();

            bool autoSaraseYra = false;

            if (sarasas.Count > 0)
            {
                foreach (Automobilis auto in sarasas)
                {
                    if (auto.GetVin().ToLower() == vin.ToLower())
                    {
                        autoSaraseYra = true;
                        break;
                    }
                }
            }

            if (autoSaraseYra)
            {
                Console.WriteLine("Automobilis su tokiu VIN kodu jau yra!");
                Console.WriteLine("Bandykite is naujo!");
            }
            else
            {
                sarasas.Add(new Automobilis(vin, marke, modelis, metai));
                Console.WriteLine("Automobilis sekmingai pridetas!");
            }

            

            Console.WriteLine("---------------------------------");
        }


        static void RedaguotiAutomobilioInformacija(List<Automobilis> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            
            if(sarasas.Count > 0)
            {
                Console.WriteLine("Automobiliu sarasas:");
                foreach (Automobilis auto in sarasas)
                {
                    Console.WriteLine(auto.ToString());
                }
            }
            else
            {
                Console.WriteLine("Automobiliu sarase siuo metu nera!");
            }

            Console.WriteLine("---------------------------------");

            Console.WriteLine("Įveskite automobilio VIN koda kuri norite redaguoti:");
            string vin = Console.ReadLine();

            if (sarasas.Count > 0)
            {
                foreach (Automobilis auto in sarasas)
                {
                    if (auto.GetVin().ToLower() == vin.ToLower())
                    {
                        Console.WriteLine(auto.ToString());
                        Console.WriteLine("Kokia auto informacija norite pakeisti:");
                        Console.WriteLine("Paspauskite 1, kad pakeisti marke.");
                        Console.WriteLine("Paspauskite 2, kad pakeisti modeli.");
                        Console.WriteLine("Paspauskite 3, kad pakeisti metus.");
                        Console.WriteLine("Paspauskite 4, kad baigti redagavima.");

                        int variantas = CheckInput(1, 4);

                        while (variantas != 4)
                        {
                            switch (variantas)
                            {
                                case 1:
                                    Console.WriteLine("Iveskite nauja marke...");
                                    string newMarke = Console.ReadLine();
                                    auto.SetMarke(newMarke);
                                    break;

                                case 2:
                                    Console.WriteLine("Iveskite nauja modeli...");
                                    string newModelis = Console.ReadLine();
                                    auto.SetModelis(newModelis);
                                    break;

                                case 3:
                                    Console.WriteLine("Iveskite naujus metus nuo 1900 iki 2024...");
                                    int newMetai = CheckInput(1900, 2024);
                                    auto.SetMetai(newMetai);
                                    break;

                                default:

                                    break;

                            }
                            Console.Clear();
                            Console.WriteLine("---------------------------------");
                            Console.WriteLine(auto.ToString());
                            Console.WriteLine("Kokia auto informacija norite pakeisti:");
                            Console.WriteLine("Paspauskite 1, kad pakeisti marke.");
                            Console.WriteLine("Paspauskite 2, kad pakeisti modeli.");
                            Console.WriteLine("Paspauskite 3, kad pakeisti metus.");
                            Console.WriteLine("Paspauskite 4, kad baigti redagavima.");

                            variantas = CheckInput(1, 4);

                        }
                    }
                    else
                    {
                        Console.WriteLine("Automobilio su tokiu vin nera!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Automobiliu sarase siuo metu nera!");
            }
        }

        static void PaieskotiAutomobilio(List<Automobilis> sarasas)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");

            if (sarasas.Count > 0)
            {
                Console.WriteLine("Pagal ka norite surasti automobili:");
                Console.WriteLine("Paspauskite 1, kad surastti pagal VIN numeri.");
                Console.WriteLine("Paspauskite 2, kad surasti pagal Marke.");
                Console.WriteLine("Paspauskite 3, kad surasti pagal Modeli.");
                Console.WriteLine("Paspauskite 4, kad baigti.");

                int variantas = CheckInput(1, 4);

                while (variantas != 4)
                {
                    switch (variantas)
                    {
                        case 1:
                            Console.WriteLine("Iveskite automobilio VIN koda...");
                            string vin = Console.ReadLine();
                            int countVIN = 0;
                            foreach (Automobilis auto in sarasas)
                            {
                                if (auto.GetVin().ToLower() == vin.ToLower())
                                {
                                    Console.WriteLine(auto.ToString());
                                    countVIN++;
                                }
                            }
                            if(countVIN == 0)
                            {
                                Console.WriteLine("Automobiliu su tokiu VIN numeriu nerasta!");
                            }
                            
                            break;

                        case 2:
                            Console.WriteLine("Iveskite automobilio Marke...");
                            string marke = Console.ReadLine();
                            int countMarke = 0;
                            foreach (Automobilis auto in sarasas)
                            {
                                if (auto.GetMarke().ToLower() == marke.ToLower())
                                {
                                    Console.WriteLine(auto.ToString());
                                    countMarke++;
                                }
                            }
                            if (countMarke == 0)
                            {
                                Console.WriteLine("Automobiliu tokios Markes nerasta!");
                            }

                            break;

                        case 3:
                            Console.WriteLine("Iveskite automobilio Modeli...");
                            string modelis = Console.ReadLine();
                            int countModelis = 0;
                            foreach (Automobilis auto in sarasas)
                            {
                                if (auto.GetModelis().ToLower() == modelis.ToLower())
                                {
                                    Console.WriteLine(auto.ToString());
                                    countModelis++;
                                }
                            }
                            if (countModelis == 0)
                            {
                                Console.WriteLine("Automobiliu tokio Modelio nerasta!");
                            }

                            break;

                        default:

                            break;

                    }
                    
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Pagal ka norite surasti automobili:");
                    Console.WriteLine("Paspauskite 1, kad surastti pagal VIN numeri.");
                    Console.WriteLine("Paspauskite 2, kad surasti pagal Marke.");
                    Console.WriteLine("Paspauskite 3, kad surasti pagal Modeli.");
                    Console.WriteLine("Paspauskite 4, kad baigti.");

                    variantas = CheckInput(1, 4);

                }
            }
            else
            {
                Console.WriteLine("Automobiliu sarase siuo metu nera!");
            }
        }


        static void ParodytiVisusAutomobiliusIrNuomosInfo(List<Automobilis> sarasasAuto, List<Nuoma> sarasasNuomos)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");

            if(sarasasNuomos.Count == 0)
            {
                foreach (Automobilis auto in sarasasAuto)
                {
                    sarasasNuomos.Add(new Nuoma(auto, false));
                }
            }
            else
            {
                foreach (Automobilis auto in sarasasAuto)
                {
                    bool toksYra = false;

                    foreach (Nuoma objektas in sarasasNuomos)
                    {
                        if (objektas.GetAutomobilis().GetVin() == auto.GetVin())
                        {
                            toksYra = true;
                            break;
                        }
                    }

                    if (!toksYra)
                    {
                        sarasasNuomos.Add(new Nuoma(auto, false));
                    }
                }
            }

            foreach (Nuoma objektas in sarasasNuomos)
            {
                Console.WriteLine(objektas.ToString());
            }

            
        }

        static void NuomotiAutomobili(List<Nuoma> sarasasNuomos, List<Klientas> sarasasKlientu)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            if(sarasasKlientu.Count == 0)
            {
                Console.WriteLine("Klientu kurie gali isnuomoti automobili siuo metu nera!");
            }
            else
            {
                foreach (Klientas klientas in sarasasKlientu)
                {
                    Console.WriteLine(klientas.ToString());
                }

                Console.WriteLine("---------------------------------");
                Console.WriteLine("Iveskite kliento Id kuris nori isnuomoti...");
                int id = CheckInput();
                bool galimaNuoma = false;
                Klientas klientas1 = new Klientas();
                foreach (Klientas klientas in sarasasKlientu)
                {
                    if (klientas.GetID() == id)
                    {
                        galimaNuoma = true;
                        klientas1 = klientas;
                    }
                }

                if (galimaNuoma)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Neisnuomotu automobiliu sarasas:");
                    foreach (Nuoma objektas in sarasasNuomos)
                    {
                        if (objektas.GetIsnumotas() == false)
                        {
                            Console.WriteLine(objektas.ToString());
                        }
                    }
                    Console.WriteLine("---------------------------------");

                    Console.WriteLine("Iveskite automobilio VIN, kuri norite issinuomoti:");
                    string vin = Console.ReadLine();

                    foreach (Nuoma objektas in sarasasNuomos)
                    {
                        if (objektas.GetAutomobilis().GetVin() == vin)
                        {
                            objektas.SetIsnuomotas(true);
                            objektas.SetNuomosPradzia(DateTime.Now);
                            objektas.SetKlientas(klientas1);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Klientas nerastas, nuoma negalima!");
                }
            }
        }

        static void GrazintiAutomobili(List<Nuoma> sarasasNuomos)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Isnuomotu automobiliu sarasas:");
            foreach (Nuoma objektas in sarasasNuomos)
            {
                if (objektas.GetIsnumotas() == true)
                {
                    Console.WriteLine(objektas.ToString());
                }
            }
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Įveskite automobilio VIN, kurį norite grąžinti...");
            string vin = Console.ReadLine();
            bool grazintas = false;
            foreach (Nuoma objektas in sarasasNuomos)
            {
                if (objektas.GetIsnumotas() == true)
                {
                    if(objektas.GetAutomobilis().GetVin() == vin)
                    {
                        objektas.SetIsnuomotas(false);
                        objektas.SetKlientas(null);
                        grazintas = true;
                        Console.WriteLine("Automobilis sekmingai grazintas!");
                    }
                    
                }
            }
            if (!grazintas)
            {
                Console.WriteLine("VIN numeris ivestas neteisingai!");
            }
        }

        static void ParodytiVisusNuomotusAutomobilius(List<Nuoma> sarasasNuomos)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Siuo metu isnuomoti automobiliai:");

            if(sarasasNuomos.Count == 0)
            {
                Console.WriteLine("Sarasas tuscias!");
                return;
            }

            foreach (Nuoma objektas in sarasasNuomos)
            {
                if (objektas.GetIsnumotas() == true)
                {
                    Console.WriteLine(objektas.ToStringSuKlientu());
                }
            }
        }

        static void IstrintiAutomobili(List<Nuoma> sarasasNuomos, List<Automobilis> sarasasAuto)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Automobilių sąrašas:");
            foreach (Automobilis auto in sarasasAuto)
            {
                Console.WriteLine(auto.ToString());
            }
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Įveskite automobilio VIN kodą, kurį norite pašalinti iš sistemos...");
            string vin = Console.ReadLine();
            bool pasalintas = false;

            
            foreach (Nuoma objektas in sarasasNuomos)
            {
                if (objektas.GetAutomobilis().GetVin().ToLower() == vin.ToLower())
                {
                    if (objektas.GetIsnumotas() == true)
                    {
                        Console.WriteLine("Automobilis negali būti pašalintas, šiuo metu yra išnuomotas!");
                        pasalintas = true;
                        return;
                    }
                }
            }

            
            for (int i = 0; i < sarasasNuomos.Count; i++)
            {
                if (sarasasNuomos[i].GetAutomobilis().GetVin().ToLower() == vin.ToLower())
                {
                    sarasasNuomos.RemoveAt(i);
                }
            }

            for (int i = 0; i < sarasasAuto.Count; i++)
            {
                if (sarasasAuto[i].GetVin().ToLower() == vin.ToLower())
                {
                    sarasasAuto.RemoveAt(i);
                    Console.WriteLine("Automobilis sekmingai pasalintas!");
                    pasalintas = true;
                }
            }

            if (!pasalintas)
            {
                Console.WriteLine("VIN kodas nerastas!");
            }
        }


        
    }
}