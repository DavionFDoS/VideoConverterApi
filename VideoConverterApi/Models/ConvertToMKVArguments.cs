using VideoConverterApi.Models;
using VideoConverterApi.Enums;

namespace VideoConverterApi.Modelsж
{
    public class ConvertToMKVArguments : ConvertationBaseArguments
    {
        private int crf;
        public int? Crf { get { return crf; } set { if (value > 51) crf = 51; } }
        public MKVCompatibleVideoCodecs MKVCompatibleVideoCodecs { get; set; }
        public MKVCompatibleAudioCodecs MKVCompatibleAudioCodecs { get; set; }
    }
}
