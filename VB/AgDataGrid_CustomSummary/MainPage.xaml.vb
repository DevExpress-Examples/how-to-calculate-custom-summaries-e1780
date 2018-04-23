Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Data

Namespace AgDataGrid_CustomSummary
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = ProductList.GetData()
		End Sub

		Private totalPrice As Double
		Private Sub grid_CustomSummary(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs)
			If e.SummaryProcess = CustomSummaryProcess.Start Then
				totalPrice = 0
			End If
			If e.SummaryProcess = CustomSummaryProcess.Calculate Then
				Dim price As Double = CDbl(e.FieldValue)
				Dim quantity As Integer = CInt(Fix(e.GetValue("Quantity")))
				totalPrice += price * quantity
				e.TotalValue = totalPrice
			End If
		End Sub
	End Class
End Namespace
