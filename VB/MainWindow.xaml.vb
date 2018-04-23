Imports DevExpress.Data.Linq
Imports System
Imports System.Windows

Namespace DXGrid_EF4_ServerMode
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            'You can use this demo code to generate a large data set, if currently, you don't have a large database for testing.

            Dim dataContext_Renamed As New NorthwindEntities()
            Try
                For i As Integer = 0 To 99999

                    Dim product_Renamed As Product = New Product With {.ProductName = String.Format("Product({0})", i), .UnitPrice = (New Random()).Next(1000)}
                    dataContext_Renamed.Products.AddObject(product_Renamed)
                Next i
                dataContext_Renamed.SaveChanges()
            Catch e As Exception
                MessageBox.Show(e.ToString())
            End Try
            grid.ItemsSource = New EntityServerModeSource() With {.ElementType = GetType(Product), .KeyExpression = "ProductID", .QueryableSource = dataContext_Renamed.Products}
        End Sub
    End Class
End Namespace