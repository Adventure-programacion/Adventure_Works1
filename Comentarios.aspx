<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comentarios.aspx.cs" Inherits="Adventure_Works.Comentarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./css/comentarios.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="comentarios__contenedor">
            <asp:Button ID="BtnVolver" runat="server" Text="Volver" OnClick="BtnVolver_Click" />
            <div>
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <div class="plantilla">
                            <h2 class="tituloFoto">
                                <%#DataBinder.Eval(Container.DataItem, "Title")  %>
                            </h2>
                            <h3 class="creadorFoto">Por:<%# DataBinder.Eval(Container.DataItem,"Owner")%></h3>
                            <img width="500" class="foto" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem, "PhotoFile")) %>"/>
                            <span class="texto">Descripcion:</span>
                            <p id="txtDescripcion" class="texto_descripcion" runat="server">
                                <%#DataBinder.Eval(Container.DataItem, "Descripcion")  %>
                            </p>
                            <span class="texto" runat="server">
                                Creado en: <%# Convert.ToString(DataBinder.Eval(Container.DataItem,"CreatedDate")).Substring(0, 10) %>
                            </span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div>
                <span class="texto">Comentarios:</span>
                <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate>
                    <div class="contenedor-comentario">
                        <span class="texto-comentario">De: <%#DataBinder.Eval(Container.DataItem, "Usuario")  %></span>
                        <span class="texto-comentario">Tema:  <%#DataBinder.Eval(Container.DataItem, "Subject")  %></span>
                        <p class="texto-comentario">Comentario: <%#DataBinder.Eval(Container.DataItem, "Body")  %></p>
                    </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:Button ID="btnAgregarComentario" runat="server" Text="Agregar comentario" OnClick="btnAgregarComentario_Click" />
            <div id="cajaComentario" class="inputs-comentario" runat="server" visible="false">
                <asp:TextBox ID="txtUsuario" CssClass="input" runat="server" placeholder="Ingrese su usuario"></asp:TextBox>
                <asp:TextBox ID="txtTema" CssClass="input" runat="server" placeholder="Ingrese el tema"></asp:TextBox>
                <textarea id="txtComentario" class="input" runat="server" cols="20" rows="4" resize="none" placeholder="Ingrese el comentario"></textarea>
                <asp:Button ID="btnAceptarComentario" runat="server" Text="Aceptar" OnClick="btnAceptarComentario_Click" />
            </div>
        </div>
    </form>
</body>
</html>
