namespace Timesheets.Web.DTOs;

public class CreatePersonDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public int Age { get; set; }
}