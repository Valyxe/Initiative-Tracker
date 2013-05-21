using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class InitiativeNode
    {
        private String charName;
        private int initNum;
        private InitiativeNode next;

        public InitiativeNode(String name, int num, InitiativeNode prev)
        {
            charName = name;
            initNum = num;
            next = null;
            prev.setNext(this);
        }

        public void setNext(InitiativeNode node)
        {
            next = node;
        }

        public String getCharName()
        {
            return charName;
        }

        public int getInit()
        {
            return initNum;
        }

        public InitiativeNode getNext()
        {
            return next;
        }
    }
}
