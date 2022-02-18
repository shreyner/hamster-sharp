using System.ComponentModel;

namespace Timesheets.DB.Entities;

public class Employee : BaseEntity
{
        [DefaultValue(false)]
        public bool isDeleted { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
}
