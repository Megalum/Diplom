using Factors.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Factors
{
    public partial class Graphics : Form
    {
        public Graphics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Graphics_Load(object sender, EventArgs e)
        {
            double spead = Elements.Spead - Intervals.Spead;
            double speadStep = Intervals.Spead / 2;
            double load = Elements.Load - Intervals.Load;
            double loadStep = Intervals.Load / 2;
            double press = Elements.Press - Intervals.Press;
            double pressStep = Intervals.Press / 2;

            double[] chartSpead1 = { 0.006, 0.007, 0.009, 0.0125, 0.0175, 0.024, 0.03 };
            double[] chartSpead2 = { 0.004, 0.004, 0.0048, 0.0068, 0.0101, 0.015, 0.0218 };
            double[] chartPress = { 0.017, 0.01333, 0.01066, 0.0081, 0.0066 };
            double[] chartLoad1 = { 0.007, 0.0058, 0.0051, 0.0047, 0.0051, 0.0059 };
            double[] chartLoad2 = { 0.013, 0.0131, 0.0136, 0.0147, 0.0161, 0.01815 };

            chart1.Series[0].XValueType = ChartValueType.Int32;
            chart1.Series[0].YValueType = ChartValueType.Double;
            chart1.ChartAreas[0].AxisX.Minimum = spead - speadStep;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            chart2.Series[0].XValueType = ChartValueType.Int32;
            chart2.Series[0].YValueType = ChartValueType.Double;
            chart2.ChartAreas[0].AxisX.Minimum = spead - speadStep;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();

            for (int i = 0; i < 7; i++)
            {
                chart1.Series[0].Points.AddXY(spead, chartSpead1[i]);
                chart1.Series[1].Points.AddXY(spead, chartSpead1[i]);
                chart2.Series[0].Points.AddXY(spead, chartSpead2[i]);
                chart2.Series[1].Points.AddXY(spead, chartSpead2[i]);
                spead += speadStep;
            }

            chart3.Series[0].XValueType = ChartValueType.Double;
            chart3.Series[0].YValueType = ChartValueType.Double;
            chart3.ChartAreas[0].AxisX.Minimum = press - pressStep;
            chart3.ChartAreas[0].AxisY.Minimum = 0.006;
            chart3.Series[0].Points.Clear();
            chart3.Series[1].Points.Clear();

            for (int i = 0; i < 5; i++)
            {
                chart3.Series[0].Points.AddXY(press, chartPress[i]);
                chart3.Series[1].Points.AddXY(press, chartPress[i]);
                press += pressStep;
            }

            chart4.Series[0].XValueType = ChartValueType.Double;
            chart4.Series[0].YValueType = ChartValueType.Double;
            chart4.ChartAreas[0].AxisX.Minimum = load - loadStep;
            chart4.ChartAreas[0].AxisY.Minimum = 0.004;
            chart4.Series[0].Points.Clear();
            chart4.Series[1].Points.Clear();

            chart5.Series[0].XValueType = ChartValueType.Double;
            chart5.Series[0].YValueType = ChartValueType.Double;
            chart5.ChartAreas[0].AxisX.Minimum = load - loadStep;
            chart5.ChartAreas[0].AxisY.Minimum = 0.012;
            chart5.Series[0].Points.Clear();
            chart5.Series[1].Points.Clear();

            for (int i = 0; i < 6; i++)
            {
                chart4.Series[0].Points.AddXY(load, chartLoad1[i]);
                chart4.Series[1].Points.AddXY(load, chartLoad1[i]);
                chart5.Series[0].Points.AddXY(load, chartLoad2[i]);
                chart5.Series[1].Points.AddXY(load, chartLoad2[i]);
                load += loadStep;
            }
        }
    }
}
