using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DatumiIto
{
	public class Kurs
	{
		public string Naziv { get; set; }

		public DateTime DatumPocetka { get; set; }
		public DateTime DatumKraja { get; set; }

		public bool ProveraDatuma(DateTime datum)
			=> datum.Date >= DatumPocetka.Date && datum.Date <= DatumKraja.Date;
		public bool ProveraDana(DateTime datum)
			=> Dani.Contains(datum.DayOfWeek);

		public TimeSpan VremePocetka { get; set; }
		public TimeSpan Trajanje { get; set; }

		public bool ProveraVremena(TimeSpan vreme)
			=> vreme >= VremePocetka && vreme <= VremePocetka + Trajanje;

		public bool Provera(DateTime vreme)
			=> ProveraDatuma(vreme) && ProveraDana(vreme) && ProveraVremena(vreme.TimeOfDay);

		public List<DayOfWeek> Dani { get; set; } = new();
	}

	class Program
	{
		static void Main(string[] args)
		{
			Kurs k1 = new();
			k1.DatumPocetka = DateTime.Now.AddMonths(-1);
			k1.DatumKraja = DateTime.Now;
			k1.Dani.AddRange(new[] { DayOfWeek.Monday, DayOfWeek.Friday });
			k1.VremePocetka = new(9, 0, 0);
			k1.Trajanje = new(1, 30, 0);

			for(DateTime datum = k1.DatumPocetka; datum.Date <= k1.DatumKraja; datum = datum.AddDays(1))
			{
				Console.Write(datum);
				if (k1.ProveraDana(datum))
					Console.WriteLine("  [x]");
				else
					Console.WriteLine("  [ ]");
			}

			Console.WriteLine(k1.Provera(DateTime.Now));

			
		}
	}
		
}
