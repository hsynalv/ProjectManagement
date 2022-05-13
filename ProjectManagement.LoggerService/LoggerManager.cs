using NLog;
using ProjectManagement.Contracts;

namespace ProjectManagement.LoggerService;

public class LoggerManager : ILoggerManager
{
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

    public void LogInfo(string message)
    {
        logger.Info(message);
    }

    public void LogWarning(string message)
    {
        logger.Warn(message);
    }


    public void LogError(string message)
    {
        logger.Error(message);
    }

    public void LogDebug(string message)
    {
        logger.Debug(message);
    }
}