'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Slides. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Slides
Imports Aspose.Slides.Pptx

Namespace AddingPlainLineToSlide
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate PresentationEx class that represents the PPTX file
			Dim pres As New PresentationEx()

			'Get the first slide
			Dim sld As SlideEx = pres.Slides(0)

			'Add an autoshape of type line
			Dim idx As Integer = sld.Shapes.AddAutoShape(ShapeTypeEx.Line, 50, 150, 300, 0)

			'Write the PPTX to Disk
			pres.Write(dataDir & "LineShape1.pptx")

		End Sub
	End Class
End Namespace