using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum MP4CompatibleAudioCodecs
{
    [EnumMember(Value = "aac")]
    AAC,
    [EnumMember(Value = "mp3")]
    MP3
}
