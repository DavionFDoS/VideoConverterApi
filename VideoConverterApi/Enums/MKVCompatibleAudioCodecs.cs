using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum MKVCompatibleAudioCodecs
{
    [EnumMember(Value = "aac")]
    AAC,
    [EnumMember(Value = "mp3")]
    MP3,
    [EnumMember(Value = "vorbis")]
    Vorbis,
    [EnumMember(Value = "alac")]
    ALAC
}
