using VideoConverterApi.Models;
using VideoConverterApi.Enums;

namespace VideoConverterApi.Models
{
    public class ConvertToMKVArguments : ConvertationBaseArguments
    {
        private int crf = 22;
        public int Crf { get { return crf; } set { if (value > 51) crf = 51; else if (value < 0) crf = 0; } }
        public MKVCompatibleVideoCodecs MKVCompatibleVideoCodecs { get; set; }
        public MKVCompatibleAudioCodecs MKVCompatibleAudioCodecs { get; set; }
    }
}
