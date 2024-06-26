﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allat1
{
    class Allat
    {
        private string nev;
        private int szuletesiEv;
        private int oltIgazolasSzam;
        public int sorszam = 0;

        private int szepsegPont, viselkedesPont;
        private int pontSzam;

        private static int aktualisEv;
        private static int korHatar;

        public Allat(string nev, int szuletesiEv, int oltIgazolasSzam)
        {
            this.nev = nev;
            this.szuletesiEv = szuletesiEv;
            this.oltIgazolasSzam = oltIgazolasSzam;
        }

        public int Kor()
        {
            return aktualisEv - szuletesiEv;
        }

        public void Pontozzak(int szepsegPont, int viselkedesPont)
        {
            this.szepsegPont = szepsegPont;
            this.viselkedesPont = viselkedesPont;
        }

        public int PontSzam()
        {
            if (Kor() <= korHatar)
            {
                return viselkedesPont * Kor() + szepsegPont * (korHatar - Kor());
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return nev + " sorszám: " + sorszam + " pontszáma: " + pontSzam + " pont";
        }

        public string Nev
        {
            get { return nev; }
        }

        public int SzuletesiEv
        {
            get { return szuletesiEv; }
        }

        public int OltIgazolasSzam
        {
            get { return oltIgazolasSzam; }
        }

        public int SzepsegPont
        {
            get { return szepsegPont; }
        }

        public int ViselkedesPont
        {
            get { return viselkedesPont; }
        }

        public static int AktualisEv
        {
            get { return aktualisEv; }
            set { aktualisEv = value; }
        }

        public static int KorHatar
        {
            get { return korHatar; }
            set { korHatar = value; }
        }

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            int aktEv = 2024, korhatar = 10;

            Allat.AktualisEv = aktEv;
            Allat.KorHatar = korhatar;

            AllatVerseny();

            Console.ReadKey();

        }

        private static void AllatVerseny()
        {
            Allat allat;

            string nev;
            int szulEv;
            int oltIgazSzam;
            int szepseg, viselkedes;
            int veletlenPontHatar = 10;

            Random rand = new Random();

            int osszesVersenyzo = 0;
            int osszesPont = 0;
            int legtobbPont = 0;

            Console.WriteLine("Kezdődik a verseny");

            char tovabb = 'i';
            while (tovabb == 'i')
            {
                Console.Write("Az állat neve: ");
                nev = Console.ReadLine();

                Console.Write("születési éve: ");
                while (!int.TryParse(Console.ReadLine(), out szulEv) || szulEv <= 0 || szulEv > Allat.AktualisEv)
                {
                    Console.Write("Hibás adat, kérem újra.");
                }

                Console.Write("Az állat oltási igazolásának száma: ");
                oltIgazSzam = int.Parse(Console.ReadLine());

                szepseg = rand.Next(veletlenPontHatar + 1);
                viselkedes = rand.Next(veletlenPontHatar + 1);
                
                allat = new Allat(nev, szulEv, 16342);

                allat.Pontozzak(szepseg, viselkedes);

                Console.WriteLine(allat);

                osszesVersenyzo++;
                osszesPont += allat.PontSzam();
                if (legtobbPont < allat.PontSzam())
                {
                    legtobbPont = allat.PontSzam();
                }

                Console.Write("Van még állat? (i/n) ");
                tovabb = char.Parse(Console.ReadLine());
            }


            Console.WriteLine("\nÖsszesen " + osszesVersenyzo + " versenyző volt,"
                + "\nösszpontszámuk: " + osszesPont + " pont,"
                + "\nlegnagyobb pontszám: " + legtobbPont);

        }

    }
}
