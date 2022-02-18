using System.ComponentModel.DataAnnotations;

namespace Timesheets.Web.DTOs;

public class UserCreateRequest
{
    [Required]
    [MinLength(3)]
    public string FirstName { get; set; }
    
    [Required]
    [MinLength(3)]
    public string MiddleName { get; set; }
    
    [Required]
    [MinLength(3)]
    public string LastName { get; set; }
}
