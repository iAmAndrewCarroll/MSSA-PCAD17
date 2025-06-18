using System;
using System.Linq;
using System.Windows.Forms;
using _10._3.Models;
using _10._3.Data;

namespace _10._3
{
    public partial class Form1 : Form
    {
        private readonly CarDbContext _context = new CarDbContext();

        public Form1()
        {
            InitializeComponent();
            _context.Database.EnsureCreated(); // Create DB if not exists
            LoadCars();
        }

        private void LoadCars()
        {
            dataGridView1.DataSource = _context.Cars.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var car = new Car
            {
                VIN = txtVIN.Text,
                Make = txtMake.Text,
                Model = txtModel.Text,
                Year = int.Parse(txtYear.Text),
                Price = decimal.Parse(txtPrice.Text)
            };

            _context.Cars.Add(car);
            _context.SaveChanges();
            LoadCars();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Car car)
            {
                car.VIN = txtVIN.Text;
                car.Make = txtMake.Text;
                car.Model = txtModel.Text;
                car.Year = int.Parse(txtYear.Text);
                car.Price = decimal.Parse(txtPrice.Text);

                _context.SaveChanges();
                LoadCars();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Car car)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
                LoadCars();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Car car)
            {
                txtVIN.Text = car.VIN;
                txtMake.Text = car.Make;
                txtModel.Text = car.Model;
                txtYear.Text = car.Year.ToString();
                txtPrice.Text = car.Price.ToString("F2");
            }
        }
    }
}
