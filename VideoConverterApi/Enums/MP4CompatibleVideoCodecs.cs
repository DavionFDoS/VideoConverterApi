using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum MP4CompatibleVideoCodecs
{
    [EnumMember(Value = "libx264")]
    H264,
    [EnumMember(Value = "libx265")]
    H265,
    [EnumMember(Value = "mpeg4")]
    MPEG4
}
