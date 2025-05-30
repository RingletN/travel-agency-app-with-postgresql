namespace COURSACH_APP_WITH_SQL
{
    partial class tableClientForm
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
            this.idClient = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.emailClient = new System.Windows.Forms.TextBox();
            this.promocodeLabel = new System.Windows.Forms.Label();
            this.npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            this.dateBookingRequestLabel = new System.Windows.Forms.Label();
            this.lastNameClient = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.firstNameClient = new System.Windows.Forms.TextBox();
            this.idTourServiceLabel = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dateBookingRequestLabelStart = new System.Windows.Forms.Label();
            this.middleNameClient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passportClient = new System.Windows.Forms.TextBox();
            this.phoneClient = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // idClient
            // 
            this.idClient.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.idClient.Location = new System.Drawing.Point(8, 58);
            this.idClient.Multiline = true;
            this.idClient.Name = "idClient";
            this.idClient.Size = new System.Drawing.Size(196, 44);
            this.idClient.TabIndex = 59;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.idLabel.Location = new System.Drawing.Point(8, 16);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(196, 38);
            this.idLabel.TabIndex = 58;
            this.idLabel.Text = "ID клиента:";
            // 
            // emailClient
            // 
            this.emailClient.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.emailClient.Location = new System.Drawing.Point(356, 341);
            this.emailClient.Multiline = true;
            this.emailClient.Name = "emailClient";
            this.emailClient.Size = new System.Drawing.Size(342, 44);
            this.emailClient.TabIndex = 56;
            // 
            // promocodeLabel
            // 
            this.promocodeLabel.AutoSize = true;
            this.promocodeLabel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.promocodeLabel.Location = new System.Drawing.Point(358, 300);
            this.promocodeLabel.Name = "promocodeLabel";
            this.promocodeLabel.Size = new System.Drawing.Size(111, 38);
            this.promocodeLabel.TabIndex = 55;
            this.promocodeLabel.Text = "Email:";
            // 
            // npgsqlDataAdapter1
            // 
            this.npgsqlDataAdapter1.DeleteCommand = null;
            this.npgsqlDataAdapter1.InsertCommand = null;
            this.npgsqlDataAdapter1.SelectCommand = null;
            this.npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // dateBookingRequestLabel
            // 
            this.dateBookingRequestLabel.AutoSize = true;
            this.dateBookingRequestLabel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.dateBookingRequestLabel.Location = new System.Drawing.Point(358, 109);
            this.dateBookingRequestLabel.Name = "dateBookingRequestLabel";
            this.dateBookingRequestLabel.Size = new System.Drawing.Size(282, 38);
            this.dateBookingRequestLabel.TabIndex = 53;
            this.dateBookingRequestLabel.Text = "Номер телефона:";
            // 
            // lastNameClient
            // 
            this.lastNameClient.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastNameClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.lastNameClient.Location = new System.Drawing.Point(8, 151);
            this.lastNameClient.Multiline = true;
            this.lastNameClient.Name = "lastNameClient";
            this.lastNameClient.Size = new System.Drawing.Size(295, 44);
            this.lastNameClient.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(8, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 38);
            this.label5.TabIndex = 51;
            this.label5.Text = "Фамилия:";
            // 
            // firstNameClient
            // 
            this.firstNameClient.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstNameClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.firstNameClient.Location = new System.Drawing.Point(8, 244);
            this.firstNameClient.Multiline = true;
            this.firstNameClient.Name = "firstNameClient";
            this.firstNameClient.Size = new System.Drawing.Size(295, 44);
            this.firstNameClient.TabIndex = 50;
            // 
            // idTourServiceLabel
            // 
            this.idTourServiceLabel.AutoSize = true;
            this.idTourServiceLabel.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.idTourServiceLabel.Location = new System.Drawing.Point(8, 203);
            this.idTourServiceLabel.Name = "idTourServiceLabel";
            this.idTourServiceLabel.Size = new System.Drawing.Size(92, 38);
            this.idTourServiceLabel.TabIndex = 49;
            this.idTourServiceLabel.Text = "Имя:";
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
            this.buttonCancel.Location = new System.Drawing.Point(8, 429);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(295, 61);
            this.buttonCancel.TabIndex = 48;
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
            this.buttonAdd.Location = new System.Drawing.Point(356, 429);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(342, 61);
            this.buttonAdd.TabIndex = 47;
            this.buttonAdd.Text = "Подтвердить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dateBookingRequestLabelStart
            // 
            this.dateBookingRequestLabelStart.AutoSize = true;
            this.dateBookingRequestLabelStart.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.dateBookingRequestLabelStart.Location = new System.Drawing.Point(358, 203);
            this.dateBookingRequestLabelStart.Name = "dateBookingRequestLabelStart";
            this.dateBookingRequestLabelStart.Size = new System.Drawing.Size(157, 38);
            this.dateBookingRequestLabelStart.TabIndex = 46;
            this.dateBookingRequestLabelStart.Text = "Паспорт:";
            // 
            // middleNameClient
            // 
            this.middleNameClient.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.middleNameClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.middleNameClient.Location = new System.Drawing.Point(8, 341);
            this.middleNameClient.Multiline = true;
            this.middleNameClient.Name = "middleNameClient";
            this.middleNameClient.Size = new System.Drawing.Size(295, 44);
            this.middleNameClient.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 38);
            this.label1.TabIndex = 60;
            this.label1.Text = "Отчество:";
            // 
            // passportClient
            // 
            this.passportClient.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.passportClient.Location = new System.Drawing.Point(356, 244);
            this.passportClient.Multiline = true;
            this.passportClient.Name = "passportClient";
            this.passportClient.Size = new System.Drawing.Size(342, 44);
            this.passportClient.TabIndex = 62;
            // 
            // phoneClient
            // 
            this.phoneClient.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.phoneClient.Location = new System.Drawing.Point(356, 151);
            this.phoneClient.Multiline = true;
            this.phoneClient.Name = "phoneClient";
            this.phoneClient.Size = new System.Drawing.Size(342, 44);
            this.phoneClient.TabIndex = 63;
            // 
            // tableClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(715, 502);
            this.Controls.Add(this.phoneClient);
            this.Controls.Add(this.passportClient);
            this.Controls.Add(this.middleNameClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idClient);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.emailClient);
            this.Controls.Add(this.promocodeLabel);
            this.Controls.Add(this.dateBookingRequestLabel);
            this.Controls.Add(this.lastNameClient);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.firstNameClient);
            this.Controls.Add(this.idTourServiceLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dateBookingRequestLabelStart);
            this.Name = "tableClientForm";
            this.Text = "tableClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox idClient;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox emailClient;
        private System.Windows.Forms.Label promocodeLabel;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private System.Windows.Forms.Label dateBookingRequestLabel;
        private System.Windows.Forms.TextBox lastNameClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox firstNameClient;
        private System.Windows.Forms.Label idTourServiceLabel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label dateBookingRequestLabelStart;
        private System.Windows.Forms.TextBox middleNameClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passportClient;
        private System.Windows.Forms.TextBox phoneClient;
    }
}