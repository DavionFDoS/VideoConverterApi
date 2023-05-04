namespace VideoConverterApi.Models;

public class CutVideoArguments
{
    public string? InputFileName { get; set; }
    public int FromHours { get; set; }
    public int FromMinutes { get; set; }
    public int FromSeconds { get; set; }
    public int ToHours { get; set; }
    public int ToMinutes { get; set; }
    public int ToSeconds { get; set; }
}
