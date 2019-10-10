using System;
using System.Linq;

namespace ASCIICombiner
{
    public class FileMerger
    {
        public char[][] mergeFiles(System.Collections.Generic.List<string[]> args)
        {
            char[][] ar = new char[args.First().Length][];
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = new char[args.First()[0].Length];
            }
            for (int i = 0; i < args.First().Length; i++)
            {
                if (args.First().Length != ar.Length)
                {
                    return null;
                }
                for (int j = 0; j < args.First()[0].Length; j++)
                {
                    if (args.First()[0].Length != ar.Length)
                    {
                        return null;
                    }
                    for (int k = 0; k < args.Count(); k++)
                    {
                        if (args[k][i][j] != ' ')
                        {
                            ar[i][j] = args[k][i][j];
                        }
                    }
                }
            }
            return ar;
        }
    }
}
