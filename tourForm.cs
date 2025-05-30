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
    public partial class tourForm : Form
    {
        private DB db;
        string _mode;
        string _role;
        string id_field;
        decimal p;
        public tourForm(string role, string mode, int id = 0, string name = "", string type = "", string price = "", int duration = 1, string description = "", string availiability = "")
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
            nameTour.Text = name;
            descriptionTour.Text = description;
            durationTour.Value = duration;
            typeTour.Items.Add("Пеший");
            typeTour.Items.Add("Автобусный");
            typeTour.Items.Add("Отдых на базе");
            typeTour.Items.Add("Морской");
            typeTour.Items.Add("Экскурсионный");
            typeTour.Items.Add("Другое");
            availTour.Items.Add("Доступен");
            availTour.Items.Add("Недоступен");
            if (_mode == "add")
            {
                buttonAdd.Text = "Добавить тур";
                if (_role == "administrator")
                {
                    idTour.Enabled = true;// можно менять айди 
                }
                else
                {
                    idTour.Enabled = false; //нельзя менять id
                    idTour.Text = "*default*";
                }
            }
            else if (_mode == "edit")
            {
                idTour.Text = id.ToString();
                buttonAdd.Text = "Изменить";

                typeTour.SelectedItem = typeTour.Items.Cast<object>().FirstOrDefault(item => item.ToString() == type);
                availTour.SelectedItem = availTour.Items.Cast<object>().FirstOrDefault(item => item.ToString() == availiability);

                if (_role == "administrator")
                {
                    idTour.Enabled = true; //можно менять id
                }
                else
                {
                    idTour.Enabled = false; //нельзя менять id
                    idTour.Text = id.ToString();
                }
            }
            priceTour.Text = price.Replace(",", ".");
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
                    if (_role == "administrator" && idTour.Text != "")
                        query = @"UPDATE Tour SET tour_id = @id, name = @name, type = tour_type(@type), price = @price, duration_days = @duration, " +
                            "description = @description, availability = availability(@availability) WHERE tour_id = @old_id";
                    else if (_role == "manager" || idTour.Text == "")
                        query = @"UPDATE Tour SET name = @name, type = tour_type(@type), price = @price, duration_days = @duration,  " +
                            "description = @description, availability = availability(@availability) WHERE tour_id = @old_id";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {

                        command.Parameters.Add("@old_id", NpgsqlDbType.Integer).Value = int.Parse(id_field);
                        if (_role == "administrator" && idTour.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idTour.Text);
                        command.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = nameTour.Text;
                        command.Parameters.Add("@type", NpgsqlDbType.Varchar).Value = typeTour.Text;
                        command.Parameters.Add("@duration", NpgsqlDbType.Integer).Value = durationTour.Value;
                        command.Parameters.Add("@description", NpgsqlDbType.Text).Value = descriptionTour.Text;
                        command.Parameters.Add("@availability", NpgsqlDbType.Varchar).Value = availTour.Text;
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        if (decimal.TryParse(priceTour.Text, NumberStyles.Number, culture, out decimal p))
                        {
                            command.Parameters.Add("@price", NpgsqlDbType.Numeric).Value = p;
                        }
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Тур успешно изменён!");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при изменении тура: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (_mode == "add")
            {
                try
                {
                    if (_role == "administrator" && idTour.Text != "")
                        query = @"INSERT INTO Tour (tour_id, name, type, price, duration_days, description,availability) 
                          VALUES (@id, @name, tour_type(@type), @price,  @duration, @description,availability(@availability))";
                    else if (_role == "manager" || idTour.Text == "")
                        query = @"INSERT INTO Tour (name, type, price, duration_days, description,availability) 
                          VALUES (@name, tour_type(@type), @price,  @duration, @description,availability(@availability))";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        if (_role == "administrator" && idTour.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idTour.Text);
                        command.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = nameTour.Text;
                        command.Parameters.Add("@type", NpgsqlDbType.Varchar).Value = typeTour.Text;
                        command.Parameters.Add("@duration", NpgsqlDbType.Integer).Value = durationTour.Value;
                        command.Parameters.Add("@description", NpgsqlDbType.Text).Value = descriptionTour.Text;
                        command.Parameters.Add("@availability", NpgsqlDbType.Varchar).Value = availTour.Text;
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        if (decimal.TryParse(priceTour.Text, NumberStyles.Number, culture, out decimal p))
                        {
                            command.Parameters.Add("@price", NpgsqlDbType.Numeric).Value = p;
                        }
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Тур успешно добавлен!");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении тура: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
