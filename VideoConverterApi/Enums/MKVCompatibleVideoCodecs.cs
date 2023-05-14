using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum MKVCompatibleVideoCodecs
{
    [EnumMember(Value = "libx264")]
    H264,
    [EnumMember(Value = "libx265")]
    H265,
    [EnumMember(Value = "libvpx-vp9")]
    VP9,
    [EnumMember(Value = "mpeg2video")]
    MPEG2,
    [EnumMember(Value = "mpeg4")]
    MPEG4,
    [EnumMember(Value = "mjpeg")]
    MJPEG
}
