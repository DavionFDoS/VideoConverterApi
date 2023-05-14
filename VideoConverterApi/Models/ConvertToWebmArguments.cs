using VideoConverterApi.Enums;
namespace VideoConverterApi.Models;


public class ConvertToWebmArguments : ConvertationBaseArguments
{
    private int crf;
    public int? Crf { get { return crf; } set { if (value > 51) crf = 51; } }
    public WebmCompatibleVideoCodecs WebmCompatibleVideoCodecs { get; set; }
    public WebmCompatibleAudioCodecs WebmCompatibleAudioCodecs { get; set; }
}
