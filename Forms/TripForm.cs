using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataGridView_team4.Standart.Contracts.Models;

namespace DataGridView_team4.Forms
{
    public partial class TripForm : Form
    {
        private Trip currentTrip;

        public TripForm(Trip currentTrip = null)
        {
            InitializeComponent();

            if (currentTrip != null)
            {
                this.currentTrip = new Trip
                {
                    TripId = currentTrip.TripId,
                    ExtraCharges = currentTrip.ExtraCharges,
                    DepartureDate = currentTrip.DepartureDate,
                    Location = currentTrip.Location,
                    WiFiAvailable = currentTrip.WiFiAvailable,
                    Nights = currentTrip.Nights,
                    ParticipantCount = currentTrip.ParticipantCount,
                    CostPerPerson = currentTrip.CostPerPerson,
                };
            }
            else
            {
                this.currentTrip = DataGen.CreateTrip();
            }
        }

        public Trip EditableTrip { get => currentTrip; set => currentTrip = value; }

        private void TourForm_Load(object sender, EventArgs e)
        {
            SetupForm();
        }

        // Настройка формы в зависимости от типа операции
        private void SetupForm()
        {
            // Заполнение списка направлений
            foreach (var item in Enum.GetValues(typeof(Location)))
            {
                cmbxLocation.Items.Add(item);
            }
            BindControlsToData();
        }

        private void BindControlsToData()
        {
            // Привязка данных к элементам управления
            cmbxLocation.BindData(t => t.SelectedItem, currentTrip, s => s.Location);
            dtmDepartureDate.BindData(t => t.Value, currentTrip, s => s.DepartureDate);
            numNightsCount.BindData(t => t.Value, currentTrip, s => s.Nights, errorProvider1);
            numPricePerPerson.BindData(t => t.Value, currentTrip, s => s.CostPerPerson);
            numPeopleCount.BindData(t => t.Value, currentTrip, s => s.ParticipantCount);
            cbxWiFi.BindData(t => t.Checked, currentTrip, s => s.WiFiAvailable);
            numExtraFees.BindData(t => t.Value, currentTrip, s => s.ExtraCharges);
        }

        private bool HasValidationErrors()
        {
            var validationContext = new ValidationContext(currentTrip);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(currentTrip, validationContext, validationResults, true);

            foreach (var result in validationResults)
            {
                Debug.WriteLine($"Ошибка: {result.ErrorMessage}");
            }

            return !isValid;
        }

        private void cmbxLocation_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Location)(sender as ComboBox).Items[e.Index];
                e.Graphics.DrawString(value.GetEnumDisplayValue(),
                   e.Font,
                   new SolidBrush(e.ForeColor),
                   e.Bounds.X + 20,
                   e.Bounds.Y);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (HasValidationErrors())
            {
                MessageBox.Show("Некоторые поля заполнены неверно. Проверьте ошибки и попробуйте снова.",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var validationContext = new ValidationContext(currentTrip);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(currentTrip, validationContext, validationResults, validateAllProperties: true);
            if (validationResults.Any())
            {
                return;
            }

            Close();
            DialogResult =
            DialogResult.OK;
        }
    }
}
