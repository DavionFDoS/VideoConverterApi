using VideoConverterApi.Models;

namespace VideoConverterApi.Interfaces;

public interface IVideoToolsService
{
    Task AddAudioAsync();
    Task AddSubtitlesAsync();
    Task AddWatermarkAsync();
    Task ChangeAudioBitrateAsync(ChangeAudioBitrateArguments changeAudioBitrateArguments);
    Task ChangeAudioVolumeAsync();
    Task ChangeVideoBitrateAsync(ChangeVideoBitrateArguments changeVideoBitrateArguments);
    Task ChangeVideoResolutionAsync();
    Task ChangeVideoSpeedAsync();
    Task CropVideoAsync(CropVideoArguments cropVideoArguments);
    Task CutVideoAsync(CutVideoArguments cutVideoArguments);
    Task ExtractAudioAsync();
    Task ExtractSingleFrameAsync();
    Task MergeVideosAsync();
    Task ReflectVideoAsync(ReflectVideoArguments reflectVideoArguments);
    Task RemoveAudioAsync(RemoveVideoArguments removeVideoArguments);
    Task ReverseVideoAsync(ReverseVideoArguments reverseVideoArguments);
    Task RotateVideoByAngleAsync(RotateVideoArguments rotateVideoArguments);
    Task WebOptimizeVideoAsync();
}