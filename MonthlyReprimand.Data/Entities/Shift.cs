namespace MonthlyReprimand.Data.Entities;

/// <summary>
/// Смена
/// </summary>
public class Shift
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
    public int HoursWorked { get; set; }

    /// <summary>
    /// Индентификатор сотрудника
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Сотрудник
    /// </summary>
    public Employee Employee { get; set; }
}
