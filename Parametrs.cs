using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factors
{
    public partial class Parametrs : Form
    {

        int table;
        double[] f;
        double[] y2;
        public Parametrs()
        {
            InitializeComponent();
        }

        public Parametrs(int table, double[] f, double[] y2)
        {
            InitializeComponent();
            this.table = table;
            this.f = f;
            this.y2 = y2;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (table == 1)
            {
                textBox7.Visible = true;
                textBox8.Visible = true;
                if (isNumber(textBox1.Text) && isNumber(textBox2.Text) &&
                    isNumber(textBox3.Text) && isNumber(textBox4.Text) &&
                    isNumber(textBox5.Text) && isNumber(textBox6.Text) &&
                    isNumber(textBox7.Text) && isNumber(textBox8.Text))
                {
                    double[] y = {  double.Parse(textBox1.Text), double.Parse(textBox2.Text),
                                    double.Parse(textBox3.Text), double.Parse(textBox4.Text),
                                    double.Parse(textBox5.Text), double.Parse(textBox6.Text),
                                    double.Parse(textBox7.Text), double.Parse(textBox8.Text)};
                    new Form1(y, false, 0, null, y2).Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Некоторые значения не корректны", "Error");
                }

            }
            else if (table == 2)
            {
                textBox7.Visible = false;
                textBox8.Visible = false;
                if (isNumber(textBox1.Text) && isNumber(textBox2.Text) &&
                    isNumber(textBox3.Text) && isNumber(textBox4.Text) &&
                    isNumber(textBox5.Text) && isNumber(textBox6.Text))
                {
                    double[] y = {  double.Parse(textBox1.Text), double.Parse(textBox2.Text),
                                    double.Parse(textBox3.Text), double.Parse(textBox4.Text),
                                    double.Parse(textBox5.Text), double.Parse(textBox6.Text)};
                    new Form1(f, true, 1, y, y2).Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Некоторые значения не корректны", "Error");
                }
            }
            else if (table == 3)
            {
                textBox7.Visible = false;
                textBox8.Visible = false;
                if (isNumber(textBox1.Text) && isNumber(textBox2.Text) &&
                    isNumber(textBox3.Text) && isNumber(textBox4.Text) &&
                    isNumber(textBox5.Text) && isNumber(textBox6.Text))
                {
                    double[] y = {  double.Parse(textBox1.Text), double.Parse(textBox2.Text),
                                    double.Parse(textBox3.Text), double.Parse(textBox4.Text),
                                    double.Parse(textBox5.Text), double.Parse(textBox6.Text)};
                    new Form1(f, true, 2, y, y2).Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Некоторые значения не корректны", "Error");
                }
            }
        }

        private bool isNumber(string input)
        {
            Regex regex = new Regex(@"^[0-9,\,]+$");
            return regex.IsMatch(input);
        }

        private void Parametrs_Load(object sender, EventArgs e)
        {
            if (table == 1)
            {
                panel4.Visible = true;
            }
            else if (table == 2 || table == 3)
            {
                panel4.Visible = false;
                button1.Location = new Point(127,186);
                this.Height = 280;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Parametrs_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool formIsOpen = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1)
                {
                    if (form.Visible)
                    {
                        formIsOpen = true;
                        break;
                    }
                }
            }

            if (!formIsOpen)
            {
                new Form1().Show();
            }
        }
    }
}
