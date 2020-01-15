using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Cabinet_medical
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//this.BackgroundImage = Image.FromFile(@"C:\Users\hp\Desktop\Amine\BackgroundGif.gif");

			
			int formHeight = this.Height;
			int formWidth = this.Width;
			PictureBox picture = new PictureBox
			{
				Name = "pictureBox",
				Size = new Size(formWidth, formHeight),
				Location = new Point(0, 0),
				Image = Image.FromFile(@"BackgroundGif.gif"),
				SizeMode = PictureBoxSizeMode.StretchImage
			};
			Controls.Add(picture);
			
		}

		private void sTARTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			Login login = new Login();
			login.Show();
			toolStripMenuItem1.Enabled = false;
		}

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{}
	}
}
