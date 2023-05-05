namespace VideoConverterApi.Models;

public class AddWatermarkArguments : InputFileArguments
{
    public string? WatermarkFileName { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}
