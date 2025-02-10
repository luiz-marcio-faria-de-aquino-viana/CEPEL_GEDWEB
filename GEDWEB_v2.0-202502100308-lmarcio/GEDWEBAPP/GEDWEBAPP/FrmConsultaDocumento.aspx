<!--
// Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
//
// ConsultaDocumento.aspx
// Autor:
//   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
//   Unidade: Universidade do Estado do Rio de Janeiro
//   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
//   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
//
// Revisoes: ...
//
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmConsultaDocumento.aspx.cs" Inherits="GEDWEBAPP.ConsultaDocumento" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" />

<html>

<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=ISO-8859-1" />
    <title><%= AppTitle %></title>
</head>

<body bgcolor="#ffffff" onload="init()" style="font-family:Arial; font-size: 10px">
    <form id="AcionForm" runat="server" method="post" enctype="multipart/form-data">

        <table style="width:100%; height:200px; font-family:Arial; font-size: 10px">
            <tr>
                <td style="width:100%"><img src="images/img_header.jpg" style="width:100%; height:200px" alt="<%= AppTitle %>"/></td>
            </tr>
        </table>

        <br />

        <table cellspacing="0" style="border: solid; border-color: #FFFFFF; border-width: thin; width:100%; font-family:Arial; font-size: 10px">
            <tr>
                <td align="center" style="background-color: #808080; border: solid; border-color: #FFFFFF; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                    <a href="FrmConsultaDocumento.aspx">
                        <b>Home</b>
                    </a>
                </td>
                <td align="center" style="background-color: #808080; border: solid; border-color: #FFFFFF; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                    <a href="FrmCadastroDocumento.aspx">
                        <b>Novo</b>
                    </a>
                </td>
            </tr>
        </table>

        <br />

        <table style="width:100%; font-family:Arial; font-size: 10px">
            <tr>
                <td style="width:100%">

                    <table cellspacing="0" style="border: solid; border-color: #000000; border-width: thin; width:100%; font-family:Arial; font-size: 10px">
                        <tr>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Codigo</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Nome</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Arquivo</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Descricao</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Data</b>
                            </td>
                        </tr>
    
                        <% if(LsDocumento != null) { %>

                            <% foreach (GEDWEBAPP.Apps.Record.DocumentoRecord oDocumento in LsDocumento) { %>
                            <tr>
                                <td align="center" style="border: solid; border-color: #000000; border-width: thin; width:100px;">
                                    <%= oDocumento.DocumentoId %>
                                </td>
                                <td align="left" style="border: solid; border-color: #000000; border-width: thin; width:300px;">
                                    <a href="FrmDetalheDocumento.aspx?DocumentoId=<%= oDocumento.DocumentoId %>">
                                    <%= oDocumento.DocumentoNome %>
                                    </a>
                                </td>
                                <td align="left" style="border: solid; border-color: #000000; border-width: thin; width:300px;">
                                    <%= oDocumento.DocumentoNomeArquivo %>
                                </td>
                                <td align="left" style="border: solid; border-color: #000000; border-width: thin; width:300px;">
                                    <%= oDocumento.DocumentoDescricao %>
                                </td>
                                <td align="center" style="border: solid; border-color: #000000; border-width: thin; width:100px;">
                                    <%= oDocumento.DocumentoData %>
                                </td>
                            </tr>
                            <% } %>

                        <% } %>

                    </table>

                </td>
            </tr>
        </table>

    </form>

</body>

</html>
