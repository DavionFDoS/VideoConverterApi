using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class ConvertToMP4Arguments : ConvertationBaseArguments
{
    private int crf;
    public int? Crf { get { return crf; } set { if (value > 51) crf = 51; } }
    public MP4CompatibleVideoCodecs MP4CompatibleVideoCodecs { get; set; }
    public MP4CompatibleAudioCodecs MP4CompatibleAudioCodecs { get; set; }

}
