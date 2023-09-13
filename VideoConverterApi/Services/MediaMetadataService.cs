using MediaInfoDotNet;
using VideoConverterApi.Models;

namespace VideoConverterApi.Services;

public class MediaMetadataService
{
    public MediaMetadata GetMediaMetadata(string pathToMediaFile)
    {
        var mediaInfo = new MediaFile(pathToMediaFile);

        return new MediaMetadata()
        {
            Size = mediaInfo.General.Size,
            FileExtension = mediaInfo.General.Format,
            Duration = (double)mediaInfo.General.Duration / 1000,
            BitRate = mediaInfo.General.BitRate,
            CodecId = mediaInfo.Video[0].CodecId,
            VideoBitRate = mediaInfo.Video[0].bitRate,
            Height = mediaInfo.Video[0].Height,
            Width = mediaInfo.Video[0].Width,
            FrameRate = mediaInfo.General.frameRate,
            AudioCodecId = mediaInfo.Audio[0].CodecId,
            AudioBitRate = mediaInfo.Audio[0].bitRate
        };
    }
}
