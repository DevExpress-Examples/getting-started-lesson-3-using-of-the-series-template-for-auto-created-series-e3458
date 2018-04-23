Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows.Controls
Imports System.Xml.Linq

Namespace SilverlightApplication3
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			chartControl.DataSource = CreateDataSource()
		End Sub

		Private Function CreateDataSource() As List(Of GSP)
			Dim document As XDocument = DataLoader.LoadXmlFromResources("/GSP.xml")
			Dim result As New List(Of GSP)()
			If document IsNot Nothing Then
				For Each element As XElement In document.Element("GSPs").Elements()
					Dim region As String = element.Element("Region").Value
					Dim year As String = element.Element("Year").Value
					Dim product As Double = Convert.ToDouble(element.Element("Product").Value, CultureInfo.InvariantCulture)
					result.Add(New GSP(region, year, product))
				Next element
			End If
			Return result
		End Function

		Public NotInheritable Class DataLoader
			Private Sub New()
			End Sub
			Public Shared Function LoadXmlFromResources(ByVal fileName As String) As XDocument
				Try
					Return XDocument.Load("/SilverlightApplication3;component" & fileName)
				Catch
					Return Nothing
				End Try
			End Function
		End Class

		Public Class GSP
			Private ReadOnly region_Renamed As String
			Private ReadOnly year_Renamed As String
			Private ReadOnly product_Renamed As Double

			Public ReadOnly Property Region() As String
				Get
					Return region_Renamed
				End Get
			End Property
			Public ReadOnly Property Year() As String
				Get
					Return year_Renamed
				End Get
			End Property
			Public ReadOnly Property Product() As Double
				Get
					Return product_Renamed
				End Get
			End Property

			Public Sub New(ByVal region As String, ByVal year As String, ByVal product As Double)
				Me.region_Renamed = region
				Me.year_Renamed = year
				Me.product_Renamed = product
			End Sub
		End Class
	End Class
End Namespace



