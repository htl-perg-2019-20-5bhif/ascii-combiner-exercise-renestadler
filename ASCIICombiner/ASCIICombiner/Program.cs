using System;
using System.Collections.Generic;
using System.IO;

namespace ASCIICombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough arguments specified");
                Console.WriteLine("Usage: ASCIIArtCombiner.exe <textfile1> <textfile2>");
            }
            ProcessFiles(args);
        }

        private async static void ProcessFiles(string[] files)
        {
            var texts = new List<string[]>();

            for (int i = 0; i < files.Length; i++)
            {
                texts.Add((await File.ReadAllTextAsync(files[i])).Replace("\r", string.Empty).Split("\n"));
            }
            Console.WriteLine((await File.ReadAllTextAsync(files[0])).Replace("\r", string.Empty).Split("\n"));
            Console.WriteLine(texts[1]);
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
                Console.WriteLine(new string(ar[0]));
            }
        }
    }
}
