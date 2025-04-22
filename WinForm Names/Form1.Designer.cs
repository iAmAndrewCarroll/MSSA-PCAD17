namespace WinForm_Names
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
            btnAdd = new Button();
            lblName = new Label();
            lstNames = new ListBox();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(138, 75);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 35);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Name";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(67, 25);
            lblName.TabIndex = 1;
            lblName.Text = "Names";
            lblName.Click += label1_Click;
            // 
            // lstNames
            // 
            lstNames.FormattingEnabled = true;
            lstNames.IntegralHeight = false;
            lstNames.Location = new Point(12, 35);
            lstNames.Name = "lstNames";
            lstNames.Size = new Size(120, 179);
            lstNames.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(138, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 31);
            txtName.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 219);
            Controls.Add(txtName);
            Controls.Add(lstNames);
            Controls.Add(lblName);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Names";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label lblName;
        private ListBox lstNames;
        private TextBox txtName;
    }
}
