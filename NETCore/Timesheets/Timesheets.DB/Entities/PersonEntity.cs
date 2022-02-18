namespace Timesheets.DB.Entities;

public class PersonEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public int Age { get; set; }
}
