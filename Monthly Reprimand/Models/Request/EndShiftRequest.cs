using System.ComponentModel;

namespace MonthlyReprimand.Models.Request;
public class EndShiftRequest
{
    /// <summary>
    /// Номер пропуска
    /// </summary>
    [DisplayName("Id")]
    public int Id { get; set; }

    /// <summary>
    /// Конец смены
    /// </summary>
    [DisplayName("End Shift")]
    public DateTime EndShift { get; set; }
}
