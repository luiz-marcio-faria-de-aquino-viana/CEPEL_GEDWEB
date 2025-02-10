<!--
// Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
//
// FrmLogin.aspx
// Autor:
//   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
//   Unidade: Universidade do Estado do Rio de Janeiro
//   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
//   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
//
// Revisoes: ...
//
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="GEDWEBAPP.FrmLogin" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" />

<html>

<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=ISO-8859-1" />
    <title><%= AppTitle %></title>
</head>

<body bgcolor="#ffffff" onload="init()">
    <form id="AcionForm" runat="server" method="post" enctype="multipart/form-data">

        <table style="width:100%; height:200px;">
            <tr>
                <td style="width:100%"><img src="images/img_header.jpg" style="width:100%; height:200px" alt="<% Response.Write(AppTitle); %>"/></td>
            </tr>
        </table>

        <br />

        <table style="width:100%; height:300px;">
            <tr>
                <td style="width:100%">

                    <center>

                    <table style="background-color:rgba(132, 154, 216, 0.80); width:400px; height:200px; font-family: Arial; font-size: 12px;">
                        <tr>
                            <td align="center" colspan="2" style="font-family: Arial; font-size: 14px;">
                                <b>Informe o seu login e senha de acesso</b>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width:100px;">
                                <b>Login:&nbsp;</b>
                            </td>
                            <td style="width:300px;">
                                <input type="text" name="txtLogin" value="<%= TxtLogin %>" size="30" maxlength="30" style="width:250px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width:100px;">
                                <b>Senha:&nbsp;</b>
                            </td>
                            <td style="width:300px;">
                                <input type="text" name="txtSenha" value="<%= TxtSenha %>" size="30" maxlength="30" style="width:250px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <input type="submit" name="btnEntrar" value="Entrar" style="width:75%;" />
                            </td>
                        </tr>
                    </table>

                    </center>

                </td>
            </tr>
        </table>

    </form>

</body>

</html>
