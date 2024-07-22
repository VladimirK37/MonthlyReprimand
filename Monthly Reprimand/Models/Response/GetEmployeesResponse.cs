using MonthlyReprimand.Data.Entities;

namespace MonthlyReprimand.Models.Response;
public class GetEmployeesResponse
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
    /// Смены
    /// </summary>
    public List<ShiftResponse> Shifts { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    public Position Position { get; set; }

    /// <summary>
    /// Замечание сотруднику
    /// </summary>
    public int ReprimandCount { get; set; }
}
