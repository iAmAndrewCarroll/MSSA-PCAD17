using System.Web;

namespace Assignment4_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void custID_TextChanged(object sender, EventArgs e)
        {

        }

        private void kwhUsed_TextChanged(object sender, EventArgs e)
        {

        }

        private void calculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lastName.Text))
            {
                MessageBox.Show("Please enter a valid Customer Name.");
                return;
            }
            if (string.IsNullOrEmpty(custID.Text))
            {
                MessageBox.Show("Please enter a valid Customer ID.");
                return;
            }

            if (!int.TryParse(kwhUsed.Text, out int units))
            {
                MessageBox.Show("Invalid KwH input. Please try again.");
                return;
            }

            double baseAmount = CalculateBaseAmount(units);
            double surcharge = baseAmount > 400 ? baseAmount * 0.15 : 0.0;
            double totalAmount = baseAmount + surcharge;

            amountDue.Text = totalAmount.ToString("0.00"); // formatted for money

            MessageBox.Show(
                $"Last Name: {lastName.Text}\n" +
                $"custID: {custID.Text}\n" +
                $"KwH Usage: {units}\n" +
                $"Base Amount: ${baseAmount: 0.00}\n" +
                $"Surcharge: ${surcharge:0.00}\n" +
                $"Total Due: ${totalAmount:0.00}",
                "Electricity Bill");
        }

        private readonly (int Start, double Rate)[] tiers = new[]
        {
            (600, 2.00),
            (400, 1.80),
            (200, 1.50),
            (0, 1.20)
        };

        private double CalculateBaseAmount(double units)
        {
            double amount = 0;

            foreach (var tier in tiers)
            {
                if (units > tier.Start)
                {
                    double unitsInTier = units - tier.Start;
                    amount += unitsInTier * tier.Rate;
                    units = tier.Start;
                }
            }

            return amount;
        }

        //private double GetRate(double units) => units switch
        //{
        //    <= 199 => 1.20,
        //    >= 200 and < 400 => 1.50,
        //    >= 400 and < 600 => 1.80,
        //    _ => 2.00
        //};

        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear the form?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lastName.Text = "";
                custID.Text = "";
                kwhUsed.Text = "";
                amountDue.Text = "";
                custID.Focus(); // sets cursor back to custID
            }

        }

        private List<Customer> customers = new List<Customer>();

        private void addCustomer_Click(object sender, EventArgs e)
        {
            // validate the last name
            if (string.IsNullOrWhiteSpace(lastName.Text))
            {
                MessageBox.Show("Please enter a valid Last Name.");
                return;
            }

            // validate custID
            if (!int.TryParse(custID.Text, out int customerID))
            {
                MessageBox.Show("Please enter a valid numeric Customer ID.");
                return;
            }

            if (!int.TryParse(kwhUsed.Text, out int kwHourUsed))
            {
                MessageBox.Show("Please enter a valid numeric KwH used.");
                return;
            }

            Customer newCustomer = new Customer
            {
                lastName = lastName.Text.Trim(),
                custID = customerID,
                kwhUsed = kwHourUsed

            };

            customers.Add(newCustomer);

            custList.Items.Clear();
            foreach (var c in customers)
            {
                custList.Items.Add(c.ToString());
            }

            lastName.Clear();
            custID.Clear();
            kwhUsed.Clear();
        }

        private void lastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void custList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
