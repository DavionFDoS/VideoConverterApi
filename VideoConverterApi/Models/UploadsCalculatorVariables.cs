namespace VideoConverterApi.Models;

public class UploadsCalculatorVariables
{
    public PrecalculatedSize? PrecalculatedSize { get; set; }

    public bool CanBeUploadedToVK { get; set; }

    public bool CanBeUploadedToTelegram { get; set; }

    public bool CanBeUploadedToReddit { get; set; }

    public bool CanBeUploadedToYoutube { get; set; }

    public bool CanBeUploadedToDiscord { get; set; }

    public bool CanBeUploadedToTwitter { get; set; }
}
