namespace COURSACH_APP_WITH_SQL
{
    partial class reportForm
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
            this.cbDetails = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cbReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDetails
            // 
            this.cbDetails.Font = new System.Drawing.Font("Constantia", 18F);
            this.cbDetails.FormattingEnabled = true;
            this.cbDetails.Location = new System.Drawing.Point(249, 137);
            this.cbDetails.Name = "cbDetails";
            this.cbDetails.Size = new System.Drawing.Size(433, 45);
            this.cbDetails.TabIndex = 0;
//            this.cbDetails.SelectedIndexChanged += new System.EventHandler(this.cbDetails_SelectedIndexChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Constantia", 18F);
            this.dtpStartDate.Location = new System.Drawing.Point(16, 338);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(325, 44);
            this.dtpStartDate.TabIndex = 1;
      //      this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Constantia", 18F);
            this.dtpEndDate.Location = new System.Drawing.Point(411, 338);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(325, 44);
            this.dtpEndDate.TabIndex = 2;
        //    this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // cbReportType
            // 
            this.cbReportType.Font = new System.Drawing.Font("Constantia", 18F);
            this.cbReportType.FormattingEnabled = true;
            this.cbReportType.Location = new System.Drawing.Point(16, 137);
            this.cbReportType.Name = "cbReportType";
            this.cbReportType.Size = new System.Drawing.Size(189, 45);
            this.cbReportType.TabIndex = 3;
            this.cbReportType.SelectedIndexChanged += new System.EventHandler(this.cbReportType_SelectedIndexChanged);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.btnGenerateReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnGenerateReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.btnGenerateReport.Location = new System.Drawing.Point(16, 437);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(720, 61);
            this.btnGenerateReport.TabIndex = 7;
            this.btnGenerateReport.Text = "Экспорт данных";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(404, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 38);
            this.label7.TabIndex = 22;
            this.label7.Text = "По:";
         //   this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(9, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 38);
            this.label6.TabIndex = 21;
            this.label6.Text = "Вид:";
         //   this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(9, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 38);
            this.label5.TabIndex = 20;
            this.label5.Text = "Период";
       //     this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(9, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 38);
            this.label4.TabIndex = 19;
            this.label4.Text = "С:";
        //    this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(242, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 38);
            this.label1.TabIndex = 23;
            this.label1.Text = "Тип тура / Категория услуги:";
       //     this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(100, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(535, 38);
            this.label2.TabIndex = 24;
            this.label2.Text = "Отчет по продажам туров и услуг!";
            // 
            // reportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(749, 510);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.cbReportType);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cbDetails);
            this.Name = "reportForm";
            this.Text = "reportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDetails;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cbReportType;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}