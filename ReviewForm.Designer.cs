namespace COURSACH_APP_WITH_SQL
{
    partial class ReviewForm
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
            this.photoReview = new System.Windows.Forms.TextBox();
            this.buttonEditAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textReview = new System.Windows.Forms.TextBox();
            this.ratingReview = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tourReview = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clientReview = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.idReview = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateReview = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ratingReview)).BeginInit();
            this.SuspendLayout();
            // 
            // photoReview
            // 
            this.photoReview.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.photoReview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.photoReview.Location = new System.Drawing.Point(290, 140);
            this.photoReview.Multiline = true;
            this.photoReview.Name = "photoReview";
            this.photoReview.Size = new System.Drawing.Size(508, 44);
            this.photoReview.TabIndex = 3;
            this.photoReview.Click += new System.EventHandler(this.photoReview_Click);
            // 
            // buttonEditAdd
            // 
            this.buttonEditAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonEditAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonEditAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonEditAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonEditAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAdd.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.buttonEditAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.buttonEditAdd.Location = new System.Drawing.Point(290, 423);
            this.buttonEditAdd.Name = "buttonEditAdd";
            this.buttonEditAdd.Size = new System.Drawing.Size(508, 61);
            this.buttonEditAdd.TabIndex = 6;
            this.buttonEditAdd.Text = "Изменить";
            this.buttonEditAdd.UseVisualStyleBackColor = false;
            this.buttonEditAdd.Click += new System.EventHandler(this.buttonEditReview_Click);
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
            this.buttonCancel.Location = new System.Drawing.Point(15, 423);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(207, 61);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(290, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фото:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(290, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "Текст отзыва:";
            // 
            // textReview
            // 
            this.textReview.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textReview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.textReview.Location = new System.Drawing.Point(290, 234);
            this.textReview.Multiline = true;
            this.textReview.Name = "textReview";
            this.textReview.Size = new System.Drawing.Size(508, 137);
            this.textReview.TabIndex = 9;
            // 
            // ratingReview
            // 
            this.ratingReview.Font = new System.Drawing.Font("Constantia", 18F);
            this.ratingReview.Location = new System.Drawing.Point(290, 45);
            this.ratingReview.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ratingReview.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ratingReview.Name = "ratingReview";
            this.ratingReview.Size = new System.Drawing.Size(160, 44);
            this.ratingReview.TabIndex = 10;
            this.ratingReview.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(290, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 38);
            this.label2.TabIndex = 11;
            this.label2.Text = "Рейтинг:";
            // 
            // tourReview
            // 
            this.tourReview.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tourReview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.tourReview.Location = new System.Drawing.Point(15, 234);
            this.tourReview.Multiline = true;
            this.tourReview.Name = "tourReview";
            this.tourReview.Size = new System.Drawing.Size(207, 44);
            this.tourReview.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(15, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 38);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID тура:";
            // 
            // clientReview
            // 
            this.clientReview.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientReview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.clientReview.Location = new System.Drawing.Point(15, 140);
            this.clientReview.Multiline = true;
            this.clientReview.Name = "clientReview";
            this.clientReview.Size = new System.Drawing.Size(207, 44);
            this.clientReview.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(15, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 38);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID клиента:";
            // 
            // idReview
            // 
            this.idReview.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idReview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.idReview.Location = new System.Drawing.Point(15, 45);
            this.idReview.Multiline = true;
            this.idReview.Name = "idReview";
            this.idReview.Size = new System.Drawing.Size(207, 44);
            this.idReview.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 38);
            this.label6.TabIndex = 16;
            this.label6.Text = "ID отзыва:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(15, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 38);
            this.label7.TabIndex = 18;
            this.label7.Text = "Дата:";
            // 
            // dateReview
            // 
            this.dateReview.CalendarFont = new System.Drawing.Font("Constantia", 10F);
            this.dateReview.Font = new System.Drawing.Font("Constantia", 18F);
            this.dateReview.Location = new System.Drawing.Point(15, 327);
            this.dateReview.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.dateReview.Name = "dateReview";
            this.dateReview.Size = new System.Drawing.Size(207, 44);
            this.dateReview.TabIndex = 40;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(822, 505);
            this.Controls.Add(this.dateReview);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.idReview);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clientReview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tourReview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ratingReview);
            this.Controls.Add(this.textReview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonEditAdd);
            this.Controls.Add(this.photoReview);
            this.Controls.Add(this.label1);
            this.Name = "ReviewForm";
            this.Text = "editReviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.ratingReview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox photoReview;
        private System.Windows.Forms.Button buttonEditAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textReview;
        private System.Windows.Forms.NumericUpDown ratingReview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tourReview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox clientReview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox idReview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateReview;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}