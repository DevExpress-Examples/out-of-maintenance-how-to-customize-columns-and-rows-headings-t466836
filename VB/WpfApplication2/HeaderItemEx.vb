Imports System
Imports System.Globalization
Imports System.Linq
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Markup
Imports DevExpress.Xpf.Spreadsheet
Imports DevExpress.Xpf.Spreadsheet.Internal
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace WpfApplication2
	Public Class HeaderConverter
		Implements IMultiValueConverter

		Public Function Convert(ByVal value() As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
			If value Is Nothing OrElse value(0) Is Nothing Then
				Return Nothing
			End If
			Dim columnHeader As String = value(0).ToString()
			Dim collection As ObservableCollection(Of CustomHeaderCaption) = TryCast(value(1), ObservableCollection(Of CustomHeaderCaption))
			If collection Is Nothing OrElse collection.Count = 0 Then
				Return columnHeader
			End If

			Dim result As String = collection.Where(Function(l) l.OriginalCaption = columnHeader).Select(Function(caption) caption.NewHeader).FirstOrDefault()
			If result IsNot Nothing Then
				Return result
			End If

			Return columnHeader
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetTypes() As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
			Return TryCast(value, Object())
		End Function
	End Class
End Namespace
