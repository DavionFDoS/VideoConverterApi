using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum AVICompatibleVideoCodecs
{
    [EnumMember(Value = "libx264")]
    H264,
    [EnumMember(Value = "mpeg2video")]
    MPEG2,
    [EnumMember(Value = "mpeg4")]
    MPEG4
}
