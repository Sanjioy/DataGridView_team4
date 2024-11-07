using DataGridView_team4.Standart.Contracts.Models;

namespace DataGridView_team4
{
    public static class Editor
    {
        public static Trip Validation(Validation currentTrip)
        {
            return new Trip
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

        public static Validation Validate(Trip currentTrip)
        {
            return new Validation
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
    }
}
