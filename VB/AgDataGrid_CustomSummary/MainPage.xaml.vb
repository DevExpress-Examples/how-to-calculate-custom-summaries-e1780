Imports Microsoft.VisualBasic
Imports System.Windows.Controls

Namespace AgDataGrid_CustomSummary
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = ProductList.GetData()
		End Sub

		Private totalPrice As Double
		Private Sub grid_CustomSummary(ByVal sender As Object, _
                                        ByVal e As DevExpress.AgData.CustomSummaryEventArgs)
			If e.SummaryProcess = _
                                                        DevExpress.AgData.CustomSummaryProcess.Start Then
				totalPrice = 0
			End If
				If e.SummaryProcess = _
                                                                         DevExpress.AgData.CustomSummaryProcess.Calculate Then
					Dim price As Double = CDbl(e.FieldValue)
					Dim quantity As Integer = CInt(Fix(e.GetValue("Quantity")))
					totalPrice += price * quantity
					e.TotalValue = totalPrice
				End If
		End Sub
	End Class
End Namespace
