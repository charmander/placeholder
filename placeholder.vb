Option Strict On
Option Explicit On

Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Module Application
	Function Main(args As String()) As Integer
		Dim width, height As Integer

		If args.Length <> 3 OrElse Not Integer.TryParse(args(0), width) OrElse Not Integer.TryParse(args(1), height) Then
			Console.Error.WriteLine("Usage: placeholder <width> <height> <output>")
			Return 1
		End If

		If width <= 0 OrElse height <= 0 Then
			Console.Error.WriteLine("Width and height must be positive")
			Return 1
		End If

		Dim outputPath As String = args(2)

		Using _
				b As New Bitmap(width, height),
				f As New Font("Fira Sans", 16.0f),
				p As New Pen(Color.DimGray, width:=8.0f),
				g As Graphics = Graphics.FromImage(b)
			p.Alignment = PenAlignment.Inset

			Dim layoutRectangle As New RectangleF(0.0f, 0.0f, width, height)
			Dim text As String = String.Format("{0}×{1}", width, height)

			Dim textFormat As New StringFormat()
			textFormat.Alignment = StringAlignment.Center
			textFormat.LineAlignment = StringAlignment.Center

			g.Clear(Color.Gray)
			g.DrawRectangle(p, 0, 0, width, height)
			g.DrawString(text, f, Brushes.Black, layoutRectangle, textFormat)

			b.Save(outputPath)
		End Using

		Return 0
	End Function
End Module
