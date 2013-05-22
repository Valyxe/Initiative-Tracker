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
		private Button removeCharBtn;
		private ListView initListView;
		private ListViewItem initListViewNames;
		private ListViewItem initListViewNums;
		private List<InitiativeNode> initList;

		//Initialize the form.
		public InitiativeForm()
		{
			//Initialize control structures.
			charNameTxtBox = new TextBox();
			charInitTxtBox = new TextBox();
			addCharBtn = new Button();
			removeCharBtn = new Button();
			initListView = new ListView();
			initList = new List<InitiativeNode>();

			//Set form attributes.
			this.MaximizeBox = false;
			this.MinimizeBox = true ;
			this.BackColor = Color.LightGray;
			this.ForeColor = Color.Black;
			this.Size = new System.Drawing.Size(300, 300);
			this.Text = "Initiative Tracker";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
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

			//Add button that removes character from list.
			removeCharBtn.BackColor = Color.DarkGray;
			removeCharBtn.Text = "Del Character";
			removeCharBtn.Location = new System.Drawing.Point(155, 55);
			removeCharBtn.Size = new System.Drawing.Size(85, 20);
			removeCharBtn.Click += new EventHandler(removeButtonClick);
			this.Controls.Add(removeCharBtn);

			//Add list view that shows character names and initiatives.
			initListView.GridLines = true;
			initListView.Location = new System.Drawing.Point(10, 85);
			initListView.Size = new System.Drawing.Size(200, 100);
			this.Controls.Add(initListView);

			//Give focus to name text box.
			charNameTxtBox.Focus();
		}

		private void addButtonClick(object sender, System.EventArgs e)
		{
			if (charNameTxtBox.Text.Trim().Length == 0 || charInitTxtBox.Text.Trim().Length == 0)
			{
				//Give focus to name text box.
				charNameTxtBox.Focus();
				return;
			}
			String name = charNameTxtBox.Text;
			int init = Convert.ToInt32(charInitTxtBox.Text);
			InitiativeNode node = new InitiativeNode(name, init);
			for (int i = 0; i < initList.Count; i++)
			{
				if (initList.ElementAt(i).getCharName().Equals(node.getCharName()))
				{
					Console.Write("Error on addButtonClick: Character already exists in list");
					charNameTxtBox.Text = "";
					charInitTxtBox.Text = "";

					//Give focus to name text box.
					charNameTxtBox.Focus();
					return;
				}
			}
			initList.Add(node);
			initList.Sort();

			repopulateListBox();
			charNameTxtBox.Text = "";
			charInitTxtBox.Text = "";

			//Give focus to name text box.
			charNameTxtBox.Focus();
		}

		private void removeButtonClick(object sender, System.EventArgs e)
		{
			if (charNameTxtBox.Text.Trim().Length == 0)
			{
				//Give focus to name text box.
				charNameTxtBox.Focus();
				return;
			}
			String name = charNameTxtBox.Text;
			for (int i = 0; i < initList.Count; i++)
			{
				if (initList.ElementAt(i).getCharName().Equals(name))
				{
					initList.RemoveAt(i);
					break;
				}
			}

			repopulateListBox();
			charNameTxtBox.Text = "";
			charInitTxtBox.Text = "";

			//Give focus to name text box.
			charNameTxtBox.Focus();
		}

		private void repopulateListBox()
		{
			initListView.Items.Clear();
			Console.Write("------------------\n");
			for (int i = 0; i < initList.Count; i++)
			{
				initListView.Items.Add(""+initList.ElementAt(i).getCharName()+"\t\t:\t"+initList.ElementAt(i).getInit());
				Console.Write("{0}", initList.ElementAt(i).ToString());
			}
		}
	}
}
