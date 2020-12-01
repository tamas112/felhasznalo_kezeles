using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1144_200810_Felhasznalok
{
    class Program
    {
        struct ember
        {
            public string nev;
            public string jelszo;
            public string beosztas;

        }
        static List<ember> emberek = new List<ember>();
        static void Main(string[] args)
        {
            Console.Write("Név: ");
            string nev = Console.ReadLine();
            Console.Write("Jelszó: ");
            string jelszo = Console.ReadLine();
            StreamReader sr = new StreamReader("..\\..\\felhasznalok.txt");
            bool belepve = false;
            string beosztas = "";
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split('*');
                ember e = new ember();
                e.nev = sor[0];
                e.jelszo = sor[1];
                e.beosztas = sor[2];
                emberek.Add(e);
                if (nev == e.nev && jelszo == e.jelszo)
                {
                    belepve = true;
                    beosztas = e.beosztas;
                }
            }
            if (belepve)
            {
                Console.WriteLine("Sikres belépés");
                Console.WriteLine("Beosztás: " + beosztas);
                Console.Write("Milyen keresztneveket listázzunk: ");
                string keresztnev = Console.ReadLine();
                Console.WriteLine("A {0} keresztnevűek listája",keresztnev);
                foreach (var item in emberek)
                {
                    string n = item.nev;
                    string kn = n.Split(' ')[1];
                    if (kn == keresztnev)
                    {
                        Console.WriteLine(n);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sikertelen belépés");
            }
            Console.ReadKey();
        }
    }
}
