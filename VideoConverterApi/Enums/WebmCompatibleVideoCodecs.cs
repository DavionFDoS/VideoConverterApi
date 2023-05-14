using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum WebmCompatibleVideoCodecs
{
    [EnumMember(Value = "libvpx")]
    VP8,
    [EnumMember(Value = "libvpx-vp9")]
    VP9
}
