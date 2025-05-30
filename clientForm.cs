
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COURSACH_APP_WITH_SQL
{
    public partial class clientForm : Form
    {
        private DB db;
        private DataTable data;

        bool fl_podr = false;
        bool t = true;
        bool s = false;
        bool ph = false;
        bool r = false;
        int id;
        string passUser;
        bool showOnlyMyReviews = false; // Флаг для фильтрации отзывов
        bool showMyRequests = false;
        bool showMyBooking = false;
        bool grid = true;
        string textReview;
        string photoReview;
        int ratingReview;
        string clientReview;
        string tourReview;
        string dateReview;

        public clientForm(string p)
        {
            passUser = p;
            InitializeComponent();
            PreviousPropreties();

            db = new DB();
            if (!db.OpenConnection())
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            db.ExecuteQuery("SET ROLE client");
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
            //
            int x1 = (panelWidth - (buttonWidthUp * 3) - (horizontalSpacing * 2)) / 2;
            int x2 = x1 + buttonWidthUp + horizontalSpacing;
            int x3 = x2 + buttonWidthUp + horizontalSpacing;
            int y = (panelContainer.Height - buttonHeight) / 2;
            //
            buttonTours.Location = new Point(x1, y);
            buttonTours.Size = new Size(buttonWidthUp, buttonHeight);
            buttonTours.MinimumSize = new Size(buttonWidthUp, buttonHeight);
            buttonTours.AutoSize = false;
            //
            buttonServices.Location = new Point(x2, y);
            buttonServices.Size = new Size(buttonWidthUp, buttonHeight);
            buttonServices.MinimumSize = new Size(buttonWidthUp, buttonHeight);
            buttonServices.AutoSize = false;
            //
            buttonReviews.Location = new Point(x3, y);
            buttonReviews.Size = new Size(buttonWidthUp, buttonHeight);
            buttonReviews.MinimumSize = new Size(buttonWidthUp, buttonHeight);
            buttonReviews.AutoSize = false;
            //
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

            buttonAddBookingServiceReview.Location = new Point((this.Width - buttonWidthDown) / 2, 650 - 2 * buttonHeight - 2 * verticalSpacing);
            buttonAddBookingServiceReview.Size = new Size(buttonWidthDown, buttonHeight);
            buttonAddBookingServiceReview.MinimumSize = buttonAddBookingServiceReview.Size;
            buttonAddBookingServiceReview.MaximumSize = buttonAddBookingServiceReview.Size;
            buttonAddBookingServiceReview.AutoSize = false;

            buttonTourPhoto.Location = new Point((this.Width - buttonWidthDown) / 2, 650 - 3 * buttonHeight - 3 * verticalSpacing);
            buttonTourPhoto.Size = new Size(buttonWidthDown, buttonHeight);
            buttonTourPhoto.MinimumSize = buttonTourPhoto.Size;
            buttonTourPhoto.MaximumSize = buttonTourPhoto.Size;
            buttonTourPhoto.AutoSize = false;

            buttonPay.Location = new Point(BackButton.Left + 242 + 6, 650 - 2 * buttonHeight - 2 * verticalSpacing);
            buttonPay.Size = new Size(232, buttonHeight);
            buttonPay.MinimumSize = buttonPay.Size;
            buttonPay.MaximumSize = buttonPay.Size;
            buttonPay.AutoSize = false;

            buttonCancel.Location = new Point(BackButton.Left, 650 - 2 * buttonHeight - 2 * verticalSpacing);
            buttonCancel.Size = new Size(232, buttonHeight);
            buttonCancel.MinimumSize = buttonPay.Size;
            buttonCancel.MaximumSize = buttonPay.Size;
            buttonCancel.AutoSize = false;
            //
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            buttonEdit.Text = "Изменить";
            buttonEdit.Click += buttonEdit_Click;

            int buttonWidthMini = buttonWidthDown / 2 - verticalSpacing * 3;
            buttonEdit.Location = new Point((this.Width - buttonWidthMini) / 2, 650 - 2 * buttonHeight - 2 * verticalSpacing);
            buttonEdit.Size = new Size(buttonWidthMini, buttonHeight);
            buttonEdit.MinimumSize = buttonEdit.Size;
            buttonEdit.MaximumSize = buttonEdit.Size;
            buttonEdit.AutoSize = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ReviewForm editReviewForm = new ReviewForm("client", "edit", clientReview, id, tourReview, dateReview, photoReview, textReview, ratingReview);
            editReviewForm.ShowDialog();
            ShowDetails();
        }

        private void buttonAddBookingServiceReview_Click(object sender, EventArgs e)
        {
            if (t)
            {
                BookingRequestForm BookingRequestForm = new BookingRequestForm("client", "add", 't', id, passUser, id.ToString());
                BookingRequestForm.ShowDialog();
                showMyBooking = true;
            }

            else if (s)
            {
                BookingRequestForm BookingRequestForm = new BookingRequestForm("client", "add", 's', id, passUser, id.ToString());
                BookingRequestForm.ShowDialog();
                showMyRequests = true;
            }

            else if (r)
            {
                ReviewForm ReviewForm = new ReviewForm("client", "add", passUser);
                ReviewForm.ShowDialog();
                showOnlyMyReviews = false;

            }
            BackButton_Click(null, null);
        }

        private void BookingRequest(string status = "")
        {
            string query = "";


            using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
            {
                command.Parameters.AddWithValue("@status", NpgsqlDbType.Varchar).Value = status;
                command.ExecuteNonQuery();
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {

            db.ExecuteQuery("SET ROLE administrator");
            string query = "";
            if (t)
                query = "UPDATE Booking SET booking_status = payment_status(@status) WHERE booking_id = @id";
            else if (s)
                query = "UPDATE ServiceRequest SET request_status = payment_status(@status) WHERE request_id = @id";

            using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@status", NpgsqlDbType.Varchar).Value = "В обработке";
                command.ExecuteNonQuery();
            }

            db.ExecuteQuery("SET ROLE client");

            BackButton_Click(null, null);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            db.ExecuteQuery("SET ROLE administrator");
            string query = "";
            if (t)
                query = "UPDATE Booking SET booking_status = payment_status(@status) WHERE booking_id = @id";
            else if (s)
                query = "UPDATE ServiceRequest SET request_status = payment_status(@status) WHERE request_id = @id";

            using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@status", NpgsqlDbType.Varchar).Value = "Отклонен";
                command.ExecuteNonQuery();
            }

            db.ExecuteQuery("SET ROLE client");
            BackButton_Click(null, null);
        }

        private void buttonTours_Click(object sender, EventArgs e) //клик по кнопке сверху Туры
        {
            t = true;
            s = false;
            ph = false;
            r = false;
            textBoxSearch.Clear();
            SqlConnectionReader();
        }
        private void buttonServices_Click(object sender, EventArgs e) //клик по кнопке сверху Услуги
        {
            t = false;
            s = true;
            ph = false;
            r = false;
            textBoxSearch.Clear();
            SqlConnectionReader();
        }
        private void buttonReviews_Click(object sender, EventArgs e) //клик по кнопке сверху Отзывы
        {
            t = false;
            s = false;
            ph = false;
            r = true;
            textBoxSearch.Clear();
            SqlConnectionReader();
        }

        private void buttonTourPhoto_Click(object sender, EventArgs e) //клик по кнопке перехода на фото из тура и обратно
        {
            if (ph)
            {
                buttonTourPhoto.Text = $"Посмотреть фотографии тура";
                ph = false;
                ShowDetails();
            }
            else
            {
                buttonTourPhoto.Text = $"Вернуться к туру №{id}";
                ph = true;
                ShowPhotos();
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            name_label.Visible = false;
            data_richTextBox.Visible = false;
            BackButton.Visible = false;
            buttonTourPhoto.Visible = false;
            buttonPay.Visible = false;
            buttonCancel.Visible = false;
            buttonAddBookingServiceReview.Visible = false;
            data_panel.Visible = false;
            pictureBox1.Visible = false;
            buttonEdit.Visible = false;

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
                else if (r)
                {
                    showOnlyMyReviews = !showOnlyMyReviews;
                }
            }
            if (t)
            {
                t = true;
                s = false;
                ph = false;
            }
            else if (s)
            {
                t = false;
                s = true;
                ph = false;
            }
            else if (r)
            {
                t = false;
                s = false;
                r = true;
                ph = false;
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
            BackButton.Visible = true;
            buttonTourPhoto.Visible = false;
            buttonPay.Visible = false;
            buttonCancel.Visible = false;
            buttonAddBookingServiceReview.Visible = false;
            data_panel.Visible = false;
            textBoxSearch.Visible = true;
            pictureBox1.Visible = false;
            buttonEdit.Visible = false;
            name_label.Width = 838;
            data_richTextBox.Width = 838;

            try
            {
                if (t)
                {


                    if (showMyBooking)
                    {
                        label_main.Text = "Информация о бронированиях!";
                        data = db.ExecuteQuery($"SELECT booking_id AS id, tour_id AS id_тура, booking_status AS Статус_брони, manager_notes AS Примечание_брони, booking_date AS Дата_брони,  arrival_date AS Дата_начала FROM Booking WHERE client_id = {passUser}");
                        BackButton.Text = "Показать все туры";
                    }
                    else
                    {

                        label_main.Text = "Информация обо всех турах!";
                        data = db.ExecuteQuery("SELECT tour_id AS id, name AS Название, type AS Тип, price AS Цена, duration_days AS Длительность, availability AS Доступность FROM Tour;");
                        BackButton.Text = "Мои бронирования";
                    }

                }
                else if (s)
                {

                    if (showMyRequests)
                    {
                        label_main.Text = "Информация о запросах на услуги!";
                        data = db.ExecuteQuery($"SELECT request_id AS id, service_id AS id_услуги, request_status AS Статус_запроса, manager_notes AS Примечание, request_date AS Дата_запроса, service_date AS Дата_услуги, promo_code AS Промокод FROM ServiceRequest WHERE client_id = {passUser}");
                        BackButton.Text = "Показать все услуги";
                    }
                    else
                    {
                        label_main.Text = "Информация обо всех услугах!";
                        data = db.ExecuteQuery("SELECT service_id AS id, name AS Название, category AS Категория, price AS Цена, availability AS Доступность FROM Service");
                        BackButton.Text = "Мои запросы на услуги";
                    }

                }
                else if (r)
                {
                    string query = "SELECT r.review_id AS id, r.tour_id AS id_тура, c.first_name || ' ' || c.last_name AS ФИО_клиента, r.rating AS Рейтинг, r.review_date AS Дата_отзыва FROM Review AS r JOIN Client AS c ON r.client_id = c.client_id";

                    if (showOnlyMyReviews)
                    {
                        // Добавляем условие для отображения только отзывов текущего пользователя
                        query += $" WHERE r.client_id = {passUser}";
                        BackButton.Text = "Показать все отзывы";
                    }
                    else
                    {
                        BackButton.Text = "Показать только мои отзывы";
                    }

                    buttonAddBookingServiceReview.Visible = true;
                    buttonAddBookingServiceReview.Text = "Оставить отзыв";
                    data = db.ExecuteQuery(query);
                    label_main.Text = "Честные отзывы о наших турах!";
                }

                if (!fl_podr)
                {
                    // Добавление столбца "Подробности" 
                    DataGridViewButtonColumn detailsColumn = new DataGridViewButtonColumn();
                    detailsColumn.HeaderText = "Подробности";
                    detailsColumn.Text = "Подробнее";
                    detailsColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(detailsColumn);
                    fl_podr = true;
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

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].HeaderText == "Подробности") // Проверка на существование столбца
            {
                try
                {
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                    ShowDetails();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при извлечении ID тура: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            buttonEdit.Visible = false;

            string query;

            if (t)
            {
                if (showMyBooking)
                {
                    label_main.Text = "Информация о бронированиях!";
                    BackButton.Text = "Вернуться к списку бронирований";
                    buttonTourPhoto.Visible = false;

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

                                if (reader["booking_status"].ToString() == "Ожидает оплаты")
                                {
                                    buttonPay.Visible = true;
                                    buttonCancel.Visible = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    label_main.Text = "Информация обо всех турах!";
                    BackButton.Text = "Вернуться к списку туров";
                    buttonTourPhoto.Visible = true;
                    buttonTourPhoto.Text = "Посмотреть фотографии тура";
                    buttonAddBookingServiceReview.Visible = true;
                    buttonAddBookingServiceReview.Text = "Забронировать тур";

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
                    buttonTourPhoto.Visible = true;
                    buttonTourPhoto.Visible = false;

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

                                if (reader["request_status"].ToString() == "Ожидает оплаты")
                                {
                                    buttonPay.Visible = true;
                                    buttonCancel.Visible = true;
                                }
                            }
                        }
                    }
                }
                else
                {

                    label_main.Text = "Информация обо всех услугах!";
                    BackButton.Text = "Вернуться к списку услуг";
                    buttonTourPhoto.Visible = false;
                    buttonAddBookingServiceReview.Visible = true;
                    buttonAddBookingServiceReview.Text = "Запросить услугу";

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

                label_main.Text = "Честные отзывы о наших турах!!";
                BackButton.Text = "Вернуться к списку отзывов";
                buttonTourPhoto.Visible = false;
                buttonAddBookingServiceReview.Visible = false;

                // Запрос данных о туре и фотографиях
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

                                    pictureBox1.Size = new Size(data_richTextBox.Width, data_richTextBox.Height + name_label.Height - 4);     // Т_Т ЧЕЕЕ ВСМЫСЛЕ ЗАЧЕМ ОТНИМАТЬ 4, ЕСЛИ РАЗМЕР ИТАК ПРАВИЛЬНЫЙ((((( НУЛАДНАА ВИЗУАЛЬНО ТАК НОРМ 
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
        }

        private void ShowPhotos()
        {
            grid = false;
            dataGridView1.Visible = false;
            name_label.Visible = false;
            data_richTextBox.Visible = false;
            BackButton.Visible = true;
            buttonTourPhoto.Visible = true;
            data_panel.Visible = true;
            textBoxSearch.Visible = false;
            pictureBox1.Visible = false;

            string query = @"
                SELECT 
                    p.*
                FROM 
                    Photo p
                WHERE 
                    p.tour_id = @id";

            using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        label_main.Text = $"Фотографии тура №{id}";

                        // Отображение фотографий - обработка нескольких фотографий
                        List<string> imagePaths = new List<string>();
                        List<string> imageDescriptions = new List<string>();

                        do
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("path")))
                            {
                                imagePaths.Add(reader["path"].ToString());
                                imageDescriptions.Add(reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader["description"].ToString());
                            }
                        } while (reader.Read());

                        // Отображение фотографий
                        FlowLayoutPanel imagePanel = new FlowLayoutPanel();
                        imagePanel.Dock = DockStyle.Fill;
                        imagePanel.AutoScroll = true;
                        imagePanel.FlowDirection = FlowDirection.LeftToRight;
                        imagePanel.WrapContents = true;
                        imagePanel.AutoSize = false;

                        int imageSize = 180;

                        foreach (var item in imagePaths.Zip(imageDescriptions, (path, desc) => new { path, desc }))
                        {
                            try
                            {
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Load(item.path);
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                pictureBox.Width = imageSize;
                                pictureBox.Height = imageSize;
                                pictureBox.Margin = new Padding(12); // Отступы между картинками
                                pictureBox.BackColor = Color.FromArgb(153, 180, 209);

                                // Tooltip - описание по наведению
                                pictureBox.MouseHover += (sender, e) =>
                                {
                                    System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
                                    tooltip.SetToolTip(pictureBox, item.desc);
                                };
                                Console.WriteLine("Photo Path: " + item.path);
                                imagePanel.Controls.Add(pictureBox);
                                imagePanel.Size = new Size(imagePanel.PreferredSize.Width, imagePanel.PreferredSize.Height);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                            }
                        }
                        data_panel.Controls.Clear();
                        data_panel.Controls.Add(imagePanel);
                    }
                }
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
            Console.WriteLine(textBoxSearch);
        }

        private void FilterDataGridView()
        {
            string searchText = textBoxSearch.Text.ToLower();
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = BuildFilterExpression(searchText);
        }

        private string BuildFilterExpression(string searchText)
        {
            searchText = searchText.ToLower(); // Приводим поисковый запрос к нижнему регистру

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
                filterExpression = $" Convert(id, 'System.String') LIKE '%{searchText}%' OR Convert(id_тура, 'System.String') LIKE '%{searchText}%' OR Convert(ФИО_клиента, 'System.String') LIKE '%{searchText}%' OR Convert(Дата_отзыва, 'System.String') LIKE '%{searchText}%' OR Convert(Рейтинг, 'System.String') LIKE '%{searchText}%'";
            }
            return filterExpression;
        }
        private void client_info_Click(object sender, EventArgs e)
        {
            grid = false;
            buttonAddBookingServiceReview.Visible = false;
            dataGridView1.Visible = false;
            name_label.Visible = false;
            data_richTextBox.Visible = true;
            data_richTextBox.Height = 307;
            name_label.Width = 838;
            data_richTextBox.Width = 838;
            BackButton.Visible = false;
            buttonTourPhoto.Visible = false;
            buttonPay.Visible = false;
            buttonCancel.Visible = false;
            data_panel.Visible = false;
            textBoxSearch.Visible = false;
            pictureBox1.Visible = false;
            buttonEdit.Visible = false;

            label_main.Text = "Персональная информация";

            try
            {
                // Запрос информации о клиенте по ID (passUser)
                string query = @"SELECT * FROM Client WHERE client_id = @clientId";
                using (NpgsqlCommand command = new NpgsqlCommand(query, db.connection))
                {
                    int clientId;
                    if (int.TryParse(passUser, out clientId))
                    {
                        command.Parameters.AddWithValue("@clientId", clientId);
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

                                data_richTextBox.Text = $"ID клиента: {clientId}\n\n";
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
                    else
                    {
                        MessageBox.Show("Неверный формат ID клиента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении информации о клиенте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttons_MouseHover(object sender, EventArgs e)
        {
            buttonReviews.BackColor = Color.FromArgb(153, 180, 209);
        }

    }

}

