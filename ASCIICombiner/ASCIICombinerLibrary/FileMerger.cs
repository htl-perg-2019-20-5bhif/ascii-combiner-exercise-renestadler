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
            for (int i = 0; i < args.Count(); i++)
            {
                if (args[i].Length != ar.Length)
                {
                    return null;
                }
                for (int j = 0; j < args.First().Length; j++)
                {
                    if (args[i][j].Length != ar[0].Length)
                    {
                        return null;
                    }
                    for (int k = 0; k < args.First()[0].Length; k++)
                    {
                        if (args[i][j][k] != ' ')
                        {
                            ar[j][k] = args[i][j][k];
                        }
                    }
                }
            }
            return ar;
        }
    }
}
