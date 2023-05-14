using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum AVICompatibleAudioCodecs
{
    [EnumMember(Value = "mp3")]
    MP3,
    [EnumMember(Value = "pcm_s16le")]
    pcm_s16le,
    [EnumMember(Value = "libmp3lame")]
    LAME
}
