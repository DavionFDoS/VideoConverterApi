using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum Resolutions
{   
    [EnumMember(Value = "320x180")]
    Resolution320x180,
    [EnumMember(Value = "320x240")]
    R240p,
    [EnumMember(Value = "426x240")]
    Resolution426x240,
    [EnumMember(Value = "480x360")]
    R360p,
    [EnumMember(Value = "640x360")]
    Resolution640x360,
    [EnumMember(Value = "640x480")]
    R480p,
    [EnumMember(Value = "854x480")]
    FWVGA,
    [EnumMember(Value = "960x540")]
    qHD,
    [EnumMember(Value = "1024x768")]
    XGA,
    [EnumMember(Value = "1280x720")]
    HD720,
    [EnumMember(Value = "1280x1024")]
    SXGA,
    [EnumMember(Value = "1360x768")]
    Resolution1360x768,
    [EnumMember(Value = "1368x768")]
    Resolution1368x768,
    [EnumMember(Value = "1920x1080")]
    FHD1080,
    [EnumMember(Value = "2560x1440")]
    QHD1440,
    [EnumMember(Value = "3840x2160")]
    UHD4K,
    [EnumMember(Value = "7680x4320")]
    UHD8K
}
