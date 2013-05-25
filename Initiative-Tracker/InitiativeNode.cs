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
		private double initNum;

        public InitiativeNode(String name, int num)
        {
            charName = name;
            initNum = num;
        }

		public String Name
		{
			get { return charName; }
			set { charName = value; }
		}

		public double Init
		{
			get { return initNum; }
			set { initNum = value; }
		}


		public ListViewItem getListItem()
		{
			ListViewItem item = new ListViewItem();
			item.SubItems.Add(charName);
			item.SubItems.Add(initNum.ToString("0.00"));
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
			return -1*initNum.CompareTo(node.Init);
		}
    }
}