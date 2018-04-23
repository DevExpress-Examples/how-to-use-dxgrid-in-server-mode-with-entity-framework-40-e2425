Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports DevExpress.Data.Linq

Namespace DXGrid_EF4_ServerMode
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			'You can use this demo code to generate a large data set, if currently, you don't have a large database for testing.
			Dim dataContext As New NorthwindEntities()
			Try
				For i As Integer = 0 To 99999
					Dim product As Product = New Product With {.ProductName = String.Format("Product({0})", i), .UnitPrice = New Random().Next(1000)}
					dataContext.Products.AddObject(product)
				Next i
				dataContext.SaveChanges()
			Catch e As Exception
				MessageBox.Show(e.ToString())
			End Try
			grid.ItemsSource = New LinqServerModeSource() With {.ElementType = GetType(Product), .KeyExpression = "ProductID", .QueryableSource = dataContext.Products}
		End Sub
	End Class
End Namespace