using System;
using System.Drawing.Text;
using System.Globalization;
using System.Net.Sockets;
using System.Windows.Forms;
using Assignment4_1.Models;
using Assignment4_1.Services;

namespace Assignment4_1
{
    public partial class Form1 : Form
    {
        private readonly AddressBook _addressBook = new AddressBook(); // storage manager

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshGrid(); // populate grid on startup
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null; // clear old data
            dataGridView1.DataSource = _addressBook.ListAllPeople(); // reload fresh data
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newPerson = new Person()
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                MobilePhone = txtMobilePhone.Text.Trim(),
                WorkPhone = txtWorkPhone.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            if (_addressBook.AddPerson(newPerson))
            {
                MessageBox.Show("Person added successfully!");
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("A person with that name already exists."):
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var person = (Person)dataGridView1.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show(
                    $"Are you sure you want to delete {person.FullName}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo.No);

                if (confirm == Dialogresults.Yes)
                {
                    _addressBook.DeletePerson(person.FullName);
                    RefreshGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a person to delete.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fullName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            var found = _addressBook.FindPerson(fullName);

            if (found != null)
            {
                MessageBox.Show(
                    $"Mobile: {found.MobilePhone}\nWork: {found.WorkPhone}\nAddress: {found.Address}",
                    "Search Result"
                );
            }
            else
            {
                MessageBox.Show("Person not found.");
            }
        }
    }
}