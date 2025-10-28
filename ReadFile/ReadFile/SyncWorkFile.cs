using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadFile
{
    public class SyncWorkFile : ReadingFile
    {
        private string _content;

        public SyncWorkFile(string path)
        {
            if(string.IsNullOrEmpty(path) || !TryReadFile(path)) throw new ArgumentException("File is empty!");
        }
        
        protected override void ReadFile(string path)
            => _content = File.ReadAllText(path);
        
        private bool TryReadFile(string path)
        {
            if(!string.IsNullOrEmpty(File.ReadAllText(path)))
            {
                ReadFile(path);
                return true;
            }

            return false;
        }
        
        private List<int> ParseListNumbers()
        {
            var numbersList = new List<int>();
            string currentNumber = null;

            _content.ToList().ForEach(x =>
            {
                if(char.IsDigit(x))
                    currentNumber += x;

                else if(!string.IsNullOrEmpty(currentNumber))
                {
                    numbersList.Add(int.Parse(currentNumber));
                    currentNumber = null;
                }
            });
            
            if(!string.IsNullOrEmpty(currentNumber))
                numbersList.Add(int.Parse(currentNumber));
            
            return numbersList;
        }
        
        public override void GetContent()
            => Console.WriteLine(_content);

        public int GetSumNumbers()
            => ParseListNumbers().Sum();

    }
}