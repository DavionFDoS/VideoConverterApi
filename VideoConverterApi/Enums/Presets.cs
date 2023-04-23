using System.Runtime.Serialization;

namespace VideoConverterApi.Enums;

public enum Presets
{
    [EnumMember(Value = "ultrafast")]
    UltraFast,
    [EnumMember(Value = "superfast")]
    SuperFast,
    [EnumMember(Value = "veryfast")]
    VeryFast,
    [EnumMember(Value = "faster")]
    Faster,
    [EnumMember(Value = "fast")]
    Fast,
    [EnumMember(Value = "medium")]
    Medium,
    [EnumMember(Value = "slow")]
    Slow,
    [EnumMember(Value = "slower")]
    Slower,
    [EnumMember(Value = "veryslow")]
    VerySlow
}
