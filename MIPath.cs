/*****************************************************************************
 *                                                                           *
 *  Path.cs                                                                  *
 *  7 September 2006                                                         *
 *  Project: MetaphysicsIndustries.IO                                        *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2006 Metaphysics Industries, Inc.                            *
 *                                                                           *
 *  Converted from C++ to C# on 31 July 2009                                 *
 *                                                                           *
 *  Some useful functions for manipulating path strings. See                 *
 *    System.IO.Path                                                         *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
//using MetaphysicsIndustries.Collections;
using System.IO;
using System.Text;

namespace MetaphysicsIndustries.Utilities
{
    public class MIPath
    {
        public static string ConstructRelativePath(string from, string to)
        {
            string filename;

            filename = System.IO.Path.GetFileName(to);

            from = System.IO.Path.GetFullPath(from);
            to = System.IO.Path.GetFullPath(to);

            if (System.IO.Path.GetPathRoot(from) != System.IO.Path.GetPathRoot(to))
            {
                //different drives. no relative path can be made.
                throw new InvalidOperationException("The filenames indicate separate drives. There is no valid relative path between them.");
            }

            from = System.IO.Path.GetDirectoryName(from);
            to = System.IO.Path.GetDirectoryName(to);

            string[] af;
            string[] at;

            af = SplitPath(from);
            at = SplitPath(to);

            int i;
            int j;
            j = Math.Min(af.Length, at.Length);
            for (i = 0; i < j; i++)
            {
                if (af[i] != at[i]) break;
            }

            StringBuilder sb;
            int len;
            int k;

            k = i;
            j = at.Length;
            len = 0;
            for (; i < j; i++)
            {
                len += at[i].Length;
            }
            len += j - k - 1;
            len += 3 * af.Length - 1;
            sb = new StringBuilder(len);

            j = af.Length;
            for (i = k; i < j; i++)
            {
                sb.Append("..");
                sb.Append(System.IO.Path.DirectorySeparatorChar, 1);
            }
            j = at.Length;
            for (i = k; i < j; i++)
            {
                sb.Append(at[i]);
                sb.Append(System.IO.Path.DirectorySeparatorChar, 1);
            }

            sb.Append(filename);

            return sb.ToString();
        }

        public static string[] SplitPath(string path)
        {
            System.IO.Path.GetFullPath(path);	//run check on invalid characters
            return path.Split(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
        }

        public static string JoinPath(params string[] foldernames)
        {
            foreach (string s in foldernames)
            {
                System.IO.Path.GetFullPath(s);
            }

            return string.Join(new string(System.IO.Path.DirectorySeparatorChar, 1), foldernames);
        }

    }
}
