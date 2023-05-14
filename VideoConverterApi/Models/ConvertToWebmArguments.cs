using VideoConverterApi.Enums;
namespace VideoConverterApi.Models;


public class ConvertToWebmArguments : ConvertationBaseArguments
{
    public WebmCompatibleVideoCodecs WebmCompatibleVideoCodecs { get; set; }
    public WebmCompatibleAudioCodecs WebmCompatibleAudioCodecs { get; set; }
}
