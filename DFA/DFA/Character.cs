using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFA
{
    class Character
    {
        public static char charValue;
        public static int listIndex;

        public void setCharValue(char c)
        {
            charValue = c;
        }

        public void setListIndex(int i)
        {
            listIndex = i;
        }
    }
}
