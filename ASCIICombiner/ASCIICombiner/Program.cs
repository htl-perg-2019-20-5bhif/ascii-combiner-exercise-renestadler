using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ASCIICombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough files specified");
                Console.WriteLine("Usage: ASCIIArtCombiner.exe <textfile1> <textfile2>");
                return;
            }
            ProcessFiles(args);
            
        }

        private static void ProcessFiles(string[] files)
        {
            var texts = new List<string[]>();
            for (int i = 0; i < files.Length; i++)
            {
                if (!File.Exists("TestData/" + files[i]))
                {
                    Console.WriteLine($"File {files[i]} does not exist.");
                    Console.WriteLine("Usage: ASCIIArtCombiner.exe <textfile1> <textfile2>");
                    return;
                }
                texts.Add(File.ReadAllText("TestData/" + files[i]).Replace("\r", string.Empty).Split("\n"));
            }
            FileMerger fm = new FileMerger();
            char[][] ar = fm.mergeFiles(texts);
            if (ar == null)
            {
                Console.WriteLine("Files are not all of equal length");
                Console.WriteLine("Usage: ASCIIArtCombiner.exe <textfile1> <textfile2>");
                return;
            }
            for (int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine(new string(ar[i]));
            }
        }
    }
}
