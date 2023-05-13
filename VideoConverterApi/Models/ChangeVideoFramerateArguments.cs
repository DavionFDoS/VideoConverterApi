namespace VideoConverterApi.Models;

public class ChangeVideoFramerateArguments : InputFileArguments
{
    public int DesiredFramerate { get; set; }
}
