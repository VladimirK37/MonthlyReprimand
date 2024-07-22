using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MonthlyReprimand.Models.Request;
public class DeleteEmployeeRequest
{
    /// <summary>
    /// Номер пропуска
    /// </summary>
    [DisplayName("Id")]
    [Required(AllowEmptyStrings = false)]
    public int Id { get; set; }
}
