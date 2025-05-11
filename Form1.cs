using Factors.Data;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.VisualBasic;
using System.CodeDom.Compiler;
using System.Data;
using System.Text.RegularExpressions;

namespace Factors
{
    public partial class Form1 : Form
    {
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
                Elements elements = new Elements(double.Parse(textBox1.Text),
                                                 double.Parse(textBox2.Text),
                                                 double.Parse(textBox3.Text));
                if (isNumber(textBox4.Text, textBox5.Text, textBox6.Text))
                {
                    Intervals intervals = new Intervals(double.Parse(textBox4.Text),
                                                        double.Parse(textBox5.Text),
                                                        double.Parse(textBox6.Text));
                    run(elements, intervals);
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

        private void run(Elements elements, Intervals intervals)
        {
            dataGridView1.Rows.Clear();
            double[] b = { 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 1; i < 9; i++)
            {
                dataGridView1.Rows.Add(i, "+", "-", "-", "-", "-", "-", "-", "-", f[i - 1].ToString());
                b[0] += f[i - 1];

                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i - 1].Cells[2].Value = "+";
                    b[1] += f[i - 1];
                    b[1] = Math.Round(b[1], 8);
                }
                else
                {
                    b[1] -= f[i - 1];
                    b[1] = Math.Round(b[1], 8);
                }

                if ((i > 2 && i < 5) || i > 6)
                {
                    dataGridView1.Rows[i - 1].Cells[3].Value = "+";
                    b[2] += f[i - 1];
                    b[2] = Math.Round(b[2], 8);
                }
                else
                {
                    b[2] -= f[i - 1];
                    b[2] = Math.Round(b[2], 8);
                }


                if (i > 4)
                {
                    dataGridView1.Rows[i - 1].Cells[4].Value = "+";
                    b[3] += f[i - 1];
                    b[3] = Math.Round(b[3], 8);
                }
                else
                {
                    b[3] -= f[i - 1];
                    b[3] = Math.Round(b[3], 8);
                }

                if (((i % 2 == 0) && ((i > 2 && i < 5) || i > 6)) ||
                    ((i % 2 != 0) && ((i < 3 || i > 4) && i < 7)))
                {
                    dataGridView1.Rows[i - 1].Cells[5].Value = "+";
                    b[4] += f[i - 1];
                    b[4] = Math.Round(b[4], 8);
                }
                else
                {
                    b[4] -= f[i - 1];
                    b[4] = Math.Round(b[4], 8);
                }

                if (((i % 2 == 0) && (i > 4)) || ((i % 2 != 0) && (i < 5)))
                {
                    dataGridView1.Rows[i - 1].Cells[6].Value = "+";
                    b[5] += f[i - 1];
                    b[5] = Math.Round(b[5], 8);
                }
                else
                {
                    b[5] -= f[i - 1];
                    b[5] = Math.Round(b[5], 8);
                }

                if (((i > 4) && ((i > 2 && i < 5) || i > 6)) ||
                    ((i < 5) && ((i < 3 || i > 4) && i < 7)))
                {
                    dataGridView1.Rows[i - 1].Cells[7].Value = "+";
                    b[6] += f[i - 1];
                    b[6] = Math.Round(b[6], 8);
                }
                else
                {
                    b[6] -= f[i - 1];
                    b[6] = Math.Round(b[6], 8);
                }

                int count = 0;
                for (int j = 0; j < 3; j++)
                    if (dataGridView1.Rows[i - 1].Cells[2 + j].Value.ToString() == "-")
                        count++;

                if (count % 2 == 0)
                {
                    dataGridView1.Rows[i - 1].Cells[8].Value = "+";
                    b[7] += f[i - 1];
                    b[7] = Math.Round(b[7], 8);
                }
                else
                {
                    b[7] -= f[i - 1];
                    b[7] = Math.Round(b[7], 8);
                }
            }

            string regression = "y = ";
            string[] parametrs = { "x1", "x2", "x3", "x1x2", "x1x3", "x2x3", "x1x2x3" };
            for (int i = 0; i < 8; i++)
            {
                b[i] = Math.Round(b[i] / 8, 8);
                if (b[i] < 0)
                {
                    regression += $"{b[i]}{parametrs[i - 1]} ";
                }
                else if (i > 0)
                {
                    regression += $"+{b[i]}{parametrs[i - 1]} ";
                }
                else
                {
                    regression += $"{b[i]} ";
                }
            }


            MessageBox.Show(regression, "Уравнение регрессии");
            new AdequacyCheck(b, f, flag, i, y1, y2).Show();
            button2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //double[] k = { 0.0051, 0.0073, 0.0047, 0.00467, 0.0132, 0.01105, 0.0178, 0.0077 };
            //f = k;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new Parametrs(1, f, null).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
