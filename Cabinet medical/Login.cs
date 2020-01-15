using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cabinet_medical
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}


		public static LoginList loginList = Utils.deserializerLogin();



		/////////////////////////////////////////////////////////////////////
		Point lastPoint;
		private void Login_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}
		private void Login_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Utils.serializerPatients(Form1.patientList);
			Utils.serializerRvList(Form1.rvList);
			Utils.serializerLogin(Login.loginList);
			Application.Exit();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
		/////////////////////////////////////////////////////////////////////
		


		private void button3_Click(object sender, EventArgs e)
		{
			Register f = new Register();
			f.Show();
			button4.Enabled = false;
			Program.button = button4;
		}

		private void Login_Load(object sender, EventArgs e)
		{

		}
		public static string bienvenue;
		private void button3_Click_1(object sender, EventArgs e)
		{
			
			int cp=0;
			int x=0;
			for(int i=0;i<loginList.lg.Count;i++)
			{
				if (loginList.lg[i].Nom != textBox1.Text)
				{
					cp++;
				}
			}
			if (loginList.lg.Count == cp)
			{
				label3.Text = "*nom d'utilisateur introuvable";
			}
			else
				label3.Text = "";

			for (int i = 0; i < loginList.lg.Count; i++)
			{
				if (loginList.lg[i].Nom == textBox1.Text)
				{
					if (loginList.lg[i].Pass == textBox2.Text)
					{
						x++;
						bienvenue = loginList.lg[i].Nom;
					}
					else
					{
						label4.Text = "*mot de passe incorect";
					}
						
				}	
			}
			if(x != 0)
			{
				this.Hide();
				Form1 form1 = new Form1();
				form1.Show();
			}
			
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (textBox2.UseSystemPasswordChar == true)
				textBox2.UseSystemPasswordChar = false;
			else
				textBox2.UseSystemPasswordChar = true;
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			// Vérifier si l'utilisateur existe

			
			int cp = 0;
			for(int i=0;i< loginList.lg.Count;i++)
			{
				if (loginList.lg[i].Nom != textBox1.Text)
				{
					cp++;
				}
			}
			if (loginList.lg.Count == cp)
			{
				label3.Text = "*nom d'utilisateur introuvable";
			}
			else
				label3.Text = "";
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				button3_Click_1(sender, e);


		}
	}
}
