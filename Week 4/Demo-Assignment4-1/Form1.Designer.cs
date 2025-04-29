namespace Demo_Assignment4_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            searchButton = new Button();
            Add = new Button();
            mobilePhone = new Label();
            mobilePhoneTextBox = new TextBox();
            workPhone = new Label();
            workPhoneTextBox = new TextBox();
            address = new Label();
            addressTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(922, 740);
            dataGridView1.TabIndex = 0;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(940, 40);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(364, 31);
            firstNameTextBox.TabIndex = 1;
            firstNameTextBox.TextChanged += firstNameTextBox_TextChanged;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(940, 102);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(364, 31);
            lastNameTextBox.TabIndex = 2;
            lastNameTextBox.TextChanged += lastNameTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(940, 12);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 3;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(940, 74);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 4;
            label2.Text = "Last Name";
            // 
            // searchButton
            // 
            searchButton.Location = new Point(940, 334);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(217, 34);
            searchButton.TabIndex = 5;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // Add
            // 
            Add.Location = new Point(940, 375);
            Add.Name = "Add";
            Add.Size = new Size(217, 34);
            Add.TabIndex = 6;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // mobilePhone
            // 
            mobilePhone.AutoSize = true;
            mobilePhone.Location = new Point(940, 139);
            mobilePhone.Name = "mobilePhone";
            mobilePhone.Size = new Size(122, 25);
            mobilePhone.TabIndex = 8;
            mobilePhone.Text = "Mobile Phone";
            // 
            // mobilePhoneTextBox
            // 
            mobilePhoneTextBox.Location = new Point(940, 167);
            mobilePhoneTextBox.Name = "mobilePhoneTextBox";
            mobilePhoneTextBox.Size = new Size(364, 31);
            mobilePhoneTextBox.TabIndex = 7;
            mobilePhoneTextBox.TextChanged += mobilePhoneTextBox_TextChanged;
            // 
            // workPhone
            // 
            workPhone.AutoSize = true;
            workPhone.Location = new Point(940, 203);
            workPhone.Name = "workPhone";
            workPhone.Size = new Size(109, 25);
            workPhone.TabIndex = 10;
            workPhone.Text = "Work Phone";
            // 
            // workPhoneTextBox
            // 
            workPhoneTextBox.Location = new Point(940, 231);
            workPhoneTextBox.Name = "workPhoneTextBox";
            workPhoneTextBox.Size = new Size(364, 31);
            workPhoneTextBox.TabIndex = 9;
            workPhoneTextBox.TextChanged += workPhoneTextBox_TextChanged;
            // 
            // address
            // 
            address.AutoSize = true;
            address.Location = new Point(940, 269);
            address.Name = "address";
            address.Size = new Size(77, 25);
            address.TabIndex = 12;
            address.Text = "Address";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(940, 297);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(364, 31);
            addressTextBox.TabIndex = 11;
            addressTextBox.TextChanged += addressTextBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1318, 764);
            Controls.Add(address);
            Controls.Add(addressTextBox);
            Controls.Add(workPhone);
            Controls.Add(workPhoneTextBox);
            Controls.Add(mobilePhone);
            Controls.Add(mobilePhoneTextBox);
            Controls.Add(Add);
            Controls.Add(searchButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private Label label1;
        private Label label2;
        private Button searchButton;
        private Button Add;
        private Label mobilePhone;
        private TextBox mobilePhoneTextBox;
        private Label workPhone;
        private TextBox workPhoneTextBox;
        private Label address;
        private TextBox addressTextBox;
    }
}
