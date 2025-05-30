namespace COURSACH_APP_WITH_SQL
{
    partial class serviceForm
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
            this.availService = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryService = new System.Windows.Forms.ComboBox();
            this.idService = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nameService = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.priceService = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionService = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // availService
            // 
            this.availService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.availService.Font = new System.Drawing.Font("Constantia", 18F);
            this.availService.FormattingEnabled = true;
            this.availService.Location = new System.Drawing.Point(4, 144);
            this.availService.Name = "availService";
            this.availService.Size = new System.Drawing.Size(244, 45);
            this.availService.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 38);
            this.label2.TabIndex = 76;
            this.label2.Text = "Доступность:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 38);
            this.label1.TabIndex = 74;
            this.label1.Text = "Цена:";
            // 
            // categoryService
            // 
            this.categoryService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryService.Font = new System.Drawing.Font("Constantia", 18F);
            this.categoryService.FormattingEnabled = true;
            this.categoryService.Location = new System.Drawing.Point(312, 144);
            this.categoryService.Name = "categoryService";
            this.categoryService.Size = new System.Drawing.Size(379, 45);
            this.categoryService.TabIndex = 73;
            // 
            // idService
            // 
            this.idService.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.idService.Location = new System.Drawing.Point(4, 46);
            this.idService.Multiline = true;
            this.idService.Name = "idService";
            this.idService.Size = new System.Drawing.Size(244, 44);
            this.idService.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 38);
            this.label6.TabIndex = 70;
            this.label6.Text = "ID услуги:";
            // 
            // nameService
            // 
            this.nameService.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.nameService.Location = new System.Drawing.Point(310, 46);
            this.nameService.Multiline = true;
            this.nameService.Name = "nameService";
            this.nameService.Size = new System.Drawing.Size(692, 44);
            this.nameService.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(312, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 38);
            this.label5.TabIndex = 68;
            this.label5.Text = "Название:";
            // 
            // priceService
            // 
            this.priceService.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.priceService.Location = new System.Drawing.Point(4, 240);
            this.priceService.Multiline = true;
            this.priceService.Name = "priceService";
            this.priceService.Size = new System.Drawing.Size(244, 44);
            this.priceService.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(312, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 38);
            this.label4.TabIndex = 66;
            this.label4.Text = "Категория:";
            // 
            // descriptionService
            // 
            this.descriptionService.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(5)))), ((int)(((byte)(46)))));
            this.descriptionService.Location = new System.Drawing.Point(310, 240);
            this.descriptionService.Multiline = true;
            this.descriptionService.Name = "descriptionService";
            this.descriptionService.Size = new System.Drawing.Size(692, 146);
            this.descriptionService.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 18.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(312, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 38);
            this.label3.TabIndex = 64;
            this.label3.Text = "Описание:";
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
            this.buttonCancel.Location = new System.Drawing.Point(4, 424);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(244, 61);
            this.buttonCancel.TabIndex = 63;
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
            this.buttonAdd.Location = new System.Drawing.Point(312, 424);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(379, 61);
            this.buttonAdd.TabIndex = 62;
            this.buttonAdd.Text = "Изменить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // serviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1030, 511);
            this.Controls.Add(this.availService);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryService);
            this.Controls.Add(this.idService);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nameService);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.priceService);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.descriptionService);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Name = "serviceForm";
            this.Text = "serviceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox availService;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryService;
        private System.Windows.Forms.TextBox idService;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nameService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox priceService;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionService;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
    }
}