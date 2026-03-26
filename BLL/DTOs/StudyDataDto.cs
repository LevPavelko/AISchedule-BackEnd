using System;

namespace AIScheduleUI5.BLL.DTOs;

public class StudyDataDto
{
    public Guid?Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UniId { get; set; }
    public UniversityDto? University { get; set; }
    public Guid MajorId { get; set; }
    public MajorDto? Major { get; set; }
    public int Semester { get; set; }
}
