using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    public interface IFileLoggerC
    {
        /// <summary>
        /// Saves the Time of the last written
        /// </summary>
        public abstract TimeOnly LastLog { get; set; }

        /// <summary>
        /// This variable determines the span in which new files are created
        /// </summary>
        public int SpanForFileCreation { get; set; }

        /// <summary>
        /// This variable determines the path where files will be created
        /// </summary>
        public string Path { get; set; }

        public string DirectoryV { get; set; }

        /// <summary>
        /// This method creates a new file log, this occurrence should happen every 2 hours
        /// </summary>
        /// <param name="path"> the path of the file, it is optional, 
        /// as if we don't put nothing the default one will be taken</param>
        public abstract void CreateNewLog();
        

        public abstract void ModifyLog(string content,string type);

        public abstract void Log(string info, string type ="information");

        public abstract Task DeleteLog();

    }
}
