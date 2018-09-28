using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HW1_prob2
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
                MessageBox.Show("The string " + userInput + " is accepted for a(odd)b(even)");
            }
            else
            {
                MessageBox.Show("The string " + userInput + " is rejected for a(odd)b(even)");
            }
        }

        public bool stringIsValid(string w)
        {
            bool verdict = false;
            char[] arrayVersionOfW = w.ToCharArray();

            for (int i = 0; i < w.Length; i++)
            {
                char pre_s = arrayVersionOfW[i];
                string s = pre_s.ToString();

                //regex: b*(bb)*(aa)*

                switch (s)
                {
                    case "a":
                        if (String.Equals(currentState, "q0"))
                        {
                            currentState = "q4";
                            verdict = false;
                        }
                        else if (String.Equals(currentState, "q1"))
                        {
                            currentState = "q2";
                            verdict = false;
                        }
                        else if (String.Equals(currentState, "q2"))
                        {
                            currentState = "q1";
                            verdict = true;
                        }
                        else if (String.Equals(currentState, "q3"))
                        {
                            currentState = "q4";
                            verdict = false;
                        }
                        else if (String.Equals(currentState, "q4"))
                        {
                            currentState = "q4";
                            verdict = false;
                            //q4 is a dead end
                        }
                        else
                        {
                            //something weird has happened
                            MessageBox.Show("An error happened with the state tree.");
                        }
                        break;

                    case "b":
                        if (String.Equals(currentState, "q0"))
                        {
                            currentState = "q1";
                            verdict = true;
                        }
                        else if (String.Equals(currentState, "q1"))
                        {
                            currentState = "q3";
                            verdict = false;
                        }
                        else if (String.Equals(currentState, "q2"))
                        {
                            currentState = "q4";
                            verdict = false;
                        }
                        else if (String.Equals(currentState, "q3"))
                        {
                            currentState = "q1";
                            verdict = true;
                        }
                        else if (String.Equals(currentState, "q4"))
                        {
                            currentState = "q4";
                            verdict = false;
                            //q4 is a dead end
                        }
                        else
                        {
                            //symbol not in the language has happened
                            MessageBox.Show("An error happened with the state tree.");
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
