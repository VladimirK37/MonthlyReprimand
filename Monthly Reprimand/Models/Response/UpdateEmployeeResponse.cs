namespace MonthlyReprimand.Models.Response;
public class UpdateEmployeeResponse
{
    /// <summary>
    /// Номер пропуска
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public string PositionName { get; set; }
}
