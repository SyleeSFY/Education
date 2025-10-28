using System;

namespace ReadFile
{
    public class Program
    {
        private static readonly string path = "/Users/artemryklin/RiderProjects/ReadFile/ReadFile/File.txt";
        
        public static void Main(string[] args)
        {
            var sync = new SyncWorkFile(path);
            var thread = new ThreadWorkFile(path);
            
            Console.WriteLine(sync.GetSumNumbers());
            Console.WriteLine(thread.GetSumAsync().Result);
            Console.WriteLine(thread.ThreadGetSum());

        }
    }
}