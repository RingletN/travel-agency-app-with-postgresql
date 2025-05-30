using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COURSACH_APP_WITH_SQL
{
    public partial class reportForm : Form
    {
        DB db;
        public reportForm()
        {
            InitializeComponent();
            db = new DB();
            if (!db.OpenConnection())
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            cbReportType.Items.Add("Тур");
            cbReportType.Items.Add("Услуга");
        }
        private void cbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDetails.Items.Clear();
            Console.WriteLine(cbReportType.SelectedItem);
            if (cbReportType.SelectedItem.ToString() == "Тур")
            {
                string[] tourTypes = GetTourTypes();
                cbDetails.Items.AddRange(tourTypes);
            }
            else if (cbReportType.SelectedItem.ToString() == "Услуга")
            {
                string[] serviceCategories = GetServiceCategories();
                cbDetails.Items.AddRange(serviceCategories);
            }
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string reportType = cbReportType.SelectedItem.ToString();
            string detailType = cbDetails.SelectedItem?.ToString(); //Обработка случая, когда ничего не выбрано
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            string query = GenerateSqlQuery(reportType, startDate, endDate, detailType);
            try
            {
                DataTable dataTable = db.ExecuteQuery(query);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    saveFileDialog.FileName = "Отчет.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            //Заголовки отчета
                            writer.WriteLine($"Отчет по продажам {reportType} за период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}");
                            writer.WriteLine($"Тип: {detailType}");
                            writer.WriteLine("--------------------------------------------------------------------------------------------------");
                            // Ширина столбцов
                            int[] columnWidths = { 10, 12, 12, 45, 15, 20 }; // ID Брони, ID Клиента, Дата, Название, Цена, Продолжительность/Категория
                            // Заголовки столбцов
                            WriteFormattedLine(writer, columnWidths, "ID Брони", "ID Клиента", "Дата", "Название", "Цена", reportType == "Тур" ? "Продолжительность (дней)" : "Категория");
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string[] rowData = {
                            reportType == "Тур" ? row["booking_id"].ToString() : row["request_id"].ToString(),
                            row["client_id"].ToString(),
                              reportType == "Тур" ? ((DateTime)row["booking_date"]).ToString("dd.MM.yyyy") : ((DateTime)row["request_date"]).ToString("dd.MM.yyyy"),
                            row["name"].ToString(),
                            row["price"].ToString(),
                            reportType == "Тур" ? row["duration_days"].ToString() : row["category"].ToString()
                        };
                                WriteFormattedLine(writer, columnWidths, rowData);
                            }
                        }
                        MessageBox.Show("Отчет успешно сохранен!");
                    }
                }
                else
                {
                    MessageBox.Show("Данные не найдены.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при генерации отчета: " + ex.Message);
            }
        }
        private void WriteFormattedLine(StreamWriter writer, int[] columnWidths, params string[] data)
        {
            string line = "";
            for (int i = 0; i < data.Length; i++)
            {
                line += data[i].PadRight(columnWidths[i]).Replace("\n", " "); //Удаление переносов строки для корректного отображения
            }
            writer.WriteLine(line);
        }
        private string GenerateSqlQuery(string reportType, DateTime startDate, DateTime endDate, string detailType)
        {
            string whereClauseTour = $"b.booking_date >= '{startDate:yyyy-MM-dd}' AND b.booking_date <= '{endDate:yyyy-MM-dd}' AND b.booking_status = 'Оплачен'";
            string whereClauseService = $"sr.request_date >= '{startDate:yyyy-MM-dd}' AND sr.request_date <= '{endDate:yyyy-MM-dd}' AND sr.request_status = 'Оплачен'";
            if (reportType == "Тур")
            {
                string typeCondition = string.IsNullOrEmpty(detailType) ? "" : $"AND t.type = '{detailType}'"; // Условие для типа тура
                return $@" SELECT b.booking_id, b.client_id, b.booking_date, t.name, t.price, t.duration_days FROM Booking b JOIN Tour t ON b.tour_id = t.tour_id WHERE {whereClauseTour} {typeCondition} ";
            }
            else if (reportType == "Услуга")
            {
                string categoryCondition = string.IsNullOrEmpty(detailType) ? "" : $"AND s.category = '{detailType}'"; // Условие для категории услуги
                return $@" SELECT sr.request_id, sr.client_id, sr.request_date, s.name, s.price, s.category FROM ServiceRequest sr JOIN Service s ON sr.service_id = s.service_id WHERE {whereClauseService} {categoryCondition} ";
            }
            return "";
        }
        public string[] GetTourTypes()
        {
            string query = "SELECT DISTINCT type FROM Tour";
            DataTable dataTable = db.ExecuteQuery(query);
            if (dataTable == null) return new string[0]; // Возвращаем пустой массив при ошибке
            Console.WriteLine("DataTable rows count tour: " + dataTable.Rows.Count);
            string[] types = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                types[i] = dataTable.Rows[i][0].ToString();
            }
            Console.WriteLine("types tour: " + types);
            return types;
        }
        public string[] GetServiceCategories()
        {
            string query = "SELECT DISTINCT category FROM Service";
            DataTable dataTable = db.ExecuteQuery(query);
            if (dataTable == null) return new string[0];
            Console.WriteLine("DataTable rows count service: " + dataTable.Rows.Count);
            string[] categories = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                categories[i] = dataTable.Rows[i][0].ToString();
            }
            Console.WriteLine("categories service: " + categories);
            return categories;
        }
    }
}
