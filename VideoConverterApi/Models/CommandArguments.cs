using VideoConverterApi.Enums;

namespace VideoConverterApi.Models;

public class CommandArguments
{
    public string? InputFileName { get; set; }
    public string? VideoBitrate { get; set; }
    public string? AudioBitrate { get; set; }
    public string? Crf { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? RotateAngle { get; set; }
    public string? CropWidth { get; set; }
    public string? CropHeight { get; set; }
    public string? CropX { get; set; }
    public string? CropY { get; set; }
    public string? WatermarkOverlayX { get; set; }
    public string? WatermarkOverlayY { get; set; }
    public string? WatermarkFileName { get; set; }
    public string? SubtitlesFilename { get; set; }
    public string? AudioFileName { get; set; }
    public string? FrameNumber { get; set; }
    public Resolutions Resolution { get; set; }
    public Presets Preset { get; set; }
    public FrameRate Framerate { get; set; }
    public AudioCodecs AudioCodec { get; set; }
    public VideoCodecs VideoCodec { get; set; }
}
