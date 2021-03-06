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
Imports Aspose.Slides.Export
Imports Aspose.Slides.Animation
Imports System.Drawing

Namespace AnimationsOnShapes
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create directory if it is not already present.
			Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
			If (Not IsExists) Then
				System.IO.Directory.CreateDirectory(dataDir)
			End If

			'Instantiate PrseetationEx class that represents the PPTX
			Using pres As New Presentation()
				Dim sld As ISlide = pres.Slides(0)

				'Now create effect "PathFootball" for existing shape from scratch.
				Dim ashp As IAutoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25)

				ashp.AddTextFrame("Animated TextBox")

				'Add PathFootBall animation effect
				pres.Slides(0).Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.AfterPrevious)

				'Create some kind of "button".
				Dim shapeTrigger As IShape = pres.Slides(0).Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20)

				'Create sequence of effects for this button.
				Dim seqInter As ISequence = pres.Slides(0).Timeline.InteractiveSequences.Add(shapeTrigger)

				'Create custom user path. Our object will be moved only after "button" click.
				Dim fxUserPath As IEffect = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick)

				'Created path is empty so we should add commands for moving.
				Dim motionBhv As IMotionEffect = (CType(fxUserPath.Behaviors(0), IMotionEffect))

				Dim pts(0) As PointF
				pts(0) = New PointF(0.076f, 0.59f)
				motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, True)
				pts(0) = New PointF(-0.076f, -0.59f)
				motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, False)
				motionBhv.Path.Add(MotionCommandPathType.End, Nothing, MotionPathPointsType.Auto, False)

				'Write the presentation as PPTX to disk
				pres.Save(dataDir & "AnimExample.pptx", SaveFormat.Pptx)

			End Using
		End Sub
	End Class
End Namespace