
/*****************************************************************************
 *                                                                           *
 *  BufferedPanel.h                                                          *
 *  26 July 2006                                                             *
 *  Project: PaperDoll                                                       *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2006 Metaphysics Industries                                  *
 *                                                                           *
 *  A double-buffered version of the Panel control.                          *
 *                                                                           *
 *****************************************************************************/



#pragma once

using namespace System::Windows::Forms;
using namespace System::Drawing;



namespace MetaphysicsIndustries { namespace Utilities { 
;



public ref class BufferedPanel : System::Windows::Forms::Panel
{

public:

	BufferedPanel(void);

	//property HScrollBar^ HorizontalScrollBar
	//{
	//	HScrollBar^ get(void);
	//}
	//property VScrollBar^ VerticalScrollBar
	//{
	//	VScrollBar^ get(void);
	//}

	//virtual property Rectangle ClientRectangle
	//{
	//	Rectangle get(void);// override;// = Panel::ClientRectangle::get;
	//}
	//virtual property Drawing::Size ClientSize
	//{
	//	virtual Drawing::Size get(void);
	//	virtual void set(Drawing::Size);
	//}

protected:

	//virtual void OnClientSizeChanged(EventArgs^) override;

	//void ScrollBars_VisibleChanged(Object^, EventArgs^);

	//HScrollBar^	hscroll;
	//VScrollBar^	vscroll;
	//Panel^		littlepanel;

};



} } 



	//this->MainPanel = gcnew BufferedPanel;
	////this->toolStripContainer1->ContentPanel->Controls->Add(this->MainPanel);
	//this->ContentPanel->Controls->Add(this->MainPanel);
	//this->MainPanel->Dock = System::Windows::Forms::DockStyle::Fill;
	//this->MainPanel->Location = System::Drawing::Point(0, 0);
	//this->MainPanel->Name = L"BufferedPanel";
	//this->MainPanel->Size = System::Drawing::Size(288, 223);
	//this->MainPanel->TabIndex = 0;