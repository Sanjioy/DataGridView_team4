namespace DataGridView_team4.Forms
{
    partial class TourForm
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxWIFI = new System.Windows.Forms.CheckBox();
            this.cmbxDirection = new System.Windows.Forms.ComboBox();
            this.dtmDeparture = new System.Windows.Forms.DateTimePicker();
            this.numNights = new System.Windows.Forms.NumericUpDown();
            this.numSumPers = new System.Windows.Forms.NumericUpDown();
            this.numCountPers = new System.Windows.Forms.NumericUpDown();
            this.numSumExtra = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSumPers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountPers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSumExtra)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 119);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(239, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Данные тура";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DataGridView_team4.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(47, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Location = new System.Drawing.Point(0, 414);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 54);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(384, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(245, 19);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Направление";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Дата вылета";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Количество ночей";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Стоимость за отдыхающего";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Количество отдыхающих";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Доплаты";
            // 
            // cbxWIFI
            // 
            this.cbxWIFI.AutoSize = true;
            this.cbxWIFI.Location = new System.Drawing.Point(47, 340);
            this.cbxWIFI.Name = "cbxWIFI";
            this.cbxWIFI.Size = new System.Drawing.Size(98, 17);
            this.cbxWIFI.TabIndex = 8;
            this.cbxWIFI.Text = "Наличие WI-FI";
            this.cbxWIFI.UseVisualStyleBackColor = true;
            // 
            // cmbxDirection
            // 
            this.cmbxDirection.FormattingEnabled = true;
            this.cmbxDirection.Location = new System.Drawing.Point(245, 132);
            this.cmbxDirection.Name = "cmbxDirection";
            this.cmbxDirection.Size = new System.Drawing.Size(214, 21);
            this.cmbxDirection.TabIndex = 9;
            this.cmbxDirection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbxDirection_DrawItem);
            // 
            // dtmDeparture
            // 
            this.dtmDeparture.Location = new System.Drawing.Point(245, 166);
            this.dtmDeparture.Name = "dtmDeparture";
            this.dtmDeparture.Size = new System.Drawing.Size(214, 20);
            this.dtmDeparture.TabIndex = 10;
            // 
            // numNights
            // 
            this.numNights.Location = new System.Drawing.Point(245, 204);
            this.numNights.Name = "numNights";
            this.numNights.Size = new System.Drawing.Size(214, 20);
            this.numNights.TabIndex = 11;
            // 
            // numSumPers
            // 
            this.numSumPers.Location = new System.Drawing.Point(245, 239);
            this.numSumPers.Name = "numSumPers";
            this.numSumPers.Size = new System.Drawing.Size(214, 20);
            this.numSumPers.TabIndex = 12;
            // 
            // numCountPers
            // 
            this.numCountPers.Location = new System.Drawing.Point(245, 272);
            this.numCountPers.Name = "numCountPers";
            this.numCountPers.Size = new System.Drawing.Size(214, 20);
            this.numCountPers.TabIndex = 13;
            // 
            // numSumExtra
            // 
            this.numSumExtra.Location = new System.Drawing.Point(245, 307);
            this.numSumExtra.Name = "numSumExtra";
            this.numSumExtra.Size = new System.Drawing.Size(214, 20);
            this.numSumExtra.TabIndex = 14;
            // 
            // TourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 468);
            this.Controls.Add(this.numSumExtra);
            this.Controls.Add(this.numCountPers);
            this.Controls.Add(this.numSumPers);
            this.Controls.Add(this.numNights);
            this.Controls.Add(this.dtmDeparture);
            this.Controls.Add(this.cmbxDirection);
            this.Controls.Add(this.cbxWIFI);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TourForm";
            this.Text = "TourForm";
            this.Load += new System.EventHandler(this.TourForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numNights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSumPers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountPers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSumExtra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numSumExtra;
        private System.Windows.Forms.NumericUpDown numCountPers;
        private System.Windows.Forms.NumericUpDown numSumPers;
        private System.Windows.Forms.NumericUpDown numNights;
        private System.Windows.Forms.DateTimePicker dtmDeparture;
        private System.Windows.Forms.ComboBox cmbxDirection;
        private System.Windows.Forms.CheckBox cbxWIFI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
    }
}