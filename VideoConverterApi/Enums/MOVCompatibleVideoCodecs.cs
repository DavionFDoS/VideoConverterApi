using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum MOVCompatibleVideoCodecs
{
    [EnumMember(Value = "libx264")]
    H264,
    [EnumMember(Value = "libx265")]
    H265,
    [EnumMember(Value = "mpeg4")]
    MPEG4,
    [EnumMember(Value = "mjpeg")]
    MJPEG,
    [EnumMember(Value = "prores")]
    ProRes,
    [EnumMember(Value = "prores_ks")]
    ProRes4444
}
