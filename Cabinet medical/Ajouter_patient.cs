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
	public partial class Ajouter_patient : Form
	{
		public Ajouter_patient()
		{
			InitializeComponent();
		}
		///////////////////////////////////////////////////////////////////////////
		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Program.toolStripMenuItemN.Enabled = true;
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



		private void Ajouter_patient_Load(object sender, EventArgs e)
		{
			pictureBox11.Hide();
			pictureBox12.Hide();
			pictureBox13.Hide();
			pictureBox14.Hide();
			pictureBox15.Hide();
			pictureBox16.Hide();
			pictureBox17.Hide();
			pictureBox18.Hide();
			pictureBox19.Hide();
			pictureBox20.Hide();
			pictureBox21.Hide();
			pictureBox22.Hide();
			pictureBox23.Hide();
			pictureBox24.Hide();
			pictureBox25.Hide();
			pictureBox26.Hide();

			textBox6.Enabled = false;


			textBox6.Text = "" + Form1.patientList.getNextNumber();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
			comboBox1.Text = "";
			comboBox2.Text = "";
			comboBox3.Text = "";
			dateTimePicker1.Text = "";
			dateTimePicker2.Text = "";
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Program.toolStripMenuItemN.Enabled = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			
			if (textBox1.Text != "")
			{ pictureBox11.Hide(); pictureBox12.Show();  }
			else
			{ pictureBox12.Hide(); pictureBox11.Show();  }

			if (textBox2.Text != "")
			{ pictureBox13.Hide(); pictureBox14.Show();  }
			else
			{ pictureBox14.Hide(); pictureBox13.Show();  }

			if (comboBox1.Text != "")
			{ pictureBox15.Hide(); pictureBox16.Show();  }
			else
			{ pictureBox16.Hide(); pictureBox15.Show();  }

			if (textBox3.Text != "")
			{ pictureBox17.Hide(); pictureBox18.Show();  }
			else
			{ pictureBox18.Hide(); pictureBox17.Show();  }

			if (textBox4.Text != "")
			{ pictureBox19.Hide(); pictureBox20.Show();  }
			else
			{ pictureBox20.Hide(); pictureBox19.Show();  }

			if (textBox5.Text != "")
			{ pictureBox21.Hide(); pictureBox22.Show();  }
			else
			{ pictureBox22.Hide(); pictureBox21.Show();  }

			if (comboBox2.Text != "")
			{ pictureBox23.Hide(); pictureBox24.Show();  }
			else
			{ pictureBox24.Hide(); pictureBox23.Show();  }

			if (comboBox3.Text != "")
			{ pictureBox25.Hide(); pictureBox26.Show();  }
			else
			{ pictureBox26.Hide(); pictureBox25.Show();  }

			

			if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox4.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
			{
				bool valide = true;
				int tel = 0;
				try {
					tel = int.Parse(textBox5.Text);
				} catch (FormatException ex) {
					valide = false;
					label11.Text = ex.Message;
				}
				int CIN = 0;
				try { 
					CIN = int.Parse(textBox4.Text);
				} catch (FormatException ex) {
					valide = false;
					label12.Text = ex.Message;
				}
				if(valide)
				{ 
					int number = Form1.patientList.getNextNumber();
					Patient p = new Patient(number, textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, tel, DateTime.Parse(dateTimePicker1.Text),CIN, comboBox2.Text, comboBox3.Text,DateTime.Parse(dateTimePicker2.Text));

					Form1.patientList.lp.Add(p);

					MessageBox.Show("Patient ajoutée avec succès !!");
					textBox6.Text = "" + Form1.patientList.getNextNumber();

					textBox1.Clear();
					textBox2.Clear();
					textBox3.Clear();
					textBox4.Clear();
					textBox5.Clear();
					comboBox1.Text = "";
					comboBox2.Text = "";
					comboBox3.Text = "";
					dateTimePicker1.Text = "";
					dateTimePicker2.Text = "";

					pictureBox11.Hide();
					pictureBox12.Hide();
					pictureBox13.Hide();
					pictureBox14.Hide();
					pictureBox15.Hide();
					pictureBox16.Hide();
					pictureBox17.Hide();
					pictureBox18.Hide();
					pictureBox19.Hide();
					pictureBox20.Hide();
					pictureBox21.Hide();
					pictureBox22.Hide();
					pictureBox23.Hide();
					pictureBox24.Hide();
					pictureBox25.Hide();
					pictureBox26.Hide();
				}
			}
			
		}

		private void textBox5_Leave(object sender, EventArgs e)
		{
			int tel = 0;
			try
			{
				tel = int.Parse(textBox5.Text);
				label11.Text = "";
			}
			catch (FormatException ex)
			{
				label11.Text = ex.Message;
			}
			if (textBox5.Text != "")
			{ pictureBox21.Hide(); pictureBox22.Show(); }
			else
			{ pictureBox22.Hide(); pictureBox21.Show(); }
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			int CIN = 0;
			try
			{
				CIN = int.Parse(textBox4.Text);
				label12.Text = "";
			}
			catch (FormatException ex)
			{
				label12.Text = ex.Message;
			}
			if (textBox4.Text != "")
			{ pictureBox19.Hide(); pictureBox20.Show(); }
			else
			{ pictureBox20.Hide(); pictureBox19.Show(); }
		}
		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (textBox1.Text != "")
			{ pictureBox11.Hide(); pictureBox12.Show(); }
			else
			{ pictureBox12.Hide(); pictureBox11.Show(); }
		}
		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (textBox2.Text != "")
			{ pictureBox13.Hide(); pictureBox14.Show(); }
			else
			{ pictureBox14.Hide(); pictureBox13.Show(); }
		}
		private void textBox3_Leave(object sender, EventArgs e)
		{
			if (textBox3.Text != "")
			{ pictureBox17.Hide(); pictureBox18.Show(); }
			else
			{ pictureBox18.Hide(); pictureBox17.Show(); }
		}
		private void comboBox1_Leave(object sender, EventArgs e)
		{
			if (comboBox1.Text != "")
			{ pictureBox15.Hide(); pictureBox16.Show(); }
			else
			{ pictureBox16.Hide(); pictureBox15.Show(); }
		}
		private void comboBox2_Leave(object sender, EventArgs e)
		{
			if (comboBox2.Text != "")
			{ pictureBox23.Hide(); pictureBox24.Show(); }
			else
			{ pictureBox24.Hide(); pictureBox23.Show(); }
		}
		private void comboBox3_Leave(object sender, EventArgs e)
		{
			if (comboBox3.Text != "")
			{ pictureBox25.Hide(); pictureBox26.Show(); }
			else
			{ pictureBox26.Hide(); pictureBox25.Show(); }
		}


		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{}
		private void panel1_Paint(object sender, PaintEventArgs e)
		{}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{}
		private void textBox2_TextChanged(object sender, EventArgs e)
		{}
		private void textBox5_TextChanged(object sender, EventArgs e)
		{}
		private void textBox6_TextChanged(object sender, EventArgs e)
		{}
	}
}
