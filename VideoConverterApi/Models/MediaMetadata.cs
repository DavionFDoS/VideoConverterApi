﻿namespace VideoConverterApi.Models;

public class MediaMetadata
{
    public long Size { get; set; }
    public string? FileExtension { get; set; }
    public string? CodecId { get; set; }
    public int BitRate { get; set; }
    public double Duration { get; set; }
    public string? VideoBitRate { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public float FrameRate { get; set; }
    public string? AudioCodecId { get; set; }
    public string? AudioBitRate { get; set; }
}
