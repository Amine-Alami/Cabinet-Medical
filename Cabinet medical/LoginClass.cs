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
	public class LoginClass
	{
		string nom;
		string pass;

		public string Nom { get => nom; set => nom = value; }
		public string Pass { get => pass; set => pass = value; }

		
		public LoginClass(string Nom, string Pass)
		{
			this.nom = Nom;
			this.pass = Pass;
		}
		
		
	}
}
