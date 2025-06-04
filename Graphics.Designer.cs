namespace Factors
{
    partial class Graphics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart5 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button1 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label2 = new Label();
            panel3 = new Panel();
            chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart4).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart3).BeginInit();
            SuspendLayout();
            // 
            // chart5
            // 
            chart5.BackColor = Color.Transparent;
            chartArea1.BackColor = Color.PaleGoldenrod;
            chartArea1.Name = "ChartArea1";
            chart5.ChartAreas.Add(chartArea1);
            chart5.Enabled = false;
            chart5.Location = new Point(16, 42);
            chart5.Margin = new Padding(3, 2, 3, 2);
            chart5.Name = "chart5";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = Color.Navy;
            series1.Name = "Series1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = Color.Navy;
            series2.Name = "Series2";
            chart5.Series.Add(series1);
            chart5.Series.Add(series2);
            chart5.Size = new Size(429, 240);
            chart5.TabIndex = 3;
            chart5.Text = "chart5";
            // 
            // chart4
            // 
            chart4.BackColor = Color.Transparent;
            chartArea2.BackColor = Color.PaleGoldenrod;
            chartArea2.Name = "ChartArea1";
            chart4.ChartAreas.Add(chartArea2);
            chart4.Enabled = false;
            chart4.Location = new Point(461, 42);
            chart4.Margin = new Padding(3, 2, 3, 2);
            chart4.Name = "chart4";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = Color.Navy;
            series3.Name = "Series1";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Color = Color.Navy;
            series4.Name = "Series2";
            chart4.Series.Add(series3);
            chart4.Series.Add(series4);
            chart4.Size = new Size(429, 240);
            chart4.TabIndex = 2;
            chart4.Text = "chart4";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(628, 755);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(302, 54);
            button1.TabIndex = 10;
            button1.Text = "Закрыть окно";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(chart4);
            panel1.Controls.Add(chart5);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            panel1.Location = new Point(25, 317);
            panel1.Name = "panel1";
            panel1.Size = new Size(905, 290);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 18);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(532, 22);
            label1.TabIndex = 0;
            label1.Text = "Влияние нагрузки на коэффициент сопротивления качению";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(chart2);
            panel2.Controls.Add(chart1);
            panel2.Controls.Add(label2);
            panel2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            panel2.Location = new Point(25, 11);
            panel2.Name = "panel2";
            panel2.Size = new Size(905, 290);
            panel2.TabIndex = 12;
            // 
            // chart2
            // 
            chart2.BackColor = Color.Transparent;
            chartArea3.BackColor = Color.PaleGoldenrod;
            chartArea3.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea3);
            chart2.Enabled = false;
            chart2.Location = new Point(461, 42);
            chart2.Margin = new Padding(3, 2, 3, 2);
            chart2.Name = "chart2";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = Color.Navy;
            series5.Name = "Series1";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.Color = Color.Navy;
            series6.Name = "Series2";
            chart2.Series.Add(series5);
            chart2.Series.Add(series6);
            chart2.Size = new Size(429, 240);
            chart2.TabIndex = 2;
            chart2.Text = "chart6";
            // 
            // chart1
            // 
            chart1.BackColor = Color.Transparent;
            chartArea4.BackColor = Color.PaleGoldenrod;
            chartArea4.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea4);
            chart1.Enabled = false;
            chart1.Location = new Point(16, 42);
            chart1.Margin = new Padding(3, 2, 3, 2);
            chart1.Name = "chart1";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = Color.Navy;
            series7.Name = "Series1";
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series8.Color = Color.Navy;
            series8.Name = "Series2";
            chart1.Series.Add(series7);
            chart1.Series.Add(series8);
            chart1.Size = new Size(429, 240);
            chart1.TabIndex = 3;
            chart1.Text = "chart7";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 18);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(538, 22);
            label2.TabIndex = 0;
            label2.Text = "Влияние скорости на коэффициент сопротивления качению";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(chart3);
            panel3.Controls.Add(label3);
            panel3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            panel3.Location = new Point(25, 626);
            panel3.Name = "panel3";
            panel3.Size = new Size(579, 290);
            panel3.TabIndex = 13;
            // 
            // chart3
            // 
            chart3.BackColor = Color.Transparent;
            chartArea5.BackColor = Color.PaleGoldenrod;
            chartArea5.Name = "ChartArea1";
            chart3.ChartAreas.Add(chartArea5);
            chart3.Enabled = false;
            chart3.Location = new Point(61, 42);
            chart3.Margin = new Padding(3, 2, 3, 2);
            chart3.Name = "chart3";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Color = Color.Navy;
            series9.Name = "Series1";
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series10.Color = Color.Navy;
            series10.Name = "Series2";
            chart3.Series.Add(series9);
            chart3.Series.Add(series10);
            chart3.Size = new Size(429, 240);
            chart3.TabIndex = 4;
            chart3.Text = "chart3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 18);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(535, 22);
            label3.TabIndex = 0;
            label3.Text = "Влияние давления на коэффициент сопротивления качению";
            // 
            // Graphics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 931);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Graphics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр графиков";
            Load += Graphics_Load;
            ((System.ComponentModel.ISupportInitialize)chart5).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart5;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label label2;
        private Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private Label label3;
    }
}