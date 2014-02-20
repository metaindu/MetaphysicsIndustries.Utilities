
/*****************************************************************************
 *                                                                           *
 *  BufferedPanel.cpp                                                        *
 *  26 July 2006                                                             *
 *  Project: PaperDoll                                                       *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2006 Metaphysics Industries                                  *
 *                                                                           *
 *  A double-buffered version of the Panel control.                          *
 *                                                                           *
 *****************************************************************************/



#include "stdafx.h"
#include "BufferedPanel.h"



;
NAMESPACE_START
;



BufferedPanel::BufferedPanel(void)
{
	this->DoubleBuffered = true;

	//this->hscroll = gcnew HScrollBar;
	//this->vscroll = gcnew VScrollBar;
	//this->hscroll->Visible = true;
	//this->hscroll->Enabled = false;
	//this->vscroll->Visible = true;
	//this->vscroll->Enabled = false;

	//EventHandler^	eh;
	//eh = gcnew EventHandler(this, &BufferedPanel::ScrollBars_VisibleChanged);
	//this->hscroll->VisibleChanged += eh;
	//this->vscroll->VisibleChanged += eh;

	//this->littlepanel = gcnew Panel;
	//this->littlepanel->Visible = true;
	//this->littlepanel->BackColor = SystemColors::Control;

	//this->Controls->Add(this->hscroll);
	//this->Controls->Add(this->vscroll);
	//this->Controls->Add(this->littlepanel);

	////this->ClientSizeChanged += gcnew EventHandler(this, &BufferedPanel::BufferedPanel_ClientSizeChanged);

	//this->OnClientSizeChanged(gcnew EventArgs);

}

//HScrollBar^ BufferedPanel::HorizontalScrollBar::get(void)
//{
//	return this->hscroll;
//}
//VScrollBar^ BufferedPanel::VerticalScrollBar::get(void)
//{
//	return this->vscroll;
//}
//
////void BufferedPanel::BufferedPanel_ClientSizeChanged(Object^, EventArgs^)
//void BufferedPanel::OnClientSizeChanged(EventArgs^ e)
//{
//	Drawing::Size	s;
//
//	s = this->Panel::ClientSize;
//
//	this->hscroll->Left = 0;
//	this->hscroll->Top = s.Height - this->hscroll->Height;
//	this->hscroll->Width = s.Width;
//	if (this->vscroll->Visible)
//	{
//		this->hscroll->Width -= this->vscroll->Width;
//	}
//
//	this->vscroll->Left = s.Width - this->vscroll->Width;
//	this->vscroll->Top = 0;
//	this->vscroll->Height = s.Height;
//	if (this->hscroll->Visible)
//	{
//		this->vscroll->Height -= this->hscroll->Height;
//	}
//
//	this->littlepanel->Left = this->vscroll->Left;
//	this->littlepanel->Top = this->hscroll->Top;
//	this->littlepanel->Width = this->vscroll->Width;
//	this->littlepanel->Height = this->hscroll->Height;
//
//	this->Panel::OnClientSizeChanged(e);
//}
//
//Rectangle BufferedPanel::ClientRectangle::get(void)
//{
//	Rectangle	r;
//
//	r = this->Panel::ClientRectangle;
//
//	if (this->vscroll->Visible)
//	{
//		r.Width -= this->vscroll->Width;
//	}
//	if (this->hscroll->Visible)
//	{
//		r.Height -= this->hscroll->Height;
//	}
//
//	return r;
//}
//
//Drawing::Size BufferedPanel::ClientSize::get(void)
//{
//	Drawing::Size	s;
//
//	s = this->Panel::ClientSize;
//
//	if (this->vscroll->Visible)
//	{
//		s.Width -= this->vscroll->Width;
//	}
//	if (this->hscroll->Visible)
//	{
//		s.Height -= this->hscroll->Height;
//	}
//
//	return s;
//}
//
//void BufferedPanel::ClientSize::set(Drawing::Size s)
//{
//	if (this->vscroll->Width)
//	{
//		s.Width += this->vscroll->Width;
//	}
//	if (this->hscroll->Visible)
//	{
//		s.Height += this->hscroll->Height;
//	}
//
//	this->Panel::ClientSize = s;
//}
//
//void BufferedPanel::ScrollBars_VisibleChanged(Object^, EventArgs^)
//{
//	this->littlepanel->Visible = (this->hscroll->Visible && this->vscroll->Visible);
//	this->OnClientSizeChanged(gcnew EventArgs);
//}




;
NAMESPACE_END
;



