using DocumentFormat.OpenXml.Packaging;
//using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
//using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
//using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Wordprocessing;

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
        double[] f;
        double[] y;
        double[] y2;
        string write;

        public AdequacyCheck(double[] b, double[] f, bool flag, byte i, double[] y1, double[] y2)
        {
            InitializeComponent();
            this.b = b;
            this.f = f;
            if (flag)
            {
                if (i == 1)
                {
                    y = y1;
                    this.y2 = y2;
                }
                else
                {
                    this.y2 = y1;
                    y = y2;
                }
            }
            else
            {
                double[] q = { 0.00416, 0.0042, 0.00415, 0.0041, 0.00422, 0.00413 };
                y = q;
                double[] q1 = { 0.0098, 0.00505, 0.0066, 0.00537, 0.0056, 0.0149 };
                this.y2 = q1;
            }
        }

        private void AdequacyCheck_Load(object sender, EventArgs e)
        {
            double _y = 0;
            for (int i = 1; i < 7; i++)
            {
                dataGridView1.Rows.Add(i, "+", "0", "0", "0", "0", "0", "0", y[i - 1]);
                _y += y[i - 1];
            }
            _y = _y / 6;
            label2.Text = $"Параметр оптимизации в центре плана = {Math.Round(_y, 5)}";

            double s1 = 0;
            for (int i = 1; i < 7; i++)
            {
                s1 += Math.Pow(y[i - 1] - _y, 2);
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
            label4.Text = $"Разница оптимизации в центре плана и свободного члена = {Math.Round(t, 5)}";
            double s2 = Math.Sqrt(s1);
            read = s2;
            key = 0;
            while (read < 0.9)
            {
                key++;
                read *= 10;
            }
            label5.Text = $"Ошибка эксперемента = {Math.Round(read, 5)} * 10^{-key}";

            ////////////////////////////////////////////////////////////////////////////////////////

            int count_factors = 3;
            double stars = Math.Pow(2.0, (count_factors / 4.0));

            int count_experience = 20;
            double[] b2 = { 0.006457, -0.00021, -0.00003708, 0.0005829, 0.00002946, 0.00004172, -0.00001238, -0.000715, 0.0002098, 0.0001978, 0.0001548 };
            string[] parametrs = { "x1", "x2", "x3", "x1x2", "x1x3", "x2x3", "x1x2x3", "x1^2", "x2^2", "x3^2" };
            double[] s = { 0.0000000001633, 0.00000000004083, -0.000000000005671, -0.000000000002142 };
            double[] b3 = { 0.0001684, 0.00001642, 0.00000612, 0.00000376 };
            double[] b4 = { 2.26, 0.2882, 0.9819, 0.6555, 0.4389 };
            string[] y4 = { "x1", "x2", "x1^2", "x2^2" };
            double remaining_amount = 0.4102;
            double sum_squares = 0.077284;
            double variance = 0.0333;
            double f_criteria = 0.00002528;


            key = 2;
            for (int i = 1; i < 7; i++)
            {
                dataGridView2.Rows.Add(i + 6, "+", "0", "0", "0", "0", "0", "0", y2[i - 1]);
                if (i % 2 == 0)
                {
                    dataGridView2.Rows[i - 1].Cells[key].Value = $"+{Math.Round(stars, 3)}";
                    dataGridView2.Rows[i - 1].Cells[key + 3].Value = $"{Math.Round(Math.Pow(stars, 2), 3)}";
                    key++;
                }
                else
                {
                    dataGridView2.Rows[i - 1].Cells[key].Value = $"-{Math.Round(stars, 3)}";
                    dataGridView2.Rows[i - 1].Cells[key + 3].Value = $"{Math.Round(Math.Pow(stars, 2), 3)}";
                }
            }

            ////////////////////////////////////////////////////////////////////////////////

            write = "Y = ";
            for (int i = 0; i < b2.Length; i++)
            {
                if (b2[i] < 0)
                {
                    write += $"{number_sort(b2[i])}{parametrs[i - 1]} ";
                }
                else if (i > 0)
                {
                    write += $"+ {number_sort(b2[i])}{parametrs[i - 1]} ";
                }
                else
                {
                    write += $"{number_sort(b2[i])} ";
                }
            }

            ////////////////////////////////////////////////////////////////////////////////

            label7.Text = $"Дисперсия [b0] = {number_sub(s[0])}";
            label8.Text = $"Дисперсия [bi] = {number_sub(s[1])}";
            label9.Text = $"Дисперсия [bil] = {number_sub(s[2])}";
            label10.Text = $"Дисперсия [bii] = {number_sub(s[3])}";

            label11.Text = $"Доверительные интервалы b0 = {number_sort(b3[0])}";
            label12.Text = $"Доверительные интервалы bi = {number_sort(b3[1])}";
            label13.Text = $"Доверительные интервалы bil = {number_sort(b3[2])}";
            label14.Text = $"Доверительные интервалы bii = {number_sort(b3[3])}";

            string model = "Y = ";
            for (int i = 0; i < b4.Length; i++)
            {
                if (b4[i] < 0)
                {
                    model += $"{b4[i]}{y4[i - 1]} ";
                }
                else if (i > 0)
                {
                    model += $"+ {b4[i]}{y4[i - 1]} ";
                }
                else
                {
                    model += $"{b4[i]} ";
                }
            }
            label16.Text = model;

            label17.Text = $"Остаточная сумма квадратов = {remaining_amount}";
            label18.Text = $"Cумма квадратов = {sum_squares}";
            label19.Text = $"Дисперсия = {variance}";
            label20.Text = $"Расчет значений F-критерия = {number_sort(f_criteria)}";
        }

        private string number_sort(double num)
        {
            string res = "";
            double param = num;

            if (param < 1 && param > 0)
            {
                res = "0,";
                param = Math.Round(param * 10, 6);
            }
            else if (param > -1 && param < 0)
            {
                res = "- 0,";
                param = Math.Round(param * -10, 6);
            }
            while (param % 10 != 0)
            {
                param = Math.Round(param * 10, 6);
                res += Math.Floor(param / 10).ToString()[Math.Floor(param / 10).ToString().Length - 1];
            }

            return res;
        }

        private string number_sub(double num)
        {
            string res = "";
            double read = num;

            int key = 0;
            if (read > 0)
            {
                while (read < 0.9)
                {
                    key++;
                    read *= 10;
                }
            }
            else
            {
                while (read > -0.9)
                {
                    key++;
                    read *= 10;
                }
            }

            res = $"{Math.Round(read, 5)} * 10^-{key}";

            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(write, "Функция отклика полиномом");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Parametrs(2, f, y2).Show();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Parametrs(3, f, y).Show();
            Close();

        }

        private void ExportDataGridViewToWord(DataGridView dgv, string filePath, MainDocumentPart mainPart, Body body)
        {
                // Создаем таблицу
                Table table = new Table();

                // Создаем строку заголовков
                TableRow headerRow = new TableRow();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    TableCell cell = new TableCell();
                    cell.Append(new Paragraph(new Run(new Text(column.HeaderText))));
                    headerRow.Append(cell);
                }
                table.Append(headerRow);

                // Добавляем строки данных
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)  // Исключаем последнюю пустую строку
                    {
                        TableRow dataRow = new TableRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            TableCell tableCell = new TableCell();
                            tableCell.Append(new Paragraph(new Run(new Text(cell.Value?.ToString() ?? string.Empty))));
                            dataRow.Append(tableCell);
                        }
                        table.Append(dataRow);
                    }
                }

                // Добавляем таблицу в тело документа
                body.Append(table);
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            saveFileDialog1.Filter = "Word Documents (*.docx)|*.docx";
            saveFileDialog1.FileName = "export.docx";
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(string.Empty))
                {
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(saveFileDialog1.FileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                    {
                        // Создаем тело документа
                        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        Body body = new Body();
                        mainPart.Document.Append(body);

                        RunProperties runProperties = new RunProperties();
                        runProperties.Append(new Bold());
                        Paragraph paragraph = new Paragraph();
                        Run run = new Run();
                        run.Append(runProperties);
                        run.Append(new Text("Результаты опытов в центре плана"));
                        paragraph.Append(run);
                        body.Append(paragraph);
                        ExportDataGridViewToWord(dataGridView1, saveFileDialog1.FileName, mainPart, body);
                        
                        paragraph = new Paragraph();
                        run = new Run();
                        run.Append(new Text("Результаты опытов в “звездных” точках"));
                        paragraph.Append(run);
                        body.Append(paragraph);
                        ExportDataGridViewToWord(dataGridView2, saveFileDialog1.FileName, mainPart, body);
                        mainPart.Document.Save();
                    }
                    MessageBox.Show("Данные успешно экспортированы в Word файл.");
                }
            }

        }
    }
}
