using UnityEngine;

namespace Core.GlobalServices.LogService
{
    public class LogGlobalService : ILogGlobalService
    {
        public void Log(string msg) => 
            Debug.Log(msg);
        
        public void LogError(string msg) => 
            Debug.LogError(msg);

        public void LogWarning(string msg) => 
            Debug.LogWarning(msg);
    }
}