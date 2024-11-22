using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Mebel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void продукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\Mebel\\Mebel\\MebelDatabase.mdf;Integrated Security=True";
            string query = "SELECT * FROM Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Здесь dataGridView1 — имя вашего элемента DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\Mebel\\Mebel\\MebelDatabase.mdf;Integrated Security=True";
            string query = "SELECT * FROM Orders";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Здесь dataGridView1 — имя вашего элемента DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\Mebel\\Mebel\\MebelDatabase.mdf;Integrated Security=True";
            string query = "SELECT * FROM Clients";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Здесь dataGridView1 — имя вашего элемента DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\Mebel\\Mebel\\MebelDatabase.mdf;Integrated Security=True";
            string query = "SELECT * FROM Suppliers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Здесь dataGridView1 — имя вашего элемента DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void материалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\Mebel\\Mebel\\MebelDatabase.mdf;Integrated Security=True";
            string query = "SELECT * FROM Materials";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Здесь dataGridView1 — имя вашего элемента DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();

        }

        private void showChart_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series.Clear(); // Очищаем предыдущий график

                // Создаем серию данных для диаграммы
                Series series1 = new Series("Диаграмма");
                series1.ChartType = SeriesChartType.Column; // Столбчатая диаграмма. Для круговой - Pie

                // Извлекаем данные из DataGridView (предполагаем, что первый столбец - метки, второй - значения)
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // Пропускаем пустую строку

                    string label = row.Cells[0].Value?.ToString() ?? ""; // Метка для столбца или сектора
                    string valueStr = row.Cells[1].Value?.ToString() ?? "0"; // Значение для столбца или сектора

                    // Преобразуем строку в числовое значение (обработка ошибок)
                    if (double.TryParse(valueStr, out double value))
                    {
                        series1.Points.AddXY(label, value);
                    }
                    else
                    {
                        MessageBox.Show($"Не удалось преобразовать значение '{valueStr}' в число. Проверьте данные в DataGridView.");
                        return; // Прерываем построение диаграммы
                    }
                }

                // Добавляем серию на график
                chart1.Series.Add(series1);

                // Настраиваем диаграмму (опционально)
                chart1.Titles.Add("Диаграмма данных");
                chart1.ChartAreas[0].AxisX.Title = "Категории";
                chart1.ChartAreas[0].AxisY.Title = "Значения";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при построении диаграммы: " + ex.Message);
            }
        }
        

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Задаем вопрос пользователю перед удалением
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранные строки?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Создаем временный список для удаления строк (чтобы избежать исключений)
                    DataGridViewRow[] rowsToDelete = new DataGridViewRow[dataGridView1.SelectedRows.Count];
                    dataGridView1.SelectedRows.CopyTo(rowsToDelete, 0);

                    foreach (DataGridViewRow row in rowsToDelete)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                    MessageBox.Show("Выбранные строки успешно удалены из DataGridView.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строки для удаления.");
            }
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем ID из TextBox
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    MessageBox.Show("Пожалуйста, введите ID для поиска.");
                    return;
                }
                int searchID;
                if (!int.TryParse(textBoxSearch.Text, out searchID))
                {
                    MessageBox.Show("Неверный формат ID. Введите целое число.");
                    return;
                }

                // Находим строку с заданным ID
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // Пропускаем последнюю пустую строку

                    if (Convert.ToInt32(row.Cells[0].Value) == searchID) // Замените 0 на индекс столбца с ID
                    {
                        // Делаем строку видимой (если она не была видима)
                        row.Visible = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index; // Прокручиваем к найденной строке

                        // (Опционально) Выделяем найденную строку:
                        row.Selected = true;

                        MessageBox.Show("Запись найдена!");
                        return; // Завершаем поиск после нахождения первой записи
                    }
                    else
                    {
                        // Скрываем строки, которые не соответствуют поиску (опционально)
                        row.Visible = false;
                    }
                }

                MessageBox.Show("Запись с таким ID не найдена.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }   
}
