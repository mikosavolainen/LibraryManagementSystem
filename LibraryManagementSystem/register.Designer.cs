namespace LibraryManagementSystem
{
    partial class register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            groupBox1 = new GroupBox();
            label9 = new Label();
            textBox5 = new TextBox();
            button3 = new Button();
            label8 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            maskedTextBox3 = new MaskedTextBox();
            label6 = new Label();
            maskedTextBox2 = new MaskedTextBox();
            maskedTextBox1 = new MaskedTextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            label5 = new Label();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 190);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(171, 161);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(175, 23);
            textBox2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(maskedTextBox3);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(maskedTextBox2);
            groupBox1.Controls.Add(maskedTextBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Location = new Point(3, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(490, 373);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Register";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(73, 222);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 19;
            label9.Text = "Adress";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(171, 219);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(175, 23);
            textBox5.TabIndex = 18;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(366, 327);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 17;
            button3.Text = "Create user";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(73, 105);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 16;
            label8.Text = "First Name";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(171, 102);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(175, 23);
            textBox4.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 134);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 14;
            label7.Text = "Last Name";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(171, 131);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(175, 23);
            textBox3.TabIndex = 13;
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.Location = new Point(171, 306);
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.PasswordChar = '*';
            maskedTextBox3.Size = new Size(175, 23);
            maskedTextBox3.TabIndex = 11;
            maskedTextBox3.MaskInputRejected += maskedTextBox3_MaskInputRejected;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(73, 309);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 12;
            label6.Text = "Password again";
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new Point(171, 248);
            maskedTextBox2.Mask = "(+358) 00000000";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(175, 23);
            maskedTextBox2.TabIndex = 10;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(171, 277);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.PasswordChar = '*';
            maskedTextBox1.Size = new Size(175, 23);
            maskedTextBox1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 280);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 8;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 251);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 7;
            label4.Text = "Phone number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 164);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 6;
            label2.Text = "User Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 193);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 5;
            label1.Text = "E-Mail";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(57, 52);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 25);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 6;
            label5.Text = "Already account?";
            label5.Click += label5_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(535, 101);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 100);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Already account?";
            // 
            // register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "register";
            Text = "register";
            Load += register_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button button2;
        private Label label5;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox3;
        private Label label6;
        private GroupBox groupBox2;
        private Label label8;
        private TextBox textBox4;
        private Label label7;
        private TextBox textBox3;
        private Button button3;
        private Label label9;
        private TextBox textBox5;
    }
}