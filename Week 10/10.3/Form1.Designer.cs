namespace _10._3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtVIN;
        private TextBox txtMake;
        private TextBox txtModel;
        private TextBox txtYear;
        private TextBox txtPrice;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtVIN = new TextBox();
            txtMake = new TextBox();
            txtModel = new TextBox();
            txtYear = new TextBox();
            txtPrice = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 34;
            dataGridView1.Location = new Point(20, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1307, 200);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // txtVIN
            // 
            txtVIN.Location = new Point(325, 257);
            txtVIN.Name = "txtVIN";
            txtVIN.PlaceholderText = "VIN";
            txtVIN.Size = new Size(100, 31);
            txtVIN.TabIndex = 1;
            // 
            // txtMake
            // 
            txtMake.Location = new Point(465, 257);
            txtMake.Name = "txtMake";
            txtMake.PlaceholderText = "Make";
            txtMake.Size = new Size(100, 31);
            txtMake.TabIndex = 2;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(605, 257);
            txtModel.Name = "txtModel";
            txtModel.PlaceholderText = "Model";
            txtModel.Size = new Size(100, 31);
            txtModel.TabIndex = 3;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(745, 257);
            txtYear.Name = "txtYear";
            txtYear.PlaceholderText = "Year";
            txtYear.Size = new Size(100, 31);
            txtYear.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(885, 257);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Price";
            txtPrice.Size = new Size(100, 31);
            txtPrice.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(465, 307);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 41);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(605, 307);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 41);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(770, 307);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 41);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1339, 441);
            Controls.Add(dataGridView1);
            Controls.Add(txtVIN);
            Controls.Add(txtMake);
            Controls.Add(txtModel);
            Controls.Add(txtYear);
            Controls.Add(txtPrice);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "Form1";
            Text = "Car Inventory";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
