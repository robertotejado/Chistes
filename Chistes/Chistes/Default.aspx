<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Sitio.Master" EnableEventValidation="true"  AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Chistes._Default" %>

<%@ Import Namespace="System.Data.OleDb" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3></h3>
    <ol class="round">
        <li class="one"></li>
        <li class="two"></li>
        <li class="three"></li>
    </ol>
    
    
       <!-- contact form -->
                    <div class="add-comment contact-form boxed">

                        <div class="comment-form">
                            </div>
                                <div class="add-comment-title"><h3>Escriba su chistaco</h3></div>
                                <div class="form-inner">
                                    <div class="field_text">
  <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        
                                    </div>
                                   
                                    <div class="clear"></div>
                                   
                                    <div class="field_select">
                                        <label for="contact_subject" class="label_title">Categoria</label>
    <asp:DropDownList ID="listaCategorias" runat="server">
     <asp:ListItem>Futbol</asp:ListItem>
        <asp:ListItem>Lepe</asp:ListItem>
        <asp:ListItem>Chiquito</asp:ListItem>
      </asp:DropDownList>
                                     </div>
                                        <div class="clear"></div>
                                      <span class="btn btn-hover">                                 
 <asp:Button ID="Button1" runat="server" Text="Enviar" />
                                          </span>
                                    <div class="clear"></div>
                                 </div>
                                 </div>
                      
                    <!--/ contact form -->
   
    <asp:GridView ID="chistacos" runat="server"></asp:GridView>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <% 
                If (IsPostBack) Then
                    Label1.Text = TextBox1.Text
                Else
                    Label1.Text = "Error"
                     End If
            
                
            %>
</asp:Content>
