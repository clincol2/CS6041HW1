using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HW1_prob3
{
    public partial class Form1 : Form
    {
        public static string userInput = "";
        public static int inputLen;

        public static string currentState = "q0";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userInput = userInputBox.Text;

            if (stringIsValid(userInput))
            {
                MessageBox.Show("The string " + userInput + " is accepted for 0*1*0");
            }
            else
            {
                MessageBox.Show("The string " + userInput + " is rejected for 0*1*0");
            }
        }


        public bool stringIsValid(String w)
        {
            bool verdict = false;

            char[] arrayVersionOfW = w.ToCharArray();

            string previousInW = "";

            if (String.IsNullOrEmpty(w))
            {
                //fails because it must have
                //at least "0"
                verdict = false;
                return verdict;
            }

            //
            for (int i = 0; i < w.Length; i++)
            {
                char pre_s = arrayVersionOfW[i];
                string s = pre_s.ToString();

                previousInW = previousInW + s;

                switch (s)
                {

                    //since this is an nfa, we can explicitly
                    //refer back to previous values
                    //instead of relying on how the nodes are arranged

                    case("0"):
                        if(String.Equals(currentState,"q0")) 
                        {
                            currentState = "q0";
                            verdict = true;
                        }
                        else if (String.Equals(currentState,"q1"))
                        {
                            currentState = "q2";
                            verdict = true;
                        }
                        else if (String.Equals(currentState, "q2"))
                        {
                            //this happens when you
                            //have something like
                            //0001100, and you can't
                            //have more than one zero 
                            //at the end

                            //if anything happens after the
                            //ending zero, then w is 
                            //automatically invalid

                            //strings like "0000"
                            //with only zeroes are valid,
                            //but we don't need to worry about
                            //them here, since they will
                            //have stayed on q0 the
                            //whole time
                            verdict = false;
                        }
                        break;

                    case("1"):
                        if (String.Equals(currentState, "q0"))
                        {
                            currentState = "q1";
                            verdict = false;
                        }
                        else if (String.Equals(currentState, "q1"))
                        {
                            currentState = "q1";
                            verdict = false;
                        }
                        else if (String.Equals(currentState, "q2"))
                        {
                            //this happens when you
                            //have something like
                            //0001101, and you can't
                            //have 1's happening
                            //in more than the one
                            //substring in the middle

                            //the only way it would be
                            //here at q2 is if
                            //the substring "10" has happened,
                            //and, logically, that can't
                            //have anything after it

                            verdict = false;
                        }
                        break;

                    default:

                        break;
                }
            }

            return verdict;
        }

    }
}
