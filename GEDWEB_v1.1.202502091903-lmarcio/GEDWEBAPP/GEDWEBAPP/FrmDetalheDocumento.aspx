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

    <script language="JavaScript" type="text/javascript">

        function init() {
        <%
        if(AppErro != null) {
        %>
            alert(unescape(appErro).replace(/\+/g, " "));
        <%
        }
        %>
        }

    </script>

</head>

<body bgcolor="#ffffff" onload="init()" style="font-family:Arial; font-size: 10px">
    <form id="AcionForm" runat="server">
    </form>

    <form name="CgiForm" action="http://localhost:9090/GEDWEB/GEDWEBAUTHCGI.exe" method="get" target="_blank">

        <table style="width:100%; height:200px; font-family:Arial; font-size: 10px">
            <tr>
                <td style="width:100%"><img src="images/img_header.jpg" style="width:100%; height:200px" alt="<%= AppTitle %>"/></td>
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
	                    <td>DocumentoRevisaoId:&nbsp;</td>
	                    <td><input type="text" name="txtDocumentoRevisaoId" value="<%= UltimoDocumentoRevisao.DocumentoRevisaoId %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoId:&nbsp;</td>
	                    <td><input type="text" name="txtDocumentoId" value="<%= Documento.DocumentoId %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoNome:&nbsp;</td>
	                    <td><input type="text" name="txtDocumentoNome" value="<%= Documento.DocumentoNome %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoNomeArquivo:&nbsp;</td>
	                    <td><input type="text" name="txtDocumentoNomeArquivo" value="<%= Documento.DocumentoNomeArquivo %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoDescricao:&nbsp;</td>
	                    <td><input type="text" name="txtDocumentoDescricao" value="<%= Documento.DocumentoDescricao %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoData:&nbsp;</td>
	                    <td><input type="text" name="txtDocumentoData" value="<%= Documento.DocumentoData %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>DocumentoRevisaoData:&nbsp;</td>
	                    <td><input type="text" name="txtDocumentoRevisaoData" value="<%= UltimoDocumentoRevisao.DocumentoRevisaoData %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td colspan="2"><b>2. Se&ccedil;&atilde;o Autor</b></td>
                    </tr>
                    <tr>
	                    <td>AutorId:&nbsp;</td>
	                    <td><input type="text" name="txtAutorId" value="<%= Autor.UsuarioId %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>AutorNome:&nbsp;</td>
	                    <td><input type="text" name="txtAutorNome" value="<%= Autor.Nome %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>AutorFormacao:&nbsp;</td>
	                    <td><input type="text" name="txtAutorFormacao" value="<%= Autor.Formacao %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>AutorEmail:&nbsp;</td>
	                    <td><input type="text" name="txtAutorEmail" value="<%= Autor.Email %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>AutorTelefone:&nbsp;</td>
	                    <td><input type="text" name="txtAutorTelefone" value="<%= Autor.Telefone %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td colspan="2"><b>3. Se&ccedil;&atilde;o Usuario</b></td>
                    </tr>
                    <tr>
	                    <td>UsuarioId:&nbsp;</td>
	                    <td><input type="text" name="txtUsuarioId" value="<%= Usuario.UsuarioId %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>UsuarioNome:&nbsp;</td>
	                    <td><input type="text" name="txtUsuarioNome" value="<%= Usuario.Nome %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>UsuarioEmail:&nbsp;</td>
	                    <td><input type="text" name="txtUsuarioEmail" value="<%= Usuario.Email %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td>UsuarioTelefone:&nbsp;</td>
	                    <td><input type="text" name="txtUsuarioTelefone" value="<%= Usuario.Telefone %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td colspan="2"><b>4. Se&ccedil;&atilde;o Dados</b></td>
                    </tr>
                    <tr>
	                    <td>ArquivoDados:&nbsp;</td>
	                    <td><input type="text" name="txtArquivoDados" value="<%= UltimoDocumentoRevisao.DocumentoRevisaoNomeDisco %>" size="255"></td>
                    </tr>
                    <tr>
	                    <td colspan="2"><b>5. Se&ccedil;&atilde;o Saida</b></td>
                    </tr>
                    <tr>
	                    <td>ArquivoSaida:&nbsp;</td>
	                    <td><input type="text" name="txtArquivoSaida" value="output-<%= UltimoDocumentoRevisao.DocumentoRevisaoNomeDisco %>.xml" size="255"></td>
                    </tr>
                    <tr>
	                    <td colspan="2"><input type="submit" name="btnEnviar" value="Enviar"></td>
                    </tr>
                    </table>

                    <br />

                    <table cellspacing="0" style="border: solid; border-color: #000000; border-width: thin; width:100%; font-family:Arial; font-size: 10px">
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

                    </table>

                </td>
            </tr>
        </table>

    </form>

</body>

</html>
