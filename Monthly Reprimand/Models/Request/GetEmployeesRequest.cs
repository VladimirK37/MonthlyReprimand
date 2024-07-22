using System.ComponentModel;

namespace MonthlyReprimand.Models.Request;
public class GetEmployeesRequest
{
    /// <summary>
    /// Название должности сотрудника
    /// </summary>
    [DisplayName("Position Name")]
    public string? PositionName { get; set; }
}
