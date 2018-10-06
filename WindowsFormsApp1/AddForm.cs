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
	public partial class AddForm : Form
	{
		public AddForm(int tabIndex)
		{
			InitializeComponent();
			tabControl1.SelectedIndex = tabIndex;
		}

		private void AddForm_Load(object sender, EventArgs e)
		{
			tabControl1.SizeMode = TabSizeMode.Fixed;
			tabControl1.ItemSize = new Size(tabControl1.Width / tabControl1.TabCount, 0);
			button1.DialogResult = DialogResult.OK;
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox1.DataSource = null;
				comboBox1.DataSource = db.Olympiads.ToList();
				comboBox1.DisplayMember = "OlympiadYear";

				comboBox2.DataSource = null;
				comboBox2.DataSource = db.Sports.ToList();
				comboBox2.DisplayMember = "SportName";

				comboBox3.DataSource = null;
				comboBox3.DataSource = db.Persons.ToList();
				comboBox3.DisplayMember = "PersonFirstName";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				if (tabControl1.SelectedIndex == 0)
				{
					bool season = false;
					if (radioButton1.Checked)
					{
						season = true;
					}
					else if (radioButton2.Checked)
					{
						season = false;
					}
					db.Olympiads.Add(new Olympiad
					{
						OlympiadYear = Convert.ToInt32(textBox1.Text),
						OlympiadSeason = season,
						OlympiadCountry = textBox2.Text,
						OlympiadCity = textBox3.Text
					});
					db.SaveChanges();

				}
				else if (tabControl1.SelectedIndex == 1)
				{
					db.Sports.Add(new Sport
					{
						OlympiadId = (comboBox1.SelectedItem as Olympiad).Id,
						SportName = textBox4.Text,
						SportInfo = textBox5.Text,
						SportPersonCount = Convert.ToInt32(textBox6.Text)
					});
					db.SaveChanges();
				}
				else if (tabControl1.SelectedIndex == 2) 
				{
					db.Persons.Add(new Person
					{
						SportId = (comboBox2.SelectedItem as Sport).Id,
						PersonFirstName = textBox9.Text,
						PersonLastName = textBox8.Text,
						PersonCountry = textBox7.Text,
						PersonDateOfBirthday = dateTimePicker1.Value
					});
					db.SaveChanges();
				}
				else if (tabControl1.SelectedIndex == 3)
				{
					db.Results.Add(new Result
					{
						PersonId = (comboBox3.SelectedItem as Person).Id,
						ResultMedalType = comboBox4.Text
					});
					db.SaveChanges();
				}
			}
		
		}
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
				radioButton2.Checked = false;
			else
				radioButton1.Checked = true;
		}
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
				radioButton1.Checked = false;
			else
				radioButton2.Checked = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox1.Text = string.Empty;
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
			textBox4.Text = string.Empty;
			textBox5.Text = string.Empty;
			textBox6.Text = string.Empty;
			textBox7.Text = string.Empty;
			textBox8.Text = string.Empty;
			textBox9.Text = string.Empty;
		}
	}
}
