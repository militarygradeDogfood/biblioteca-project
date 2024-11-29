namespace WebApplication1.NewFolder
{
    public class FileLogger
    {
        private readonly string _filePath;
        
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void LogError(string message, Exception ex)
        {
            var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR: {message}\n" +
                $"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}\n";
            WriteToFile(logMessage);
        }

        public void LogInfo(string message)
        {
            var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - INFO: {message}\n";
            WriteToFile(logMessage);
        }

        public void WriteToFile(string logMessage)
        {
            lock(this)
            {
                File.AppendAllText(_filePath, logMessage);
            }
        }
    }
}
