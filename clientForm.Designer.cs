using System.Drawing;

namespace COURSACH_APP_WITH_SQL
{
    partial class clientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

        }

        
        private void InitializeComponent()
        {
            this.label_main = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name_label = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.buttonTours = new System.Windows.Forms.Button();
            this.buttonServices = new System.Windows.Forms.Button();
            this.buttonReviews = new System.Windows.Forms.Button();
            this.buttonTourPhoto = new System.Windows.Forms.Button();
            this.data_panel = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.data_richTextBox = new System.Windows.Forms.RichTextBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.client_info = new System.Windows.Forms.PictureBox();
            this.buttonAddBookingServiceReview = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.client_info)).BeginInit();
            this.SuspendLayout();
            // 
            // label_main
            // 
            this.label_main.BackColor = System.Drawing.Color.Transparent;
            this.label_main.Font = new System.Drawing.Font("Constantia", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_main.Location = new System.Drawing.Point(-5, 101);
            this.label_main.Name = "label_main";
            this.label_main.Size = new System.Drawing.Size(1527, 73);
            this.label_main.TabIndex = 1;
            this.label_main.Text = "Информация обо всех турах!";
            this.label_main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 244);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1434, 426);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Visible = false;
            // 
            // name_label
            // 
            this.name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.name_label.Font = new System.Drawing.Font("Constantia", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name_label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.name_label.Location = new System.Drawing.Point(204, 189);
            this.name_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(1116, 59);
            this.name_label.TabIndex = 3;
            this.name_label.Text = "name_label";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name_label.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.BackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.BackButton.Location = new System.Drawing.Point(488, 766);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(475, 43);
            this.BackButton.TabIndex = 7;
            this.BackButton.Text = "Вернуться к списку туров";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            this.BackButton.MouseHover += new System.EventHandler(this.buttons_MouseHover);
            // 
            // buttonTours
            // 
            this.buttonTours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTours.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonTours.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTours.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonTours.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonTours.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonTours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTours.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonTours.Location = new System.Drawing.Point(0, 2);
            this.buttonTours.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTours.Name = "buttonTours";
            this.buttonTours.Size = new System.Drawing.Size(150, 39);
            this.buttonTours.TabIndex = 11;
            this.buttonTours.Text = "Туры";
            this.buttonTours.UseVisualStyleBackColor = false;
            this.buttonTours.Click += new System.EventHandler(this.buttonTours_Click);
            this.buttonTours.MouseHover += new System.EventHandler(this.buttons_MouseHover);
            // 
            // buttonServices
            // 
            this.buttonServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonServices.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonServices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonServices.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonServices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonServices.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonServices.Location = new System.Drawing.Point(168, 2);
            this.buttonServices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(150, 39);
            this.buttonServices.TabIndex = 12;
            this.buttonServices.Text = "Услуги";
            this.buttonServices.UseVisualStyleBackColor = false;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            this.buttonServices.MouseHover += new System.EventHandler(this.buttons_MouseHover);
            // 
            // buttonReviews
            // 
            this.buttonReviews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReviews.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonReviews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReviews.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonReviews.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonReviews.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReviews.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReviews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonReviews.Location = new System.Drawing.Point(337, 2);
            this.buttonReviews.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReviews.Name = "buttonReviews";
            this.buttonReviews.Size = new System.Drawing.Size(150, 39);
            this.buttonReviews.TabIndex = 13;
            this.buttonReviews.Text = "Отзывы";
            this.buttonReviews.UseVisualStyleBackColor = false;
            this.buttonReviews.Click += new System.EventHandler(this.buttonReviews_Click);
            this.buttonReviews.MouseHover += new System.EventHandler(this.buttons_MouseHover);
            // 
            // buttonTourPhoto
            // 
            this.buttonTourPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTourPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.buttonTourPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTourPhoto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonTourPhoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonTourPhoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonTourPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTourPhoto.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTourPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonTourPhoto.Location = new System.Drawing.Point(407, 696);
            this.buttonTourPhoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTourPhoto.Name = "buttonTourPhoto";
            this.buttonTourPhoto.Size = new System.Drawing.Size(556, 45);
            this.buttonTourPhoto.TabIndex = 14;
            this.buttonTourPhoto.Text = "Посмотреть фотографии тура";
            this.buttonTourPhoto.UseVisualStyleBackColor = false;
            this.buttonTourPhoto.Visible = false;
            this.buttonTourPhoto.Click += new System.EventHandler(this.buttonTourPhoto_Click);
            this.buttonTourPhoto.MouseHover += new System.EventHandler(this.buttons_MouseHover);
            // 
            // data_panel
            // 
            this.data_panel.AutoScroll = true;
            this.data_panel.AutoSize = true;
            this.data_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.data_panel.Location = new System.Drawing.Point(204, 189);
            this.data_panel.Name = "data_panel";
            this.data_panel.Size = new System.Drawing.Size(1116, 415);
            this.data_panel.TabIndex = 15;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonDelete.Location = new System.Drawing.Point(1231, 114);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(213, 45);
            this.buttonDelete.TabIndex = 23;
            this.buttonDelete.Text = "Изменить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Visible = false;
            this.buttonDelete.MouseHover += new System.EventHandler(this.buttons_MouseHover);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.buttonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonEdit.Location = new System.Drawing.Point(888, 114);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(213, 45);
            this.buttonEdit.TabIndex = 22;
            this.buttonEdit.Text = "Удалить";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Visible = false;
            this.buttonEdit.MouseHover += new System.EventHandler(this.buttons_MouseHover);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxSearch.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSearch.Location = new System.Drawing.Point(624, 203);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(259, 26);
            this.textBoxSearch.TabIndex = 16;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(77, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // data_richTextBox
            // 
            this.data_richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_richTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data_richTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.data_richTextBox.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.data_richTextBox.Location = new System.Drawing.Point(204, 244);
            this.data_richTextBox.Name = "data_richTextBox";
            this.data_richTextBox.ReadOnly = true;
            this.data_richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.data_richTextBox.Size = new System.Drawing.Size(1116, 346);
            this.data_richTextBox.TabIndex = 19;
            this.data_richTextBox.Text = "data_richTextBox";
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.client_info);
            this.panelContainer.Controls.Add(this.buttonReviews);
            this.panelContainer.Controls.Add(this.buttonTours);
            this.panelContainer.Controls.Add(this.buttonServices);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1515, 81);
            this.panelContainer.TabIndex = 21;
            // 
            // client_info
            // 
            this.client_info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.client_info.Image = global::COURSACH_APP_WITH_SQL.Properties.Resources.user;
            this.client_info.Location = new System.Drawing.Point(14, 22);
            this.client_info.Name = "client_info";
            this.client_info.Size = new System.Drawing.Size(45, 40);
            this.client_info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.client_info.TabIndex = 22;
            this.client_info.TabStop = false;
            this.client_info.Click += new System.EventHandler(this.client_info_Click);
            // 
            // buttonAddBookingServiceReview
            // 
            this.buttonAddBookingServiceReview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddBookingServiceReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.buttonAddBookingServiceReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddBookingServiceReview.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonAddBookingServiceReview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonAddBookingServiceReview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonAddBookingServiceReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddBookingServiceReview.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddBookingServiceReview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonAddBookingServiceReview.Location = new System.Drawing.Point(407, 625);
            this.buttonAddBookingServiceReview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddBookingServiceReview.Name = "buttonAddBookingServiceReview";
            this.buttonAddBookingServiceReview.Size = new System.Drawing.Size(414, 45);
            this.buttonAddBookingServiceReview.TabIndex = 24;
            this.buttonAddBookingServiceReview.Text = "Сделать запрос на услугу";
            this.buttonAddBookingServiceReview.UseVisualStyleBackColor = false;
            this.buttonAddBookingServiceReview.Visible = false;
            this.buttonAddBookingServiceReview.Click += new System.EventHandler(this.buttonAddBookingServiceReview_Click);
            // 
            // buttonPay
            // 
            this.buttonPay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.buttonPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonPay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPay.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonPay.Location = new System.Drawing.Point(878, 647);
            this.buttonPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(242, 45);
            this.buttonPay.TabIndex = 25;
            this.buttonPay.Text = "Оплатить";
            this.buttonPay.UseVisualStyleBackColor = false;
            this.buttonPay.Visible = false;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonCancel.Location = new System.Drawing.Point(888, 705);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(242, 45);
            this.buttonCancel.TabIndex = 26;
            this.buttonCancel.Text = "Отказаться";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1515, 800);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.buttonAddBookingServiceReview);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.buttonTourPhoto);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label_main);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.data_richTextBox);
            this.Controls.Add(this.data_panel);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1515, 800);
            this.Name = "clientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "clientForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.client_info)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button buttonReviews;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label_main;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonTours;
        private System.Windows.Forms.Button buttonServices;
        private System.Windows.Forms.Button buttonTourPhoto;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.RichTextBox data_richTextBox;
        private System.Windows.Forms.Panel data_panel;
        private System.Windows.Forms.PictureBox client_info;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddBookingServiceReview;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonCancel;
    }
}