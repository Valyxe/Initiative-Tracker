using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Initiative_Tracker
{
	class Program
	{
		static void Main(string[] args)
		{
			InitiativeForm init = new InitiativeForm();
			init.ShowDialog();
			init.Focus();
		}
	}
}
