/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* AppError.cs
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.Base
{

    public class AppError
    {
    //Public Static
        public static string ERR_ARQUIVO_NAO_ENCONTRATO = "Arquivo nao encontrado";
        public static string ERR_CAMPO_NAO_INFORMADO = "Campo nao informado";
        public static string ERR_CAMPO_INVALIDO_OU_NAO_INFORMADO = "Campo invalido ou nao informado";
        public static string ERR_CAMPOS_OBRIGATORIOS_NAO_INFORMADOS = "Campos obrigatorios nao informados";
        public static string ERR_FALHA_PROCESSAMENTO = "Falha no processamento";

    //Public

        public static string getClassName(string fullClassName)
        {
            string[] arr = fullClassName.Split('.');
            int n = arr.Length;
            if (n > 0)
                return arr[n - 1];
            return fullClassName;
        }

        public static void showWarn(int debugLevel, string warnmsg, string fullClassName)
        {
            if (debugLevel != AppDefs.DEBUG_LEVEL) return;

            string className = getClassName(fullClassName);

            string str = string.Format("WARN({0}): {1}", className, warnmsg);
            Console.WriteLine(str);
        }

        public static void showError(string errmsg, string fullClassName)
        {
            string className = getClassName(fullClassName);

            string str = string.Format("ERR({0}): {1}", className, errmsg);
            Console.WriteLine(str);
        }

    }

}
