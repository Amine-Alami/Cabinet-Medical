using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Cabinet_medical
{
	[Serializable]
	public class Patient
	{
		int numero;
		string nom;
		string prenom;
		string sexe;
		string adresse;
		int tele;
		DateTime date_naissance;
		int cin;
		string situation;
		string mutuelle;
		DateTime date_creation;

		public int Numero { get => numero; set => numero = value; }
		public string Nom { get => nom; set => nom = value; }
		public string Prenom { get => prenom; set => prenom = value; }
		public string Sexe { get => sexe; set => sexe = value; }
		public string Adresse { get => adresse; set => adresse = value; }
		public int Tele { get => tele; set => tele = value; }
		public DateTime Date_naissance { get => date_naissance; set => date_naissance = value; }
		public int Cin { get => cin; set => cin = value; }
		public string Situation { get => situation; set => situation = value; }
		public string Mutuelle { get => mutuelle; set => mutuelle = value; }
		public DateTime Date_creation { get => date_creation; set => date_creation = value; }

		public Patient(int numero, string nom, string prenom,string sexe,string adresse,int tele,DateTime date_naissance,int cin,string situation,string mutuelle,DateTime date_creation)
		{
			this.numero = numero;
			this.nom = nom;
			this.prenom = prenom;
			this.sexe = sexe;
			this.adresse = adresse;
			this.tele = tele;
			this.date_naissance = date_naissance;
			this.cin = cin;
			this.situation = situation;
			this.mutuelle = mutuelle;
			this.date_creation = date_creation;
		}
	}
}
