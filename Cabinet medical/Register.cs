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
	public partial class Register : Form
	{
		public Register()
		{
			InitializeComponent();
		}
		///////////////////////////////////////////////////////////////////
		Point lastPoint;
		private void Register_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}
		private void Register_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Program.button.Enabled = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
		////////////////////////////////////////////////////////////////////
		


		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}
		
		private void button4_Click(object sender, EventArgs e)
		{
			this.Hide();
			Program.button.Enabled = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "")
			{ pictureBox4.Hide(); pictureBox5.Show(); }
			else
			{ pictureBox5.Hide(); pictureBox4.Show(); }

			if (textBox2.Text == "")
			{ pictureBox6.Hide(); pictureBox7.Show(); }
			else
			{ pictureBox7.Hide(); pictureBox6.Show(); }

			if (textBox3.Text == "")
			{ pictureBox8.Hide(); pictureBox9.Show(); }
			else
			{ pictureBox9.Hide(); pictureBox8.Show(); }



			if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
			{
				if (textBox1.Text.Length <= 3)
					label4.Text = "*Le nom doit avoir plus de 3 characteres";
				else
					label4.Text = "";
				if (textBox2.Text.Length <= 3)
					label5.Text = "*Le mot de passe doit avoir plus de 3 characteres";
				else
					label5.Text = "";
				if (textBox3.Text != textBox2.Text)
					label6.Text = "*Le mot de passe doit etre identique";
				else
					label6.Text = "";
				if (textBox1.Text.Length > 3 && textBox2.Text.Length > 3 && textBox3.Text == textBox2.Text)
				{
					LoginClass g = new LoginClass(textBox1.Text, textBox2.Text);

					Login.loginList.lg.Add(g);
					
					MessageBox.Show("Utilisateur ajoutée");
					this.Hide();
				}
				
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			
			if (textBox1.Text.Length <= 3)
				label4.Text = "*Le nom doit avoir plus de 3 characteres";
			else 
				label4.Text = ""; 

			for (int i = 0; i < Login.loginList.lg.Count; i++)
			{
				if (textBox1.Text == Login.loginList.lg[i].Nom)
					label4.Text = "*Ce nom existe dèja";
				
			}

			if (textBox1.Text == "")
			{ pictureBox4.Hide(); pictureBox5.Show(); }
			else
			{ pictureBox5.Hide(); pictureBox4.Show(); }

		}
		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (textBox2.Text.Length <= 3)
				label5.Text = "*Le mot de passe doit avoir plus de 3 characteres";
			else
				label5.Text = "";

			if (textBox2.Text == "")
			{ pictureBox6.Hide(); pictureBox7.Show(); }
			else
			{ pictureBox7.Hide(); pictureBox6.Show(); }
		}
		private void textBox3_Leave(object sender, EventArgs e)
		{
			if (textBox3.Text != textBox2.Text)
				label6.Text = "*Le mot de passe doit etre identique";
			else
				label6.Text = "";

			if (textBox3.Text == "")
			{ pictureBox8.Hide(); pictureBox9.Show(); }
			else
			{ pictureBox9.Hide(); pictureBox8.Show(); }
		}

		private void Register_Load(object sender, EventArgs e)
		{
			pictureBox4.Hide();
			pictureBox5.Hide();
			pictureBox6.Hide();
			pictureBox7.Hide();
			pictureBox8.Hide();
			pictureBox9.Hide();
		}
		
		private void button5_Click(object sender, EventArgs e)
		{
			if (textBox2.UseSystemPasswordChar == true)
				textBox2.UseSystemPasswordChar = false;
			else
				textBox2.UseSystemPasswordChar = true;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (textBox3.UseSystemPasswordChar == true)
				textBox3.UseSystemPasswordChar = false;
			else
				textBox3.UseSystemPasswordChar = true;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("This Button Will Erase All Users !!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.OK)
			{
				Utils.DeleteLogin();
			}
		}
	}
}
