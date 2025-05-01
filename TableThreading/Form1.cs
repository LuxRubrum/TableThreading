using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TableThreading
{
    public partial class frmMain : Form
    {
        List<List<int>> table = new List<List<int>>();
        public frmMain()
        {
            InitializeComponent();
            lsbLog.Items.Add("Приложение готово к работе.");
        }

        private void btnStart1_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            lsbLog.Items.Add("Инициирован запуск: 1 поток.");
            stopWatch.Start();
            oneThreadedSort();
            stopWatch.Stop();
            lsbLog.Items.Add("Таблица отсортирована одним потоком.");
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            lsbLog.Items.Add("Потрачено времени: " + elapsedTime);
        }
        private void btnStart2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            lsbLog.Items.Add("Инициирован запуск: 2 потока.");
            stopWatch.Start();
            twoThreadedSort();
            stopWatch.Stop();
            lsbLog.Items.Add("Таблица отсортирована двумя потоками.");
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            lsbLog.Items.Add("Потрачено времени: " + elapsedTime);

        }
        private void btnStart4_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            lsbLog.Items.Add("Инициирован запуск: 4 потока.");
            stopWatch.Start();
            fourThreadedSort();
            stopWatch.Stop();
            lsbLog.Items.Add("Таблица отсортирована четырьмя потоками.");
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            lsbLog.Items.Add("Потрачено времени: " + elapsedTime);
        }

        private List<List<int>> tableGen()
        {
            Random rnd = new Random();
            int x = int.Parse(txbX.Text);
            int y = int.Parse(txbY.Text);
            List<List<int>> table = new List<List<int>>();
            for (int i = 0; i < y; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < x; j++)
                {
                    int k = rnd.Next(0, 300);
                    row.Add(k);
                }
                table.Add(row);
            }
            return table;
        }

        private void dgvWrite(List<List<int>> list)
        {
            dgvMain.RowCount = list.Count;
            dgvMain.ColumnCount = list[0].Count;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[0].Count; j++)
                {
                    dgvMain.Rows[i].Cells[j].Value = list[i][j];
                }
            }
        }

        private void oneThreadedSort()
        {
            List<List<int>> odds = getOdds(table);
            List<List<int>> evens = getEvens(table);
            Task task = new Task(() =>
            {
                table = Sorter(table);
            });
            task.Start();
            task.Wait();
            dgvWrite(table);
        }

        private void twoThreadedSort()
        {
            int chunkSize = table.Count / 2;
            List<List<List<int>>> sublists = table
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(g => g.Select(x => x.Value).ToList())
                .ToList();
            List<List<int>> table1 = sublists[0];
            List<List<int>> table2 = sublists[1];
            Task task1 = new Task(() =>
            {
                table1 = Sorter(table1);
            });
            Task task2 = new Task(() =>
            {
                table2 = Sorter(table2);
            });
            task1.Start();
            task2.Start();
            task1.Wait();
            task2.Wait();
            table1.AddRange(table2);
            dgvWrite(table1);
        }

        private void fourThreadedSort()
        {
            int chunkSize = table.Count / 4;
            List<List<List<int>>> sublists = table
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(g => g.Select(x => x.Value).ToList())
                .ToList();
            List<List<int>> table1 = sublists[0];
            List<List<int>> table2 = sublists[1];
            List<List<int>> table3 = sublists[2];
            List<List<int>> table4 = sublists[3];
            Task task1 = new Task(() =>
            {
                table1 = Sorter(table1);
            });
            Task task2 = new Task(() =>
            {
                table2 = Sorter(table2);
            });
            Task task3 = new Task(() =>
            {
                table3 = Sorter(table3);
            });
            Task task4 = new Task(() =>
            {
                table4 = Sorter(table4);
            });
            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            task1.Wait();
            task2.Wait();
            task3.Wait();
            task4.Wait();
            table1.AddRange(table2);
            table1.AddRange(table3);
            table1.AddRange(table4);
            dgvWrite(table1);
        }

        private List<List<int>> Sorter(List<List<int>> table)
        {
            List<List<int>> odds = getOdds(table);
            List<List<int>> evens = getEvens(table);
            List<List<int>> newtable = new List<List<int>>();
            for (int i = 0; i < odds.Count; i++)
            {
                List<int> row = BubbleSort(odds[i]);
                newtable.Add(row);
                newtable.Add(evens[i]);
            }
            return newtable;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.table = tableGen();
            dgvWrite(table);
            lsbLog.Items.Add($"Создана матрица чисел: {table.Count} рядов, {table[0].Count} столбцов.");
        }

        private void txbX_Leave(object sender, EventArgs e)
        {
            int x;
            try
            {
                x = int.Parse(txbX.Text);
                if (x < 0)
                {
                    x = 4;
                    txbX.Text = "4";
                    lsbLog.Items.Add("Количество столбцов должно быть больше 0.");
                    lsbLog.Items.Add($"Количество столбцов возвращено в предустановленное значение: {x}.");
                }
                else
                {
                    lsbLog.Items.Add($"Количество столбцов изменено: {x}.");
                }
            }
            catch (Exception)
            {
                txbX.Text = "4";
                lsbLog.Items.Add("Количество столбцов должно являться цифрой.");
                lsbLog.Items.Add("Количество столбцов возвращено в предустановленное значение: 4.");
            }
        }

        private void txbY_Leave(object sender, EventArgs e)
        {
            int y;
            try
            {
                y = int.Parse(txbY.Text);
                if (y < 0)
                {
                    y = 4;
                    txbY.Text = "4";
                    lsbLog.Items.Add("Количество строк должно быть больше 0 и кратно 4.");
                    lsbLog.Items.Add($"Количество строк возвращено в предустановленное значение: {y}.");
                }
                else if (y % 4 != 0)
                {
                    int c = y / 4;
                    y = 4 * (c + 1);
                    txbY.Text = y.ToString();
                    lsbLog.Items.Add("Количество строк должно быть кратно 4.");
                    lsbLog.Items.Add($"Количество строк изменено: {y}.");
                }
                else
                {
                    lsbLog.Items.Add($"Количество строк изменено: {y}.");
                }
            }
            catch (Exception)
            {
                txbY.Text = "4";
                lsbLog.Items.Add("Количество строк должно являться цифрой.");
                lsbLog.Items.Add("Количество строк возвращено в предустановленное значение: 4.");
            }
        }

        public List<List<int>> getOdds(List<List<int>> table)
        {
            List<List<int>> odds = new List<List<int>>();
            for (int i = 0; i < table.Count; i++)
            {
                if (i % 2 == 0)
                {
                    odds.Add(table[i]);
                }
            }
            return odds;
        }

        public List<List<int>> getEvens(List<List<int>> table)
        {
            List<List<int>> evens = new List<List<int>>();
            for (int i = 0; i < table.Count; i++)
            {
                if (i % 2 != 0)
                {
                    evens.Add(table[i]);
                }
            }
            return evens;
        }

        static List<int> BubbleSort(List<int> list)
        {
            int temp;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }

        
    }
}
