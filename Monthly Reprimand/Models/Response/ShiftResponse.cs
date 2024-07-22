namespace MonthlyReprimand.Models.Response;
public class ShiftResponse
{
    /// <summary>
    /// Идентификатор смены
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Начало работы смены
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Конец работы смены
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Количество часов смены 
    /// </summary>
    public double HoursWorked { get; set; }

    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public int EmployeeId { get; set; }
}
