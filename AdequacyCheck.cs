using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factors
{
    public partial class AdequacyCheck : Form
    {
        public AdequacyCheck()
        {
            InitializeComponent();
            b = new double[8];
        }

        double[] b;

        public AdequacyCheck(double[] b)
        {
            InitializeComponent();
            this.b = b;
        }

        private void AdequacyCheck_Load(object sender, EventArgs e)
        {
            double[] y = { 0.00416, 0.0039, 0.0034, 0.003, 0.0046, 0.0032 };
            double _y = 0;
            for (int i = 1; i < 7; i++)
            {
                dataGridView1.Rows.Add(i, "+", "0", "0", "0", "0", "0", "0", y[i-1]);
                _y += y[i-1];
            }
            _y = _y / 6;
            label2.Text = $"Параметр оптимизации в центре плана = {_y}";

            double s1 = 0;
            for (int i = 1; i < 7; i++)
            {
                s1 += Math.Pow(y[i-1] - _y, 2);
            }
            s1 = s1 / 5;
            double read = s1;
            int key = 0;
            while (read < 0.9) 
            {
                key++;
                read *= 10;
            }
            label3.Text = $"Дисперсию воспроизводимости эксперимента = {Math.Round(read, 5)} * 10^{-key}";
            
            double t = Math.Abs(_y - b[0]);
            label4.Text = $"Разница оптимизации в центре плана и свободного члена = {t}";
            double s2 = Math.Sqrt(s1);
            label5.Text = $"Ошибка эксперемента = {s2}";

        }
    }
}
