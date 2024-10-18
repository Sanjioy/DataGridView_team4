using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DataGridView_team4.Contracts.Models;

namespace DataGridView_team4.Forms
{
    public partial class TourForm : Form
    {
        private Tours currentTour;

        public TourForm(Tours currentTour = null)
        {
            InitializeComponent();

            if (currentTour != null)
            {
                this.currentTour = new Tours
                {
                    Id = currentTour.Id,
                    AdditionalFees = currentTour.AdditionalFees,
                    DepartureDate = currentTour.DepartureDate,
                    Destination = currentTour.Destination,
                    HasWiFi = currentTour.HasWiFi,
                    Nights = currentTour.Nights,
                    NumberOfPeople = currentTour.NumberOfPeople,
                    PricePerPerson = currentTour.PricePerPerson,
                };
            }
            else
            {
                this.currentTour = DataGen.CreateTour();
            }
        }

        public Tours EditableTour { get => currentTour; set => currentTour = value; }

        private void TourForm_Load(object sender, EventArgs e)
        {
            SetupForm();
        }

        // Настройка формы в зависимости от типа операции
        private void SetupForm()
        {
            // Заполнение списка направлений
            foreach (var item in Enum.GetValues(typeof(Destination)))
            {
                cmbxDirection.Items.Add(item);
            }

            // Привязка данных к элементам управления
            cmbxDirection.AddBinding(t => t.SelectedItem, currentTour, s => s.Destination);
            dtmDeparture.AddBinding(t => t.Value, currentTour, s => s.DepartureDate);
            numNights.AddBinding(t => t.Value, currentTour, s => s.Nights, errorProvider1);
            numSumPers.AddBinding(t => t.Value, currentTour, s => s.PricePerPerson);
            numCountPers.AddBinding(t => t.Value, currentTour, s => s.NumberOfPeople);
            cbxWIFI.AddBinding(t => t.Checked, currentTour, s => s.HasWiFi);
            numSumExtra.AddBinding(t => t.Value, currentTour, s => s.AdditionalFees);
        }

        private void cmbxDirection_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Destination)(sender as ComboBox).Items[e.Index];
                e.Graphics.DrawString(value.GetDisplayValue(),
                   e.Font,
                   new SolidBrush(e.ForeColor),
                   e.Bounds.X + 20,
                   e.Bounds.Y);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
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
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool HasValidationErrors()
        {
            var context = new ValidationContext(currentTour);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(currentTour, context, results, true);

            foreach (var result in results)
            {
                Debug.WriteLine($"Ошибка: {result.ErrorMessage}");
            }

            return !isValid;
        }
    }
}
