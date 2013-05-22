using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initiative_Tracker
{
    class InitiativeNode : IComparable<InitiativeNode>
    {
        private String charName;
        private int initNum;

        public InitiativeNode(String name, int num)
        {
            charName = name;
            initNum = num;
        }

        public String getCharName()
        {
            return charName;
        }

        public int getInit()
        {
            return initNum;
        }

		public override String ToString()
		{
			return "" + charName + ": " + initNum + "\n";
		}

		public int CompareTo(InitiativeNode node)
		{
			if(node == null)
			{
				return 1;
			}
			return -1*initNum.CompareTo(node.getInit());
		}
    }
}