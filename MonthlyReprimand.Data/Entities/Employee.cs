namespace MonthlyReprimand.Data.Entities;
/// <summary>
/// Сотрудник
/// </summary>
public class Employee
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
    /// Должность сотудника
    /// </summary>
    public Position Position { get; set; }

    /// <summary>
    /// Список смен сотрудника
    /// </summary>
    public ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}
