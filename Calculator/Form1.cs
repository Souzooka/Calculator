using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{


    public partial class formCalculator : Form
    {
        private TextBox output() => this.textCalculator;

        public formCalculator()
        {
            InitializeComponent();
            output().Text = "0"; // Initial value for output
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Intentionally left blank
        }

        // Numbers
        private void button0_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button1_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button2_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button3_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button4_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button5_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button6_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button7_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button8_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);
        private void button9_Click(object sender, EventArgs e) => output().AppendNum(((Button)sender).Text);

        // Decimal
        private void buttonDecimal_Click(object sender, EventArgs e) => output().AppendDecimal();

    }

    public static class ExtensionMethods
    {
        public static void AppendNum(this TextBox textBox, string num)
        {
            textBox.AppendText(num);

            // Has a decimal
            if (textBox.Text.Contains("."))
            {
                return;
            }
            // Remove leading zeroes
            else
            {
                textBox.Text = Double.Parse(textBox.Text).ToString();
            }
        }

        public static void AppendDecimal(this TextBox textBox)
        {

            // Already has a decimal
            if (textBox.Text.Contains("."))
            {
                return;
            }
            else
            {
                textBox.AppendText(".0");
            }
        }
    }
}
