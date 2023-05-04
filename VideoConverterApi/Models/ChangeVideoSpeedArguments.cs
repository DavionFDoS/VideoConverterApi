namespace VideoConverterApi.Models;

public class ChangeVideoSpeedArguments : InputFileArguments
{
    public double SpeedChangeCoefficient { get; set; }
}
