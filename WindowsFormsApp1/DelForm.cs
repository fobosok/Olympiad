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
		public int counter = 0;
		public int delCounter = 0;
		public DelForm(int tabIndex)
		{
			InitializeComponent();
			if (tabIndex == 2)
			{
				comboBox4.Visible = false;
				label4.Visible = false;
				button5.Visible = false;

				delCounter = 3;
			}
			else if (tabIndex == 1)
			{
				comboBox4.Visible = false;
				label4.Visible = false;
				button5.Visible = false;

				comboBox3.Visible = false;
				label3.Visible = false;
				button4.Visible = false;

				delCounter = 2;
			}
			else if (tabIndex == 0)
			{
				comboBox4.Visible = false;
				label4.Visible = false;
				button5.Visible = false;

				comboBox3.Visible = false;
				label3.Visible = false;
				button4.Visible = false;

				comboBox2.Visible = false;
				label2.Visible = false;
				button3.Visible = false;

				delCounter = 1;
			}
			else
			{
				delCounter = 4;
			}

		}

		private void DelForm_Load(object sender, EventArgs e)
		{
			button1.Enabled = false;
			button1.DialogResult = DialogResult.OK;
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox1.DataSource = null;
				comboBox1.DataSource = db.Olympiads.ToList();
				comboBox1.DisplayMember = "OlympiadYear";
				comboBox1.SelectedIndex = -1;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				if (counter == 4)
				{
					db.Remove(comboBox4.SelectedItem as Result);
				}
				else if (counter == 3)
				{
					db.Remove(comboBox3.SelectedItem as Person);
				}
				else if (counter == 2)
				{
					db.Remove(comboBox2.SelectedItem as Sport);
				}
				else if (counter == 1)
				{
					db.Remove(comboBox1.SelectedItem as Olympiad);
				}
				db.SaveChanges();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox2.DataSource = null;
				comboBox2.DataSource = db.Sports.Where(p => p.OlympiadId == (comboBox1.SelectedItem as Olympiad).Id).ToList();
				comboBox2.DisplayMember = "SportName";
				comboBox2.SelectedIndex = -1;
			}
			counter++;
			delCounter--;
			if (delCounter == 0)
			{
				button1.Enabled = true;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox3.DataSource = null;
				comboBox3.DataSource = db.Persons.Where(p => p.SportId == (comboBox2.SelectedItem as Sport).Id).ToList();
				comboBox3.DisplayMember = "PersonFirstName";
				comboBox3.SelectedIndex = -1;
			}
			counter++;
			delCounter--;
			if (delCounter == 0)
			{
				button1.Enabled = true;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox4.DataSource = null;
				comboBox4.DataSource = db.Results.Where(p => p.PersonId == (comboBox3.SelectedItem as Person).Id).ToList();
				comboBox4.DisplayMember = "ResultMedalType";
				comboBox4.SelectedIndex = -1;
			}
			counter++;
			delCounter--;
			if (delCounter == 0)
			{
				button1.Enabled = true;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			counter++;
			delCounter--;
			if (delCounter == 0)
			{
				button1.Enabled = true;
			}
		}
	}
}
