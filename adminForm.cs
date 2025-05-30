
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COURSACH_APP_WITH_SQL
{
    public partial class adminForm : Form
    {
        private DB db;

        private DataTable data;

        bool flag_new_columns = false;
        bool t = true;
        bool s = false;
        bool ph = false;
        bool r = false;
        bool c = false;
        int id;
        string passUser;
        bool showMyRequests = false;
        bool showMyBooking = false;
        bool grid = true;
        string textReview;
        string photoReview;
        int ratingReview;
        string clientReview;
        string tourReview;
        string dateReview;

        public adminForm()
        {
            this.Show();

            InitializeComponent();
            PreviousPropreties();

            db = new DB();
            if (!db.OpenConnection())
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            db.ExecuteQuery("SET ROLE administrator");
            SqlConnectionReader();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void PreviousPropreties()
        {
            //         
            int buttonWidthUp = 150;
            int buttonHeight = 38;
            int horizontalSpacing = 20;
            int panelWidth = panelContainer.Width;

            System.Windows.Forms.Button[] buttons = { buttonClients, buttonTours, buttonPhotos, buttonServices, buttonReviews, buttonDocuments };
            int totalButtonsWidth = buttonWidthUp * buttons.Length + horizontalSpacing * (buttons.Length - 1);
            int xStart = (panelWidth - totalButtonsWidth) / 2;
            int y = (panelContainer.Height - buttonHeight) / 2;
            for (int i = 0; i < buttons.Length; i++)
            {
                int x = xStart + (buttonWidthUp + horizontalSpacing) * i;
                buttons[i].Location = new Point(x, y);
                buttons[i].Size = new Size(buttonWidthUp, buttonHeight);
                buttons[i].MinimumSize = new Size(buttonWidthUp, buttonHeight);
                buttons[i].AutoSize = false;
            }
            int m = 20; // m - отступ
            data_richTextBox.SetInnerMargins(m, m, m, 0);
            int buttonWidthDown = 476;
            int verticalSpacing = 10;
            // Размещение нижних кнопок 
            BackButton.Location = new Point((this.Width - buttonWidthDown) / 2, 650 - buttonHeight - verticalSpacing);
            BackButton.Size = new Size(buttonWidthDown, buttonHeight);
            BackButton.MinimumSize = BackButton.Size;
            BackButton.MaximumSize = BackButton.Size;
            BackButton.AutoSize = false;
            buttonAdd.Location = new Point((this.Width - buttonWidthDown) / 2, 650 - 2 * buttonHeight - 2 * verticalSpacing);
            buttonAdd.Size = new Size(buttonWidthDown, buttonHeight);
            buttonAdd.MinimumSize = buttonAdd.Size;
            buttonAdd.MaximumSize = buttonAdd.Size;
            buttonAdd.AutoSize = false;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (t)
            {
                if (showMyBooking)
                {
                    BookingRequestForm BookingRequestForm = new BookingRequestForm("administrator", "add", 't');
                    BookingRequestForm.ShowDialog();
                }
                else
                {
                    tourForm tourForm = new tourForm("administrator", "add");
                    tourForm.ShowDialog();
                }
            }
            else if (s)
            {
                if (showMyRequests)
                {
                    BookingRequestForm BookingRequestForm = new BookingRequestForm("administrator", "add", 's');
                    BookingRequestForm.ShowDialog();
                }
                else
                {
                    serviceForm serviceForm = new serviceForm("administrator", "add");
                    serviceForm.ShowDialog();
                }
            }
            else if (r)
            {
                ReviewForm ReviewForm = new ReviewForm("administrator", "add");
                ReviewForm.ShowDialog();
            }
            else if (c)
            {
                tableClientForm tableClientForm = new tableClientForm("administrator", "add");
                tableClientForm.ShowDialog();
            }
            else if (ph)
            {
                photoForm photoForm = new photoForm("administrator", "add");
                photoForm.ShowDialog();
            }
            SqlConnectionReader();
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            Console.WriteLine("клик");
            t = false;
            s = false;
            ph = false;
            r = false;
            c = true;
            textBoxSearch.Clear();
            SqlConnectionReader();
        }
        private void buttonTours_Click(object sender, EventArgs e) //клик по кнопке сверху Туры
        {
            t = true;
            s = false;
            ph = false;
            r = false;
            c = false;
            showMyBooking = false;
            textBoxSearch.Clear();
            SqlConnectionReader();
        }
        private void buttonPhoto_Click(object sender, EventArgs e) //клик по кнопке сверху Туры
        {
            t = false;
            s = false;
            ph = true;
            r = false;
            c = false;
            showMyBooking = false;
            textBoxSearch.Clear();
            SqlConnectionReader();
        }
        private void buttonServices_Click(object sender, EventArgs e) //клик по кнопке сверху Услуги
        {
            t = false;
            s = true;
            ph = false;
            r = false;
            c = false;
            showMyRequests = false;
            textBoxSearch.Clear();
            SqlConnectionReader();
        }
        private void buttonReviews_Click(object sender, EventArgs e) //клик по кнопке сверху Отзывы
        {
            t = false;
            s = false;
            ph = false;
            r = true;
            c = false;
            textBoxSearch.Clear();
            SqlConnectionReader();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            name_label.Visible = false;
            data_richTextBox.Visible = false;
            BackButton.Visible = false;
            data_panel.Visible = false;
            pictureBox1.Visible = false;

            if (grid)
            {
                if (t)
                {
                    showMyBooking = !showMyBooking;
                }
                else if (s)
                {
                    showMyRequests = !showMyRequests;
                }
            }
            if (t)
            {
                t = true;
                s = false;
                r = false;
                ph = false;
                c = false;
            }
            else if (s)
            {
                t = false;
                s = true;
                r = false;
                ph = false;
                c = false;
            }
            else if (r)
            {
                t = false;
                s = false;
                r = true;
                ph = false;
                c = false;
            }
            else if (c)
            {
                t = false;
                s = false;
                r = false;
                ph = false;
                c = true;
            }
            else if (ph)
            {
                t = false;
                s = false;
                r = false;
                ph = true;
                c = false;
            }
            SqlConnectionReader();
            FilterDataGridView();
        }

        private void SqlConnectionReader()
        {
            grid = true;

            dataGridView1.Visible = true;
            name_label.Visible = false;
            data_richTextBox.Visible = false;
            data_panel.Visible = false;
            textBoxSearch.Visible = true;
            pictureBox1.Visible = false;
            name_label.Width = 838;
            data_richTextBox.Width = 838;
            buttonAdd.Visible = true;

            try
            {
                if (t)
                {
                    BackButton.Visible = true;
                    if (showMyBooking)
                    {
                        label_main.Text = "Информация о бронированиях!";
                        data = db.ExecuteQuery($"SELECT booking_id AS id, client_id as id_клиента, tour_id AS id_тура, booking_status AS Статус, manager_notes AS Примечание, booking_date AS Дата_брони,  arrival_date AS Дата_начала FROM Booking");
                        BackButton.Text = "Показать все туры";
                        buttonAdd.Text = "Добавить бронь";
                    }
                    else
                    {

                        label_main.Text = "Информация обо всех турах!";
                        data = db.ExecuteQuery("SELECT tour_id AS id, name AS Название, type AS Тип, price AS Цена, duration_days AS Длительность, availability AS Доступность FROM Tour;");
                        BackButton.Text = "Бронирования туров";
                        buttonAdd.Text = "Добавить тур";
                    }
                }
                else if (s)
                {
                    BackButton.Visible = true;
                    if (showMyRequests)
                    {
                        label_main.Text = "Информация о запросах на услуги!";
                        data = db.ExecuteQuery($"SELECT request_id AS id, client_id as id_клиента, service_id AS id_услуги, request_status AS Статус, manager_notes AS Примечание, promo_code AS Промокод, request_date AS Дата_запроса, service_date AS Дата_услуги FROM ServiceRequest");
                        BackButton.Text = "Показать все услуги";
                        buttonAdd.Text = "Добавить запрос на услугу";
                    }
                    else
                    {
                        label_main.Text = "Информация обо всех услугах!";
                        data = db.ExecuteQuery("SELECT service_id AS id, name AS Название, category AS Категория, price AS Цена, availability AS Доступность FROM Service");
                        BackButton.Text = "Запросы на услуги";
                        buttonAdd.Text = "Добавить услугу";
                    }

                }
                else if (r)
                {
                    BackButton.Visible = false;
                    buttonAdd.Visible = true;
                    buttonAdd.Text = "Добавить отзыв";
                    data = db.ExecuteQuery("SELECT review_id AS id, client_id as id_клиента, tour_id AS id_тура, rating AS Рейтинг, text as Текст, review_date AS Дата_отзыва FROM Review");
                    label_main.Text = "Честные отзывы о наших турах!";
                }
                else if (c)
                {
                    BackButton.Visible = false;
                    buttonAdd.Visible = true;
                    buttonAdd.Text = "Добавить клиента";
                    data = db.ExecuteQuery("SELECT client_id AS id, last_name as Фамилия, first_name AS Имя, middle_name AS Отчество, passport_data as Паспорт, phone_number AS Номер, email FROM Client");
                    label_main.Text = "Информация о клиентах!";
                }
                else if (ph)
                {
                    BackButton.Visible = false;
                    buttonAdd.Visible = true;
                    buttonAdd.Text = "Добавить фото";
                    data = db.ExecuteQuery("SELECT photo_id AS id, tour_id AS id_тура, path as Путь, description AS Описание FROM Photo");
                    label_main.Text = "Фотографии туров!";
                }

                if (!flag_new_columns)
                {
                    // Добавление столбца "Подробности" 
                    DataGridViewButtonColumn detailsColumn = new DataGridViewButtonColumn();
                    detailsColumn.HeaderText = "Подробности";
                    detailsColumn.Text = "Подробнее";
                    detailsColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(detailsColumn);
                    // Добавление столбца "Изменить" 
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
                    editColumn.HeaderText = "Изменить";
                    editColumn.Text = "Изменить";
                    editColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(editColumn);
                    // Добавление столбца "Удалить" 
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                    deleteColumn.HeaderText = "Удалить";
                    deleteColumn.Text = "Удалить";
                    deleteColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(deleteColumn);
                    flag_new_columns = true;
                }

                dataGridView1.DataSource = data; // Установка DataSource 
                dataGridView1.Visible = true;
                // Стилизация заголовков
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Constantia", 10, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // Стилизация строк
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.RowsDefaultCellStyle.Font = new Font("Constantia", 10);
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Чередующиеся строки
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AllowUserToResizeRows = true;
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["id"].MinimumWidth = 50;   // Минимальная ширина

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //--------------ПРОСМОТР ПОДРОБНОСТЕЙ-----------------------------------
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].HeaderText == "Подробности") // Проверка на существование столбца
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                ShowDetails();
            }

            //--------------ДОБАВЛЕНИЕ ЗАПИСИ-----------------------
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].HeaderText == "Изменить") // Проверка на существование столбца
            {

                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                if (r) //ОТЗЫВЫ
                {
                    string query = @"SELECT * FROM Review WHERE review_id = @id;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string clientReview = reader["client_id"].ToString();
                                string tourReview = reader["tour_id"].ToString();
                                string dateReview = reader.GetDateTime(reader.GetOrdinal("review_date")).ToString("dd.MM.yyyy");
                                string textReview = reader["text"].ToString();
                                string photoReview = reader["photo"].ToString();
                                int ratingReview = (int)reader["rating"];

                                ReviewForm editReviewForm = new ReviewForm("administrator", "edit", clientReview, id, tourReview, dateReview, photoReview, textReview, ratingReview);
                                editReviewForm.ShowDialog();
                            }
                        }
                    }
                }
                else if (t)
                {
                    if (showMyBooking)
                    {
                        //БРОНИ
                        string query = @"SELECT * FROM Booking WHERE booking_id = @id;";
                        using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string clientBookingRequest = reader["client_id"].ToString();
                                    string tourBookingRequest = reader["tour_id"].ToString();
                                    string dateBookingRequest = reader.GetDateTime(reader.GetOrdinal("booking_date")).ToString("dd.MM.yyyy");
                                    string dateBookingRequestStart = reader.GetDateTime(reader.GetOrdinal("arrival_date")).ToString("dd.MM.yyyy");
                                    string statusBookingRequest = reader["booking_status"].ToString();
                                    string notesBookingRequest = reader["manager_notes"].ToString();

                                    BookingRequestForm BookingRequestForm = new BookingRequestForm("administrator", "edit", 't', id, clientBookingRequest, tourBookingRequest,
                                        dateBookingRequest, dateBookingRequestStart, statusBookingRequest, notesBookingRequest);
                                    BookingRequestForm.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        //ТУРЫ
                        string query = @"SELECT * FROM Tour WHERE tour_id = @id;";
                        using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nameTour = reader["name"].ToString();
                                    string typeTour = reader["type"].ToString();
                                    string priceTour = reader["price"].ToString();
                                    int durationTour = (int)reader["duration_days"];
                                    string descriptionTour = reader["description"].ToString();
                                    string availTour = reader["availability"].ToString();

                                    Console.WriteLine(priceTour);
                                    tourForm tourForm = new tourForm("administrator", "edit", id, nameTour, typeTour,
                                        priceTour, durationTour, descriptionTour, availTour);
                                    tourForm.ShowDialog();
                                }
                            }
                        }
                    }
                }
                else if (s)
                {
                    if (showMyRequests)
                    {
                        //ЗАПРОСЫ
                        string query = @"SELECT * FROM ServiceRequest WHERE request_id = @id;";
                        using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string clientBookingRequest = reader["client_id"].ToString();
                                    string serviceBookingRequest = reader["service_id"].ToString();
                                    string dateBookingRequest = reader.GetDateTime(reader.GetOrdinal("request_date")).ToString("dd.MM.yyyy");
                                    string dateBookingRequestStart = reader.GetDateTime(reader.GetOrdinal("service_date")).ToString("dd.MM.yyyy");
                                    string statusBookingRequest = reader["request_status"].ToString();
                                    string notesBookingRequest = reader["manager_notes"].ToString();
                                    string promocodeBookingRequest = reader["promo_code"].ToString();

                                    BookingRequestForm BookingRequestForm = new BookingRequestForm("administrator", "edit", 's', id, clientBookingRequest, serviceBookingRequest,
                                        dateBookingRequest, dateBookingRequestStart, statusBookingRequest, notesBookingRequest, promocodeBookingRequest);
                                    BookingRequestForm.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        //УСЛУГИ
                        string query = @"SELECT * FROM Service WHERE service_id = @id;";
                        using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nameService = reader["name"].ToString();
                                    string categoryService = reader["category"].ToString();
                                    string priceService = reader["price"].ToString();
                                    string descriptionService = reader["description"].ToString();
                                    string availService = reader["availability"].ToString();

                                    Console.WriteLine(priceService);
                                    serviceForm serviceForm = new serviceForm("administrator", "edit", id, nameService, categoryService,
                                        priceService, descriptionService, availService);
                                    serviceForm.ShowDialog();
                                }
                            }
                        }
                    }
                }
                else if (c)
                {
                    //КЛИЕНТЫ
                    string query = @"SELECT * FROM Client WHERE client_id = @id;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string last = reader["last_name"].ToString();
                                string first = reader["first_name"].ToString();
                                string middle = reader["middle_name"].ToString();
                                string phone = reader["phone_number"].ToString();
                                string passport = reader["passport_data"].ToString();
                                string email = reader["email"].ToString();

                                tableClientForm tableClientForm = new tableClientForm("administrator", "edit", id, last, first, middle, phone, passport, email);
                                tableClientForm.ShowDialog();
                            }
                        }
                    }
                }
                else if (ph)
                {
                    //ФОТКИ
                    string query = @"SELECT * FROM Photo WHERE photo_id = @id;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tour = reader["tour_id"].ToString();
                                string path = reader["path"].ToString();
                                string description = reader["description"].ToString();

                                photoForm photoForm = new photoForm("administrator", "edit", id, tour, path, description);
                                photoForm.ShowDialog();
                            }
                        }
                    }
                }
                SqlConnectionReader();
                FilterDataGridView();
            }
            //--------------УДАЛЕНИЕ ЛЮБОЙ ЗАПИСИ!! (ДОБАВИТЬ БРОНИ, ЗАПРОСЫ И ФОТО)-----------------------
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].HeaderText == "Удалить") // Проверка на существование столбца
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string query = "";
                        if (t)
                        {
                            if (showMyBooking)
                                query = "DELETE FROM Booking WHERE booking_id = @id";
                            else query = "DELETE FROM Tour WHERE tour_id = @id";
                        }
                        else if (s)
                        {
                            if (showMyRequests)
                                query = "DELETE FROM ServiceRequest WHERE request_id = @id";
                            else query = "DELETE FROM Service WHERE service_id = @id";
                        }
                        else if (r) query = "DELETE FROM Review WHERE review_id = @id";
                        else if (c) query = "DELETE FROM Client WHERE client_id = @id";
                        else if (ph) query = "DELETE FROM Photo WHERE photo_id = @id";
                        using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Запись успешно удалена!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                SqlConnectionReader();
                FilterDataGridView();

            }
        }

        private void ShowDetails()
        {

            grid = false;
            dataGridView1.Visible = false;
            name_label.Visible = true;
            data_richTextBox.Visible = true;
            data_richTextBox.Height = 300;
            name_label.Width = 838;
            data_richTextBox.Width = 838;
            BackButton.Visible = true;
            data_panel.Visible = false;
            textBoxSearch.Visible = false;
            pictureBox1.Visible = false;
            buttonAdd.Visible = false;
            string query;

            if (t)
            {
                if (showMyBooking)
                {
                    label_main.Text = "Информация о бронированиях!";
                    BackButton.Text = "Вернуться к списку бронирований";
                    // Запрос данных о брони
                    query = @"
                SELECT 
                    b.*,
                    t.name,
                    t.price
                FROM 
                    Booking b
                JOIN 
                    Tour t ON b.tour_id = t.tour_id
                WHERE 
                    b.booking_id = @id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label_main.Text = $"Информация о брони №{id}";
                                name_label.Visible = false;
                                data_richTextBox.Text = $"Дата брони: {reader.GetDateTime(reader.GetOrdinal("booking_date")).ToString("dd.MM.yyyy")}{Environment.NewLine}{Environment.NewLine}" +
                                                        $"Тур №{reader["tour_id"]} - {reader["name"]}{Environment.NewLine}" +
                                                        $"Цена: {reader["price"]}{Environment.NewLine}" +
                                                        $"Дата начала тура: {reader.GetDateTime(reader.GetOrdinal("arrival_date")).ToString("dd.MM.yyyy")}{Environment.NewLine}{Environment.NewLine}" +
                                                       $"Статус: {reader["booking_status"]}{Environment.NewLine}" +
                                                       $"Примечание менеджера: {reader["manager_notes"]}";
                            }
                        }
                    }
                }
                else
                {
                    label_main.Text = "Информация обо всех турах!";
                    BackButton.Text = "Вернуться к списку туров";
                    // Запрос данных о туре и фотографиях
                    query = @"
                SELECT 
                    t.*
                FROM 
                    Tour t
                WHERE 
                    t.tour_id = @id";


                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label_main.Text = $"Информация о туре №{id}";
                                name_label.Text = $"{reader["name"]}";
                                data_richTextBox.Text = $"Тип: {reader["type"]}{Environment.NewLine}" +
                                                       $"Цена: {reader["price"]}{Environment.NewLine}" +
                                                       $"Длительность: {reader["duration_days"]} дней{Environment.NewLine}" +
                                                       $"Доступность: {reader["availability"]}{Environment.NewLine}{Environment.NewLine}" +
                                                       $"Описание тура: {Environment.NewLine}" +
                                                       $"{reader["description"]}";
                            }
                        }
                    }
                }
            }
            else if (s)
            {
                if (showMyRequests)
                {

                    label_main.Text = "Информация о запросах на услуги!";
                    BackButton.Text = "Вернуться к списку запросов";
                    // Запрос данных о брони
                    query = @"
                SELECT 
                    sr.*,
                    s.name,
                    s.price
                FROM 
                    ServiceRequest sr
                JOIN 
                    Service s ON sr.service_id = s.service_id
                WHERE 
                    sr.request_id = @id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label_main.Text = $"Информация о запросе №{id}";
                                name_label.Visible = false;
                                data_richTextBox.Text = $"Дата оформления запроса: {reader.GetDateTime(reader.GetOrdinal("request_date")).ToString("dd.MM.yyyy")}{Environment.NewLine}{Environment.NewLine}" +
                                                        $"Услуга №{reader["service_id"]} - {reader["name"]}{Environment.NewLine}" +
                                                        $"Цена: {reader["price"]}{Environment.NewLine}" +
                                                        $"Дата применения услуги: {reader.GetDateTime(reader.GetOrdinal("service_date")).ToString("dd.MM.yyyy")}{Environment.NewLine}" +
                                                        $"Промокод: {reader["promo_code"]}{Environment.NewLine}{Environment.NewLine}" +
                                                       $"Статус: {reader["request_status"]}{Environment.NewLine}" +
                                                       $"Примечание менеджера: {reader["manager_notes"]}";
                            }
                        }
                    }
                }
                else
                {
                    label_main.Text = "Информация обо всех услугах!";
                    BackButton.Text = "Вернуться к списку услуг";
                    // Запрос данных об услуге
                    query = @"
                SELECT
                    s.*
                FROM
                    Service s
                WHERE
                    s.service_id = @id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label_main.Text = $"Информация об услуге №{id}";
                                name_label.Text = $"{reader["name"]}";
                                data_richTextBox.Text = $"Категория: {reader["category"]}{Environment.NewLine}" +
                                                       $"Цена: {reader["price"]}{Environment.NewLine}" +
                                                       $"Доступность: {reader["availability"]}{Environment.NewLine}{Environment.NewLine}" +
                                                       $"Описание услуги: {Environment.NewLine}" +
                                                       $"{reader["description"]}";
                            }
                        }
                    }
                }
            }
            //отзыв
            else if (r)
            {

                label_main.Text = "Честные отзывы о наших турах!";
                BackButton.Text = "Вернуться к списку отзывов";
                buttonAdd.Visible = false;

                // Запрос данных об отзыве
                query = @"
        SELECT 
            r.*, 
            c.first_name || ' ' || c.last_name AS ФИО_клиента
        FROM 
            Review r
        JOIN 
            Client c ON r.client_id = c.client_id
        WHERE 
            r.review_id = @id;";


                using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label_main.Text = $"Отзыв №{id}";
                            name_label.Text = $"{reader["ФИО_клиента"]}";
                            data_richTextBox.Text = $"Тур №{reader["tour_id"]}{Environment.NewLine}" +
                  $"Дата: {reader.GetDateTime(reader.GetOrdinal("review_date")).ToString("dd.MM.yyyy")}{Environment.NewLine}{Environment.NewLine}" +
                  $"Рейтинг: {reader["rating"]}{Environment.NewLine}{Environment.NewLine}" +
                  $"{reader["text"]}";

                            if (passUser == reader["client_id"].ToString())
                            {
                                buttonEdit.Visible = true;
                            }

                            string photoPath = reader["photo"].ToString();

                            clientReview = reader["client_id"].ToString();
                            tourReview = reader["tour_id"].ToString();
                            dateReview = reader.GetDateTime(reader.GetOrdinal("review_date")).ToString("dd.MM.yyyy");
                            textReview = reader["text"].ToString();
                            photoReview = photoPath;
                            ratingReview = (int)reader["rating"];

                            if (!string.IsNullOrEmpty(photoPath))
                            {
                                try
                                {
                                    pictureBox1.Visible = true;
                                    data_richTextBox.Width = data_richTextBox.Width / 2 - 10;
                                    pictureBox1.Location = new Point(data_richTextBox.Right + 20, name_label.Top); //расположение
                                    pictureBox1.Size = new Size(data_richTextBox.Width, data_richTextBox.Height + name_label.Height - 4);
                                    name_label.Width = name_label.Width / 2 - 10;
                                    pictureBox1.ImageLocation = photoPath;
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    pictureBox1.BackColor = Color.FromArgb(153, 180, 209);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                                }
                            }
                            else pictureBox1.Visible = false;
                        }
                    }
                }
            }
            else if (c)
            {
                label_main.Text = $"Информация о клиенте №{id}";
                name_label.Visible = false;
                BackButton.Text = "Вернуться к списку клиентов";

                query = @"SELECT * FROM Client WHERE client_id = @id";
                using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string middleName = reader.IsDBNull(reader.GetOrdinal("middle_name")) ? "  " : reader["middle_name"].ToString();
                            string email = reader["email"].ToString();
                            string phoneNumber = reader["phone_number"].ToString();
                            string passport_data = reader["passport_data"].ToString();

                            data_richTextBox.Text = $"ID клиента: {id}\n\n";
                            data_richTextBox.Text += $"Фамилия: {lastName}\n";
                            data_richTextBox.Text += $"Имя: {firstName}\n";
                            data_richTextBox.Text += $"Отчество: {middleName}\n";
                            data_richTextBox.Text += $"Паспорт: {passport_data}\n";
                            data_richTextBox.Text += $"Email: {email}\n";
                            data_richTextBox.Text += $"Номер телефона: {phoneNumber}\n";
                        }
                        else
                        {
                            MessageBox.Show("Информация о клиенте не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            else if (ph)
            {
                label_main.Text = $"Информация о фото №{id}";
                name_label.Visible = false;
                BackButton.Text = "Вернуться к списку фото";

                query = @"SELECT * FROM Photo WHERE photo_id = @id";
                using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string tourPhoto = reader["tour_id"].ToString();
                            string pathPhoto = reader["path"].ToString();
                            string description = reader["description"].ToString();
                            data_richTextBox.Text = $"ID тура: {tourPhoto}\n\n";
                            data_richTextBox.Text += $"Описание:\n{description}\n";

                            try
                            {
                                pictureBox1.Visible = true;
                                data_richTextBox.Width = data_richTextBox.Width / 2 - 10;
                                pictureBox1.Location = new Point(data_richTextBox.Right + 20, data_richTextBox.Top);
                                pictureBox1.Size = new Size(data_richTextBox.Width, data_richTextBox.Height);
                                pictureBox1.ImageLocation = pathPhoto;
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                pictureBox1.BackColor = Color.FromArgb(153, 180, 209);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Информация о клиенте не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }
        private void FilterDataGridView()
        {
            string searchText = textBoxSearch.Text.ToLower();
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = BuildFilterExpression(searchText);
        }

        private string BuildFilterExpression(string searchText)
        {
            searchText = searchText.ToLower();
            if (string.IsNullOrEmpty(searchText)) return "";

            string filterExpression = "";

            if (t && showMyBooking)
            {
                filterExpression = $"(Convert(id, 'System.String') LIKE '%{searchText}%') OR (Convert(id_клиента, 'System.String') LIKE '%{searchText}%') OR (Convert(id_тура, 'System.String') LIKE '%{searchText}%') OR (Статус LIKE '%{searchText}%') OR (Примечание LIKE '%{searchText}%') OR (Convert(Дата_брони, 'System.String') LIKE '%{searchText}%') OR (Convert(Дата_начала, 'System.String') LIKE '%{searchText}%')";
            }
            else if (t && !showMyBooking)
            {
                filterExpression = $"(Convert(id, 'System.String') LIKE '%{searchText}%') OR (Название LIKE '%{searchText}%') OR (Тип LIKE '%{searchText}%') OR (Convert(Цена, 'System.String') LIKE '%{searchText}%') OR (Convert(Длительность, 'System.String') LIKE '%{searchText}%') OR (Доступность LIKE '%{searchText}%')";
            }
            else if (s && showMyRequests)
            {
                filterExpression = $"(Convert(id, 'System.String') LIKE '%{searchText}%') OR (Convert(id_клиента, 'System.String') LIKE '%{searchText}%') OR (Convert(id_услуги, 'System.String') LIKE '%{searchText}%') OR (Статус LIKE '%{searchText}%') OR (Примечание LIKE '%{searchText}%') OR (Промокод LIKE '%{searchText}%') OR (Convert(Дата_запроса, 'System.String') LIKE '%{searchText}%') OR (Convert(Дата_услуги, 'System.String') LIKE '%{searchText}%')";
            }
            else if (s && !showMyRequests)
            {
                filterExpression = $"(Convert(id, 'System.String') LIKE '%{searchText}%') OR (Название LIKE '%{searchText}%') OR (Категория LIKE '%{searchText}%') OR (Convert(Цена, 'System.String') LIKE '%{searchText}%') OR (Доступность LIKE '%{searchText}%')";
            }
            else if (r)
            {
                filterExpression = $" Convert(id, 'System.String') LIKE '%{searchText}%' OR Convert(id_тура, 'System.String') LIKE '%{searchText}%' OR Convert(id_клиента, 'System.String') LIKE '%{searchText}%' OR Convert(Дата_отзыва, 'System.String') LIKE '%{searchText}%' OR Convert(Рейтинг, 'System.String') LIKE '%{searchText}%'OR Convert(Текст, 'System.String') LIKE '%{searchText}%'";
            }
            else if (c)
            {
                filterExpression = $"(Convert(id, 'System.String') LIKE '%{searchText}%') OR (Фамилия LIKE '%{searchText}%') OR (Имя LIKE '%{searchText}%') OR (Отчество LIKE '%{searchText}%') OR (Паспорт LIKE '%{searchText}%') OR (Номер LIKE '%{searchText}%') OR (email LIKE '%{searchText}%')";
            }
            else if (ph)
            {
                filterExpression = $"(Convert(id, 'System.String') LIKE '%{searchText}%') OR (Convert(id_тура, 'System.String') LIKE '%{searchText}%') OR (Путь LIKE '%{searchText}%') OR (Описание LIKE '%{searchText}%')";
            }

            return filterExpression;
        }
        private void buttons_MouseHover(object sender, EventArgs e)
        {
            buttonReviews.BackColor = Color.FromArgb(153, 180, 209);
        }

        private void buttonDocuments_Click(object sender, EventArgs e)
        {
            reportForm reportForm = new reportForm();
            reportForm.ShowDialog();
        }
    }

}

