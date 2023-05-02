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
			Title = mediaInfo.General.Title,
			FileExtension = mediaInfo.General.format,
			Duration = mediaInfo.General.Duration / 1000,
			Bitrate = mediaInfo.General.BitRate,
			CodecId = mediaInfo.General.CodecId,
			VideoBitRate = mediaInfo.Video[0].bitRate,
			Height = mediaInfo.General.height,
			Width = mediaInfo.General.width,
			FrameRate = mediaInfo.General.frameRate,
			AudioCodecId = mediaInfo.Audio[0].CodecId,
			AudioBitRate = mediaInfo.Audio[0].bitRate,
			AudioChannels = mediaInfo.Audio[0].Channels
		};
	}
}
