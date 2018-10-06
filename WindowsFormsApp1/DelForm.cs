using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class DelForm : Form
	{
		public DelForm(int tabIndex)
		{
			InitializeComponent();
		}

		private void DelForm_Load(object sender, EventArgs e)
		{

			button1.DialogResult = DialogResult.OK;
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox1.DataSource = db.Olympiads.ToList();
				comboBox1.DisplayMember = "OlympiadYear";
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex !=-1)
			{
				using (ApplicationContext db = new ApplicationContext())
				{
					comboBox2.DataSource = null;
					comboBox3.DataSource = null;
					comboBox4.DataSource = null;
					comboBox2.DataSource = db.Sports.Where(p => p.OlympiadId == (comboBox1.SelectedItem as Olympiad).Id).ToList();
					comboBox2.DisplayMember = "SportName";
				}
			}
			comboBox2.SelectedIndex = -1;
			comboBox3.SelectedIndex = -1;
			comboBox4.SelectedIndex = -1;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox2.SelectedIndex !=-1)
			{
				using (ApplicationContext db = new ApplicationContext())
				{
					comboBox3.DataSource = null;
					comboBox4.DataSource = null;
					comboBox3.DataSource = db.Persons.Where(p => p.SportId == (comboBox2.SelectedItem as Sport).Id).ToList();
					comboBox3.DisplayMember = "PersonFirstName";
				}
			}
			comboBox3.SelectedIndex = -1;
			comboBox4.SelectedIndex = -1;
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox3.SelectedIndex != -1)
			{
				using (ApplicationContext db = new ApplicationContext())
				{
					comboBox4.DataSource = null;
					comboBox4.DataSource = db.Results.Where(p => p.PersonId == (comboBox3.SelectedItem as Person).Id).ToList();
					comboBox4.DisplayMember = "ResultMedalType";
				}
			}
			comboBox4.SelectedIndex = -1;
		}
	}
}
