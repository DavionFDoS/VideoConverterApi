namespace VideoConverterApi.Models;

public class ChangeAudioVolumeArguments : InputFileArguments
{
    public double VolumeChangeCoefficient { get; set; }
}
