namespace VideoConverterApi.Models;

public class CropVideoArguments
{
    public string? InputFileName { get; set; }
    public int Height { get; set;}
    public int Width { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

}
