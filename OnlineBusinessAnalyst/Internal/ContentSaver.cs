using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalyst.ContentSaver
{
    /// <summary>
    /// Abstract class used for saving crawled content.
    /// </summary>
    internal abstract class ContentSaver
    {
        #region Members
        protected List<string> _buffer = new List<string>();
        #endregion

        /// <summary>
        /// Gets the buffer size.
        /// </summary>
        public int BufferSize
        {
            get;
            private set;
        }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="bufferSize">The save buffer size.</param>
        public ContentSaver(int bufferSize)
        {
            this.BufferSize = bufferSize;
        }

        /// <summary>
        /// Adds the specified item to the save buffer.
        /// </summary>
        /// <param name="contentItem">The item to be saved.</param>
        public virtual void SaveContentItem(string contentItem)
        {
            _buffer.Add(contentItem);

            if (_buffer.Count == this.BufferSize)
            {
                SaveBuffer();
            }
        }

        public void SaveBuffer()
        {
            this.SaveBuffer(_buffer.ToArray());
            _buffer.Clear();
        }

        /// <summary>
        /// Performs the actual save of the buffered items.
        /// </summary>
        /// <param name="buffer">The save buffer.</param>
        protected abstract void SaveBuffer(string[] buffer);
    }
}
