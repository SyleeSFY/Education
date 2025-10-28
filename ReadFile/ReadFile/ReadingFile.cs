using System;
using System.IO;

namespace ReadFile
{
    public abstract class ReadingFile
    {
        protected abstract void ReadFile(string path);
        public abstract void GetContent();
    }
}