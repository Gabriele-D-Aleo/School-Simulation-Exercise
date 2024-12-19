namespace FileLogger
{
    public class FileLoggerC: IFileLoggerC
    {
        /// <summary>
        /// Saves the Time of the last written
        /// </summary>
        public TimeOnly LastLog { get; set; } 

        /// <summary>
        /// This variable determines the span in which new files are created
        /// </summary>
        public int SpanForFileCreation { get; set; }

        /// <summary>
        /// This variable determines the path where files will be created
        /// </summary>
        public string Path { get; set; }

        public FileLoggerC(int span= 2,string path= "../")
        {
            LastLog = TimeOnly.FromDateTime(DateTime.Now);
            SpanForFileCreation = span;
            Path = path;
        }

        /// <summary>
        /// This method creates a new file log, this occurrence should happen every 2 hours
        /// </summary>
        public void CreateNewLog()
        { 

        }


        public  void ModifyLog() { 

        }

        public  async Task DeleteLog() { 
        
        }
    }
}