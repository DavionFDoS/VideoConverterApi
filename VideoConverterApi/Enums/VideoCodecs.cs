using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum VideoCodecs
{
    [EnumMember(Value = "libx264")]
    H264,
    [EnumMember(Value = "libx265")]
    H265,
    [EnumMember(Value = "libvpx")]
    VP8,
    [EnumMember(Value = "libvpx-vp9")]
    VP9,
    [EnumMember(Value = "prores")]
    ProRes,
    [EnumMember(Value = "prores_ks")]
    ProRes4444,
    [EnumMember(Value = "libaom-av1")]
    AV1,
    [EnumMember(Value = "mpeg2video")]
    MPEG2,
    [EnumMember(Value = "mpeg4")]
    MPEG4,
    [EnumMember(Value = "dnxhd")]
    DNxHD,
    [EnumMember(Value = "dnxhr")]
    DNxHR,
    [EnumMember(Value = "copy")]
    Copy,
    [EnumMember(Value = null)]
    Null
}
