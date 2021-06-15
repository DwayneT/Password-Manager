using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_Ticketing_System
{
    public partial class calculator : Form
    {
        public calculator()
        {
            InitializeComponent();
        }
        public void clear()
        {
            textBox_Result.Text = "";
        }
        private void button16_Click(object sender, EventArgs e)
        {

            try
            {
                int t = 0;
                if (textBox_Result.Text.Contains("+"))
                {
                    t = textBox_Result.Text.IndexOf("+");
                }
                else if (textBox_Result.Text.Contains("-"))
                {
                    t = textBox_Result.Text.IndexOf("-");
                }

                else if (textBox_Result.Text.Contains("*"))
                {
                    t = textBox_Result.Text.IndexOf("*");
                }

                else if (textBox_Result.Text.Contains("/"))
                {
                    t = textBox_Result.Text.IndexOf("/");
                }

                String x = textBox_Result.Text.Substring(t, 1);
                Double x1 = Convert.ToDouble(textBox_Result.Text.Substring(0, t));
                Double x2 = Convert.ToDouble(textBox_Result.Text.Substring(t + 1, textBox_Result.Text.Length - t - 1));
                if (x == "+")
                {
                    listBox1.Items.Add(textBox_Result + "=" + (x1 + x2));
                    textBox_Result.Text = (x1 + x2).ToString();
                }
                else if (x == "-")
                {
                    listBox1.Items.Add(textBox_Result + "=" + (x1 - x2));
                    textBox_Result.Text = (x1 - x2).ToString();
                }
                else if (x == "*")
                {
                    listBox1.Items.Add(textBox_Result + "=" + (x1 * x2));
                    textBox_Result.Text = (x1 * x2).ToString();
                }
                else if (x == "/")
                {
                    listBox1.Items.Add(textBox_Result + "=" + (x1 / x2));
                    textBox_Result.Text = (x1 / x2).ToString();
                }
            }
            catch
            {
                textBox_Result.Text = "Error!";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "4";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "5";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "6";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "1";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "2";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "3";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "/";
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "*";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "-";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox_Result.Text += "+";
        }
    }
}
