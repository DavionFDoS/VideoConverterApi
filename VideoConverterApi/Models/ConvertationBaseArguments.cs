using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class ConvertationBaseArguments : InputFileArguments
{
    public int? VideoBitrate { get; set; }
    public int? AudioBitrate { get; set; }
    public Presets Preset { get; set; }
}
