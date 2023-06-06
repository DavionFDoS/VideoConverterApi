namespace VideoConverterApi.Models;

public class ExtractSingleFrameArguments : InputFileArguments
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }
}
