using System.ComponentModel;

namespace DataGridView_team4.Contracts.Models
{
    /// <summary>
    /// Направления для туров
    /// </summary>
    public enum Destination
    {
        [Description("США")]
        USA = 1,

        [Description("Голландия")]
        Goland = 2,

        [Description("Китай")]
        China = 3,

        [Description("Канада")]
        Canade = 4,

        [Description("Австралия")]
        Australia = 5
    }
}
