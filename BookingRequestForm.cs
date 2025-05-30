using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COURSACH_APP_WITH_SQL
{
    public partial class BookingRequestForm : Form
    {
        private DB db;
        char _type;
        string _mode;
        string _role;
        string idMyOld;
        public BookingRequestForm(string role, string mode, char type, int id = 0, string client_id = "", string tour_service_id = "", string date = "", string date_start = "", string status = "", string notes = "", string promocode = "")

        {
            InitializeComponent();
            db = new DB();
            if (!db.OpenConnection())
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _type = type;
            _mode = mode;
            _role = role;
            idMyOld = id.ToString();
            dateBookingRequest.CustomFormat = "dd.MM.yyyy";
            dateBookingRequest.Format = DateTimePickerFormat.Custom;
            dateBookingRequestStart.Format = DateTimePickerFormat.Custom;
            dateBookingRequest.Text = date;
            dateBookingRequestStart.Text = date_start;
            clientBookingRequest.Text = client_id;
            tourServiceBookingRequest.Text = tour_service_id;
            promocodeRequest.Text = promocode;

            if (_role != "client")
            {
                statusBookingRequest.Items.Add("Оплачен");
                statusBookingRequest.Items.Add("Ожидает оплаты");
                statusBookingRequest.Items.Add("Отклонен");
                statusBookingRequest.Items.Add("В обработке");
                foreach (object item in statusBookingRequest.Items)
                {
                    if (item.ToString() == status)
                    {
                        statusBookingRequest.SelectedItem = item;
                        break;
                    }
                }
                notesBookingRequest.Text = notes;
                this.Width = 800;
            }
            else
            {
                this.Width = 464;
            }
            if (_mode == "edit")
            {
                buttonAdd.Text = "Изменить";
                idBookingService.Text = id.ToString();

                if (_role == "administrator")
                {
                    idBookingService.Enabled = true;
                }
                else
                {
                    idBookingService.Enabled = false;
                }
            }
            else if (_mode == "add")
            {
                buttonAdd.Text = "Добавить";
                dateBookingRequest.Value = DateTime.Today;
                if (_role == "administrator")
                {
                    tourServiceBookingRequest.Enabled = true;

                }
                else if (_role == "manager")
                {
                    idBookingService.Text = "*default*";
                    idBookingService.Enabled = false;
                    clientBookingRequest.Enabled = true;
                    tourServiceBookingRequest.Enabled = true;
                }
                else if (_role == "client")
                {
                    idBookingService.Text = "*default*";
                    dateBookingRequest.Enabled = false;
                    idBookingService.Enabled = false;
                    clientBookingRequest.Enabled = false;
                    tourServiceBookingRequest.Enabled = false;
                }
            }
            if (type == 't')
            {
                idLabel.Text = "ID брони: ";
                dateBookingRequestLabel.Text = "Дата брони: ";
                dateBookingRequestLabelStart.Text = "Дата начала тура: ";
                idTourServiceLabel.Text = "ID тура: ";
                promocodeLabel.Visible = false;
                promocodeRequest.Visible = false;
            }
            else if (type == 's')
            {
                idLabel.Text = "ID запроса: ";
                dateBookingRequestLabel.Text = "Дата запроса: ";
                dateBookingRequestLabelStart.Text = "Дата применения: ";
                idTourServiceLabel.Text = "ID услуги: ";
                promocodeLabel.Visible = true;
                promocodeRequest.Visible = true;
            }
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                if (_mode == "add") //добавление
                {
                    if (_type == 't') // Бронирование тура
                    {
                        if (_role == "administrator" && idBookingService.Text != "")
                        {
                            query = "INSERT INTO Booking (booking_id, client_id, tour_id, booking_date, arrival_date, booking_status, manager_notes) " +
                                     "VALUES (@id, @client_id, @tour_id, @booking_date, @arrival_date, payment_status(@booking_status), @manager_notes)";
                        }
                        else if (_role == "manager" || idBookingService.Text == "")
                        {
                            query = "INSERT INTO Booking (client_id, tour_id, booking_date, arrival_date, booking_status, manager_notes) " +
                                     "VALUES (@client_id, @tour_id, @booking_date, @arrival_date, payment_status(@booking_status), @manager_notes)";
                        }
                        else if (_role == "client")
                            query = "INSERT INTO Booking (client_id, tour_id, booking_date, arrival_date)" +
                                     "VALUES (@client_id, @tour_id, @booking_date, @arrival_date)";
                    }
                    else //Запросы на услуги
                    {
                        if (_role == "administrator" && idBookingService.Text != "")
                            query = "INSERT INTO ServiceRequest (request_id, client_id, service_id, request_date, service_date, promo_code, request_status, manager_notes) " +
                                     "VALUES (@id, @client_id, @service_id, @request_date, @service_date, @promo_code, payment_status(@request_status), @manager_notes)";
                        else if (_role == "manager" || idBookingService.Text == "")
                            query = "INSERT INTO ServiceRequest (client_id, service_id, request_date, service_date, promo_code, request_status, manager_notes) " +
                                     "VALUES (@client_id, @service_id, @request_date, @service_date, @promo_code, payment_status(@request_status), @manager_notes)";
                        else if (_role == "client")
                            query = "INSERT INTO ServiceRequest (client_id, service_id, request_date, service_date, promo_code)" +
                                     "VALUES (@client_id, @service_id, @request_date, @service_date, @promo_code)";
                    }
                }
                else //изменение
                {
                    Console.WriteLine("изменяем");
                    if (_type == 't') // Бронирование тура
                    {
                        if (_role == "administrator" && idBookingService.Text != "")
                            query = "UPDATE Booking SET booking_id = @id, client_id = @client_id, tour_id = @tour_id, booking_date = @booking_date, arrival_date = @arrival_date, " +
                                "booking_status = payment_status(@booking_status), manager_notes = @manager_notes WHERE booking_id = @old_id";
                        else if (_role == "manager" || idBookingService.Text == "")
                            query = "UPDATE Booking SET client_id = @client_id, tour_id = @tour_id, booking_date = @booking_date, arrival_date = @arrival_date, " +
                                    "booking_status = payment_status(@booking_status), manager_notes = @manager_notes WHERE booking_id = @old_id";
                    }
                    else
                    {
                        if (_role == "administrator" && idBookingService.Text != "")
                        {
                            Console.WriteLine("услуги админ без айди");
                            query = "UPDATE ServiceRequest SET request_id = @id, client_id = @client_id, service_id = @service_id, request_date = @request_date, service_date = @service_date, " +
                                "request_status = payment_status(@request_status), manager_notes = @manager_notes, promo_code=@promo_code WHERE request_id = @old_id";
                        }
                        else if (_role == "manager" || idBookingService.Text == "")
                            query = "UPDATE ServiceRequest SET client_id = @client_id, service_id = @service_id, request_date = @request_date, service_date = @service_date, " +
                                    "request_status = payment_status(@request_status), manager_notes = @manager_notes, promo_code=@promo_code WHERE request_id = @old_id";
                    }
                }
                using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                {
                    if (_role == "administrator" && idBookingService.Text != "") command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = int.Parse(idBookingService.Text);

                    command.Parameters.Add("@old_id", NpgsqlDbType.Integer).Value = int.Parse(idMyOld);
                    command.Parameters.Add("@client_id", NpgsqlDbType.Integer).Value = int.Parse(clientBookingRequest.Text);
                    command.Parameters.Add("@tour_id", NpgsqlDbType.Integer).Value = int.Parse(tourServiceBookingRequest.Text);
                    command.Parameters.Add("@service_id", NpgsqlDbType.Integer).Value = int.Parse(tourServiceBookingRequest.Text);
                    command.Parameters.Add("@booking_date", NpgsqlDbType.Date).Value = DateTime.Parse(dateBookingRequest.Text);
                    command.Parameters.Add("@request_date", NpgsqlDbType.Date).Value = DateTime.Parse(dateBookingRequest.Text);
                    command.Parameters.Add("@arrival_date", NpgsqlDbType.Date).Value = DateTime.Parse(dateBookingRequestStart.Text);
                    command.Parameters.Add("@service_date", NpgsqlDbType.Date).Value = DateTime.Parse(dateBookingRequestStart.Text);
                    command.Parameters.AddWithValue("@booking_status", statusBookingRequest.SelectedItem?.ToString() ?? "Ожидает оплаты");
                    command.Parameters.AddWithValue("@request_status", statusBookingRequest.SelectedItem?.ToString() ?? "Ожидает оплаты");
                    command.Parameters.Add("@manager_notes", NpgsqlDbType.Text).Value = notesBookingRequest.Text;
                    command.Parameters.Add("@promo_code", NpgsqlDbType.Varchar).Value = promocodeRequest.Text;

                    Console.WriteLine("Command Parameters:");
                    foreach (NpgsqlParameter parameter in command.Parameters)
                    {
                        string valueString = parameter.Value == null ? "NULL" : parameter.Value.ToString();
                        Console.WriteLine($"- Name: {parameter.ParameterName}, Value: {valueString}, Type: {parameter.NpgsqlDbType}");
                    }
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Запись успешно сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении записи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}