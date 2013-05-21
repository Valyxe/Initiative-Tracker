using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initiative_Tracker
{
	class InitiativeList
	{
		private InitiativeNode l_Head;

		public InitiativeList()
		{

		}

		public InitiativeList(InitiativeNode first)
		{
			l_Head = first;
		}
	}
}
