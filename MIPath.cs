
/*
 *  MetaphysicsIndustries.Utilities
 *  Copyright (C) 2014 Metaphysics Industries, Inc., Richard Sartor
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * 
 */

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
