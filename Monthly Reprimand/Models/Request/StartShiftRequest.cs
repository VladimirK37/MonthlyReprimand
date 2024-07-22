using System.ComponentModel;

namespace MonthlyReprimand.Models.Request;
public class StartShiftRequest
{
    /// <summary>
    ///  Номер пропуска
    /// </summary>
    [DisplayName("Id")]
    public int Id { get; set; }

    /// <summary>
    /// Начало смены
    /// </summary>
    [DisplayName("Start Shift")]
    public DateTime StartShift { get; set; }
}
