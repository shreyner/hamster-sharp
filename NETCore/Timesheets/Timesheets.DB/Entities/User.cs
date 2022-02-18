using System.ComponentModel;

namespace Timesheets.DB.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    
    [DefaultValue("")]
    public string Comment { get; set; }
    
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
    
    public Employee Employee { get; set; }
}