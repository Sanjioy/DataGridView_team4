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
        BindingSource tripBindingSource;
        private TripService tripManager;

        public MainForm(TripService tripManager)
        {
            InitializeComponent();
            this.tripManager = tripManager;

            tripBindingSource = new BindingSource();

            dataGridView1.DataSource = tripBindingSource;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            tripBindingSource.DataSource = await tripManager.GetAllTripsAsync();
            dataGridView1.Columns["TripId"].Visible = false;
            await UpdateStatistics();
        }

        private async void BtnAddTrip_Click(object sender, EventArgs e)
        {
            var addTripForm = new TripForm();
            if (addTripForm.ShowDialog() == DialogResult.OK)
            {
                await tripManager.AddTripAsync(addTripForm.EditableTrip);
                tripBindingSource.ResetBindings(false);
                await UpdateStatistics();
            }
        }

        private async void BtnEditTour_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedTrip = (Trip)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                var editTripForm = new TripForm(selectedTrip);
                if (editTripForm.ShowDialog() == DialogResult.OK)
                {
                    await tripManager.EditTripAsync(editTripForm.EditableTrip);
                    tripBindingSource.ResetBindings(false);
                    await UpdateStatistics();
                }
            }
        }

        private async void BtnRemoveTour_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedTrip = (Trip)dataGridView1.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Удалить поездку в {selectedTrip.Location}?", "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    await tripManager.DeleteTripAsync(selectedTrip.TripId);
                    tripBindingSource.ResetBindings(false);
                    await UpdateStatistics();
                };
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "WiFiAvailable")
            {
                var trip = (Trip)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = trip.WiFiAvailable ? "Да" : "Нет";
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Location")
            {
                var trip = (Trip)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = trip.Location.GetEnumDisplayValue();
            }
        }

        public async Task UpdateStatistics()
        {
            var stats = await tripManager.GetTripStatsAsync();
            tssTotalTrips.Text = $"Общее кол-во туров: {stats.TotalTrips}";
            tssTotalRevenue.Text = $"Общая сумма за все туры: {stats.TotalRevenue}";
            tssTotalExtras.Text = $"Общая сумма доплат: {stats.TotalExtras}";
            tssTripsWithExtras.Text = $"Количество туров с доплатами: {stats.TripsWithExtras}";
        }
    }
}
