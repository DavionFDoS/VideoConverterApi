using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum AudioCodecs
{
    [EnumMember(Value = "aac")]
    AAC,
    [EnumMember(Value = "ac3")]
    AC3,
    [EnumMember(Value = "mp3")]
    MP3,
    [EnumMember(Value = "opus")]
    Opus,
    [EnumMember(Value = "vorbis")]
    Vorbis,
    [EnumMember(Value = "copy")]
    Copy
}
