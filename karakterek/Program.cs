namespace karakterek
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];

			Beolvasas("karakterek.txt", karakterek);

            Console.WriteLine("Eredeti karakterek:");
            foreach (var karakter in karakterek)
            {
                Console.WriteLine(karakter);
            }

            MentesCSV("karakterek.csv", karakterek);
            Console.WriteLine("Karakterek elmentve CSV fájlba.");

            List<Karakter> beolvasottKarakterek = BeolvasasCSV("karakterek.csv");
            Console.WriteLine("Beolvasott karakterek:");
            foreach (var karakter in beolvasottKarakterek)
            {
                Console.WriteLine(karakter);
            }

            Console.WriteLine(LegmagasabbEletero(karakterek));

			Console.WriteLine(AtlagSzint(karakterek));

            Console.WriteLine(BiggerE(karakterek,80,0));

			Nagyobbak(karakterek,59);

			Topharom(karakterek);

        }

		static void Beolvasas(string filenev, List<Karakter> karakterek)
		{
			StreamReader sr = new(filenev);

			sr.ReadLine();

			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(";");

				Karakter karakter = new(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
		}

		static Karakter LegmagasabbEletero(List<Karakter> karakterek)
		{
			int mostbuff = 0;
			int counter = 0;
			int snapshot = 0;

			foreach (var character in karakterek)
			{
				counter++;
				if (character.Eletero > mostbuff)
				{
					mostbuff = character.Eletero;
					snapshot = counter - 1;
				}
			}
			return karakterek[snapshot];
		}


		static int AtlagSzint(List<Karakter> karakterek)
		{
			int sum = 0;
			int div = 0;
			foreach (var character in karakterek)
			{
				div++;
				sum += character.Szint;
			}
			return sum / div;
		}

		static void Eroszint(List<Karakter> karakterek)
		{
			//int strongest = 0;
			//int counter=0;
			//int snapshot = 0;
			//foreach(var character in karakterek)
			//{
			//	counter++;
			//	if (character.Ero > strongest)
			//	{
			//		strongest = character.Ero;
			//		snapshot = counter-1;
			//	}
			//}
			//return karakterek[snapshot];

			for (int i = 0; i < karakterek.Count - 1; i++)
			{
				for (int j = i + 1; j < karakterek.Count; j++)
				{
					if (karakterek[i].Ero > karakterek[j].Ero)
					{
						Karakter csere = karakterek[i];
						karakterek[i] = karakterek[j];
						karakterek[j] = csere;
					}
				}
			}
			foreach (var character in karakterek)
			{
                Console.WriteLine(character);
                Console.WriteLine();
            }
		}

		static bool BiggerE(List<Karakter> karakterek, int comp, int sorszam)
		{
			bool valasz=false;
			int strength = karakterek[sorszam].Ero;

			if ( strength>= comp)
			{
				valasz = true;
			}
			return valasz;
		}


		static void Nagyobbak(List<Karakter> karakterek, int mini)
		{
			foreach (var character in karakterek)
			{
				if (character.Ero > mini)
				{
                    Console.WriteLine(character);
				}
			}
		}

        static void MentesCSV(string fajlnev, List<Karakter> karakterek)
        {
            using StreamWriter sw = new StreamWriter(fajlnev);
            sw.WriteLine("Nev;Szint;Eletero;Ero");
            foreach (var karakter in karakterek)
            {
                sw.WriteLine($"{karakter.Nev};{karakter.Szint};{karakter.Eletero};{karakter.Ero}");
            }
        }

        static List<Karakter> BeolvasasCSV(string fajlnev)
        {
            List<Karakter> karakterek = new List<Karakter>();
            using StreamReader sr = new StreamReader(fajlnev);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                if (adatok.Length == 4)
                {
                    Karakter karakter = new Karakter(adatok[0], Convert.ToInt32(adatok[1]), Convert.ToInt32(adatok[2]), Convert.ToInt32(adatok[3]));
                    karakterek.Add(karakter);
                }
            }
            return karakterek;
        }

		static void Topharom(List<Karakter> karakterek)
		{
            var top3 = karakterek.OrderByDescending(k => k.Szint + k.Ero).Take(3);
			foreach(var character in top3)
			{
                Console.WriteLine($"{character.Nev}-{character.Szint}-{character.Ero}");
			}
        }
    }
}
