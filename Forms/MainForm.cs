using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridView_team4.Tour.Manager;
using DataGridView_team4.Contracts.Models;
using DataGridView_team4.Forms;

namespace DataGridView_team4
{
    public partial class MainForm : Form
    {
        BindingSource bindingSource;
        private TourManager tourManager;

        public MainForm(TourManager tourManager)
        {
            InitializeComponent();
            this.tourManager = tourManager;

            bindingSource = new BindingSource();

            dataGridView1.DataSource = bindingSource;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = await tourManager.GetAllToursAsync();
            dataGridView1.Columns["Id"].Visible = false;
            await SetStats();
        }

        private async void BtnAddTour_Click(object sender, EventArgs e)
        {
            var addForm = new TourForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await tourManager.AddTourAsync(addForm.EditableTour);
                bindingSource.ResetBindings(false);
                await SetStats();
            }
        }

        private async void BtnEditTour_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var data = (Tours)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                var editForm = new TourForm(data);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await tourManager.EditTourAsync(editForm.EditableTour);
                    bindingSource.ResetBindings(false);
                    await SetStats();
                }
            }
        }

        private async void BtnRemoveTour_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var data = (Tours)dataGridView1.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Удалить {data.Destination} запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    await tourManager.DeleteTourAsync(data.Id);
                    bindingSource.ResetBindings(false);
                    await SetStats();
                };
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "WiFi")
            {
                var data = (Tours)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = data.HasWiFi ? "Да" : "Нет";
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Destination")
            {
                var data = (Tours)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = data.Destination.GetDisplayValue();
            }
        }

        public async Task SetStats()
        {
            var result = await tourManager.GetStatsAsync();
            tssTotalCount.Text = $"Общее кол-во туров: {result.TotalCountTours}";
            tssTotalSum.Text = $"Общая сумма за все туры: {result.TotalSumTours}";
            tssTotalSumDop.Text = $"Общая сумма доплат: {result.TotalSumDop}";
            tssCountDop.Text = $"Количество туров с доплатами: {result.CountToursWithDop}";
        }
    }
}
