using System;
using System.Collections.Generic;

namespace AIScheduleUI5.DAL.Entities
{
    public class University
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }

        public virtual ICollection<Major> Majors { get; set; } = new List<Major>();
        public virtual ICollection<StudyData> StudyData { get; set; } = new List<StudyData>();
    }
}
