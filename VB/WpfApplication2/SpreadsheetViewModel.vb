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
        Implements INotifyPropertyChanged

        Private _Captions As ObservableCollection(Of CustomHeaderCaption)
        Public Sub New()
            Captions = New ObservableCollection(Of CustomHeaderCaption)()
            AddHandler Captions.CollectionChanged, AddressOf Captions_CollectionChanged
            EmptyDocumentCreatedCommand = New DelegateCommand(Of Object)(AddressOf EmptyDocumentCreatedExecute)
            DocumentLoadedCommand = New DelegateCommand(Of Object)(AddressOf DocumentLoadedCommandExecute)
        End Sub
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub NotifyPropertyChanged(Optional ByVal propertyName As String = "")
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
        Private Sub Captions_CollectionChanged(ByVal sender As Object, ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
            NotifyPropertyChanged("Captions")
        End Sub
        Private privateDocumentLoadedCommand As ICommand
        Public Property DocumentLoadedCommand() As ICommand
            Get
                Return privateDocumentLoadedCommand
            End Get
            Private Set(ByVal value As ICommand)
                privateDocumentLoadedCommand = value
            End Set
        End Property
        Private privateEmptyDocumentCreatedCommand As ICommand
        Public Property EmptyDocumentCreatedCommand() As ICommand
            Get
                Return privateEmptyDocumentCreatedCommand
            End Get
            Private Set(ByVal value As ICommand)
                privateEmptyDocumentCreatedCommand = value
            End Set
        End Property
        Public Property Captions() As ObservableCollection(Of CustomHeaderCaption)
            Get
                Return _Captions
            End Get
            Set(ByVal value As ObservableCollection(Of CustomHeaderCaption))
                _Captions = value
                NotifyPropertyChanged("Captions")
            End Set
        End Property

        Private Sub EmptyDocumentCreatedExecute(ByVal sender As Object)
            Captions.Clear()
        End Sub
        Private Sub DocumentLoadedCommandExecute(ByVal sender As Object)
            FillCaptions()
        End Sub

        Private Sub FillCaptions()
            Captions.Add(New CustomHeaderCaption("A", "Column 1"))
            Captions.Add(New CustomHeaderCaption("B", "Column 2"))
            Captions.Add(New CustomHeaderCaption("C", "Column 3"))
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
