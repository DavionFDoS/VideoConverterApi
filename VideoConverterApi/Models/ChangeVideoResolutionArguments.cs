using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class ChangeVideoResolutionArguments : InputFileArguments
{
    public Resolutions Resolution { get; set; }
}
