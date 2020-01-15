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
	public partial class Ajouter_RDV : Form
	{
		public Ajouter_RDV()
		{
			InitializeComponent();
		}
		///////////////////////////////////////////////////////////////////////////
		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Program.button1.Enabled = true;
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



		private void Ajouter_RDV_Load(object sender, EventArgs e)
		{
			textBox3.Enabled = false;
			textBox2.Enabled = false;
			dateTimePicker2.Format = DateTimePickerFormat.Time;
			dateTimePicker2.ShowUpDown = true;
			dateTimePicker2.Value = DateTime.Parse("09:00:00");
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			groupBox2.Enabled = true;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			groupBox2.Enabled = true;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			// Button rechercher
			
			int cp = 0;
			for (int i = 0; i < Form1.patientList.lp.Count; i++)
			{
				if (Form1.patientList.lp[i].Nom == textBox1.Text || Form1.patientList.lp[i].Numero.ToString() == textBox1.Text)
				{
					cp++;
				}
			}
			if (cp == 0)
			{
				label11.Text = "*nom d'utilisateur introuvable";
				
				textBox2.Clear();
				textBox3.Clear();
				textBox4.Clear();
				dateTimePicker2.Value = DateTime.Now;
				radioButton1.Checked = false;
				radioButton2.Checked = false;
			}
			else
				label11.Text = "";
			if (textBox1.Text == "")
				label11.Text = "";

			
			foreach (Patient i in Form1.patientList.lp)
			{
				if(textBox1.Text == i.Nom || textBox1.Text == i.Numero.ToString())
				{
					textBox3.Text = i.Nom;
					textBox2.Text = i.Prenom;
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			// Button Valider

			string t = "";
			if (radioButton1.Checked == true)
				t = "Visite";
			else if (radioButton2.Checked == true)
				t = "Contrôle";
			try
			{
				if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && (radioButton1.Checked != false || radioButton2.Checked != false))
				{
					DateTime date = DateTime.Parse(dateTimePicker1.Text);
					string time = dateTimePicker2.Value.ToString("HH:mm");
				
					ClassRDV r = new ClassRDV(textBox3.Text, textBox2.Text,DateTime.Parse(date.ToString("dd/MM/yyyy")) ,time,t,double.Parse(textBox4.Text));
					Form1.rvList.rdv.Add(r);
				
					MessageBox.Show("Le rendez-vous à étè ajouté avec succés !!");

					textBox1.Clear();
					textBox2.Clear();
					textBox3.Clear();
					textBox4.Clear();
					radioButton1.Checked = false;
					radioButton2.Checked = false;
				}
			}catch(FormatException ex)
			{
				label5.Text = ex.Message;
			}
			
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			
			if(textBox1.Text == "")
				label11.Text = "";
		}
	}
}
