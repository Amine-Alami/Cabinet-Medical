using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Cabinet_medical
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}



		public static PatientList patientList = Utils.deserializerPatients();
		public static RvList rvList = Utils.deserializerRvList();



		///////////////////////////////////////////////////////////////////////////
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
		private void button1_Click_1(object sender, EventArgs e)
		{
			Utils.serializerPatients(Form1.patientList);
			Utils.serializerRvList(Form1.rvList);
			Utils.serializerLogin(Login.loginList);
			Application.Exit();
		}
		private void button2_Click_1(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;

		}
		///////////////////////////////////////////////////////////////////////////

		private void pictureBox1_Click(object sender, EventArgs e)
		{}
		private void insererToolStripMenuItem_Click(object sender, EventArgs e)
		{}
		private void clientToolStripMenuItem_Click(object sender, EventArgs e)
		{}
		private void bunifuTextBox1_TextChange(object sender, EventArgs e)
		{}
		private void bunifuTextBox1_Enter(object sender, EventArgs e)
		{}
		private void panel3_Paint(object sender, PaintEventArgs e)
		{}
		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{}
		private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{}


		private void Form1_Load(object sender, EventArgs e)
		{
			// LOAD
			label1.Text = "Bienvenue M." + Login.bienvenue;
			bunifuDataGridView2.Hide();
			panel4.Hide();
			panel2.Hide();
			panel3.Hide();
			panel5.Hide();

		}

		private void homeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// MenuStrip : Home
			pictureBox1.Show();
			label1.Show();
			panel2.Hide();
			panel3.Hide();
			bunifuDataGridView2.Hide();
			panel4.Hide();
			panel5.Hide();
		}

		private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// MenuStrip : Patient > Nouveau
			Ajouter_patient aj = new Ajouter_patient();
			aj.Show();
			nouveauToolStripMenuItem.Enabled = false;
			Program.toolStripMenuItemN = nouveauToolStripMenuItem;
		}

		private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// MenuStrip : Patient > Modifier
			panel2.Show();
			panel3.Hide();
			pictureBox1.Hide();
			label1.Hide();
			bunifuDataGridView2.Hide();
			panel4.Hide();
			panel5.Hide();
			bunifuDataGridView1.Rows.Clear();
			
			for (int i=0;i< patientList.lp.Count;i++)
			{
				bunifuDataGridView1.Rows.Add(patientList.lp[i].Numero, patientList.lp[i].Nom, patientList.lp[i].Prenom);
			}
		}

		private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// MenuStrip : Patient > Supprimer
			Supprimer sup = new Supprimer();
			sup.Show();
			supprimerToolStripMenuItem.Enabled = false;
			Program.toolStripMenuItemS = supprimerToolStripMenuItem;
		}
		
		private void afficherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// MenuStrip : Afficher
			pictureBox1.Hide();
			label1.Hide();
			panel2.Hide();
			panel3.Hide();
			bunifuDataGridView2.Show();
			panel4.Show();
			panel5.Hide();
			

			bunifuDataGridView2.DataSource = patientList.lp;
			
		}

		private void aideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// MenuStrip : Rendez-vous
			
			pictureBox1.Hide();
			label1.Hide();
			panel2.Hide();
			bunifuDataGridView2.Hide();
			panel4.Hide();
			panel3.Show();
			panel5.Hide();

			bunifuDataGridView3.DataSource = rvList.rdv.OrderBy(r => r.Heure).ToList();

			DataGridViewButtonColumn ValidationButtonColumn = new DataGridViewButtonColumn();
			ValidationButtonColumn.Name = "Validation";
			ValidationButtonColumn.Text = "Enter";
			ValidationButtonColumn.UseColumnTextForButtonValue = true;
			int columnIndex = 6;
			if (bunifuDataGridView3.Columns["Validation"] == null)
			{
				bunifuDataGridView3.Columns.Insert(columnIndex, ValidationButtonColumn);
			}
			

			for (int i = 0; i < bunifuDataGridView3.Rows.Count; i++)
			{
				string value4 = bunifuDataGridView3.Rows[i].Cells[3].Value.ToString();
				string d1 = bunifuDataGridView3.Rows[i].Cells[2].Value.ToString();
				DateTime d2 = (DateTime)DateTime.Now.Date;

				if (d1 == d2.ToString() || value4 == d2.ToString())
				{
					bunifuDataGridView3.Rows[i].Visible = true;
				}
				else
				{
					CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[bunifuDataGridView3.DataSource];
					currencyManager1.SuspendBinding();
					bunifuDataGridView3.Rows[i].Visible = false;
					currencyManager1.ResumeBinding();
				}
			}
		}

		private void receptToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// MenuStrip : Recept

			pictureBox1.Hide();
			label1.Hide();
			panel2.Hide();
			bunifuDataGridView2.Hide();
			panel4.Hide();
			panel3.Hide();
			panel5.Show();


		}

		private void deconecterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// MenuStrip : Deconnecter
			Login f = new Login();
			f.Show();
			this.Hide();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			// PanelModifier : Effacer
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

		private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// PanelModifier : DataGridView Selected Row

			string objet = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
			
			foreach (Patient i in patientList.lp)
			{
				if (int.Parse(objet) == i.Numero)
				{
					textBox1.Text = i.Nom;
					textBox2.Text = i.Prenom;
					textBox3.Text = i.Adresse;
					textBox4.Text = i.Cin.ToString();
					textBox5.Text = i.Tele.ToString();
					comboBox1.Text = i.Sexe;
					comboBox2.Text = i.Situation;
					comboBox3.Text = i.Mutuelle;
					dateTimePicker1.Text = i.Date_naissance.ToString();
					dateTimePicker2.Text = i.Date_creation.ToString();
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
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			int CIN = 0;
			try
			{
				CIN = int.Parse(textBox4.Text);
				label14.Text = "";
			}
			catch (FormatException ex)
			{
				label14.Text = ex.Message;
			}
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			// PanelModifier : Button modifier

			if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox4.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
			{
				bool valide = true;
				int tel = 0;
				try
				{
					tel = int.Parse(textBox5.Text);
				}
				catch (FormatException ex)
				{
					valide = false;
					label11.Text = ex.Message;
				}
				int CIN = 0;
				try
				{
					CIN = int.Parse(textBox4.Text);
				}
				catch (FormatException ex)
				{
					valide = false;
					label12.Text = ex.Message;
				}
				if (valide)
				{
					string objet = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
					
					foreach (Patient i in patientList.lp)
					{
						if (int.Parse(objet) == i.Numero)
						{
							i.Nom = textBox1.Text;
							i.Prenom = textBox2.Text;
							i.Adresse = textBox3.Text;
							i.Cin = int.Parse(textBox4.Text);
							i.Tele = int.Parse(textBox5.Text);
							i.Sexe = comboBox1.Text;
							i.Situation = comboBox2.Text;
							i.Mutuelle = comboBox3.Text;
							i.Date_naissance = DateTime.Parse(dateTimePicker1.Text);
							i.Date_creation = DateTime.Parse(dateTimePicker2.Text);

							MessageBox.Show("Informations modifiées avec succès !!");
							bunifuDataGridView1.Rows.Clear();
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
							for (int a = 0; a < patientList.lp.Count; a++)
							{
								bunifuDataGridView1.Rows.Add(patientList.lp[a].Numero, patientList.lp[a].Nom, patientList.lp[a].Prenom);
							}
						}
					}
				}
			}
		}

		///////////////////// TRIER PAR ////////////////////////////////
		private void radioButton1_Click(object sender, EventArgs e)
		{
			bunifuDataGridView1.Sort(bunifuDataGridView1.Columns[0], ListSortDirection.Ascending);
		}
		private void radioButton2_Click(object sender, EventArgs e)
		{
			bunifuDataGridView1.Sort(bunifuDataGridView1.Columns[1], ListSortDirection.Ascending);
		}
		private void radioButton3_Click(object sender, EventArgs e)
		{
			bunifuDataGridView1.Sort(bunifuDataGridView1.Columns[2], ListSortDirection.Ascending);
		}
		///////////////////////////////////////////////////////////////
		
		private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{}
		
		private void button6_Click(object sender, EventArgs e)
		{
			// PanelRendez-vous : Regler un rendez-vous
			Ajouter_RDV ajr = new Ajouter_RDV();
			ajr.Show();
			button6.Enabled = false;
			Program.button1 = button6;
		}

		private void button5_Click(object sender, EventArgs e)
		{}

		private void button7_Click(object sender, EventArgs e)
		{
			// PanelRendez-vous : button Supprimer un rendez-vous
			if(bunifuDataGridView3.Rows.Count != 0)
			{ 
				DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer le rendez-vous selectionné ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if(dialogResult == DialogResult.Yes)
				{
					// désérialiser la liste des rendez-vous
					string objet1 = bunifuDataGridView3.CurrentRow.Cells[0].Value.ToString();
					string objet2 = bunifuDataGridView3.CurrentRow.Cells[1].Value.ToString();
					string objet3 = bunifuDataGridView3.CurrentRow.Cells[2].Value.ToString();
					string objet4 = bunifuDataGridView3.CurrentRow.Cells[3].Value.ToString();

					for (int i = rvList.rdv.Count - 1; i >= 0; i--)
					{
						if (objet1 == rvList.rdv[i].Nom && objet2 == rvList.rdv[i].Prenom && objet3 == rvList.rdv[i].Date.ToString() && objet4 == rvList.rdv[i].Heure)
						{
							rvList.rdv.RemoveAt(i);
							MessageBox.Show("Rendez-vous supprimé avec succés !!");
						}
					}
				}
			}
		}

		private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
		{
			// PanelRendez-vous : DateTimePicker value

			bunifuDataGridView3.DataSource = rvList.rdv.OrderBy(r => r.Heure).ToList();
			
			DataGridViewButtonColumn ValidationButtonColumn = new DataGridViewButtonColumn();
			ValidationButtonColumn.Name = "Validation";
			ValidationButtonColumn.Text = "Enter";
			ValidationButtonColumn.UseColumnTextForButtonValue = true;
			int columnIndex = 6;
			if (bunifuDataGridView3.Columns["Validation"] == null)
			{
				bunifuDataGridView3.Columns.Insert(columnIndex, ValidationButtonColumn);
			}


			for (int i = 0; i < bunifuDataGridView3.Rows.Count; i++)
			{
				string value4 = bunifuDataGridView3.Rows[i].Cells[3].Value.ToString();
				string d1 = bunifuDataGridView3.Rows[i].Cells[2].Value.ToString();
				DateTime d2 = bunifuDatePicker1.Value.Date;

				if (d1 == d2.ToString() || d2.ToString() == value4)
				{
					bunifuDataGridView3.Rows[i].Visible = true;
				}
				else
				{
					CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[bunifuDataGridView3.DataSource];
					currencyManager1.SuspendBinding();
					bunifuDataGridView3.Rows[i].Visible = false;
					currencyManager1.ResumeBinding();
				}
			}
		}
		
		//////////////////////// RESET ////////////////////////////////////////
		private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Vous êtes sur le point de supprimer tous les Information des patients !!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.OK)
			{
				Utils.DeletePatients();
			}
		}
		private void rendezvousToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Vous êtes sur le point de supprimer tous les Information des rendez-vous !!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.OK)
			{
				Utils.DeleteRV();
			}
		}
		private void tOUSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Vous êtes sur le point de supprimer tous les Information de l'application !!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.OK)
			{
				Utils.DeletePatients();
				Utils.DeleteRV();
			}
		}
		///////////////////////////////////////////////////////////////////////

		public static List<double> money = new List<double>();

		private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// PanelRendez-vous : DataGridView Enter Button 
			if (e.ColumnIndex == bunifuDataGridView3.Columns["Validation"].Index)
			{
				bunifuDataGridView3.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
				if (bunifuDataGridView3.Rows.Count != 0)
				{
					string objet1 = bunifuDataGridView3.CurrentRow.Cells[0].Value.ToString();
					string objet2 = bunifuDataGridView3.CurrentRow.Cells[1].Value.ToString();
					string objet3 = bunifuDataGridView3.CurrentRow.Cells[2].Value.ToString();
					string objet4 = bunifuDataGridView3.CurrentRow.Cells[3].Value.ToString();
					string objet5 = bunifuDataGridView3.CurrentRow.Cells[4].Value.ToString();

					for (int i = rvList.rdv.Count - 1; i >= 0; i--)
					{
						if ((objet1 == rvList.rdv[i].Nom && objet2 == rvList.rdv[i].Prenom && objet3 == rvList.rdv[i].Date.ToString() && objet4 == rvList.rdv[i].Heure) || (objet2 == rvList.rdv[i].Nom && objet3 == rvList.rdv[i].Prenom && objet4 == rvList.rdv[i].Date.ToString() && objet5 == rvList.rdv[i].Heure))
						{
							money.Add(rvList.rdv[i].Payment);
							//rvList.rdv.RemoveAt(i);
						}
					}
				}
				bunifuDataGridView3.CurrentRow.Selected = false;
			}
		}

		

		private void button5_Click_1(object sender, EventArgs e)
		{
			// Afficher : Rechercher

			for (int i = 0; i < bunifuDataGridView2.Rows.Count; i++)
			{
				string Rnum = bunifuDataGridView2.Rows[i].Cells[0].Value.ToString();
				string Rnom = bunifuDataGridView2.Rows[i].Cells[1].Value.ToString();
				string Rprenom = bunifuDataGridView2.Rows[i].Cells[2].Value.ToString();


				if (bunifuTextBox1.Text == Rnum || bunifuTextBox1.Text == Rnom || bunifuTextBox1.Text == Rprenom)
				{
					bunifuDataGridView2.Rows[i].Visible = true;
				}
				else
				{
					CurrencyManager currencyManager2 = (CurrencyManager)BindingContext[bunifuDataGridView2.DataSource];
					currencyManager2.SuspendBinding();
					bunifuDataGridView2.Rows[i].Visible = false;
					currencyManager2.ResumeBinding();
				}
			}
		}

		private void bunifuHScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuHScrollBar.ScrollEventArgs e)
		{

		}

		private void bunifuButton1_Click(object sender, EventArgs e)
		{
			DateTime StartingDate = monthCalendar1.SelectionRange.Start;
			DateTime EndingDate = monthCalendar2.SelectionRange.Start;
			List<DateTime> dates = new List<DateTime>();
			DateTime tmpDate = StartingDate;
			do
			{
				dates.Add(tmpDate);
				tmpDate = tmpDate.AddDays(1);

			} while (tmpDate <= EndingDate);

			RvList rvList = Utils.deserializerRvList();
			int count = 0;
			double montant = 0;
			double visite = 0;
			double controle = 0;
			foreach (DateTime date in dates)
			{
				foreach(ClassRDV rv in rvList.rdv)
				{
					if(date == rv.Date)
					{
						count++;
						montant += rv.Payment;
						if (rv.Type == "Contrôle")
						{
							controle++;
						}
						else if (rv.Type == "Visite")
						{
							visite++;
						}
					}
				}
			}
			bunifuTextBox2.Text = count.ToString();
			bunifuTextBox3.Text = montant.ToString() + " DH";

			double plus = controle + visite;
			double con = controle / plus * 100;
			double vis = visite / plus * 100;

			chart1.Series["s1"].Points.Clear();
			chart1.Series["s1"].IsValueShownAsLabel = true;
			chart1.Series["s1"].Points.AddXY("Contrôles", controle);
			chart1.Series["s1"].Points.AddXY("Visites", visite);
		}

		private void label21_Click(object sender, EventArgs e)
		{}
	}
}
