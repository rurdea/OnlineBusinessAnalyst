using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalyst.ContentSaver
{
    /// <summary>
    /// Class used to save crawled content to files.
    /// </summary>
    internal class FileContentSaver : ContentSaver
    {
        #region Properties
        /// <summary>
        /// Gets the output file.
        /// </summary>
        public string OutputFile
        {
            get;
            private set;
        }
        #endregion

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="outputFile">The output file path.</param>
        /// <param name="bufferSize">The save buffer size.</param>
        public FileContentSaver(string outputFile, int bufferSize)
            : base(bufferSize)
        {
            this.OutputFile = outputFile;
        }

        /// <summary>
        /// Performs the actual save of the buffered items.
        /// </summary>
        /// <param name="buffer">The save buffer.</param>
        protected override void SaveBuffer(string[] buffer)
        {
            try
            {
                File.AppendAllLines(this.OutputFile, buffer);
            }
            catch (Exception ex)
            {
                LogManager.Instance.Logger.Error("Error saving crawled content to file.", ex);
            }
        }
    }
}
