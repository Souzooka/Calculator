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
        private const string initText = "0"; // Initial value for output

        private TextBox output() => this.textResult;
        private bool newResult = false;
        private double value = 0;
        private string lastOp = "+";
        

        public formCalculator()
        {
            InitializeComponent();
            output().Text = initText;
        }

        public void AppendDecimal()
        {
            if (newResult)
            {
                newResult = false;
                output().Text = initText;
            }

            // Already has a decimal
            if (output().Text.Contains("."))
            {
                return;
            }
            else
            {
                output().AppendText(".");
            }
        }

        public void AppendNum(string num)
        {
            if (newResult)
            {
                newResult = false;
                output().Text = initText;
            }
            output().AppendText(num);

            // Has a decimal
            if (output().Text.Contains("."))
            {
                return;
            }
            // Remove leading zeroes
            else
            {
                output().Text = Double.Parse(output().Text).ToString();
            }
        }

        public void Calculate(string op)
        {
            output().Text.TrimEnd('.');
            textOperations.AppendText($" {output().Text} {op}");
            double operand = Double.Parse(output().Text);
            newResult = true;

            // TODO: Division by zero handler
            if (lastOp == "/" && output().Text == "0")
            {
                output().Text = initText;
                return;
            }

            if (lastOp == "+") { value += operand; }
            if (lastOp == "-") { value -= operand; }
            if (lastOp == "*") { value *= operand; }
            if (lastOp == "/") { value /= operand; }

            lastOp = op;
            output().Text = value.ToString();
        }

        public void Clear()
        {
            value = 0;
            textOperations.Clear();
            output().Text = initText;
            newResult = false;
        }

        public void ClearError()
        {
            output().Text = initText;
            newResult = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Intentionally left blank
        }

        // Numbers
        private void buttonNum_Click(object sender, EventArgs e) => AppendNum(((Button)sender).Text);

        // Decimal
        private void buttonDecimal_Click(object sender, EventArgs e) => AppendDecimal();

        // Clears
        private void buttonClear_Click(object sender, EventArgs e) => Clear();
        private void buttonClearError_Click(object sender, EventArgs e) => ClearError();
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            output().Text = output().Text.Substring(0, output().Text.Length - 1);
            if (String.IsNullOrEmpty(output().Text)) { output().Text = initText; }
        }

        // Calculations
        private void buttonDivide_Click(object sender, EventArgs e) => Calculate("/");
        private void buttonMultiply_Click(object sender, EventArgs e) => Calculate("*");
        private void buttonSubtract_Click(object sender, EventArgs e) => Calculate("-");
        private void buttonAdd_Click(object sender, EventArgs e) => Calculate("+");
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Calculate("+");

            string result = output().Text;
            Clear();
            newResult = true;
            output().Text = result;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            bool decimalPoint = output().Text.EndsWith(".");
            output().Text.TrimEnd('.');
            output().Text = (Double.Parse(output().Text) * -1).ToString();
            if (decimalPoint)
            {
                output().AppendText(".");
            }
        }

        // Edit menu ops
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(output().Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = Clipboard.GetText();
            double num;

            if (Double.TryParse(txt, out num))
            {
                output().Text = txt;
            }
        }
    }
}
