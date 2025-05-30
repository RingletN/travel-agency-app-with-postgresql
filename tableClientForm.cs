using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COURSACH_APP_WITH_SQL
{
    public partial class tableClientForm : Form
    {
        private DB db;
        string _mode;
        string _role;
        string id_field;
        public tableClientForm(string role, string mode, int id = 0, string last = "", string first = "", string middle = "", string phone = "", string passport = "", string email = "")
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
            lastNameClient.Text = last;
            firstNameClient.Text = first;
            middleNameClient.Text = middle;
            phoneClient.Text = phone;
            passportClient.Text = passport;
            emailClient.Text = email;
            if (_mode == "add")
            {
                buttonAdd.Text = "Добавить клиента";
            }
            else if (_mode == "edit")
            {
                buttonAdd.Text = "Изменить";
                if (_role == "administrator") idClient.Text = id.ToString();
            }
            if (_role == "manager")
            {
                idClient.Enabled = false; //нельзя менять айди
                idClient.Text = "*default*";
            }
            else if (_role == "administrator")
            {
                idClient.Enabled = true; //можна менять айди
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
                {
                    try
                    {
                        if (_role == "administrator" && idClient.Text != "")
                            query = "UPDATE Client SET client_id=@id, last_name=@last, first_name=@first, middle_name = @middle, passport_data = @passport, phone_number = @phone, email=@email WHERE client_id = @old_id";
                        else if (_role == "manager" || idClient.Text == "")
                            query = "UPDATE Client SET last_name=@last, first_name=@first, middle_name = @middle, passport_data = @passport, phone_number = @phone, email=@email WHERE client_id = @old_id";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                        {
                            command.Parameters.Add("@old_id", NpgsqlDbType.Integer).Value = int.Parse(id_field);
                            if (_role == "administrator" && idClient.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idClient.Text);
                            command.Parameters.Add("@last", NpgsqlDbType.Varchar).Value = lastNameClient.Text;
                            command.Parameters.Add("@first", NpgsqlDbType.Varchar).Value = firstNameClient.Text;
                            command.Parameters.Add("@middle", NpgsqlDbType.Varchar).Value = middleNameClient.Text;
                            command.Parameters.Add("@phone", NpgsqlDbType.Varchar).Value = phoneClient.Text;
                            command.Parameters.Add("@passport", NpgsqlDbType.Varchar).Value = passportClient.Text;
                            command.Parameters.Add("@email", NpgsqlDbType.Varchar).Value = emailClient.Text;
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Клиент успешно изменён!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при изменении клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (_mode == "add")
            {
                try
                {
                    if (_role == "manager" || idClient.Text == "")
                        query = @"INSERT INTO Client (last_name, first_name, middle_name, passport_data, phone_number, email)
                          VALUES (@last, @first, @middle, @passport, @phone, @email)";
                    else if (_role == "administrator" && idClient.Text != "")
                        query = @"INSERT INTO Client (client_id, last_name, first_name, middle_name, passport_data, phone_number, email)
                          VALUES (@id, @last, @first, @middle, @passport, @phone, @email)";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        if (_role == "administrator" && idClient.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idClient.Text);
                        command.Parameters.Add("@last", NpgsqlDbType.Varchar).Value = lastNameClient.Text;
                        command.Parameters.Add("@first", NpgsqlDbType.Varchar).Value = firstNameClient.Text;
                        command.Parameters.Add("@middle", NpgsqlDbType.Varchar).Value = middleNameClient.Text;
                        command.Parameters.Add("@phone", NpgsqlDbType.Varchar).Value = phoneClient.Text;
                        command.Parameters.Add("@passport", NpgsqlDbType.Varchar).Value = passportClient.Text;
                        command.Parameters.Add("@email", NpgsqlDbType.Varchar).Value = emailClient.Text;
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Клиент успешно добавлен!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
