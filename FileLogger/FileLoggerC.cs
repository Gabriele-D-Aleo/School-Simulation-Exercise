using Microsoft.VisualBasic;

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
        public string DirectoryV { get; set; } = "C:\\Users\\gabriele.daleo\\source\\repos\\Test&Exercises\\Test&Exercises\\StorageTemp\\Logs\\";

        public FileLoggerC(int span= 2)
        {
            foreach( string file in Directory.GetFiles(DirectoryV, "*.log"))
            {
                if (string.IsNullOrEmpty(Path))
                    Path = file;
                else if (File.GetCreationTime(file) > File.GetCreationTime(Path)  )
                    Path = file;
            }

            SpanForFileCreation = span;

            if (!string.IsNullOrEmpty(Path))
                LastLog = TimeOnly.FromDateTime(Directory.GetCreationTime(Path));
            
        }

        /// <summary>
        /// This method creates a new file log, this occurrence should happen every 2 hours
        /// </summary>
        public void CreateNewLog()
        {
           Path = DirectoryV+ "Log_"+ DateTime.Now.ToShortDateString().Replace("/","-").Replace(" ","-") + "_" + DateTime.Now.ToShortTimeString().Replace(" ", "-").Replace(":","-") + ".log" ;
           using (File.Create(Path))
            { 
            }
            LastLog = TimeOnly.FromDateTime(Directory.GetCreationTime(Path));
        }


        public void ModifyLog(string content,string type) {
            
            using (StreamWriter fs = new StreamWriter(Path,true))
            {
                if (content.Length > 100)
                {
                    fs.WriteLine(type +" --- "+ DateTime.Now.ToString() + " -- " + content.Substring(0, content.Length / 2));
                    fs.WriteLine(type + " --- "+ DateTime.Now.ToString() + " -- " + content.Substring(content.Length / 2, content.Length));
                }
                else
                    fs.WriteLine(type + " --- " + DateTime.Now.ToString() + " -- " + content);
            }
        }

        public void Log(string info,string type="information")
        {
            if (!File.Exists(Path) || DateTime.Now.Hour - LastLog.Hour >= SpanForFileCreation)
                CreateNewLog();

            ModifyLog(info, type);

        }

        public  async Task DeleteLog() {
            // maybe with filesystem we can read what's in a folder to seek all the files
            //Directory.Dir()
           /* List<File.> files =
            TimeSpan Ts = File.GetCreationTime("") - DateTime.Now;
            if ( .Su File.GetCreationTime(""))*/
        }
    }
}