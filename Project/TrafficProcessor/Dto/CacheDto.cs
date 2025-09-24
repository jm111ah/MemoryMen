using System.ComponentModel.DataAnnotations;

namespace TrafficProcessor.Dto;

public class CacheDto
{
    public required string Key { get; set; }

    public required TimeSpan? TimeSpan { get; set; }
}