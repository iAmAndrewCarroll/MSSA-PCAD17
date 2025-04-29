using System.Net;

namespace Demo_Assignment4_1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Person> contacts;
        private List<Person> peopleList;
        private BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();

            var contacts = new Dictionary<string, Person>();

            var person1 = new Person() { FirstName = "Jack", LastName = "Black", MobilePhone = "555-555-5555", WorkPhone = "766-866-5666", Address = "789 Street" };
            var person2 = new Person() { FirstName = "John", LastName = "Black", MobilePhone = "455-555-5555", WorkPhone = "626-766-6656", Address = "789 Street" };
            var person3 = new Person() { FirstName = "Jill", LastName = "Black", MobilePhone = "355-555-5555", WorkPhone = "496-636-6656", Address = "789 Street" };

            contacts.Add(person1.GetFullName(), person1);
            contacts.Add(person2.GetFullName(), person2);
            contacts.Add(person3.GetFullName(), person3);

            peopleList = contacts.Values.ToList();

            bindingSource = new BindingSource();
            bindingSource.DataSource = contacts.Values.ToList();
            dataGridView1.DataSource = bindingSource;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string firstNameQuery = firstNameTextBox.Text.Trim().ToLower();
            string lastNameQuery = lastNameTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(firstNameQuery) && string.IsNullOrEmpty(lastNameQuery))
            {
                MessageBox.Show("Please enter a first name and/or last name to search for.");
                return;
            }

            var filteredList = peopleList.Where(person =>
                (!string.IsNullOrEmpty(firstNameQuery) && person.FirstName.ToLower().Contains(firstNameQuery)) ||
                (!string.IsNullOrEmpty(lastNameQuery) && person.LastName.ToLower().Contains(lastNameQuery))).ToList();

            if (filteredList.Any())
            {
                bindingSource.DataSource = filteredList;
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("No match found.");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            // read user input
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string mobilePhone = mobilePhoneTextBox.Text.Trim();
            string workPhone = workPhoneTextBox.Text.Trim();
            string address = addressTextBox.Text.Trim();
        }

        private void mobilePhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void workPhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
