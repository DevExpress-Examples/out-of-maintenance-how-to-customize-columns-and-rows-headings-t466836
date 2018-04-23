Imports System
Imports System.Linq
Imports System.Windows
Imports System.Collections.Generic

Namespace WpfApplication2
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            ssControl1.LoadDocument("Book1.xlsx")
        End Sub
    End Class


End Namespace
