using System;

namespace ConsoleApp20
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = new Proizvodnja(Kreditne.Srebro, 400, 3000);
			IKK neka = p.Daaaj();
		}
	}

	public enum Kreditne
	{ 
		Bronza,
		Srebro,
		Zlato
	}

	public class Proizvodnja
	{
		private IFabrikaKreditnih _fab;

		public Proizvodnja(Kreditne koja, int l, int pp)
		{
			switch(koja)
			{
				case Kreditne.Bronza:
					_fab = new BronzanaFabrika(l, pp);
					break;
				case Kreditne.Srebro:
					_fab = new NekaTamoFab(l, pp);
					break;
				case Kreditne.Zlato:
					_fab = new ZlatnaFabrika(l, pp);
					break;
			}
		}
		public IKK Daaaj() =>
			_fab.DajKreditnu();
	}

	public interface IKK
	{
		public int Limit { get; set; }
		public int ProvizijaProc { get; set; }
		public string Naziv { get; set; }
	}

	class NekaTamo : IKK
	{
		private int _limit;
		private int _provizijaProc;
		private string _naziv;

		public int Limit { get => _limit; set => _limit = value; }
		public int ProvizijaProc { get => _provizijaProc; set => _provizijaProc = value; }
		public string Naziv { get => _naziv; set => _naziv = value; }

		public NekaTamo(int l, int pp)
		{
			Naziv = "Bronzana";
			Limit = l;
			ProvizijaProc = pp;
		}
	}

	class Bronzana : IKK
	{
		private int _limit;
		private int _provizijaProc;
		private string _naziv;

		public int Limit { get => _limit; set => _limit = value; }
		public int ProvizijaProc { get => _provizijaProc; set => _provizijaProc = value; }
		public string Naziv { get => _naziv; set => _naziv = value; }

		public Bronzana(int l, int pp)
		{
			Naziv = "Bronzana";
			Limit = l;
			ProvizijaProc = pp;
		}
	}

	class Srebrna : IKK
	{
		private int _limit;
		private int _provizijaProc;
		private string _naziv;

		public int Limit { get => _limit; set => _limit = value; }
		public int ProvizijaProc { get => _provizijaProc; set => _provizijaProc = value; }
		public string Naziv { get => _naziv; set => _naziv = value; }

		public Srebrna(int l, int pp)
		{
			Naziv = "Srebrna";
			Limit = l;
			ProvizijaProc = pp;
		}
	}

	class Zlatna : IKK
	{
		private int _limit;
		private int _provizijaProc;
		private string _naziv;

		public int Limit { get => _limit; set => _limit = value; }
		public int ProvizijaProc { get => _provizijaProc; set => _provizijaProc = value; }
		public string Naziv { get => _naziv; set => _naziv = value; }

		public Zlatna(int l, int pp)
		{
			Naziv = "Zlatna";
			Limit = l;
			ProvizijaProc = pp;
		}
	}


	interface IFabrikaKreditnih
	{
		public IKK DajKreditnu();
	}

	class BronzanaFabrika : IFabrikaKreditnih
	{
		private int _limit;
		private int _pp;

		public BronzanaFabrika(int l, int pp)
		{
			_limit = l;
			_pp = pp;
		}

		public IKK DajKreditnu()
		{
			return new Bronzana(_limit, _pp);
		}
	}

	class SrebrnaFabrika : IFabrikaKreditnih
	{
		private int _limit;
		private int _pp;

		public SrebrnaFabrika(int l, int pp)
		{
			_limit = l;
			_pp = pp;
		}

		public IKK DajKreditnu()
		{
			return new Srebrna(_limit, _pp);
		}
	}

	class NekaTamoFab : IFabrikaKreditnih
	{
		private int _limit;
		private int _pp;

		public NekaTamoFab(int l, int pp)
		{
			_limit = l;
			_pp = pp;
		}

		public IKK DajKreditnu()
		{
			return new NekaTamo(_limit, _pp);
		}
	}

	class ZlatnaFabrika : IFabrikaKreditnih
	{
		private int _limit;
		private int _pp;

		public ZlatnaFabrika(int l, int pp)
		{
			_limit = l;
			_pp = pp;
		}

		public IKK DajKreditnu()
		{
			return new Zlatna(_limit, _pp);
		}
	}
}
