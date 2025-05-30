namespace COURSACH_APP_WITH_SQL
{
    partial class BookingRequestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateBookingRequestLabel = new System.Windows.Forms.Label();
            this.clientBookingRequest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tourServiceBookingRequest = new System.Windows.Forms.TextBox();
            this.idTourServiceLabel = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dateBookingRequestLabelStart = new System.Windows.Forms.Label();
            this.npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            this.dateBookingRequestStart = new System.Windows.Forms.DateTimePicker();
            this.promocodeRequest = new System.Windows.Forms.TextBox();
            this.promocodeLabel = new System.Windows.Forms.Label();
            this.dateBookingRequest = new System.Windows.Forms.DateTimePicker();
            this.idBookingService = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.statusBookingRequest = new System.Windows.Forms.ComboBox();
            this.notesBookingRequest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateBookingRequestLabel
            // 
            this.dateBookingRequestLabel.AutoSize = true;
            this.dateBookingRequestLabel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.dateBookingRequestLabel.Location = new System.Drawing.Point(275, 10);
            this.dateBookingRequestLabel.Name = "dateBookingRequestLabel";
            this.dateBookingRequestLabel.Size = new System.Drawing.Size(200, 38);
            this.dateBookingRequestLabel.TabIndex = 34;
            this.dateBookingRequestLabel.Text = "Дата брони:";
            // 
            // clientBookingRequest
            // 
            this.clientBookingRequest.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientBookingRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.clientBookingRequest.Location = new System.Drawing.Point(12, 145);
            this.clientBookingRequest.Multiline = true;
            this.clientBookingRequest.Name = "clientBookingRequest";
            this.clientBookingRequest.Size = new System.Drawing.Size(207, 44);
            this.clientBookingRequest.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 38);
            this.label5.TabIndex = 30;
            this.label5.Text = "ID клиента:";
            // 
            // tourServiceBookingRequest
            // 
            this.tourServiceBookingRequest.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tourServiceBookingRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.tourServiceBookingRequest.Location = new System.Drawing.Point(12, 238);
            this.tourServiceBookingRequest.Multiline = true;
            this.tourServiceBookingRequest.Name = "tourServiceBookingRequest";
            this.tourServiceBookingRequest.Size = new System.Drawing.Size(207, 44);
            this.tourServiceBookingRequest.TabIndex = 29;
            // 
            // idTourServiceLabel
            // 
            this.idTourServiceLabel.AutoSize = true;
            this.idTourServiceLabel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.idTourServiceLabel.Location = new System.Drawing.Point(12, 197);
            this.idTourServiceLabel.Name = "idTourServiceLabel";
            this.idTourServiceLabel.Size = new System.Drawing.Size(138, 38);
            this.idTourServiceLabel.TabIndex = 28;
            this.idTourServiceLabel.Text = "ID тура:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonCancel.Location = new System.Drawing.Point(12, 321);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(207, 61);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonAdd.Location = new System.Drawing.Point(275, 321);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(302, 61);
            this.buttonAdd.TabIndex = 22;
            this.buttonAdd.Text = "Подтвердить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dateBookingRequestLabelStart
            // 
            this.dateBookingRequestLabelStart.AutoSize = true;
            this.dateBookingRequestLabelStart.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.dateBookingRequestLabelStart.Location = new System.Drawing.Point(275, 104);
            this.dateBookingRequestLabelStart.Name = "dateBookingRequestLabelStart";
            this.dateBookingRequestLabelStart.Size = new System.Drawing.Size(286, 38);
            this.dateBookingRequestLabelStart.TabIndex = 20;
            this.dateBookingRequestLabelStart.Text = "Дата начала тура:";
            // 
            // npgsqlDataAdapter1
            // 
            this.npgsqlDataAdapter1.DeleteCommand = null;
            this.npgsqlDataAdapter1.InsertCommand = null;
            this.npgsqlDataAdapter1.SelectCommand = null;
            this.npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // dateBookingRequestStart
            // 
            this.dateBookingRequestStart.Font = new System.Drawing.Font("Constantia", 18F);
            this.dateBookingRequestStart.Location = new System.Drawing.Point(275, 145);
            this.dateBookingRequestStart.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.dateBookingRequestStart.Name = "dateBookingRequestStart";
            this.dateBookingRequestStart.Size = new System.Drawing.Size(302, 44);
            this.dateBookingRequestStart.TabIndex = 36;
            // 
            // promocodeRequest
            // 
            this.promocodeRequest.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.promocodeRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.promocodeRequest.Location = new System.Drawing.Point(275, 238);
            this.promocodeRequest.Multiline = true;
            this.promocodeRequest.Name = "promocodeRequest";
            this.promocodeRequest.Size = new System.Drawing.Size(302, 44);
            this.promocodeRequest.TabIndex = 38;
            // 
            // promocodeLabel
            // 
            this.promocodeLabel.AutoSize = true;
            this.promocodeLabel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.promocodeLabel.Location = new System.Drawing.Point(275, 197);
            this.promocodeLabel.Name = "promocodeLabel";
            this.promocodeLabel.Size = new System.Drawing.Size(183, 38);
            this.promocodeLabel.TabIndex = 37;
            this.promocodeLabel.Text = "Промокод:";
            // 
            // dateBookingRequest
            // 
            this.dateBookingRequest.CalendarFont = new System.Drawing.Font("Constantia", 10F);
            this.dateBookingRequest.Font = new System.Drawing.Font("Constantia", 18F);
            this.dateBookingRequest.Location = new System.Drawing.Point(275, 51);
            this.dateBookingRequest.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.dateBookingRequest.Name = "dateBookingRequest";
            this.dateBookingRequest.Size = new System.Drawing.Size(302, 44);
            this.dateBookingRequest.TabIndex = 39;
            // 
            // idBookingService
            // 
            this.idBookingService.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idBookingService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.idBookingService.Location = new System.Drawing.Point(12, 52);
            this.idBookingService.Multiline = true;
            this.idBookingService.Name = "idBookingService";
            this.idBookingService.Size = new System.Drawing.Size(207, 44);
            this.idBookingService.TabIndex = 41;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.idLabel.Location = new System.Drawing.Point(12, 10);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(165, 38);
            this.idLabel.TabIndex = 40;
            this.idLabel.Text = "ID брони:";
            // 
            // statusBookingRequest
            // 
            this.statusBookingRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusBookingRequest.Font = new System.Drawing.Font("Constantia", 18F);
            this.statusBookingRequest.FormattingEnabled = true;
            this.statusBookingRequest.Location = new System.Drawing.Point(626, 50);
            this.statusBookingRequest.Name = "statusBookingRequest";
            this.statusBookingRequest.Size = new System.Drawing.Size(390, 45);
            this.statusBookingRequest.TabIndex = 42;
            // 
            // notesBookingRequest
            // 
            this.notesBookingRequest.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notesBookingRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.notesBookingRequest.Location = new System.Drawing.Point(626, 145);
            this.notesBookingRequest.Multiline = true;
            this.notesBookingRequest.Name = "notesBookingRequest";
            this.notesBookingRequest.Size = new System.Drawing.Size(390, 237);
            this.notesBookingRequest.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(628, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 38);
            this.label1.TabIndex = 44;
            this.label1.Text = "Статус:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(628, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 38);
            this.label2.TabIndex = 45;
            this.label2.Text = "Примечание:";
            // 
            // BookingRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1042, 399);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notesBookingRequest);
            this.Controls.Add(this.statusBookingRequest);
            this.Controls.Add(this.idBookingService);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.dateBookingRequest);
            this.Controls.Add(this.promocodeRequest);
            this.Controls.Add(this.promocodeLabel);
            this.Controls.Add(this.dateBookingRequestStart);
            this.Controls.Add(this.dateBookingRequestLabel);
            this.Controls.Add(this.clientBookingRequest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tourServiceBookingRequest);
            this.Controls.Add(this.idTourServiceLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dateBookingRequestLabelStart);
            this.Name = "BookingRequestForm";
            this.Text = "BookingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dateBookingRequestLabel;
        private System.Windows.Forms.TextBox clientBookingRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tourServiceBookingRequest;
        private System.Windows.Forms.Label idTourServiceLabel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label dateBookingRequestLabelStart;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private System.Windows.Forms.DateTimePicker dateBookingRequestStart;
        private System.Windows.Forms.TextBox promocodeRequest;
        private System.Windows.Forms.Label promocodeLabel;
        private System.Windows.Forms.DateTimePicker dateBookingRequest;
        private System.Windows.Forms.TextBox idBookingService;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.ComboBox statusBookingRequest;
        private System.Windows.Forms.TextBox notesBookingRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}