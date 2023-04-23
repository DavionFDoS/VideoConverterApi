namespace VideoConverterApi.Interfaces
{
    public interface IFFMpegCommandHandler
    {
        Task ConvertToAVIWithNoArguments();
        Task ConvertToAVIWithArguments();
        Task ConvertToMOVWithNoArguments();
        Task ConvertToMOVWithArguments();
        Task ConvertToMP4WithNoArguments();
        Task ConvertToMP4WithArguments();
        Task ConvertToWebMWithNoArguments();
        Task ConvertToWebMWithArguments();
        Task ReverseVideoAsync();
    }
}