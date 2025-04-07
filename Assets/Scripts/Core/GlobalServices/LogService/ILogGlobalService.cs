namespace Core.GlobalServices.LogService
{
    public interface ILogGlobalService
    {
        void Log(string msg);
        void LogError(string msg);
        void LogWarning(string msg);
    }
}