using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MonthlyReprimand.Models.Request;
public class UpdateEmployeeRequest
{
    /// <summary>
    ///  Номер пропуска
    /// </summary>
    [DisplayName("Id")]
    [Required(AllowEmptyStrings = false)]
    public int Id { get; set; }

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    [DisplayName("Last Name")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    [DisplayName("First Name")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    [DisplayName("Middle Name")]
    public string MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Название должности сотрудника
    /// </summary>
    [DisplayName("Position Name")]
    public string PositionName { get; set; } = string.Empty;
}
