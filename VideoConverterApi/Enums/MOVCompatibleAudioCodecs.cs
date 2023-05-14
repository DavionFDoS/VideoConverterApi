using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum MOVCompatibleAudioCodecs
{
    [EnumMember(Value = "aac")]
    AAC,
    [EnumMember(Value = "mp3")]
    MP3,
    [EnumMember(Value = "alac")]
    ALAC,
    [EnumMember(Value = "pcm_s24le")]
    pcm_s24le
}
