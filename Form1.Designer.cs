namespace Factors
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(119, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(119, 100);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(119, 133);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(347, 67);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(347, 100);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 4;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(347, 133);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(186, 198);
            button1.Name = "button1";
            button1.Size = new Size(179, 67);
            button1.TabIndex = 6;
            button1.Text = "Выполнить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10 });
            dataGridView1.Location = new Point(521, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(573, 451);
            dataGridView1.TabIndex = 7;
            // 
            // Column1
            // 
            Column1.HeaderText = "Номер опыта";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 75;
            // 
            // Column2
            // 
            Column2.HeaderText = "x0";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 40;
            // 
            // Column3
            // 
            Column3.HeaderText = "x1";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 40;
            // 
            // Column4
            // 
            Column4.HeaderText = "x2";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 40;
            // 
            // Column5
            // 
            Column5.HeaderText = "x3";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 40;
            // 
            // Column6
            // 
            Column6.HeaderText = "x12";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 40;
            // 
            // Column7
            // 
            Column7.HeaderText = "x13";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 40;
            // 
            // Column8
            // 
            Column8.HeaderText = "x23";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.Width = 40;
            // 
            // Column9
            // 
            Column9.HeaderText = "x123";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.Width = 40;
            // 
            // Column10
            // 
            Column10.HeaderText = "y";
            Column10.MinimumWidth = 6;
            Column10.Name = "Column10";
            Column10.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 8;
            label1.Text = "Скорость:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 103);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 9;
            label2.Text = "Нагрузка:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 136);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 10;
            label3.Text = "Давление:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(265, 70);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 11;
            label4.Text = "Интервал";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(265, 103);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 12;
            label5.Text = "Интервал";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(265, 136);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 13;
            label6.Text = "Интервал";
            // 
            // button2
            // 
            button2.Location = new Point(186, 318);
            button2.Name = "button2";
            button2.Size = new Size(179, 67);
            button2.TabIndex = 14;
            button2.Text = "Изменить\r\nзначения";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 514);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Calculation of experimental results";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button2;
    }
}
