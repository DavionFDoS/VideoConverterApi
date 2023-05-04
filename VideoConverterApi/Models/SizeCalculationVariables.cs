using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class SizeCalculationVariables
{
    public string? VideoBitrateAsString { get; set; }
    public string? AudioBitrateAsString { get; set; }
    public double Duration { get; set; }
    public OverheadFactor OverheadFactor { get; set; }
}
