using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;



namespace DFA
{
    public partial class Form1 : Form
    {

        public static string userInput = "";
        public static int inputLen;
        //public List<Character> inputList = new List<Character>();

        public Form1()
        {
            InitializeComponent();
            //Microsoft.VisualBasic.Interaction.InputBox("test");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userInput = userInputBox.Text;
            inputLen = userInput.Length;
            char[] inputCArray = userInput.ToCharArray();

            //for (int i = 0; i < inputLen; i++)
            //{
            //    //takes values from charArray to List<Character>
            //    //use ElementAt() for searching by index? Maybe?
            //    char x = inputCArray[i];
            //    Character y = new Character();
            //    y.setCharValue(x);
            //    y.setListIndex(i);
            //    inputList.Add(y);
            //}
            //actually, now that I think about it, we don't need a list.
            //I went to List<Object> reflexively because you can't use an
            //array for this, since they have fixed size, but really, there's
            //no need to 

            if (stringIsValid(userInput))
            {
                MessageBox.Show("The string " + userInput + " is accepted for 0*1*");
            }
            else
            {
                MessageBox.Show("The string " + userInput + " is rejected for 0*1*");
            }

        }

        public bool stringIsValid(string w) 
        {

            bool verdict = true;
            int indexOfLast0 = -1;
            int indexOfLast1 = -1;

            if(String.IsNullOrEmpty(w)) 
            { //since 0*1* takes empty strings
                verdict = true;
                return verdict;
            }

            if (String.Equals(w, "0"))
            { //since 0*1* takes 0
                verdict = true;
                return verdict;
            }

            if (String.Equals(w, "1"))
            { //since 0*1* takes 0
                verdict = true;
                return verdict;
            }

            char[] arrayVersionOfW = w.ToCharArray();
            for (int i = 0; i < w.Length; i++)
            {
                //char x = w[i];
                char pre_x = arrayVersionOfW[i];
                string x = pre_x.ToString();
                if(String.Equals(x,"0"))
                {
                    indexOfLast0 = i;
                }
                else if (String.Equals(x, "1"))
                {
                    indexOfLast1 = i;
                }
                else
                {
                    //something besides 0 or 1 slipped in, which automatically disqualifies the string
                    verdict = false;
                    break;
                }

                //ultimately, if it's just 0's and 1's, we need to check if there are any 0's after 1's
                //that's the quickest rule of logic to rule out any string for 0*1* that we've
                //verified only has 0's and 1's
                if ((indexOfLast0 > -1) && (indexOfLast1 > -1))
                {
                    if (indexOfLast0 > indexOfLast1)
                    {

                        verdict = false;
                        break;
                    }
                }

            }


            return verdict;
        }

    }
}
