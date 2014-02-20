
/*****************************************************************************
 *                                                                           *
 *  MemoryImage.cpp                                                          *
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



#include "stdafx.h"
#include "MemoryImage.h"

using namespace System::Drawing;
using System::Threading::Monitor;



;
NAMESPACE_START
;



MemoryImage::MemoryImage(void)
{
	this->bitmap = gcnew Drawing::Bitmap(1, 1, Imaging::PixelFormat::Format32bppArgb);
	this->width = 1;
	this->height = 1;

	this->Init();
}

MemoryImage::MemoryImage(Drawing::Bitmap^ b)	//maybe change this from Bitmap to Image
{
	Drawing::Bitmap^ _b = b;

	this->bitmap = b->Clone(Rectangle(Point(0, 0), b->Size), Imaging::PixelFormat::Format32bppArgb);
	this->width = this->bitmap->Width;
	this->height = this->bitmap->Height;

	this->Init();
}

void MemoryImage::Init(void)
{
	this->pixels = gcnew array<Color, 2>(this->Width, this->Height);

	this->SyncSize = gcnew Object;
	this->SyncBitmap = gcnew Object;
	this->SyncPixels = gcnew Object;
}

MemoryImage::~MemoryImage(void)
{
	
}

System::Drawing::Bitmap^ MemoryImage::Bitmap::get(void)
{
	return this->bitmap;
}

System::Drawing::Color MemoryImage::Pixel::get(int x, int y)
{
	int _x = x, _y = y;
	Color	c;

	//Monitor::Enter(this->SyncPixels);
	c = this->pixels[x, y];
	//Monitor::Exit(this->SyncPixels);

	return c;
}

void MemoryImage::Pixel::set(int x, int y, System::Drawing::Color c)
{
	int _x = x, _y = y;
	Color _c = c;

	//Monitor::Enter(this->SyncPixels);
	this->pixels[x, y] = c;
	//Monitor::Exit(this->SyncPixels);
}

int MemoryImage::Width::get(void)
{
	//Monitor::Enter(this);
	return this->width;
	//Monitor::Exit(this);
}
void MemoryImage::Width::set(int i)
{
	//synchronized in Size::set
	this->Size = Drawing::Size(i, this->Height);
}

int MemoryImage::Height::get(void)
{
	//Monitor::Enter(this);
	return this->height;
	//Monitor::Exit(this);
}
void MemoryImage::Height::set(int i)
{
	//synchronized in Size::set
	this->Size = Drawing::Size(this->Width, i);
}

Drawing::Size MemoryImage::Size::get(void)
{
	//Monitor::Enter(this);
	return Drawing::Size(this->Width, this->Height);
	//Monitor::Exit(this);
}
void MemoryImage::Size::set(Drawing::Size size)
{
	Drawing::Size _size = size;

	if (size.Width <= 0 || size.Height <= 0)
	{
		return ;
	}

	if (size.Width > this->pixels->GetLength(0) ||
		size.Height > this->pixels->GetLength(1))
	{
		int		w;
		int		h;
		int		i;
		int		j;
		array<Drawing::Color, 2>^	newpixels;

		w = System::Math::Max(size.Width, this->pixels->GetLength(0));
		h = System::Math::Max(size.Height, this->bitmap->Height);
		newpixels = gcnew array<Drawing::Color, 2>(w, h);
		w = System::Math::Min(size.Width, this->pixels->GetLength(0));
		h = System::Math::Min(size.Height, this->pixels->GetLength(1));
		for (i = 0; i < w; i++)
		{
			for (j = 0; j < h; j++)
			{
				newpixels[i, j] = this->pixels[i,j];
			}
		}
		this->pixels = newpixels;
	}

	if (size.Width > this->bitmap->Width || size.Height > this->bitmap->Height)
	{
		int		w;
		int		h;

		w = System::Math::Max(size.Width, this->bitmap->Width);
		h = System::Math::Max(size.Height, this->bitmap->Height);
		this->bitmap = gcnew System::Drawing::Bitmap(this->bitmap, w, h);
	}

	this->width = size.Width;
	this->height = size.Height;

}

System::Drawing::Rectangle MemoryImage::Rect::get(void)
{
	//Monitor::Enter(this);
	return System::Drawing::Rectangle(Point(0, 0), this->Size);
	//Monitor::Exit(this);
}

void MemoryImage::CopyPixelsToBitmap(void)
{
	Imaging::BitmapData^	data;
	IntPtr					ptr;
	array<int>^				pixeldata;
	int						count;
	int						i;
	int						j;
	int						k;
	int						ii;
	int						jj;

	ii = this->bitmap->Width;
	jj = this->bitmap->Height;
	count = ii * jj;
	data = this->bitmap->LockBits(Rectangle(0, 0, ii, jj),
									Imaging::ImageLockMode::WriteOnly,
									Imaging::PixelFormat::Format32bppArgb);

	ptr = data->Scan0;
	pixeldata = gcnew array<int>(count);

	k = 0;
	for (j = 0; j < jj; j++)
	{
		for (i = 0; i < ii; i++)
		{
			pixeldata[k] = this->pixels[i,j].ToArgb();
			k++;
		}
	}

	System::Runtime::InteropServices::Marshal::Copy(pixeldata, 0, ptr, count);

	this->bitmap->UnlockBits(data);
}

void MemoryImage::CopyBitmapToPixels(void)
{
	if (!this->Bitmap) { throw gcnew InvalidOperationException(__WCODESIG__); }

	Imaging::BitmapData^	data;
	IntPtr					ptr;
	array<int>^				pixeldata;
	int						count;
	int						i;
	int						j;
	int						k;
	int						ii;
	int						jj;

	count = this->bitmap->Width * this->bitmap->Height;
	data = this->bitmap->LockBits(Rectangle(0, 0, this->bitmap->Width, this->bitmap->Height),
									Imaging::ImageLockMode::ReadOnly,
									Imaging::PixelFormat::Format32bppArgb);
	ptr = data->Scan0;
	pixeldata = gcnew array<int>(count);

	System::Runtime::InteropServices::Marshal::Copy(ptr, pixeldata, 0, count);

	this->bitmap->UnlockBits(data);

	k = 0;
	ii = this->bitmap->Width;
	jj = this->bitmap->Height;
	for (j = 0; j < jj; j++)
	{
		for (i = 0; i < ii; i++)
		{
			this->pixels[i,j] = Color::FromArgb(pixeldata[k]);
			k++;
		}
	}

}



;
NAMESPACE_END
;


