using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridView_team4.Standart.Tour.Manager;
using DataGridView_team4.Forms;
using DataGridView_team4.Standart.Contracts.Models;

namespace DataGridView_team4
{
    public partial class MainForm : Form
    {
        private readonly TripService tripService;
        private BindingSource tripBindingSource;

        public MainForm(TripService tripService)
        {
            InitializeComponent();
            this.tripService = tripService;
            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            tripBindingSource = new BindingSource();
            dataGridView1.DataSource = tripBindingSource;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadTripsAsync();
            await UpdateStatistics();
        }

        private async Task LoadTripsAsync()
        {
            tripBindingSource.DataSource = await tripService.GetAllTripsAsync();
            dataGridView1.Columns["TripId"].Visible = false;
        }

        private void RefreshTrips()
        {
            tripBindingSource.ResetBindings(false);
        }

        private async void BtnAddTrip_Click(object sender, EventArgs e)
        {
            var addTripForm = new TripForm();
            if (addTripForm.ShowDialog() == DialogResult.OK)
            {
                await tripService.AddTripAsync(addTripForm.EditableTrip);
                RefreshTrips();
                await UpdateStatistics();
            }
        }

        private async void BtnEditTrip_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedTrip = (Trip)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                var editTripForm = new TripForm(selectedTrip);
                if (editTripForm.ShowDialog() == DialogResult.OK)
                {
                    await tripService.EditTripAsync(editTripForm.EditableTrip);
                    RefreshTrips();
                    await UpdateStatistics();
                }
            }
        }

        private async void BtnRemoveTrip_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedTrip = (Trip)dataGridView1.SelectedRows[0].DataBoundItem;
                var confirmationResult = MessageBox.Show(
                    $"Удалить поездку в {selectedTrip.Location}?",
                    "Подтверждение удаления",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );
                if (confirmationResult == DialogResult.OK)
                {
                    await tripService.DeleteTripAsync(selectedTrip.TripId);
                    RefreshTrips();
                    await UpdateStatistics();
                }
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
            var stats = await tripService.GetTripStatsAsync();
            tssTotalTrips.Text = $"Общее кол-во туров: {stats.TotalTrips}";
            tssTotalRevenue.Text = $"Общая сумма за все туры: {stats.TotalRevenue}";
            tssTotalExtras.Text = $"Общая сумма доплат: {stats.TotalExtras}";
            tssTripsWithExtras.Text = $"Количество туров с доплатами: {stats.TripsWithExtras}";
        }
    }
}
