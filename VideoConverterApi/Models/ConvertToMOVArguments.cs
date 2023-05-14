using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class ConvertToMOVArguments : ConvertationBaseArguments
{
    public MOVCompatibleVideoCodecs MOVCompatibleVideoCodecs { get; set; }
    public MOVCompatibleAudioCodecs MOVCompatibleAudioCodecs { get; set; }
}
