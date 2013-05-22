using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Initiative_Tracker
{
	class InitiativeForm : System.Windows.Forms.Form
	{
		private TextBox charNameTxtBox;
		private TextBox charInitTxtBox;
		private Button addCharBtn;
		private ListBox initNameListBox;
		private ListBox initNumListBox;
		private List<InitiativeNode> initList;

		//Initialize the form.
		public InitiativeForm()
		{
			//Initialize control structures.
			charNameTxtBox = new TextBox();
			charInitTxtBox = new TextBox();
			addCharBtn = new Button();
			initNameListBox = new ListBox();
			initNumListBox = new ListBox();
			initList = new List<InitiativeNode>();

			//Set form attributes.
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.BackColor = Color.LightGray;
			this.ForeColor = Color.Black;
			this.Size = new System.Drawing.Size(300, 300);
			this.Text = "Pathfinder Initiative Tracker";
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.StartPosition = FormStartPosition.CenterScreen;

			//Add text box for character name.
			charNameTxtBox.Location = new System.Drawing.Point(10, 25);
			charNameTxtBox.Size = new System.Drawing.Size(100, 20);
			this.Controls.Add(charNameTxtBox);
			
			//Add text box for initiative roll.
			charInitTxtBox.Location = new System.Drawing.Point(120, 25);
			charInitTxtBox.Size = new System.Drawing.Size(25, 20);
			this.Controls.Add(charInitTxtBox);

			//Add button that adds character to list.
			addCharBtn.BackColor = Color.DarkGray;
			addCharBtn.Text = "Add Character";
			addCharBtn.Location = new System.Drawing.Point(155, 25);
			addCharBtn.Size = new System.Drawing.Size(85, 20);
			addCharBtn.Click += new EventHandler(addButtonClick);
			this.Controls.Add(addCharBtn);

			//Add list box that shows character names.
			initNameListBox.Sorted = false;
			initNameListBox.Location = new System.Drawing.Point(10, 85);
			initNameListBox.Size = new System.Drawing.Size(100, 100);
			this.Controls.Add(initNameListBox);

			//Add list box that shows character initiatives.
			initNumListBox.Sorted = false;
			initNumListBox.Location = new System.Drawing.Point(110, 85);
			initNumListBox.Size = new System.Drawing.Size(100, 100);
			this.Controls.Add(initNumListBox);
		}

		private void addButtonClick(object sender, System.EventArgs e)
		{
			String name = charNameTxtBox.Text;
			int init = Convert.ToInt32(charInitTxtBox.Text);
			InitiativeNode node = new InitiativeNode(name, init);
			initList.Add(node);
			initList.Sort();

			initNameListBox.Items.Clear();
			initNumListBox.Items.Clear();
			Console.Write("------------------\n");
			for (int i = 0; i < initList.Count; i++)
			{
				initNameListBox.Items.Add(initList.ElementAt(i).getCharName());
				initNumListBox.Items.Add(initList.ElementAt(i).getInit());
				Console.Write("{0}", initList.ElementAt(i).ToString());
			}

			charNameTxtBox.Text = "";
			charInitTxtBox.Text = "";
		}
	}
}
