using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Initiative_Tracker
{
    class InitiativeNode : IComparable<InitiativeNode>
    {
		private String charName;
		private int initNum;
        private int rerollNum;

        public InitiativeNode(String name, int num)
        {
            charName = name;
            initNum = num;
            rerollNum = 0;
        }

		public String Name
		{
			get { return charName; }
			set { charName = value; }
		}

		public int Init
		{
			get { return initNum; }
			set { initNum = value; }
		}

        public int Reroll
        {
            get { return rerollNum; }
            set { rerollNum = value; }
        }

		public ListViewItem getListItem()
		{
			ListViewItem item = new ListViewItem();
			item.SubItems.Add(charName);
			item.SubItems.Add(initNum.ToString("0"));
			return item;
		}

		public override String ToString()
		{
			return "" + charName + ": " + initNum;
		}

		public int CompareTo(InitiativeNode node)
		{
			if(node == null)
			{
				return 1;
			}
            if(-1*initNum.CompareTo(node.Init) == 0)
            {
                return -1 * rerollNum.CompareTo(node.Reroll);
            }
			return -1*initNum.CompareTo(node.Init);
		}
    }
}