using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class CommandArguments
{
    public string? InputFileName { get; set; }
    public string? VideoBitrate { get; set; }
    public string? AudioBitrate { get; set; }
    public string? Crf { get; set; }
    public Presets Preset { get; set; }
    public AudioCodecs AudioCodec { get; set; }
    public VideoCodecs VideoCodec { get; set; }
}
