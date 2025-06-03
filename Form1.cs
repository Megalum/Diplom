using Factors.Data;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.VisualBasic;
using System.CodeDom.Compiler;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;

namespace Factors
{
    public partial class Form1 : Form
    {
        internal double[] ratioArray = [0, 0, 0, 0, 0, 0, 0, 0];
        public Form1()
        {
            InitializeComponent();
            double[] k = { 0.0051, 0.0073, 0.0047, 0.00467, 0.0132, 0.01105, 0.0178, 0.0077 };
            f = k;
            flag = false;
        }

        public Form1(double[] y, bool flag, byte i, double[] y1, double[] y2)
        {
            InitializeComponent();
            f = y;
            this.y1 = y1;
            this.y2 = y2;
            this.i = i;
            this.flag = flag;
        }

        public double[] f = new double[8];
        double[] y2;
        double[] y1;
        byte i;
        bool flag;

        private void button1_Click(object sender, EventArgs e)
        {

            if (isNumber(textBox1.Text, textBox2.Text, textBox3.Text))
            {
                Elements.Spead = Double.Parse(textBox1.Text);
                Elements.Press = Double.Parse(textBox3.Text);
                Elements.Load = Double.Parse(textBox2.Text);
                if (isNumber(textBox4.Text, textBox5.Text, textBox6.Text))
                {
                    Intervals.Spead = Double.Parse(textBox4.Text);
                    Intervals.Press = Double.Parse(textBox6.Text);
                    Intervals.Load = Double.Parse(textBox5.Text);
                    this.Width = 955;
                    this.Height = 400;
                    run();
                }
                else
                {
                    MessageBox.Show("Неправильный интервал", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Неправильные значения", "Error!");
            }
        }

        private bool isNumber(string preas, string load, string spead)
        {
            Regex regex = new Regex(@"^[0-9,\,]+$");
            return (regex.IsMatch(preas) && regex.IsMatch(load) && regex.IsMatch(spead));
        }

        private void run()
        {
            dataGridView1.Rows.Clear();

            for (int i = 1; i < 9; i++)
            {
                dataGridView1.Rows.Add(i, "+", "-", "-", "-", "-", "-", "-", "-", f[i - 1].ToString());
                ratioArray[0] += f[i - 1];

                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i - 1].Cells[2].Value = "+";
                    ratioArray[1] += f[i - 1];
                    ratioArray[1] = Math.Round(ratioArray[1], 8);
                }
                else
                {
                    ratioArray[1] -= f[i - 1];
                    ratioArray[1] = Math.Round(ratioArray[1], 8);
                }

                if ((i > 2 && i < 5) || i > 6)
                {
                    dataGridView1.Rows[i - 1].Cells[3].Value = "+";
                    ratioArray[2] += f[i - 1];
                    ratioArray[2] = Math.Round(ratioArray[2], 8);
                }
                else
                {
                    ratioArray[2] -= f[i - 1];
                    ratioArray[2] = Math.Round(ratioArray[2], 8);
                }


                if (i > 4)
                {
                    dataGridView1.Rows[i - 1].Cells[4].Value = "+";
                    ratioArray[3] += f[i - 1];
                    ratioArray[3] = Math.Round(ratioArray[3], 8);
                }
                else
                {
                    ratioArray[3] -= f[i - 1];
                    ratioArray[3] = Math.Round(ratioArray[3], 8);
                }

                if (((i % 2 == 0) && ((i > 2 && i < 5) || i > 6)) ||
                    ((i % 2 != 0) && ((i < 3 || i > 4) && i < 7)))
                {
                    dataGridView1.Rows[i - 1].Cells[5].Value = "+";
                    ratioArray[4] += f[i - 1];
                    ratioArray[4] = Math.Round(ratioArray[4], 8);
                }
                else
                {
                    ratioArray[4] -= f[i - 1];
                    ratioArray[4] = Math.Round(ratioArray[4], 8);
                }

                if (((i % 2 == 0) && (i > 4)) || ((i % 2 != 0) && (i < 5)))
                {
                    dataGridView1.Rows[i - 1].Cells[6].Value = "+";
                    ratioArray[5] += f[i - 1];
                    ratioArray[5] = Math.Round(ratioArray[5], 8);
                }
                else
                {
                    ratioArray[5] -= f[i - 1];
                    ratioArray[5] = Math.Round(ratioArray[5], 8);
                }

                if (((i > 4) && ((i > 2 && i < 5) || i > 6)) ||
                    ((i < 5) && ((i < 3 || i > 4) && i < 7)))
                {
                    dataGridView1.Rows[i - 1].Cells[7].Value = "+";
                    ratioArray[6] += f[i - 1];
                    ratioArray[6] = Math.Round(ratioArray[6], 8);
                }
                else
                {
                    ratioArray[6] -= f[i - 1];
                    ratioArray[6] = Math.Round(ratioArray[6], 8);
                }

                int count = 0;
                for (int j = 0; j < 3; j++)
                    if (dataGridView1.Rows[i - 1].Cells[2 + j].Value.ToString() == "-")
                        count++;

                if (count % 2 == 0)
                {
                    dataGridView1.Rows[i - 1].Cells[8].Value = "+";
                    ratioArray[7] += f[i - 1];
                    ratioArray[7] = Math.Round(ratioArray[7], 8);
                }
                else
                {
                    ratioArray[7] -= f[i - 1];
                    ratioArray[7] = Math.Round(ratioArray[7], 8);
                }
            }
            dataGridView1.Height = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) +
                     dataGridView1.ColumnHeadersHeight;

            string regression = "y = ";
            string[] parametrs = { $"X\u2081", $"X\u2082", $"X\u2083", $"X\u2081X\u2082", $"X\u2081X\u2083", $"X\u2082X\u2083", $"X\u2081X\u2082X\u2083" };
            for (int i = 0; i < 8; i++)
            {
                ratioArray[i] = Math.Round(ratioArray[i] / 8, 8);
                if (ratioArray[i] < 0)
                {
                    regression += $"- {ratioArray[i].ToString().Substring(1)}{parametrs[i - 1]} ";
                }
                else if (i > 0)
                {
                    regression += $"+ {ratioArray[i]}{parametrs[i - 1]} ";
                }
                else
                {
                    regression += $"{ratioArray[i]} ";
                }
            }
            textBox7.Text = regression;
            button2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 410;
            this.Height = 345;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new Parametrs(1, f, null).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new AdequacyCheck(ratioArray, f, flag, i, y1, y2).Show();
        }
    }
}
