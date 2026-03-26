using System;

namespace AIScheduleUI5.BLL.DTOs;

public class ScheduleDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? Title { get; set; }
    public string? Info { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}
