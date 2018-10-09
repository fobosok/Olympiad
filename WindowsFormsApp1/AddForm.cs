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

			textBox4.Enabled = false;
			textBox5.Enabled = false;
			textBox6.Enabled = false;

			comboBox2.Enabled = false;
			button7.Enabled = false;
			textBox9.Enabled = false;
			textBox8.Enabled = false;
			textBox7.Enabled = false;
			dateTimePicker1.Enabled = false;

			comboBox7.Enabled = false;
			button5.Enabled = false;

			comboBox3.Enabled = false;
			button6.Enabled = false;

			comboBox4.Enabled = false;
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox1.DataSource = null;
				comboBox1.DataSource = db.Olympiads.ToList();
				comboBox1.DisplayMember = "OlympiadYear";
				comboBox1.SelectedIndex = -1;

                comboBox5.DataSource = null;
                comboBox5.DataSource = db.Olympiads.ToList();
                comboBox5.DisplayMember = "OlympiadYear";
				comboBox5.SelectedIndex = -1;

				comboBox6.DataSource = null;
				comboBox6.DataSource = db.Olympiads.ToList();
				comboBox6.DisplayMember = "OlympiadYear";
				comboBox6.SelectedIndex = -1;
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

        private void button3_Click(object sender, EventArgs e)
        {
			comboBox2.Enabled = true;
			button7.Enabled = true;
			using (ApplicationContext db = new ApplicationContext())
            {
                comboBox2.DataSource = null;
                comboBox2.DataSource = db.Sports.Where(p => p.OlympiadId == (comboBox5.SelectedItem as Olympiad).Id).ToList();
				comboBox2.DisplayMember = "SportName";
				comboBox2.SelectedIndex = -1;
            }

        }

		private void button4_Click(object sender, EventArgs e)
		{
			comboBox7.Enabled = true;
			button5.Enabled = true;
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox7.DataSource = null;
				comboBox7.DataSource = db.Sports.Where(p => p.OlympiadId == (comboBox6.SelectedItem as Olympiad).Id).ToList();
				comboBox7.DisplayMember = "SportName";
				comboBox7.SelectedIndex = -1;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			comboBox3.Enabled = true;
			button6.Enabled = true;
			using (ApplicationContext db = new ApplicationContext())
			{
				comboBox3.DataSource = null;
				comboBox3.DataSource = db.Persons.Where(p => p.SportId == (comboBox7.SelectedItem as Sport).Id).ToList();
				comboBox3.DisplayMember = "PersonFirstName";
				comboBox3.SelectedIndex = -1;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			comboBox4.Enabled = true;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			textBox9.Enabled = true;
			textBox8.Enabled = true;
			textBox7.Enabled = true;
			dateTimePicker1.Enabled = true;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			textBox4.Enabled = true;
			textBox5.Enabled = true;
			textBox6.Enabled = true;
		}
	}
}
