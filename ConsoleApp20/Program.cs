using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp20
{
	class Program
	{
		static void Main(string[] args)
		{
			
		}
	}

	public abstract class Proracun
	{
		public string _rezultat;
		public ICollection<int> Brojevi;
		public abstract void Racunaj();
	}

	public class Zbir : Proracun
	{
		public Zbir(ICollection<int> br)
		{
			Brojevi = br;
		}
		public override void Racunaj()
		{
			int zbir = Brojevi.ToList().Aggregate((svi, x) => svi += x);
			_rezultat = $"Zbir je {zbir}";
		}
	}

	public class MMM : Proracun
	{
		public MMM(ICollection<int> br)
		{
			Brojevi = br;
		}

		public override void Racunaj()
		{
			double mean = Brojevi.ToList().Average();
			double median = 0;
			if (Brojevi.Count % 2 == 1)
				median = Brojevi.ToList()[Brojevi.Count / 2];
			else
				median = (Brojevi.ToList()[Brojevi.Count / 2] + Brojevi.ToList()[(Brojevi.Count / 2) + 1]) / 2;
			double mode = Brojevi.ToList().GroupBy(b => b).OrderByDescending(b => b.Count()).Select(b => b.Key).First();
			_rezultat = $"Mean: {mean}, Mode:{mode}, Median:{median}";
		}
	}

	public abstract class Izvestaj
	{
		protected ICollection<Proracun> Proracuni;

		public Izvestaj()
		{
			NapraviIzvestaj();
		}

		protected abstract void NapraviIzvestaj();
	}

	public class A : Izvestaj
	{
		ICollection<int> brr;
		public A(ICollection<int> b)
		{
			brr = b;
		}
		protected override void NapraviIzvestaj()
		{
			Proracuni.Add(new MMM(brr));
		}
	}

	public class B : Izvestaj
	{
		ICollection<int> brr;
		public B(ICollection<int> b)
		{
			brr = b;
		}
		protected override void NapraviIzvestaj()
		{
			Proracuni.Add(new Zbir(brr));
		}
	}

	public class C : Izvestaj
	{
		ICollection<int> brr;
		public C(ICollection<int> b)
		{
			brr = b;
		}
		protected override void NapraviIzvestaj()
		{
			Proracuni.Add(new Zbir(brr));
			Proracuni.Add(new MMM(brr));
		}
	}
}
