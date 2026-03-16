using LolCLI_V4.Models;

namespace LolCLI_V4
{
    public class Program
    {
        public static List<Hos> hosok = new List<Hos>();
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat5();
        }

        private static void Feladat5()
        {
            var legkisebbSebzesuHos = hosok.MinBy(h => h.ADLevel(5));
            Console.WriteLine($"5. Feladat: 5. szinten a legkisebb sebzéssel rendelkező hős {legkisebbSebzesuHos.Name}; sebzés={Convert.ToInt32((int)legkisebbSebzesuHos.ADLevel(5))}");
        }

        private static void Feladat3()
        {
            string nev;
            int index;
            do
            {
                Console.Write("3. Feladat: Kérem adja meg a hős nevét: ");
                nev = Console.ReadLine();
                index = hosok.IndexOf(hosok.FirstOrDefault(h => h.Name == nev));
            }
            while (index == -1);

            Console.WriteLine($"\t{nev} adatai: HP:{hosok[index].HP}; Sebzés:{hosok[index].Attackdamage}");
        }

        private static void Feladat2()
        {
            Console.WriteLine($"2. Feladat: Az állományban {hosok.Count} hős található");
        }

        public static void Feladat1()
        {
            StreamReader streamReader = new StreamReader("champions2017_V4.txt");
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                Hos hos = new Hos(streamReader.ReadLine());
                hosok.Add(hos);
            }
            streamReader.Close();
        }
    }
}
