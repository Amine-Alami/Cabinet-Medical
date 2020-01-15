using System;
using System.Collections.Generic;

namespace Cabinet_medical
{
	[Serializable]
	public class PatientList
	{
		public List<Patient> lp = new List<Patient>();

		public int getNextNumber() {
			int max = 0;
			foreach (Patient patient in lp)
			{
				if(max < patient.Numero)
				{
					max = patient.Numero;
				}
			}
			return ++max;
		}
	}
}
