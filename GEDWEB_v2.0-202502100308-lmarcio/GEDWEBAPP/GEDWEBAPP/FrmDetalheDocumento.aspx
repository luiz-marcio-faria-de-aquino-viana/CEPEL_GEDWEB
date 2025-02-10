<!--
// Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
//
// FrmDetalheDocumento.aspx
// Autor:
//   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
//   Unidade: Universidade do Estado do Rio de Janeiro
//   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
//   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
//
// Revisoes: ...
//
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDetalheDocumento.aspx.cs" Inherits="GEDWEBAPP.FrmDetalheDocumento" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" />

<html>

<% 
    //TODO:
%>

<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=ISO-8859-1" />
    <title><%= AppTitle %></title>
</head>

<body bgcolor="#ffffff" onload="init()" style="font-family:Arial; font-size: 10px">

    <form id="ActionForm" runat="server" method="post" enctype="multipart/form-data">
	    <input type="hidden" name="txtTmpDocumentoId" value="<%= Documento.DocumentoId %>"/>

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
	                    <td><input type="text" name="txtTmpDocumentoNome" value="<%= Documento.DocumentoNome %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoNomeArquivo:&nbsp;</td>
	                    <td><input type="text" name="txtTmpDocumentoNomeArquivo" value="<%= Documento.DocumentoNomeArquivo %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoDescricao:&nbsp;</td>
	                    <td><input type="text" name="txtTmpDocumentoDescricao" value="<%= Documento.DocumentoDescricao %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoData:&nbsp;</td>
	                    <td><input type="text" name="txtTmpDocumentoData" value="<%= Documento.DocumentoData %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>NumeroRevisao:&nbsp;</td>
	                    <td><input type="text" name="txtTmpNumeroRevisao" value="<%= DocumentoRevisao.NumeroRevisao %>" size="255" readonly="readonly"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoRevisaoData:&nbsp;</td>
	                    <td><input type="text" name="txtTmpDocumentoRevisaoData" value="<%= DocumentoRevisao.DocumentoRevisaoData %>" size="255" readonly="readonly"></td>
                    </tr>
                    <tr>
	                    <td colspan="2"><b>2. Se&ccedil;&atilde;o Autor</b></td>
                    </tr>
                    <tr>
	                    <td>AutorId:&nbsp;</td>
	                    <td><input type="text" name="txtTmpAutorId" value="<%= Autor.UsuarioId %>" size="255" readonly="readonly"></td>
                    </tr>
                    <tr>
	                    <td>AutorNome:&nbsp;</td>
	                    <td><input type="text" name="txtTmpAutorNome" value="<%= Autor.Nome %>" size="255" readonly="readonly"></td>
                    </tr>
                    <tr>
	                    <td>AutorFormacao:&nbsp;</td>
	                    <td><input type="text" name="txtTmpAutorFormacao" value="<%= Autor.Formacao %>" size="255" readonly="readonly"></td>
                    </tr>
                    <tr>
	                    <td>AutorEmail:&nbsp;</td>
	                    <td><input type="text" name="txtTmpAutorEmail" value="<%= Autor.Email %>" size="255" readonly="readonly"></td>
                    </tr>
                    <tr>
	                    <td>AutorTelefone:&nbsp;</td>
	                    <td><input type="text" name="txtTmpAutorTelefone" value="<%= Autor.Telefone %>" size="255" readonly="readonly"></td>
                    </tr>
                    </table>

                    <br />

                    <table cellspacing="0" style="border: solid; border-color: #000000; border-width: thin; width:100%; font-family:Arial; font-size: 10px">
                        <tr>
	                        <td colspan="7"><b>3. Lista de Revis&otilde;es do Documento:</b></td>
                        </tr>
                        <tr>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Cod.Revisao</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Codigo</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Documento</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Arquivo Disco</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Num.Revisao</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Nome Arquivo</b>
                            </td>
                            <td align="center" style="border: solid; border-color: #000000; border-width: thin; font-family:Arial; font-size: 12px; font-weight: bold;">
                                <b>Data</b>
                            </td>
                        </tr>
    
                        <% if(LsDocumentoRevisao != null) { %>

                            <% foreach (GEDWEBAPP.Apps.Record.DocumentoRevisaoRecord oDocumentoRevisao in LsDocumentoRevisao)
                               { %>
                            <tr>
                                <td align="center" style="border: solid; border-color: #000000; border-width: thin; width:75px;">
                                    <a href="FrmDetalheDocumento.aspx?DocumentoRevisaoId=<%= oDocumentoRevisao.DocumentoRevisaoId %>">
                                    <%= oDocumentoRevisao.DocumentoRevisaoId %>
                                </td>
                                <td align="center" style="border: solid; border-color: #000000; border-width: thin; width:75px;">
                                    <%= oDocumentoRevisao.DocumentoId %>
                                </td>
                                <td align="left" style="border: solid; border-color: #000000; border-width: thin; width:250px;">
                                    <%= Documento.DocumentoNome %>
	                            </td>
                                <td align="left" style="border: solid; border-color: #000000; border-width: thin; width:300px;">
                                    <%= Documento.DocumentoNomeArquivo %>
	                            </td>
                                <td align="left" style="border: solid; border-color: #000000; border-width: thin; width:100px;">
                                    <%= oDocumentoRevisao.NumeroRevisao %>
                                </td>
                                <td align="left" style="border: solid; border-color: #000000; border-width: thin; width:300px;">
                                    <%= oDocumentoRevisao.DocumentoRevisaoNomeDisco %>
                                </td>
                                <td align="left" style="border: solid; border-color: #000000; border-width: thin; width:100px;">
                                    <%= oDocumentoRevisao.DocumentoRevisaoData %>
                                </td>
                            </tr>
                            <% } %>

                        <% } %>

                        <tr>
	                        <td colspan="7"><b>NovoArquivo:</b>&nbsp;<input type="file" name="fileNovoArquivo" /></td>
                        </tr>
                    </table>

                    <br />

                    <table style="font-family:Arial; font-size: 10px">
                    <tr>
	                    <td colspan="2">
                            <input type="submit" name="btnAlterar" value="Alterar" />
	                    </td>
                    </tr>
                    </table>

                </td>
            </tr>
        </table>

    </form>

    <form name="CgiForm" action="http://localhost:9090/GEDWEB/GEDWEBAUTHCGI.exe" method="get" target="_blank">
    <input type="hidden" name="txtDocumentoRevisaoId" value="<%= DocumentoRevisao.DocumentoRevisaoId %>" />
    <input type="hidden" name="txtDocumentoId" value="<%= Documento.DocumentoId %>" />
	<input type="hidden" name="txtDocumentoNome" value="<%= Documento.DocumentoNome %>" />
	<input type="hidden" name="txtDocumentoNomeArquivo" value="<%= Documento.DocumentoNomeArquivo %>" />
	<input type="hidden" name="txtDocumentoDescricao" value="<%= Documento.DocumentoDescricao %>" />
	<input type="hidden" name="txtDocumentoData" value="<%= Documento.DocumentoData %>" />
	<input type="hidden" name="txtDocumentoRevisaoData" value="<%= DocumentoRevisao.DocumentoRevisaoData %>" />
	<input type="hidden" name="txtAutorId" value="<%= Autor.UsuarioId %>" />
	<input type="hidden" name="txtAutorNome" value="<%= Autor.Nome %>" />
	<input type="hidden" name="txtAutorFormacao" value="<%= Autor.Formacao %>" />
	<input type="hidden" name="txtAutorEmail" value="<%= Autor.Email %>" />
	<input type="hidden" name="txtAutorTelefone" value="<%= Autor.Telefone %>" />
	<input type="hidden" name="txtUsuarioId" value="<%= Usuario.UsuarioId %>" />
	<input type="hidden" name="txtUsuarioNome" value="<%= Usuario.Nome %>" />
	<input type="hidden" name="txtUsuarioEmail" value="<%= Usuario.Email %>" />
	<input type="hidden" name="txtUsuarioTelefone" value="<%= Usuario.Telefone %>" />
	<input type="hidden" name="txtArquivoDados" value="<%= DocumentoRevisao.DocumentoRevisaoNomeDisco %>" />
	<input type="hidden" name="txtArquivoSaida" value="output-<%= DocumentoRevisao.DocumentoRevisaoNomeDisco %>.xml" />
	
    <table style="font-family:Arial; font-size: 10px">
    <tr>
	    <td colspan="2">
            <input type="submit" name="btnBaixar" value="Baixar">
	    </td>
    </tr>
    </table>

    </form>

</body>

</html>
