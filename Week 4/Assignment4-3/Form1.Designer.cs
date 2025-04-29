namespace Assignment4_3
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
            calculate = new Button();
            label1 = new Label();
            custID = new TextBox();
            kwhUsed = new TextBox();
            label2 = new Label();
            amountDue = new TextBox();
            label3 = new Label();
            clearButton = new Button();
            lastName = new TextBox();
            label4 = new Label();
            addCustomer = new Button();
            custList = new ListBox();
            SuspendLayout();
            // 
            // calculate
            // 
            calculate.Location = new Point(676, 297);
            calculate.Name = "calculate";
            calculate.Size = new Size(112, 34);
            calculate.TabIndex = 0;
            calculate.Text = "Calculate";
            calculate.UseVisualStyleBackColor = true;
            calculate.Click += calculate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(552, 142);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 1;
            label1.Text = "custID";
            // 
            // custID
            // 
            custID.Location = new Point(638, 136);
            custID.Name = "custID";
            custID.Size = new Size(150, 31);
            custID.TabIndex = 2;
            custID.TextAlign = HorizontalAlignment.Right;
            custID.TextChanged += custID_TextChanged;
            // 
            // kwhUsed
            // 
            kwhUsed.Location = new Point(638, 186);
            kwhUsed.Name = "kwhUsed";
            kwhUsed.Size = new Size(150, 31);
            kwhUsed.TabIndex = 4;
            kwhUsed.TextAlign = HorizontalAlignment.Right;
            kwhUsed.TextChanged += kwhUsed_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(522, 192);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 3;
            label2.Text = "KwH Used";
            // 
            // amountDue
            // 
            amountDue.Location = new Point(638, 260);
            amountDue.Name = "amountDue";
            amountDue.ReadOnly = true;
            amountDue.Size = new Size(150, 31);
            amountDue.TabIndex = 6;
            amountDue.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(500, 266);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 5;
            label3.Text = "Amount Due";
            // 
            // clearButton
            // 
            clearButton.Location = new Point(558, 297);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(112, 34);
            clearButton.TabIndex = 7;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // lastName
            // 
            lastName.Location = new Point(638, 102);
            lastName.Name = "lastName";
            lastName.Size = new Size(150, 31);
            lastName.TabIndex = 9;
            lastName.TextAlign = HorizontalAlignment.Right;
            lastName.TextChanged += lastName_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(519, 108);
            label4.Name = "label4";
            label4.Size = new Size(95, 25);
            label4.TabIndex = 8;
            label4.Text = "Last Name";
            // 
            // addCustomer
            // 
            addCustomer.Location = new Point(558, 337);
            addCustomer.Name = "addCustomer";
            addCustomer.Size = new Size(230, 34);
            addCustomer.TabIndex = 10;
            addCustomer.Text = "Add Customer";
            addCustomer.UseVisualStyleBackColor = true;
            addCustomer.Click += addCustomer_Click;
            // 
            // custList
            // 
            custList.FormattingEnabled = true;
            custList.Location = new Point(12, 4);
            custList.Name = "custList";
            custList.Size = new Size(411, 429);
            custList.TabIndex = 11;
            custList.SelectedIndexChanged += custList_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(custList);
            Controls.Add(addCustomer);
            Controls.Add(lastName);
            Controls.Add(label4);
            Controls.Add(clearButton);
            Controls.Add(amountDue);
            Controls.Add(label3);
            Controls.Add(kwhUsed);
            Controls.Add(label2);
            Controls.Add(custID);
            Controls.Add(label1);
            Controls.Add(calculate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button calculate;
        private Label label1;
        private TextBox custID;
        private TextBox kwhUsed;
        private Label label2;
        private TextBox amountDue;
        private Label label3;
        private Button clearButton;
        private TextBox lastName;
        private Label label4;
        private Button addCustomer;
        private ListBox custList;
    }
}
