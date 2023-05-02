namespace VideoConverterApi.Interfaces;

public interface IVideoToolsService
{
    Task AddAudioAsync();
    Task AddSubtitlesAsync();
    Task AddWatermarkAsync();
    Task ChangeAudioBitrateAsync();
    Task ChangeAudioVolumeAsync();
    Task ChangeVideoBitrateAsync();
    Task ChangeVideoResolutionAsync();
    Task ChangeVideoSpeedAsync();
    Task CropVideoAsync();
    Task CutVideoAsync();
    Task ExtractAudioAsync();
    Task ExtractSingleFrameAsync();
    Task MergeVideosAsync();
    Task ReflectVideoAsync();
    Task RemoveAudioAsync();
    Task ReverseVideoAsync();
    Task RotateVideoByAngleAsync();
    Task WebOptimizeVideoAsync();
}