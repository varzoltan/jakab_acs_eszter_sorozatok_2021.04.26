using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace jakab_acs_eszter_sorozatok_2021._04._26
{
    class Program
    {
        struct Adat
        {
            public string datum;
            public string cim;
            public string epizod;
            public int hossz;
            public int megnezte;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[400];
            StreamReader olvas = new StreamReader(@"E:\OneDrive - Kisvárdai SZC Móricz Zsigmond Szakgimnáziuma és Szakközépiskolája\Oktatas\Programozas\Jakab_Acs_Eszter\Erettsegi_feladatok\2020-oktober\lista.txt");
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                adatok[n].datum = sor;
                string sor1 = olvas.ReadLine();
                adatok[n].cim = sor1;
                string sor2 = olvas.ReadLine();
                adatok[n].epizod = sor2;
                int sor3 = int.Parse(olvas.ReadLine());
                adatok[n].hossz = sor3;
                int sor4 = int.Parse(olvas.ReadLine());
                adatok[n].megnezte = sor4;
                n++;
            }
            olvas.Close();
            Console.WriteLine("1.feladat\nBeolvasás kész!");

            //2.feladat
            int db = 0;
            for (int i=0; i<n; i++)
            {
                if (adatok[i].datum != "NI")
                {
                    db++;
                }
            }
            Console.WriteLine($"2. feladat\nA listában {db} db vetítési dátummal rendelkező epizód van.");

            //3.feladat
            int latott = 0;
            for (int i =0; i<n;i++)
            {
                if (adatok[i].megnezte == 1)
                {
                    latott++;
                }
            }
            Console.WriteLine($"3.feladat\nA listában lévő epizódok {Math.Round((double)latott/n*100,2)}%-át látta");

            //4.feladat
            int osszes = 0;
            for (int i = 0; i<n;i++)
            {
                if (adatok[i].megnezte == 1)
                {
                    osszes += adatok[i].hossz;
                }
            }
            int nap = osszes / 1440;
            int maradek = osszes % 1440;
            int ora = maradek / 60;
            int perc = maradek % 60;
            Console.WriteLine("4.feladat");
            Console.WriteLine($"Sorozatnézéssel {nap} napot {ora} órát és {perc} percet töltött.");
            //Console.WriteLine(nap+" "+maradek+" "+ora+" "+perc);

            //5.feladat
            //Console.Write("Adjon meg egy dátumot! Dátum= ");
            //string datum = Console.ReadLine();


            //7.feladat
            Console.WriteLine("7.feladat");
            Console.Write("Adja meg a hét egy napját (például cs)! Nap= ");
            string rnap = Console.ReadLine();
            bool volt = false;
            int hany = 0;
            string cim1 = null, cim2 = null;
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].datum != "NI")
                {
                    string[] darab = adatok[i].datum.Split('.');
                    int ev = int.Parse(darab[0]);
                    int ho = int.Parse(darab[1]);
                    nap = int.Parse(darab[2]);
                    if (hetnapja(ev,ho,nap) == rnap)
                    {
                        volt = true;
                        hany++;
                        if (hany == 1)
                        {
                            cim1 = adatok[i].cim;
                        }          
                                                                    
                        if (hany == 2)
                        {                           
                            if (cim1 != cim2)
                            {
                                Console.WriteLine(cim1);
                            }
                            cim2 = cim1;
                            hany = 0;
                        }                      
                    }
                }              
            }
            if (!volt)
            {
                Console.WriteLine("Az adott napon nem kerül adásba sorozat.");
            }
            
            Console.ReadKey();
        }

        //6.feladat
        static string hetnapja (int ev, int ho, int nap)
        {
            string[] napok = { "v", "h", "k", "sze", "cs", "p", "szo" };
            int[] honapok = {0,3,2,5,0,3,5,1,4,6,2,4};
            if (ho<3)
            {
                ev = ev - 1;
            }
            return napok[(ev+ev/4-ev/100+ev/400+honapok[ho-1] +nap) % 7];
        }
        
    }
}
