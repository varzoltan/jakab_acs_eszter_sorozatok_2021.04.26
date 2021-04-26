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
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Desktop\J_Eszter_prog_feladat\2020-oktober\lista.txt");
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

            Console.ReadKey();
        }
    }
}
