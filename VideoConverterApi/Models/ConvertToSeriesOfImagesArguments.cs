namespace VideoConverterApi.Models;

public class ConvertToSeriesOfImagesArguments : InputFileArguments
{
    public int NumberOfImages { get; set; }
    public int PerNumberOfSeconds { get; set; }
}
