namespace MonthlyReprimand.Data.Entities;

/// <summary>
/// Должность сотрудника
/// </summary>
public class Position
{
    /// <summary>
    /// Идентификатор должности сотрудника
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование должности сотрудника
    /// </summary>
    public string Name { get; set; }
}
