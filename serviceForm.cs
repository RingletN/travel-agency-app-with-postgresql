using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COURSACH_APP_WITH_SQL
{
    public partial class serviceForm : Form
    {
        private DB db;
        string _mode;
        string _role;
        string id_field;
        decimal p;
        public serviceForm(string role, string mode, int id = 0, string name = "", string category = "", string price = "", string description = "", string availiability = "")
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
            nameService.Text = name;
            descriptionService.Text = description;

            categoryService.Items.Add("Питание");
            categoryService.Items.Add("Экскурсии");
            categoryService.Items.Add("Развлечения");
            categoryService.Items.Add("Проживание");
            categoryService.Items.Add("Страховка");
            categoryService.Items.Add("Прочее");
            availService.Items.Add("Доступен");
            availService.Items.Add("Недоступен");

            if (_mode == "add")
            {
                buttonAdd.Text = "Добавить услугу";
                if (_role == "administrator")
                {
                    idService.Enabled = true;// можно менять айди 
                }
                else
                {
                    idService.Enabled = false; //нельзя менять id
                    idService.Text = "*default*";
                }
            }
            else if (_mode == "edit")
            {
                idService.Text = id.ToString();
                buttonAdd.Text = "Изменить";

                categoryService.SelectedItem = categoryService.Items.Cast<object>().FirstOrDefault(item => item.ToString() == category);
                availService.SelectedItem = availService.Items.Cast<object>().FirstOrDefault(item => item.ToString() == availiability);

                if (_role == "administrator")
                {
                    idService.Enabled = true; //можно менять id
                }
                else
                {
                    idService.Enabled = false; //нельзя менять id
                    idService.Text = id.ToString();
                }
            }
            priceService.Text = price.Replace(",", ".");
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
                    if (_role == "administrator" && idService.Text != "")
                        query = "UPDATE Service SET service_id = @id, name = @name, category = service_category(@category), price = @price, " +
                            "description = @description, availability = availability(@availability) WHERE service_id = @old_id";
                    else if (_role == "manager" || idService.Text == "")
                        query = "UPDATE Service SET name = @name, category = service_category(@category), price = @price, " +
                            "description = @description, availability = availability(@availability) WHERE service_id = @old_id";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.Add("@old_id", NpgsqlDbType.Integer).Value = int.Parse(id_field);
                        if (_role == "administrator" && idService.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idService.Text);
                        command.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = nameService.Text;
                        command.Parameters.Add("@category", NpgsqlDbType.Varchar).Value = categoryService.Text;
                        command.Parameters.Add("@description", NpgsqlDbType.Text).Value = descriptionService.Text;
                        command.Parameters.Add("@availability", NpgsqlDbType.Varchar).Value = availService.Text;
                        // Обработка цены
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        if (decimal.TryParse(priceService.Text, NumberStyles.Number, culture, out decimal p))
                        {
                            command.Parameters.Add("@price", NpgsqlDbType.Numeric).Value = p;
                        }
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Услуга успешно изменена!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при изменении услуги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_mode == "add")
            {
                try
                {
                    if (_role == "administrator" && idService.Text != "")
                        query = @"INSERT INTO Service (service_id, name, category, price, description, availability) VALUES (@id, @name, service_category(@category), @price, @description,availability(@availability))";
                    else if (_role == "manager" || idService.Text == "")
                        query = @"INSERT INTO Service ( name, category, price, description, availability) VALUES (@name, service_category(@category), @price, @description,availability(@availability))";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        if (_role == "administrator" && idService.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idService.Text);
                        command.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = nameService.Text;
                        command.Parameters.Add("@category", NpgsqlDbType.Varchar).Value = categoryService.Text;
                        command.Parameters.Add("@description", NpgsqlDbType.Text).Value = descriptionService.Text;
                        command.Parameters.Add("@availability", NpgsqlDbType.Varchar).Value = availService.Text;
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        if (decimal.TryParse(priceService.Text, NumberStyles.Number, culture, out decimal p))
                        {
                            command.Parameters.Add("@price", NpgsqlDbType.Numeric).Value = p;
                        }
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Услуга успешно добавлена!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении услуги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
