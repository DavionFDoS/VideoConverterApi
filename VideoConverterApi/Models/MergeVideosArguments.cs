namespace VideoConverterApi.Models;

public class MergeVideosArguments : InputFileArguments
{
    public IList<string>? VideosToMerge { get; set; }
}
