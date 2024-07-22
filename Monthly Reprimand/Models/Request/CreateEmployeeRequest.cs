using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MonthlyReprimand.Models.Request;
public class CreateEmployeeRequest
{
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    [DisplayName("First Name")]
    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    [DisplayName("Last Name")]
    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; }


    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    [DisplayName("Middle Name")]
    public string MiddleName { get; set; }

    /// <summary>
    /// Название должности сотрудника
    /// </summary>
    [DisplayName("Position Name")]
    [Required(AllowEmptyStrings = false)]
    public string PositionName { get; set; }
}
