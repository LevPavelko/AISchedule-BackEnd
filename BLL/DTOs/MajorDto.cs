using System;

namespace AIScheduleUI5.BLL.DTOs;

public sealed record MajorDto
{
    public Guid Id { get; set; }
    public Guid UniId { get; set; }
    public string? Name { get; set; }
}

