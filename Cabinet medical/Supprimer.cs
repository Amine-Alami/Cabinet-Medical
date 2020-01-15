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
	public partial class Supprimer : Form
	{
		public Supprimer()
		{
			InitializeComponent();
		}
		///////////////////////////////////////////////////////////////////////////
		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Program.toolStripMenuItemS.Enabled = true;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
		Point lastPoint;
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
		///////////////////////////////////////////////////////////////////////////


		private void Supprimer_Load(object sender, EventArgs e)
		{
			textBox2.Enabled = false;
			textBox3.Enabled = false;
		}
		
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if(textBox1.Text != "")
			{
				try
				{
					int num = int.Parse(textBox1.Text);
					int compteur = 0;

					foreach (Patient i in Form1.patientList.lp)
					{
						if (i.Numero == num)
						{
							textBox2.Text = i.Nom;
							textBox3.Text = i.Prenom;
							label11.Text = "";
							compteur++;
						}
					}
					if(compteur == 0)
					{
						label11.Text = "*Numero introuvable !!";
						textBox2.Clear();
						textBox3.Clear();
					}
				}catch (FormatException ex)
				{
					label11.Text = ex.Message;
				}
			}
			else
			{
				textBox2.Clear();
				textBox3.Clear();
				label11.Text = "";
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox2.Text != "" && textBox3.Text != "")
			{
				for(int i= Form1.patientList.lp.Count - 1; i>=0 ; i--)
				{
					if (textBox2.Text == Form1.patientList.lp[i].Nom && textBox3.Text == Form1.patientList.lp[i].Prenom)
					{
						Form1.patientList.lp.RemoveAt(i);
						label4.Text = "";
						MessageBox.Show("Patient supprimé avec succés !!");
						textBox1.Clear();
						textBox2.Clear();
						textBox3.Clear();
					}
				}
			}
			else
			{
				label4.Text = "*Les champs nom et prénom sont obligatoires !!";
			}
		}
	}
}
