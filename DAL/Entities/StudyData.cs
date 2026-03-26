using System;

namespace AIScheduleUI5.DAL.Entities
{
    public class StudyData
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid UniId { get; set; }
        public Guid MajorId { get; set; }
        public int Semester { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual University University { get; set; } = null!;
        public virtual Major Major { get; set; } = null!;
    }
}
