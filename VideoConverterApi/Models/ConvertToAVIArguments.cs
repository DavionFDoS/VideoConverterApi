using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class ConvertToAVIArguments : ConvertationBaseArguments
{
    private int qv = 10;
    public int Qv { get { return qv; } set { if (value > 10) qv = 10; else if (value < 0) qv = 0; } }
    public AVICompatibleVideoCodecs AVICompatibleVideoCodecs { get; set; }
    public AVICompatibleAudioCodecs AVICompatibleAudioCodecs { get; set; }
}
