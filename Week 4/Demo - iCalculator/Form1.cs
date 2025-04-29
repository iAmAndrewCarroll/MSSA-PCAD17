using System.Configuration;

namespace Demo___iCalculator
{
    public partial class Form1 : Form
    {
        // === Form Logic Base State ===
        private string currentInput = "";
        private double x = 0;
        private double y = 0;
        private string op = ""; // holds the operator
        private readonly ICalculator calc = new Calculator();
        public Form1()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(currentInput, out y))
            {
                textBox1.Text = "Invalid input for y";
                return;
            }

            try
            {
                double result = op switch
                {
                    "+" => calc.Add(x, y),
                    "-" => calc.Subtract(x, y),
                    "*" => calc.Multiply(x, y),
                    "/" => calc.Divide(x, y),
                    _ => throw new InvalidOperationException("No operator selected")
                };

                textBox1.Text = result.ToString(); // show result
                currentInput = result.ToString(); // Let result chain into next input
                x = result; // store result as next x
                y = 0;
                op = "";
            }
            catch (DivideByZeroException ex)
            {
                textBox1.Text = ex.Message;
                currentInput = "";
                x = y = 0;
                op = "";
            }
            catch (Exception ex)
            {
                textBox1.Text = $"Error: {ex.Message}";
                currentInput = "";
                x = y = 0;
                op = "";
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(currentInput, out x))
            {
                textBox1.Text = "Invalid input for x";
                return;
            }

            Button btn = sender as Button;
            op = btn.Text;
            currentInput = "";
            textBox1.Text = "";
        }

        // === Number Button Handler ===
        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            currentInput += btn.Text;
            textBox1.Text = currentInput;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Click += Number_Click;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Click += Number_Click;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Click += Number_Click;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Click += Number_Click;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Click += Number_Click;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Click += Number_Click;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            button7.Click += Number_Click;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Click += Number_Click;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Click += Number_Click;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Click += Number_Click;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            currentInput = "";
            textBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            op = "";
            currentInput = "";
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button13.Click += Operator_Click;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button14.Click += Operator_Click;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.Click += Operator_Click;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.Click += Operator_Click;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button17.Click += Enter_Click;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
