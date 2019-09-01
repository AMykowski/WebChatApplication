using System;
using WebChat.Models;
using WebChat.Repositories;

namespace WebChat.Helpers
{
    public class Logger
    {
        private const string FILE_EXT = ".log";
        private readonly string datetimeFormat;
        private readonly string logFilename;
        private readonly string logFilePath;
        private DbConnector dc = new DbConnector();

        /// <summary>
        /// Constructor: set up path, create one log file for each day in desktop directory
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        public Logger()
        {
            //Sets log datetime format, file name and path to desktop folder
            datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            //file name with current day date to have only one log file per day
            logFilename = "SimpleChat [" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + FILE_EXT;
            logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + logFilename;


            // Log file header line
            string logHeader = logFilename + " is created.";
            if (!System.IO.File.Exists(logFilePath))
            {
                WriteLog(System.DateTime.Now.ToString(datetimeFormat) + " " + logHeader, false);
            }
        }

        /// <summary>
        /// Loggs sent messages in log file locally and inserts messages to Message table in db
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="text"> The message </param>
        /// <param name="startUser"> The sender</param>
        /// <param name="endUser"> The receiver</param>
        public void Message(string text, string startUser, string endUser)
        {
            //Write to file
            WriteFormattedLog(LogType.MESSAGE, text, startUser, endUser);


            //Write to db
            int lastId = ChatMessage.GetMessages(dc).Count;
            ChatMessage message = new ChatMessage();
            message.ChatMessageId = lastId;
            message.SenderUsername = startUser;
            message.ReceiverUsername = endUser;
            message.Message = text;
            message.Time = DateTime.Now;

            dc.ChatMessageRepository.Insert(message);
            dc.Save();

        }

        /// <summary>
        /// Loggs error messages to log file
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="text"> The message</param>
        public void Error(string text)
        {
            WriteFormattedLog(LogType.ERROR, text);
        }

        /// <summary>
        /// Loggs info messages to log file
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="text">The message</param>
        public void Info(string text)
        {
            WriteFormattedLog(LogType.INFO, text);
        }

        /// <summary>
        /// Writes log through StreamWriter
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="text">The message</param>
        /// <param name="append">The append specification</param>
        private void WriteLog(string text, bool append = true)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilePath, append, System.Text.Encoding.UTF8))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Creates format for message log 
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="logType">Log level</param>
        /// <param name="text">The message</param>
        /// <param name="startUser">The sender</param>
        /// <param name="endUser">The receiver</param>
        private void WriteFormattedLog(LogType logType, string text, string startUser, string endUser)
        {
            string pretext;
            switch (logType)
            {
                case LogType.MESSAGE:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [MESSAGE]  FROM: [" + startUser + " TO " + endUser + "] :";
                    break;
                default:
                    pretext = "";
                    break;
            }

            WriteLog(pretext + text);
        }

        /// <summary>
        /// Creates format for info and error logs
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="logType">Log level</param>
        /// <param name="text">The message</param>
        private void WriteFormattedLog(LogType logType, string text)
        {
            string pretext;
            switch (logType)
            {

                case LogType.INFO:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [INFO]    ";
                    break;
                case LogType.ERROR:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [ERROR]   ";
                    break;
                default:
                    pretext = "";
                    break;
            }

            WriteLog(pretext + text);
        }

        /// <summary>
        /// Enums Log types
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        [System.Flags]
        private enum LogType
        {
            MESSAGE,
            INFO,
            ERROR
        }
    }
}