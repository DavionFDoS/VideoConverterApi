using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum AudioCodecs
{
    [EnumMember(Value = "aac")]
    AAC,
    [EnumMember(Value = "libmp3lame")]
    LAME,
    [EnumMember(Value = "libopus")]
    Libopus,
    [EnumMember(Value = "ac3")]
    AC3,
    [EnumMember(Value = "mp3")]
    MP3,
    [EnumMember(Value = "opus")]
    Opus,
    [EnumMember(Value = "vorbis")]
    Vorbis,
    [EnumMember(Value = "pcm_s16le")]
    pcm_s16le,
    [EnumMember(Value = "pcm_s24le")]
    pcm_s24le,
    [EnumMember(Value = "copy")]
    Copy,
    [EnumMember(Value = null)]
    None
}
