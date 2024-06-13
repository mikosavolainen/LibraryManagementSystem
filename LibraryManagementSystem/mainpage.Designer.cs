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
            listBox1.Location = new Point(182, 112);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(781, 504);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 79);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
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
            button1.Location = new Point(853, 22);
            button1.Name = "button1";
            button1.Size = new Size(94, 77);
            button1.TabIndex = 9;
            button1.Text = "Profile";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(25, 145);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 10;
            buttonSearch.Text = "search";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonLoan
            // 
            buttonLoan.Location = new Point(25, 326);
            buttonLoan.Name = "buttonLoan";
            buttonLoan.Size = new Size(94, 29);
            buttonLoan.TabIndex = 11;
            buttonLoan.Text = "Loan";
            buttonLoan.UseVisualStyleBackColor = true;
            // 
            // mainpage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 628);
            Controls.Add(buttonLoan);
            Controls.Add(buttonSearch);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
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