Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Definir una lista de ejemplo
        Dim listaClientes As New List(Of Cliente)()

        ' Agregar clientes a la lista
        Dim cliente1 As New Cliente()
        cliente1.Nombre = "Juan"
        cliente1.Edad = 30
        cliente1.FechaRegistro = DateTime.Now
        cliente1.Saldo = 1000.5
        listaClientes.Add(cliente1)

        Dim cliente2 As New Cliente()
        cliente2.Nombre = "María"
        cliente2.Edad = 25
        cliente2.FechaRegistro = DateTime.Now.AddDays(-15)
        cliente2.Saldo = 500.75
        listaClientes.Add(cliente2)

        ' Guardar la lista en una variable de sesión para acceder a ella desde la página ASPX
        Session("MiLista") = listaClientes

        ' Verificar si la lista tiene elementos (esto es opcional, dependiendo de tus necesidades)
        If listaClientes.Count = 0 Then
            ' Si la lista está vacía, mostrar un mensaje de error en un Label
            lblMensaje.Text = "La lista está vacía."
        End If

        ' Enlazar el Repeater solo si no es una postback
        If Not IsPostBack Then
            Repeater1.DataSource = Session("MiLista")
            Repeater1.DataBind()
        End If
    End Sub
End Class


Public Class Cliente
    Public Property Nombre As String
    Public Property Edad As Integer
    Public Property FechaRegistro As DateTime
    Public Property Saldo As Decimal
    ' Otras propiedades según sea necesario
End Class