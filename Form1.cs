using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routes
{
	public partial class Form1 : Form
	{
		Navigator Navigator;
		public Form1()
		{
			Navigator = new Navigator();
			InitializeComponent();
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(Routes.Navigator.Cities);
			comboBox2.Items.Clear();
			comboBox2.Items.AddRange(Routes.Navigator.Cities);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex == comboBox2.SelectedIndex) 
			{ 
				MessageBox.Show("Star and Finish must differ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				//вот тут надо в label4.Text вывести результат
				label4.Text = Navigator.Dijkstra(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
			}
		}
	}
}
