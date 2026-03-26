using System;
using System.Collections.Generic;

namespace AIScheduleUI5.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //public string? Salt { get; set; }

        public virtual ICollection<StudyData> StudyData { get; set; } = new List<StudyData>();
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
