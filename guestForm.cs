
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COURSACH_APP_WITH_SQL
{
    public partial class guestForm : Form
    {
        private DB db;

        private DataTable data;

        bool fl_podr = false;
        bool t = true;
        bool s = false;
        bool ph = false;
        bool r = false;
        int id;            

        public guestForm()
        {
            InitializeComponent();
            PreviousPropreties();

            db = new DB();
            if (!db.OpenConnection())
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            db.ExecuteQuery("SET ROLE guest");
            SqlConnectionReader();

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void PreviousPropreties()
        {
            //         
            int buttonWidth = 150; // Ширина
            int buttonHeight = 38; // Высота
            int horizontalSpacing = 20; // Расстояние между кнопками
            int panelWidth = panelContainer.Width;
            //
            int x1 = (panelWidth - (buttonWidth * 3) - (horizontalSpacing * 2)) / 2;  //координаты первой кнопки
            int x2 = x1 + buttonWidth + horizontalSpacing; //координаты второй кнопки
            int x3 = x2 + buttonWidth + horizontalSpacing; //координаты третьей кнопки
            int y = (panelContainer.Height - buttonHeight) / 2; //вертикальное выравнивание
            //
            buttonTours.Location = new Point(x1, y);
            buttonTours.Size = new Size(buttonWidth, buttonHeight);
            buttonTours.MinimumSize = new Size(buttonWidth, buttonHeight);
            buttonTours.AutoSize = false;
            //
            buttonServices.Location = new Point(x2, y);
            buttonServices.Size = new Size(buttonWidth, buttonHeight);
            buttonServices.MinimumSize = new Size(buttonWidth, buttonHeight);
            buttonServices.AutoSize = false;
            //
            buttonReviews.Location = new Point(x3, y);
            buttonReviews.Size = new Size(buttonWidth, buttonHeight);
            buttonReviews.MinimumSize = new Size(buttonWidth, buttonHeight);
            buttonReviews.AutoSize = false;
            //
            int m = 20; // m - отступ
            data_richTextBox.SetInnerMargins(m, m, m, 0);
            //
            int buttonWidthBack = 476;
            int buttonWidthPhoto = 556;            
            int verticalSpacing = 10;
            // Размещение нижних кнопок 
            BackButton.Location = new Point((this.Width - buttonWidthBack) / 2, 650 - buttonHeight- verticalSpacing);
            BackButton.Size = new Size(buttonWidthBack, buttonHeight);
            BackButton.MinimumSize = BackButton.Size;
            BackButton.MaximumSize = BackButton.Size;
            BackButton.AutoSize = false;

            buttonTourPhoto.Location = new Point((this.Width - buttonWidthPhoto) / 2 , 650 - 2*buttonHeight - 2*verticalSpacing);
            buttonTourPhoto.Size = new Size(buttonWidthPhoto, buttonHeight);
            buttonTourPhoto.MinimumSize = new Size(buttonWidthPhoto, buttonHeight);
            buttonTourPhoto.MaximumSize = buttonTourPhoto.Size;
            buttonTourPhoto.AutoSize = false;

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
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
            data_panel.Visible = false;
            pictureBox1.Visible = false;

            if (t)
            {
             //   label_main.Text = "Информация обо всех турах!";
                t = true;
                s = false;
                ph = false;
            }
            else if (s)
            {
               // label_main.Text = "Информация обо всех услугах!";
                t = false;
                s = true;
                ph = false;
            }
            else
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
            dataGridView1.Visible = true;
            name_label.Visible = false;
            data_richTextBox.Visible = false;
            BackButton.Visible = false;
            buttonTourPhoto.Visible = false;
            data_panel.Visible = false;
            textBoxSearch.Visible = true;
            pictureBox1.Visible = false;
            name_label.Width = 838;
            data_richTextBox.Width = 838;

            try
            {                
                if (t)
                {
                    data = db.ExecuteQuery("SELECT tour_id AS id, name AS Название, type AS Тип, price AS Цена, duration_days AS Длительность, availability AS Доступность FROM Tour;");
                    label_main.Text = "Информация обо всех турах!";
                }
                else if (s)
                {
                    data = db.ExecuteQuery("SELECT service_id AS id, name AS Название, category AS Категория, price AS Цена, availability AS Доступность FROM Service");
                    label_main.Text = "Информация обо всех услугах!";
                }
                else if (r)
                {
                    data = db.ExecuteQuery("SELECT r.review_id AS id, r.tour_id AS id_тура, c.first_name || ' ' || c.last_name AS ФИО_клиента, r.rating AS Рейтинг, r.review_date AS Дата_отзыва FROM Review AS r JOIN Client AS c ON r.client_id = c.client_id;");
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
            dataGridView1.Visible = false;
            name_label.Visible = true;
            data_richTextBox.Visible = true;
            data_richTextBox.Height = 307;
            name_label.Width = 838;
            data_richTextBox.Width = 838;
            BackButton.Visible = true;
            data_panel.Visible = false;
            textBoxSearch.Visible = false;
            pictureBox1.Visible = false;

            string query;

            if (t)
            {
                label_main.Text = "Информация обо всех турах!";
                BackButton.Text = "Вернуться к списку туров";
                buttonTourPhoto.Visible = true;
                buttonTourPhoto.Text = $"Посмотреть фотографии тура";                

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
                                                   $"Доступность: {reader["availability"]}{Environment.NewLine}{ Environment.NewLine}"+
                                                   $"Описание тура: {Environment.NewLine}" +
                                                   $"{reader["description"]}";
                        }
                    }
                }

            }
            else if (s)
            {
                label_main.Text = "Информация обо всех услугах!";
                BackButton.Text = "Вернуться к списку услуг";
                buttonTourPhoto.Visible = false;

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
            //отзыв
            else if (r)
            {

                label_main.Text = "Честные отзывы о наших турах!!";
                BackButton.Text = "Вернуться к списку отзывов";
                buttonTourPhoto.Visible = false;

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

                            string photoPath = reader["photo"].ToString();
  
                            if (!string.IsNullOrEmpty(photoPath))
                            {
                            try
                            {
                                pictureBox1.Visible = true;

                                    data_richTextBox.Width = data_richTextBox.Width/2-10;

                                    pictureBox1.Location = new Point(data_richTextBox.Right + 20, name_label.Top); //расположение

                                    pictureBox1.Size = new Size(data_richTextBox.Width, data_richTextBox.Height+name_label.Height-4); 
                                    name_label.Width = name_label.Width /2-10;
                           

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
                                pictureBox.MouseHover += (sender, e) => {
                                    ToolTip tooltip = new ToolTip();
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
  
            filterExpression = t ?
           $"Convert(id, 'System.String') LIKE '%{searchText}%' OR Convert(Цена, 'System.String') LIKE '%{searchText}%' OR Convert(Длительность, 'System.String') LIKE '%{searchText}%' OR Название LIKE '%{searchText}%' OR Тип LIKE '%{searchText}%' OR Доступность LIKE '%{searchText}%'" :
           s ?// обаботка услуг
           $"Convert(id, 'System.String') LIKE '%{searchText}%' OR Convert(Цена, 'System.String') LIKE '%{searchText}%' OR Название LIKE '%{searchText}%' OR Convert(Категория, 'System.String') LIKE '%{searchText}%' OR Доступность LIKE '%{searchText}%'" :
           r ?  // Обработка отзывов
            $" Convert(id, 'System.String') LIKE '%{searchText}%' OR Convert(id_тура, 'System.String') LIKE '%{searchText}%' OR Convert(ФИО_клиента, 'System.String') LIKE '%{searchText}%' OR Convert(Дата_отзыва, 'System.String') LIKE '%{searchText}%' OR Convert(Рейтинг, 'System.String') LIKE '%{searchText}%'" :
      "";
            return filterExpression;
        }
        private void button_MouseHover(object sender, EventArgs e)
        {
           BackButton.BackColor = Color.FromArgb(153, 180, 209);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
            Console.WriteLine(textBoxSearch);
        }

    }
}
