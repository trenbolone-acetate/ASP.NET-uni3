namespace ASPNET3.Services;
public interface ITimeAnalyzerService
{
    string GetMessageBasedOnTimeOfDay();
}

public class TimeAnalyzerService : ITimeAnalyzerService
{
    public string GetMessageBasedOnTimeOfDay()
    {
        var currentHour = DateTime.Now.Hour;
        return currentHour switch
        {
            >= 0 and < 6 => "It is night currently",
            >= 6 and < 12 => "It is morning currently",
            >= 12 and < 18 => "It is day currently",
            _ => "It is evening currently"
        };
    }
}