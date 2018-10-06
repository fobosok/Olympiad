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
    public partial class Form1 : Form
    {
		AddForm AddForm = null;
		DelForm DelForm = null;
        public Form1()
        {
            InitializeComponent();
        }
		public void RefreshTree()
		{
			treeView1.Nodes.Clear();
			using (ApplicationContext db = new ApplicationContext())
			{
				foreach (var olympiad in db.Olympiads.ToList())
				{
					TreeNode nodeOlympiad = new TreeNode(olympiad.OlympiadYear.ToString());
					treeView1.Nodes.Add(nodeOlympiad);
					foreach (var sport in db.Sports.ToList())
					{
						if (sport.OlympiadId == olympiad.Id)
						{
							TreeNode nodeSport = new TreeNode(sport.SportName);
							nodeOlympiad.Nodes.Add(nodeSport);
							foreach (var person in db.Persons.ToList())
							{
								if (person.SportId == sport.Id)
								{
									TreeNode nodePerson = new TreeNode(person.PersonFirstName);
									nodeSport.Nodes.Add(nodePerson);
									foreach (var result in db.Results.ToList())
									{
										if(result.PersonId == person.Id)
										{
											TreeNode nodeResult = new TreeNode(result.ResultMedalType);
											nodePerson.Nodes.Add(nodeResult);
										}
									}
								}
							}
						}
					}
				}
			}
		}
        private void Form1_Load(object sender, EventArgs e)
        {
			RefreshTree();
            using (ApplicationContext db = new ApplicationContext())
            {
			}
        }

        private void button1_Click(object sender, EventArgs e)
        {
			AddForm = new AddForm(0);
			if(AddForm.ShowDialog()==DialogResult.OK)
			{
				RefreshTree();
			}
        }

		private void button2_Click(object sender, EventArgs e)
		{
			AddForm = new AddForm(1);
			if (AddForm.ShowDialog() == DialogResult.OK)
			{
				RefreshTree();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			AddForm = new AddForm(2);
			if (AddForm.ShowDialog() == DialogResult.OK)
			{
				RefreshTree();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			AddForm = new AddForm(3);
			if (AddForm.ShowDialog() == DialogResult.OK)
			{
				RefreshTree();
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			DelForm = new DelForm(0);
			if (DelForm.ShowDialog()== DialogResult.OK)
			{
				RefreshTree();
			}
		}
	}
}
