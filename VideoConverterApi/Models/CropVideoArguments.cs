namespace VideoConverterApi.Models;

public class CropVideoArguments : InputFileArguments
{
    public int Height { get; set;}
    public int Width { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

}
