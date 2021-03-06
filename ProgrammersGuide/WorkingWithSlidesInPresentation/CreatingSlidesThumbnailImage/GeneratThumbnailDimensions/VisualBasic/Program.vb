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
Imports System.Drawing

Namespace GeneratThumbnailDimensions
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate a Presentation class that represents the presentation file
			Using pres As New Presentation(dataDir & "Aspose.pptx")

				'Access the first slide
				Dim sld As ISlide = pres.Slides(0)

				'User defined dimension
				Dim desiredX As Integer = 1200
				Dim desiredY As Integer = 800

				'Getting scaled value  of X and Y
				Dim ScaleX As Single = CSng(1.0 / pres.SlideSize.Size.Width) * desiredX
				Dim ScaleY As Single = CSng(1.0 / pres.SlideSize.Size.Height) * desiredY

				'Create a full scale image
				Dim bmp As Bitmap = sld.GetThumbnail(ScaleX, ScaleY)

				'Save the image to disk in JPEG format
				bmp.Save(dataDir & "Thumbnail.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

			End Using
		End Sub
	End Class
End Namespace