Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Input
Imports DevExpress.Mvvm

Namespace WpfApplication2
	Public Class SpreadsheetViewModel
		Private _Captions As ObservableCollection(Of CustomHeaderCaption)
		Public Sub New()
			Captions = New ObservableCollection(Of CustomHeaderCaption)()
			FillCaptions()
		End Sub
		Public Property Captions() As ObservableCollection(Of CustomHeaderCaption)
			Get
				Return _Captions
			End Get
			Set(ByVal value As ObservableCollection(Of CustomHeaderCaption))
				_Captions = value
			End Set
		End Property

		Private Sub FillCaptions()
			Captions.Add(New CustomHeaderCaption("A", "Column 1"))
			Captions.Add(New CustomHeaderCaption("B", "Column 2"))
			Captions.Add(New CustomHeaderCaption("C", "Column 3"))

			Captions.Add(New CustomHeaderCaption("1", "Row 1"))
			Captions.Add(New CustomHeaderCaption("2", "Row 2"))
			Captions.Add(New CustomHeaderCaption("3", "Row 3"))
		End Sub
	End Class

	Public Class CustomHeaderCaption
		Public Property OriginalCaption() As String

		Public Property NewHeader() As String
		Public Sub New(ByVal oldText As String, ByVal newText As String)
			Me.OriginalCaption = oldText
			Me.NewHeader = newText
		End Sub


	End Class
End Namespace
