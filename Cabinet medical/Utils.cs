using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet_medical
{
	public class Utils
	{
		/////////////////////////////////////////////////////////////////////
		public static void serializerPatients(PatientList patientList)
		{
			FileStream sp = new FileStream("Patient_File.bat", FileMode.OpenOrCreate, FileAccess.Write);
			BinaryFormatter bep = new BinaryFormatter();
			bep.Serialize(sp, patientList);
			sp.Close();
		}
		
		public static PatientList deserializerPatients()
		{
			FileStream stp = new FileStream("Patient_File.bat", FileMode.OpenOrCreate, FileAccess.Read);
			PatientList patientList = new PatientList();
			if (stp.Length > 0) {
				BinaryFormatter bp = new BinaryFormatter();
				patientList = (PatientList)(bp.Deserialize(stp));
			}
			stp.Close();
			return patientList;
		}
		/////////////////////////////////////////////////////////////////////
		public static void serializerRvList(RvList rvList)
		{
			FileStream sr = new FileStream("RV_File.bat", FileMode.OpenOrCreate, FileAccess.Write);
			BinaryFormatter ber = new BinaryFormatter();
			ber.Serialize(sr, rvList);
			sr.Close();
		}

		public static RvList deserializerRvList()
		{
			FileStream str = new FileStream("RV_File.bat", FileMode.OpenOrCreate, FileAccess.Read);
			RvList rvList = new RvList();
			if (str.Length > 0) {
				BinaryFormatter br = new BinaryFormatter();
				rvList = (RvList)(br.Deserialize(str));
			}
			str.Close();
			return rvList;
		}
		/////////////////////////////////////////////////////////////////////
		public static void serializerLogin(LoginList loginList)
		{
			FileStream sl = new FileStream("Login_File.bat", FileMode.OpenOrCreate, FileAccess.Write);
			BinaryFormatter bel = new BinaryFormatter();
			bel.Serialize(sl, loginList);
			sl.Close();
		}

		public static LoginList deserializerLogin()
		{
			FileStream stl = new FileStream("Login_File.bat", FileMode.OpenOrCreate, FileAccess.Read);
			LoginList loginList = new LoginList();
			if (stl.Length > 0)
			{
				BinaryFormatter bl = new BinaryFormatter();
				loginList = (LoginList)(bl.Deserialize(stl));
			}
			stl.Close();
			return loginList;
		}
		/////////////////////////////////////////////////////////////////////
		
		public static void DeletePatients()
		{
			if(new FileInfo("Patient_File.bat").Exists == true)
			{ 
				if(new FileInfo("Patient_File.bat").Length != 0)
				{
					File.Delete("Patient_File.bat");
				}
			}
		}
		public static void DeleteRV()
		{
			if (new FileInfo("RV_File.bat").Exists == true)
			{
				if (new FileInfo("RV_File.bat").Length != 0)
				{
					File.Delete("RV_File.bat");
				}
			}
		}
		public static void DeleteLogin()
		{
			if (new FileInfo("Login_File.bat").Exists == true)
			{
				if (new FileInfo("Login_File.bat").Length != 0)
				{
					File.Delete("Login_File.bat");
				}
			}
		}

		//////////////////////////////////////////////////////////////////
		

		//public static void serializerLogin()
		//{
		//	FileStream s = new FileStream("Login_File.bat", FileMode.OpenOrCreate, FileAccess.Write);
		//	BinaryFormatter be = new BinaryFormatter();
		//	be.Serialize(s, LoginClass.lg);
		//	s.Close();
		//}
		//public static void deserializerLogin()
		//{
		//	FileStream st = new FileStream("Login_File.bat", FileMode.Open, FileAccess.Read);
		//	BinaryFormatter b = new BinaryFormatter();
		//	LoginClass.lg = (List<LoginClass>)(b.Deserialize(st));
		//	st.Close();
		//}
	}
}
