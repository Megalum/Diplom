using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using Factors.Data;

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
            string[] upNumber = { $"\u2070", $"\u00B9", $"\u00B2", $"\u00B3", $"\u2074", $"\u2075", $"\u2076", $"\u2077", $"\u2078", $"\u2079" };

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
            label3.Text = $"Дисперсию воспроизводимости эксперимента = {Math.Round(read, 5)} * 10\u207B";

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

            label21.Text = "";
            for (int i = 0; i < 11; i++)
            {
                label21.Text += number_sort(b2[i]) + ";";
            }
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
                res = "-0,";
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

            TableProperties tblProperties = new TableProperties(
                new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "100%" }
            );

            // Создание границ таблицы
            TableBorders tableBorders = new TableBorders(
                new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12, Space = 0, Color = "000000" },
                new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12, Space = 0, Color = "000000" },
                new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12, Space = 0, Color = "000000" },
                new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12, Space = 0, Color = "000000" },
                new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12, Space = 0, Color = "000000" },
                new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12, Space = 0, Color = "000000" }
            );

            string[] with = { "10%", "10%", "10%", "10%", "10%", "10%", "10%", "10%", "20%" };

            // Добавляем границы к свойствам таблицы
            tblProperties.Append(tableBorders);

            // Добавляем свойства таблицы к таблице
            table.AppendChild(tblProperties);

            // Устанавливаем выравнивание по центру
            TableCellProperties cellProperties = new TableCellProperties(
                new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center }
            );

            // Создаем строку заголовков
            TableRow headerRow = new TableRow();
            int i = 0;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                TableCell cell = new TableCell(
                    new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = with[i++] },    // Установка ширены столбцов
                        new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center }  // Верикатьное выравнивание по центру
                    ),
                    new Paragraph(
                        new ParagraphProperties(
                            new Justification() { Val = JustificationValues.Center },                   // Горизонтальное выравнивание по центру
                            new SpacingBetweenLines() { After = "0" }                                   // Устанавливаем интервалы
                        ),
                        new Run(
                            new RunProperties(
                                new Bold(),
                                new FontSize() { Val = "24" },
                                new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman" }
                            ),
                            new Text(column.HeaderText)
                        )
                    )
                );
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
                        TableCell tableCell = new TableCell(
                            new TableCellProperties(
                                new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center }  // Верикатьное выравнивание по центру
                            ),
                            new Paragraph(
                                new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center },                   // Горизонтальное выравнивание по центру
                                    new SpacingBetweenLines() { After = "0" }                                   // Устанавливаем интервалы
                                ),
                                new Run(
                                    new RunProperties(
                                        new FontSize() { Val = "20" },
                                        new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman" }
                                    ),
                                    new Text(cell.Value?.ToString() ?? string.Empty)
                                )
                            )
                        );
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

                        string[] b = { "b0", "b1", "b2", "b3", "b12", "b13", "b23", "b123", "b11", "b22", "b33" };
                        string[] x = { "", "x1", "x2", "x3", "x1x2", "x1x3", "x2x3", "x1x2x3", "x1^2", "x2^2", "x3^2" };

                        printText("Отчёт", true, 48, "Times New Roman", "center", false, mainPart, body);
                        printText("", true, 32, "Times New Roman", "center", false, mainPart, body);

                        string text = "Для проверки адекватности полученного уравнения регрессии и определения " +
                            "дисперсий коэффициентов необходимо знать дисперсию воспроизводимости " +
                            "эксперимента. Находим ее по результатам шести опытов, поставленных в центре плана";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);

                        printText("Результаты опытов в центре плана", true, 32, "Times New Roman", "center", false, mainPart, body);
                        ExportDataGridViewToWord(dataGridView1, saveFileDialog1.FileName, mainPart, body);

                        text = $"Среднее арифметическое значение параметра " +
                            $"оптимизации в центре плана ={label2.Text.Split('=')[1]}";
                        printText("", true, 28, "Times New Roman", "center", false, mainPart, body); 
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);
                        printText(label3.Text, false, 28, "Times New Roman", "boch", true, mainPart, body);
                        text = $"Разность между значением параметра оптимизации в центр плана и " +
                            $"величиной свободного члена ={label4.Text.Split('=')[1]}";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);
                        text = $"Если полученная разность во много раз превышает ошибку эксперимента:{label5.Text.Split('=')[1]}";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);
                        string func = "y = ";
                        for (int i = 0; i < 11; i++)
                        {
                            func += b[i] + x[i];
                            if (i != 10)
                            {
                                func += " + ";
                            }
                        }
                        text = $"Из этого следует, что коэффициенты при квадратичных членах значимо " +
                            $"отличаются от нуля, а исследуемая зависимость не может быть с достаточной " +
                            $"точностью аппроксимирована уравнением. То перешли к планированию " +
                            $"второго порядка и аппроксимировали неизвестную функцию отклика " +
                            $"полиномом вида: {func}";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);


                        printText("Результаты опытов в “звездных” точках", true, 32, "Times New Roman", "center", false, mainPart, body);
                        ExportDataGridViewToWord(dataGridView2, saveFileDialog1.FileName, mainPart, body);
                        printText("", false, 28, "Times New Roman", "boch", true, mainPart, body);

                        text = "Дополнили шестью опытами в “звездных” точках. " +
                            "Величина “звездного” плеча в рассматриваемом случае равна 1,682.";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);
                        text = "Для ротатабельного планирования второго порядка важное значение " +
                            "имеет выбор числа опытов в центре плана, так как число опытов в центре " +
                            "плана определяет характер распределения получаемой информации о " +
                            "поверхности отклика. Число опытов в центре плана выбирается таким, чтобы " +
                            "обеспечивалось так называемое униформ-планирование. Планирование " +
                            "называется униформ-ротатабельным, если получаемая информация " +
                            "постоянно остается внутри интервала. Униформ-ротатабельное планирование " +
                            "возможно, если, некоторая константа, не превышает единицы (немного меньше ее).";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);
                        text = "Получили следующие значения коэффициентов:";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);

                        int k = 0;
                        text = "";
                        foreach (string element in label21.Text.Split(';'))
                        {
                            text += $"{b[k++]}={element}";
                            if (k != 11)
                            {
                                text += ";      ";
                            }
                            else
                            {
                                text += ".";
                                break;
                            }
                        }
                        printText(text, true, 28, "Times New Roman", "both", false, mainPart, body);
                        text = "После подстановки значений коэффициентов в уравнение оно получило вид:";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);

                        k = 0;
                        text = "y = ";
                        foreach (string element in label21.Text.Split(';'))
                        {
                            if (Double.Parse(element) > 0 && k > 0)
                            {
                                text += $" + {element}{x[k++]}";
                            }
                            else if (Double.Parse(element) < 0 && k > 0)
                            {
                                text += $" - {element.Substring(1)}{x[k++]}";
                            }
                            else
                            {
                                text += $"{element}{x[k++]}";
                            }                            
                            if (k == 11)
                            {
                                break;
                            }
                        }
                        printText(text, true, 28, "Times New Roman", "center", true, mainPart, body);

                        text = "Дисперсии коэффициентов имеют следующие значения:";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);
                        text = "S^2{b0} =" + label7.Text.Split("=")[1] + ";      S^2{bi} = " + label8.Text.Split("=")[1];
                        printText(text, true, 28, "Times New Roman", "center", false, mainPart, body);
                        text = "S^2{bil} =" + label9.Text.Split("=")[1] + ";      S^2{bii} = " + label10.Text.Split("=")[1];
                        printText(text, true, 28, "Times New Roman", "center", false, mainPart, body);

                        text = "Доверительные интервалы для коэффициентов равны:";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);
                        text = $"\u0394b0 = \u00B1{label11.Text.Split("= ")[1]}";
                        printText(text, false, 28, "Times New Roman", "boch", true, mainPart, body);

                        mainPart.Document.Save();
                    }
                    MessageBox.Show("Данные успешно экспортированы в Word файл.");
                }
            }

        }

        private void printText(string text, bool bold, int size, string style, string justifications, bool identy, MainDocumentPart mainPart, Body body)
        {
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            Run run = new Run();

            //Выравнивание
            if (justifications == "center")
            {
                Justification justification = new Justification() { Val = JustificationValues.Center };
                paragraphProperties.Append(justification);
            }
            else if (justifications == "right")
            {
                Justification justification = new Justification() { Val = JustificationValues.Right };
                paragraphProperties.Append(justification);
            }
            else if (justifications == "left")
            {
                Justification justification = new Justification() { Val = JustificationValues.Left };
                paragraphProperties.Append(justification);
            }
            else
            {
                Justification justification = new Justification() { Val = JustificationValues.Both };
                paragraphProperties.Append(justification);
            }
            Paragraph paragraph = new Paragraph(paragraphProperties);

            // Жирный
            RunProperties runProperties = new RunProperties();
            if (bold)
            {
                runProperties.Append(new Bold());
            }

            // Отступ
            if (identy)
            {
                Indentation indentation = new Indentation() { Left = "0", Right = "0", FirstLine = "709" };
                paragraphProperties.Append(indentation);
            }

            runProperties.Append(new FontSize() { Val = size.ToString() }); // Размер шрифта
            runProperties.Append(new RunFonts() { Ascii = style, HighAnsi = style, EastAsia = style, ComplexScript = style }); // Стиль шрифта

            run.Append(runProperties);
            run.Append(new Text(text));
            paragraph.Append(run);
            body.Append(paragraph);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Graphics().Show();
        }
    }
}
