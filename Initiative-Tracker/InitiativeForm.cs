﻿using System;
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
            this.Icon = new System.Drawing.Icon("../../d20.ico");
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.StartPosition = FormStartPosition.CenterScreen;

			//Add text box for character name.
			charNameTxtBox.Location = new System.Drawing.Point(15, 25);
			charNameTxtBox.Size = new System.Drawing.Size(125, 20);
			this.Controls.Add(charNameTxtBox);
			
			//Add text box for initiative roll.
			charInitTxtBox.Location = new System.Drawing.Point(150, 25);
			charInitTxtBox.Size = new System.Drawing.Size(25, 20);
			this.Controls.Add(charInitTxtBox);

			//Add button that adds character to list.
			addCharBtn.BackColor = Color.DarkGray;
			addCharBtn.Text = "Add";
			addCharBtn.Location = new System.Drawing.Point(185, 25);
			addCharBtn.Size = new System.Drawing.Size(80, 20);
			addCharBtn.Click += new EventHandler(addButtonClick);
			this.Controls.Add(addCharBtn);

			//Add button that removes character from list.
			removeCharBtn.BackColor = Color.DarkGray;
			removeCharBtn.Text = "Remove";
			removeCharBtn.Location = new System.Drawing.Point(100, 215);
			removeCharBtn.Size = new System.Drawing.Size(80, 20);
			removeCharBtn.Click += new EventHandler(removeButtonClick);
			this.Controls.Add(removeCharBtn);

			//Add list view that shows character names and initiatives.
			initListView.View = View.Details;
			initListView.FullRowSelect = true;
			initListView.MultiSelect = false;
			initListView.GridLines = true;
			initListView.Columns.Add("", 0);
			initListView.Columns.Add("Name", 176, HorizontalAlignment.Left);
			initListView.Columns.Add("Roll", 70, HorizontalAlignment.Center);
			initListView.AllowColumnReorder = false;
			initListView.Location = new System.Drawing.Point(15, 65);
			initListView.Size = new System.Drawing.Size(250, 130);
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
            int init = 0;
            try
            {
                init = Convert.ToInt32(charInitTxtBox.Text);
            }
            catch (System.FormatException)
            {
                string text = "Incorrect input on roll number.";
                string caption = "Format Error.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBox.Show(text, caption, button, icon);

                charNameTxtBox.Text = "";
                charInitTxtBox.Text = "";

                //Give focus to name text box.
                charNameTxtBox.Focus();
                return;
            }
			InitiativeNode node = new InitiativeNode(name, init);
			for (int i = 0; i < initList.Count; i++)
			{
				if (initList.ElementAt(i).Name.Equals(node.Name))
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

            checkForConflicts();

			//Give focus to name text box.
			charNameTxtBox.Focus();
		}

		private void removeButtonClick(object sender, System.EventArgs e)
		{
			if (initListView.SelectedItems.Count > 0)
			{
				initList.RemoveAt(initListView.SelectedItems[0].Index);

				repopulateListBox();
			}
			charNameTxtBox.Text = "";
			charInitTxtBox.Text = "";

			//Give focus to name text box.
			charNameTxtBox.Focus();
		}

		private void checkForConflicts()
		{
			Console.WriteLine("------------");
			for (int i = 0; i < initList.Count(); i++)
			{
				Console.WriteLine("Checking for conflicts: " + i);
				List<InitiativeNode> conflicts = initList.FindAll(
					delegate(InitiativeNode node)
					{
						if (node.Init == initList.ElementAt(i).Init)
						{
							return true;
						}
						return false;
					});

				if (conflicts.Count > 1)
				{
					foreach (InitiativeNode n in conflicts)
					{
                        Console.WriteLine(n.Reroll);
                        if (n.Reroll == 0)
                        {
                            string reroll = "";
                            InputForm.InputBox("Conflict Resolution", n.Name + "'s reroll.", ref reroll);
                            Console.WriteLine(initList.ElementAt(initList.IndexOf(n)).ToString());
                            initList.ElementAt(initList.IndexOf(n)).Reroll = Convert.ToInt32(reroll);
                            Console.WriteLine(initList.ElementAt(initList.IndexOf(n)).ToString());
                        }
					}
				}

				initList.Sort();
				repopulateListBox();
			}
		}

		private void repopulateListBox()
		{
			//Clear the list before repopulation.
			initListView.Items.Clear();

			//Add items to sublists.
			Console.Write("------------------\n");
			for (int i = 0; i < initList.Count; i++)
			{
				initListView.Items.Add(initList.ElementAt(i).getListItem());
				Console.Write(initList.ElementAt(i).ToString());
			}
		}
	}
}