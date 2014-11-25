Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class _Default
    Inherits Page




    Sub Page_Load()
        Cargar_Categorias()
        Cargar_Chistacos()
        If (IsPostBack) Then
            ' Label1.Text = TextBox1.Text & ",bienvenido a Visual Studio!"

            Dim chiste As String = TextBox1.Text.ToString()
            Dim categoria As String = listaCategorias.SelectedValue.ToString()
            InsertarChistaco(chiste, categoria)

            Cargar_Chistacos()

        End If
    End Sub

    Sub Cargar_Categorias()
       ''''''''''''''''''''''''''''''
        Dim sql As String = "SELECT categoria FROM categoria_chistaco"
        Dim dbcon = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Server.MapPath("~/App_Data/chistacos.mdb"))
        Dim cmd As New OleDbCommand(sql, dbcon)
        Dim da As New OleDbDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        listaCategorias.DataTextField = ds.Tables(0).Columns("categoria").ToString()
        listaCategorias.DataValueField = ds.Tables(0).Columns("categoria").ToString()
        listaCategorias.DataSource = ds.Tables(0)
        listaCategorias.DataBind()

    End Sub

    Sub Cargar_Chistacos()
        Dim dbconn, sql
        dbconn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Server.MapPath("~/App_Data/chistacos.mdb"))
        dbconn.Open()
        sql = "SELECT chistaco FROM chistaco ORDER BY Id DESC"
        Dim custCmd As OleDbCommand = New OleDbCommand(sql, dbconn)
        Dim custReader As OleDbDataReader = custCMD.ExecuteReader()
        'Dim orderReader As OleDbDataReader

        Dim dt As DataTable = New DataTable()
        dt.Load(custReader)
        chistacos.DataSource = dt
        chistacos.DataBind()

        dbconn.Close()
    End Sub

    Sub InsertarChistaco(ByVal chiste As String, ByVal categoria As String)
        Dim dbconn, sql
        'Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
        dbconn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Server.MapPath("~/App_Data/chistacos.mdb"))
        dbconn.Open()
        'sql = "INSERT INTO chistaco VALUES ('','" & categoria & "','" & chiste & "')"
        sql = "INSERT INTO chistaco( categoria, chistaco) VALUES ('" & categoria & "','" & chiste & "')"
        Dim command As OleDbCommand = New OleDbCommand(sql, dbconn)

        command.ExecuteNonQuery()
        dbconn.Close()
    End Sub

End Class