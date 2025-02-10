<!--
// Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
//
// FrmCadastroDocumento.aspx
// Autor:
//   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
//   Unidade: Universidade do Estado do Rio de Janeiro
//   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
//   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
//
// Revisoes: ...
//
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCadastroDocumento.aspx.cs" Inherits="GEDWEBAPP.FrmCadastroDocumento" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" />

<html>

<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=ISO-8859-1" />
    <title><%= AppTitle %></title>
</head>

<body bgcolor="#ffffff" onload="init()" style="font-family:Arial; font-size: 10px">

    <form id="ActionForm" runat="server" method="post" enctype="multipart/form-data">

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

                    <table style="font-family:Arial; font-size: 10px">
                    <tr>
	                    <td colspan="2"><b>1. Se&ccedil;&atilde;o Documento</b></td>
                    </tr>
                    <tr>
	                    <td>DocumentoNome:&nbsp;</td>
	                    <td><input type="text" name="txtTmpDocumentoNome" value="" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoNomeArquivo:&nbsp;</td>
	                    <td><input type="text" name="txtTmpDocumentoNomeArquivo" value="" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoDescricao:&nbsp;</td>
	                    <td><input type="text" name="txtTmpDocumentoDescricao" value="" size="255"></td>
                    </tr>
                    <tr>
	                    <td colspan="2"><b>NovoArquivo:</b>&nbsp;<input type="file" name="fileNovoArquivo" /></td>
                    </tr>
                    <tr>
	                    <td colspan="2">
                            <input type="submit" name="btnEnviar" value="Enviar" />
	                    </td>
                    </tr>
                    </table>

                </td>
            </tr>
        </table>

    </form>

</body>

</html>
