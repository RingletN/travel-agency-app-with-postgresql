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
    public partial class photoForm : Form
    {
        private DB db;
        string _mode;
        string _role;
        string id_field;
        public photoForm(string role, string mode, int id = 0, string tour_id = "", string path = "", string description = "")
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

            if (_mode == "add")
            {
                buttonAdd.Text = "Добавить фото";
            }
            else if (_mode == "edit")
            {
                idPhoto.Text = id.ToString();
                tourPhoto.Text = tour_id;
                pathPhoto.Text = path;
                descriptionPhoto.Text = description;
                buttonAdd.Text = "Изменить";
            }
            if (_role == "manager")
            {
                idPhoto.Enabled = false; //нельзя изменять айди фото
                idPhoto.Text = "*default*";
            }
            else if (_role == "administrator")
            {
                idPhoto.Enabled = true; //нельзя изменять айди фото
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string query = "";

            if (_mode == "edit")
            {
                try
                {
                    if (_role == "administrator" && idPhoto.Text != "")

                        query = @"UPDATE Photo SET photo_id=@id, tour_id=@tour, path=@path, description = @description WHERE photo_id = @old_id";

                    else if (_role == "manager" || idPhoto.Text == "")
                        query = @"UPDATE Photo SET tour_id=@tour, path=@path, description = @description WHERE photo_id = @old_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.Add("@old_id", NpgsqlDbType.Integer).Value = int.Parse(id_field);
                        if (_role == "administrator" && idPhoto.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idPhoto.Text);
                        command.Parameters.Add("@tour", NpgsqlDbType.Integer).Value = int.Parse(tourPhoto.Text);
                        command.Parameters.Add("@path", NpgsqlDbType.Varchar).Value = pathPhoto.Text;
                        command.Parameters.Add("@description", NpgsqlDbType.Text).Value = descriptionPhoto.Text;
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Фото успешно изменено!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при изменении фото: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_mode == "add")
            {
                try
                {
                    if (_role == "administrator" && idPhoto.Text != "")
                        query = @"INSERT INTO Photo (photo_id, tour_id, path, description) VALUES (@id, @tour, @path, @description)";

                    else if (_role == "manager" || idPhoto.Text == "")
                        query = @"INSERT INTO Photo (tour_id, path, description) VALUES (@tour, @path, @description)";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        if (_role == "administrator" && idPhoto.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idPhoto.Text);
                        command.Parameters.Add("@tour", NpgsqlDbType.Integer).Value = int.Parse(tourPhoto.Text);
                        command.Parameters.Add("@path", NpgsqlDbType.Varchar).Value = pathPhoto.Text;
                        command.Parameters.Add("@description", NpgsqlDbType.Text).Value = descriptionPhoto.Text;

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Фото успешно добавлено!");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении фото: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pathPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|All Files (*.*)|*.*"; // Фильтр по типам файлов
            openFileDialog1.Title = "Выберите изображение";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog1.FileName;
                string fileName = Path.GetFileName(sourcePath);
                string destinationPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "images1", fileName);
                try
                {
                    File.Copy(sourcePath, destinationPath, true); // Копируем файл, перезаписывая, если существует
                    string relativePath = Path.Combine("images1", fileName); // Обрезаем путь
                    pathPhoto.Text = relativePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка копирования файла: {ex.Message}");
                }
            }

        }
    }
}
