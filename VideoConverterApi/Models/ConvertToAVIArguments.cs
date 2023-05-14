using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class ConvertToAVIArguments : ConvertationBaseArguments
{
    public AVICompatibleVideoCodecs AVICompatibleVideoCodecs { get; set; }
    public AVICompatibleAudioCodecs AVICompatibleAudioCodecs { get; set; }
}
