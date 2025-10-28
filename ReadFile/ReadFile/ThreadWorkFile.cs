using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReadFile
{
    public class ThreadWorkFile : ReadingFile
    {
        private string _content;

        public ThreadWorkFile(string path)
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
        
        private List<string> CreateChunk(int chunkSize)
        {
            var chunks = new List<string>();
            int length;
            
            for(int i = 0; i < _content.Length; i += chunkSize)
            {
                length = Math.Min(chunkSize, _content.Length - i);
                chunks.Add(_content.Substring(i, length));
            }
            return chunks;
        }

        private List<int> ParseChunk(string chunk)
        {
            var numbersListChunks = new List<int>();
            string currentNumber = null;

            chunk.ToList().ForEach(x =>
            {
                if(char.IsDigit(x))
                    currentNumber += x;
                
                else if(!string.IsNullOrEmpty(currentNumber))
                {
                    numbersListChunks.Add(int.Parse(currentNumber));
                    currentNumber = null;
                }
            });

            return numbersListChunks;
        }
        
        public override void GetContent()
            => Console.WriteLine(_content);
        
        public async Task<int> GetSumAsync()
            => await Task.Run(() => ParseListNumbers().Sum());
        
        public int ThreadGetSum()
        {
            var numbersList = new List<int>();
            var chunks = CreateChunk(100);
    
            Parallel.ForEach(chunks, chunk =>
            {
                var chunkNumbers = ParseChunk(chunk);
                lock (numbersList)
                {
                    numbersList.AddRange(chunkNumbers);
                }
            });
    
            return numbersList.Sum();
        }

    }
}