namespace DataGridView_team4
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssTotalTrips = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTotalRevenue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTotalExtras = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTripsWithExtras = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnAddTour = new System.Windows.Forms.ToolStripButton();
            this.BtnEditTour = new System.Windows.Forms.ToolStripButton();
            this.BtnRemoveTour = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAddTour,
            this.BtnEditTour,
            this.BtnRemoveTour});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssTotalTrips,
            this.tssTotalRevenue,
            this.tssTotalExtras,
            this.tssTripsWithExtras});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssTotalTrips
            // 
            this.tssTotalTrips.Name = "tssTotalTrips";
            this.tssTotalTrips.Size = new System.Drawing.Size(79, 17);
            this.tssTotalTrips.Text = "tssTotalTrips";
            // 
            // tssTotalRevenue
            // 
            this.tssTotalRevenue.Name = "tssTotalRevenue";
            this.tssTotalRevenue.Size = new System.Drawing.Size(70, 17);
            this.tssTotalRevenue.Text = "tssTotalRevenue";
            // 
            // tssTotalExtras
            // 
            this.tssTotalExtras.Name = "tssTotalExtras";
            this.tssTotalExtras.Size = new System.Drawing.Size(92, 17);
            this.tssTotalExtras.Text = "tssTotalExtras";
            // 
            // tssTripsWithExtras
            // 
            this.tssTripsWithExtras.Name = "tssTripsWithExtras";
            this.tssTripsWithExtras.Size = new System.Drawing.Size(76, 17);
            this.tssTripsWithExtras.Text = "tssTripsWithExtras";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 403);
            this.dataGridView1.TabIndex = 2;
            // 
            // BtnAddTour
            // 
            this.BtnAddTour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAddTour.Image = global::DataGridView_team4.Properties.Resources.plus;
            this.BtnAddTour.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddTour.Name = "BtnAddTour";
            this.BtnAddTour.Size = new System.Drawing.Size(23, 22);
            this.BtnAddTour.Text = "toolStripButton1";
            this.BtnAddTour.Click += new System.EventHandler(this.BtnAddTrip_Click);
            // 
            // BtnEditTour
            // 
            this.BtnEditTour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEditTour.Image = global::DataGridView_team4.Properties.Resources.pencil;
            this.BtnEditTour.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEditTour.Name = "BtnEditTour";
            this.BtnEditTour.Size = new System.Drawing.Size(23, 22);
            this.BtnEditTour.Text = "toolStripButton2";
            this.BtnEditTour.Click += new System.EventHandler(this.BtnEditTour_Click);
            // 
            // BtnRemoveTour
            // 
            this.BtnRemoveTour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRemoveTour.Image = global::DataGridView_team4.Properties.Resources.delete;
            this.BtnRemoveTour.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRemoveTour.Name = "BtnRemoveTour";
            this.BtnRemoveTour.Size = new System.Drawing.Size(23, 22);
            this.BtnRemoveTour.Text = "toolStripButton3";
            this.BtnRemoveTour.Click += new System.EventHandler(this.BtnRemoveTour_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnAddTour;
        private System.Windows.Forms.ToolStripButton BtnEditTour;
        private System.Windows.Forms.ToolStripButton BtnRemoveTour;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssTotalTrips;
        private System.Windows.Forms.ToolStripStatusLabel tssTotalRevenue;
        private System.Windows.Forms.ToolStripStatusLabel tssTotalExtras;
        private System.Windows.Forms.ToolStripStatusLabel tssTripsWithExtras;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

