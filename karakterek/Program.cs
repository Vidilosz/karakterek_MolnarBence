namespace karakterek
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];

			Beolvasas("karakterek.txt", karakterek);

			Console.WriteLine(LegmagasabbEletero(karakterek));

			Console.WriteLine(AtlagSzint(karakterek));

			Eroszint(karakterek);
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
	}
}
