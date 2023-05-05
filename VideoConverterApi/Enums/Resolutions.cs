using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum Resolutions
{   
    [EnumMember(Value = "320:180")]
    Resolution320x180,
    [EnumMember(Value = "320:240")]
    R240p,
    [EnumMember(Value = "426:240")]
    Resolution426x240,
    [EnumMember(Value = "480:360")]
    R360p,
    [EnumMember(Value = "640:360")]
    Resolution640x360,
    [EnumMember(Value = "640:480")]
    R480p,
    [EnumMember(Value = "854:480")]
    FWVGA,
    [EnumMember(Value = "960:540")]
    qHD,
    [EnumMember(Value = "1024:768")]
    XGA,
    [EnumMember(Value = "1280:720")]
    HD720,
    [EnumMember(Value = "1280:1024")]
    SXGA,
    [EnumMember(Value = "1360:768")]
    Resolution1360x768,
    [EnumMember(Value = "1368:768")]
    Resolution1368x768,
    [EnumMember(Value = "1920:1080")]
    FHD1080,
    [EnumMember(Value = "2560:1440")]
    QHD1440,
    [EnumMember(Value = "3840:2160")]
    UHD4K,
    [EnumMember(Value = "7680:4320")]
    UHD8K
}
