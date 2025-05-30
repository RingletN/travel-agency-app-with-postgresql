using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace COURSACH_APP_WITH_SQL
{
    public partial class ReviewForm : Form
    {
        private DB db;
        string _mode;
        string _role;
        string id_field;
        public ReviewForm(string role, string mode, string client_id = "", int id = 0, string tour_id = "", string date = "", string photo = "", string text = "", int rating = 5)
        {
            InitializeComponent();
            db = new DB();
            if (!db.OpenConnection())
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _mode = mode;
            _role = role;
            id_field = id.ToString();
            clientReview.Text = client_id;
            dateReview.CustomFormat = "dd.MM.yyyy";
            dateReview.Format = DateTimePickerFormat.Custom;
            tourReview.ReadOnly = false;
            if (_mode == "add")
            {
                dateReview.Value = DateTime.Today;
                buttonEditAdd.Text = "Добавить отзыв";
            }
            else if (_mode == "edit")
            {
                idReview.Text = id.ToString();
                tourReview.Text = tour_id;
                dateReview.Value = DateTime.Parse(date);
                photoReview.Text = photo;
                textReview.Text = text;
                ratingReview.Value = rating;
                buttonEditAdd.Text = "Изменить";
                if (_role == "administrator")
                {
                    tourReview.Enabled = true; //можно менять тур
                }
                else tourReview.Enabled = false; //нельзя менять тур
            }

            if (_role == "client")
            {
                dateReview.Enabled = false; //Запрет редактирования 
                idReview.Enabled = false; // нельзя изменять айди отзыва
                clientReview.Enabled = false; //нельзя изменять айди клиента
                idReview.Text = "*default*";
            }
            else if (_role == "administrator")
            {
                dateReview.Enabled = true; //можно менять дату
                idReview.Enabled = true;// можно менять айди отзыва
                clientReview.Enabled = true; //можно менять айди клиента
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonEditReview_Click(object sender, EventArgs e)
        {
            string query = "";
            if (_mode == "edit")
            {
                try
                {
                    if (_role == "administrator" && idReview.Text != "")
                        query = @"UPDATE Review SET review_id=@id, client_id=@client, tour_id=@tour, review_date=@date, photo = @photo, rating = @rating, text = @text WHERE review_id = @old_id";
                    else if (_role == "client" || idReview.Text == "")
                        query = @"UPDATE Review SET client_id=@client, tour_id=@tour, review_date=@date, photo = @photo, rating = @rating, text = @text WHERE review_id = @old_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.Add("@old_id", NpgsqlDbType.Integer).Value = int.Parse(id_field);
                        if (_role == "administrator" && idReview.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idReview.Text);
                        command.Parameters.Add("@client", NpgsqlDbType.Integer).Value = int.Parse(clientReview.Text);
                        command.Parameters.Add("@tour", NpgsqlDbType.Integer).Value = int.Parse(tourReview.Text);
                        command.Parameters.Add("@date", NpgsqlDbType.Date).Value = DateTime.Parse(dateReview.Text);
                        command.Parameters.Add("@photo", NpgsqlDbType.Varchar).Value = photoReview.Text;
                        command.Parameters.Add("@text", NpgsqlDbType.Text).Value = textReview.Text;
                        command.Parameters.Add("@rating", NpgsqlDbType.Integer).Value = ratingReview.Value;
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Отзыв успешно изменён!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при изменении отзыва: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_mode == "add")
            {
                try
                {
                    if (_role == "administrator" && idReview.Text != "")
                        query = @"INSERT INTO Review (review_id, client_id, tour_id, review_date, photo, rating, text) VALUES (@id, @client, @tour, @date, @photo, @rating, @text)";
                    else if (_role == "client" || idReview.Text == "")
                        query = @"INSERT INTO Review (client_id, tour_id, review_date, photo, rating, text) VALUES (@client, @tour, @date, @photo, @rating, @text)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        if (_role == "administrator" && idReview.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idReview.Text);
                        command.Parameters.Add("@client", NpgsqlDbType.Integer).Value = int.Parse(clientReview.Text);
                        command.Parameters.Add("@tour", NpgsqlDbType.Integer).Value = int.Parse(tourReview.Text);
                        command.Parameters.Add("@date", NpgsqlDbType.Date).Value = DateTime.Parse(dateReview.Text);
                        command.Parameters.Add("@photo", NpgsqlDbType.Varchar).Value = photoReview.Text;
                        command.Parameters.Add("@text", NpgsqlDbType.Text).Value = textReview.Text;
                        command.Parameters.Add("@rating", NpgsqlDbType.Integer).Value = ratingReview.Value;
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Отзыв успешно добавлен!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении отзыва: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void photoReview_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|All Files (*.*)|*.*"; // Фильтр по типам файлов
            openFileDialog1.Title = "Выберите изображение";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string sourcePath = openFileDialog1.FileName;
                string fileName = Path.GetFileName(sourcePath); // Извлекаем имя файла
                string destinationPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "images1", fileName);

                try
                {
                    File.Copy(sourcePath, destinationPath, true); // Копируем файл, перезаписывая, если существует
                    string relativePath = Path.Combine("images1", fileName); // Обрезаем путь
                    Console.WriteLine(relativePath);
                    photoReview.Text = relativePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка копирования файла: {ex.Message}");
                }
            }
        }
    }
}
