namespace Assignment4_1
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox7 = new TextBox();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(883, 363);
            button1.Name = "btnAdd";
            button1.Size = new Size(150, 34);
            button1.TabIndex = 0;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1039, 363);
            button2.Name = "btnDelete";
            button2.Size = new Size(150, 34);
            button2.TabIndex = 1;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(883, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(883, 130);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(306, 31);
            textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1039, 59);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 31);
            textBox5.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(883, 31);
            label1.Name = "label1";
            label1.Size = new Size(45, 25);
            label1.TabIndex = 7;
            label1.Text = "First";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1039, 31);
            label2.Name = "label2";
            label2.Size = new Size(43, 25);
            label2.TabIndex = 8;
            label2.Text = "Last";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(883, 102);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 9;
            label3.Text = "Mobile Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(479, 278);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(883, 173);
            label5.Name = "label5";
            label5.Size = new Size(109, 25);
            label5.TabIndex = 12;
            label5.Text = "Work Phone";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(883, 201);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(306, 31);
            textBox6.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(883, 244);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 14;
            label6.Text = "Address";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(883, 272);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(306, 31);
            textBox7.TabIndex = 13;
            // 
            // button3
            // 
            button3.Location = new Point(883, 323);
            button3.Name = "button3";
            button3.Size = new Size(306, 34);
            button3.TabIndex = 15;
            button3.Text = "Search";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(865, 385);
            dataGridView1.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 600);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(textBox7);
            Controls.Add(label5);
            Controls.Add(textBox6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox7;
        private Button button3;
        private DataGridView dataGridView1;
    }
}
