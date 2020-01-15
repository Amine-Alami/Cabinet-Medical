using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Cabinet_medical
{
	[Serializable]
	public class ClassRDV
	{
		string nom;
		string prenom;
		DateTime date;
		string heure;
		string type;
		double payment;

		public string Nom { get => nom; set => nom = value; }
		public string Prenom { get => prenom; set => prenom = value; }
		public DateTime Date { get => date; set => date = value; }
		public string Heure { get => heure; set => heure = value; }
		public string Type { get => type; set => type = value; }
		public double Payment { get => payment; set => payment = value; }

		public ClassRDV(string nom,string prenom,DateTime date, string heure,string type,double payment)
		{
			this.nom = nom;
			this.prenom = prenom;
			this.date = date;
			this.heure = heure;
			this.type = type;
			this.payment = payment;
		}
	}
}
