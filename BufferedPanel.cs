
/*****************************************************************************
 *                                                                           *
 *  BufferedPanel.cs                                                         *
 *  26 July 2006                                                             *
 *  Project: PaperDoll                                                       *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2006 Metaphysics Industries, Inc.                            *
 *                                                                           *
 *  Converted from C++ to C# on 8 February 2008                              *
 *                                                                           *
 *  A double-buffered version of the Panel control.                          *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
//using MetaphysicsIndustries.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace MetaphysicsIndustries.Utilities
{
	public class BufferedPanel : System.Windows.Forms.Panel
	{
		public BufferedPanel()
		{
			DoubleBuffered = true;
		}
	}
}
