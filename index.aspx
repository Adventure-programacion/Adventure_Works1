<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Adventure_Works.index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Adventure Works</title>
    <link rel="stylesheet" href="./css/cabecera/cabecera.css"/>
    <link rel="stylesheet" href="./css/nav/nav.css"/>
    <link rel="stylesheet" href="./css/style.css" />
    <link rel="stylesheet" href="./css/tarjeta/tarjeta.css"/>
    
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <header class="cabecera">
                <h1 class="cabecera__titulo">Compartir Fotos Adventure Works</h1>
               <asp:HyperLink ID="Hplink2" runat="server" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/login.aspx">Cerrar Sesion</asp:HyperLink>
                <asp:HyperLink ID="Hplink" runat="server" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/login.aspx">Inicio de Sesion</asp:HyperLink>
                <br />
                <asp:Label ID="lblusuario" runat="server"></asp:Label>

            </header>
            <nav class="nav">
                <asp:Button class="nav__boton" ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" />
                <asp:Button class="nav__boton" ID="btnGaleria" runat="server" Text="Galeria" OnClick="btnGaleria_Click" />
                <asp:Button class="nav__boton" ID="btnAgregarFoto" runat="server" Text="Agregar Foto" OnClick="btnAgregarFoto_Click" />
                <asp:Button class="nav__boton" ID="btnPresentacion" runat="server" Text="Presentacion" OnClick="btnPresentacion_Click" />
            </nav>
            <main class="principal">
                
                 <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <asp:HiddenField ID="txtIDfoto" runat="server" value=' <%# DataBinder.Eval(Container.DataItem,"PhotoID")%>'/>
                            <section class="tarjeta">
                                <h2 class="tarjeta__titulo">
                                    <%#DataBinder.Eval(Container.DataItem, "Title")  %>
                                </h2>
                                <img width="100" class="tarjeta__imagen" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem, "PhotoFile")) %>"/>
                                <h3 class="tarjeta__creador">Por:<%# DataBinder.Eval(Container.DataItem,"Owner")%></></h3>                       
                                <span class="tarjeta__fecha">
                                    Creado en: <%# Convert.ToString(DataBinder.Eval(Container.DataItem,"CreatedDate")).Substring(0, 10) %>
                                </span>
                                <asp:LinkButton ID="LinkButton1" CssClass="btn-Detalles" runat="server"  CommandName="mostrarDetalles" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"PhotoID")%>'>Detalles</asp:LinkButton>
                            </section>
                        </ItemTemplate>
                </asp:Repeater>
            </main>
        </div>
       
    </form>
</body>
    <!--
                <section class="tarjeta">
                    <h2 class="tarjeta__titulo">"Titulo"</h2>
                    <h3 class="tarjeta__creador">Por:Creador</h3>
                    <div class="tarjeta__imagen"></div>
                    <span class="tarjeta__fecha">Creado en: fecha</span>
                </section>
        <link rel="stylesheet" href="./Content/bootstrap.css"/>
                -->
</html>
