using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum FrameRate
{
    [EnumMember(Value = "1")]
    FPS_1,
    [EnumMember(Value = "2")]
    FPS_2,
    [EnumMember(Value = "3")]
    FPS_3,
    [EnumMember(Value = "5")]
    FPS_5,
    [EnumMember(Value = "10")]
    FPS_10,
    [EnumMember(Value = "15")]
    FPS_15,
    [EnumMember(Value = "24")]
    FPS_24,
    [EnumMember(Value = "25")]
    FPS_25,
    [EnumMember(Value = "30")]
    FPS_30,
    [EnumMember(Value = "60")]
    FPS_60,
    [EnumMember(Value = "120")]
    FPS_120,
    [EnumMember(Value = "144")]
    FPS_144,
    [EnumMember(Value = "1/2")]
    FPS_1_2,
    [EnumMember(Value = "1/3")]
    FPS_1_3,
    [EnumMember(Value = "1/5")]
    FPS_1_5,
}
