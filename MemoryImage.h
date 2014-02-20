
/*****************************************************************************
 *                                                                           *
 *  MemoryImage.h                                                            *
 *  26 July 2006                                                             *
 *  Project: PaperDoll                                                       *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2006 Metaphysics Industries                                  *
 *                                                                           *
 *  A managed class that organizes access to a Bitmap object. Taken from the *
 *    MathPaint project. Need to put this in a separate assembly. Maybe      *
 *    MetaphysicsIndustries.Utility or something.                            *
 *                                                                           *
 *****************************************************************************/



#pragma once



namespace MetaphysicsIndustries { namespace Utilities { 
;



public ref class MemoryImage
{

public:

	MemoryImage(void);
	MemoryImage(System::Drawing::Bitmap^);
	virtual ~MemoryImage(void);

	property System::Drawing::Bitmap^ Bitmap
	{
		System::Drawing::Bitmap^ get(void);
	}

	property System::Drawing::Color Pixel[int, int]
	{
		System::Drawing::Color get(int, int);
		void set(int, int, System::Drawing::Color);
	}

	property int Width
	{
		int get(void);
		void set(int);
	}
	property int Height
	{
		int get(void);
		void set(int);
	}
	property System::Drawing::Size Size
	{
		System::Drawing::Size get(void);
		void set(System::Drawing::Size);
	}

	property System::Drawing::Rectangle Rect
	{
		System::Drawing::Rectangle get(void);
	}

	void CopyPixelsToBitmap(void);
	void CopyBitmapToPixels(void);

protected:

	System::Drawing::Bitmap^			bitmap;

	int									width;
	int									height;

	Object^								SyncSize;	//always sync on these in this order
	Object^								SyncBitmap;	//and unsync in the opposite order
	Object^								SyncPixels;

	array<System::Drawing::Color, 2>^	pixels;

private:

	void Init(void);

};



} } 




