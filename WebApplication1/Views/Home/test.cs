using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApplication1.Views.Home
{
	public partial class test : Form
	{
		public Image choosedImage = Image.FromFile("wwwroot\\res\\henry.jpeg");
		public test()
		{
			InitializeComponent();
			BackgroundImage = choosedImage;
		}

		private void test_Load(object sender, EventArgs e)
		{
			BackgroundImage = choosedImage;
		}
	}
}
