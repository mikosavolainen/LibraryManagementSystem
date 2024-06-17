namespace LibraryManagementSystem
{
    partial class mainpage
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
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            buttonSearch = new Button();
            buttonLoan = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(159, 84);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(684, 379);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 84);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(133, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 59);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 5;
            label1.Text = "Search";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.No;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(746, 16);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 58);
            button1.TabIndex = 9;
            button1.Text = "Profile";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(22, 109);
            buttonSearch.Margin = new Padding(3, 2, 3, 2);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(82, 22);
            buttonSearch.TabIndex = 10;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonLoan
            // 
            buttonLoan.Location = new Point(22, 244);
            buttonLoan.Margin = new Padding(3, 2, 3, 2);
            buttonLoan.Name = "buttonLoan";
            buttonLoan.Size = new Size(82, 22);
            buttonLoan.TabIndex = 11;
            buttonLoan.Text = "Loan";
            buttonLoan.UseVisualStyleBackColor = true;
            // 
            // mainpage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 471);
            Controls.Add(buttonLoan);
            Controls.Add(buttonSearch);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "mainpage";
            Text = "Form1";
            Load += mainpage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button buttonSearch;
        private Button buttonLoan;
    }
}