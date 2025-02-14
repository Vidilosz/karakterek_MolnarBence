namespace karakterek
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];

			Beolvasas("karakterek.txt", karakterek);

            Console.WriteLine(LegmagasabbEletero(karakterek));
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

		static (string, int, int) LegmagasabbEletero(List<Karakter> karakterek)
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
					snapshot = counter-1;
				}
			}
			return (karakterek[snapshot].Nev,karakterek[snapshot].Szint,karakterek[snapshot].Ero);
		}

	}
}
