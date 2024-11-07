using System.ComponentModel;

namespace DataGridView_team4.Standart.Contracts.Models
{
    /// <summary>
    /// Перечисление доступных локаций для поездок
    /// </summary>
    public enum Location
    {
        [Description("США")]
        USA = 1,

        [Description("Голландия")]
        Netherlands = 2,

        [Description("Китай")]
        China = 3,

        [Description("Канада")]
        Canada = 4,

        [Description("Австралия")]
        Australia = 5
    }
}
