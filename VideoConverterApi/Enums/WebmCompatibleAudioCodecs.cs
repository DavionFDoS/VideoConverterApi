using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum WebmCompatibleAudioCodecs
{
    [EnumMember(Value = "libopus")]
    Libopus,
    [EnumMember(Value = "vorbis")]
    Vorbis
}
