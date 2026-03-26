using System;
using System.Collections.Generic;

namespace AIScheduleUI5.DAL.Entities
{
    public class Major
    {
        public Guid Id { get; set; }
        public Guid UniId { get; set; }
        public string? Name { get; set; }

        public virtual University University { get; set; } = null!;
        public virtual ICollection<StudyData> StudyData { get; set; } = new List<StudyData>();
    }
}
