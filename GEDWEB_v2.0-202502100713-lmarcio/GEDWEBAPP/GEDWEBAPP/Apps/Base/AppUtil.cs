/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* AppUtil.cs
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
using System.IO;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.Base
{

    public class AppUtil
    {
    //Public

        public static string getFileNameWithExtension(string fullFileName)
        {
            return Path.GetFileName(fullFileName);
        }

        public static string getFileNameWithoutExtension(string fullFileName)
        {
            return Path.GetFileNameWithoutExtension(fullFileName);
        }

        public static string getFullFileNameWithoutExtension(string fullFileName)
        {
            string ff = string.Format(
                "{0}\\{1}",
                Path.GetDirectoryName(fullFileName),
                Path.GetFileNameWithoutExtension(fullFileName));
            return ff;
        }

        public static List<string> readFileToList(string fileName)
        {
            List<string> lsStr = new List<string>();
            StreamReader fin = null;
            try
            {
                fin = new StreamReader(fileName);
                string sbuf = null;
                while ((sbuf = fin.ReadLine()) != null)
                {
                    lsStr.Add(sbuf);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fin != null) fin.Close();
            }
            return lsStr;
        }

        public static List<string> saveFileFromList(string fileName, List<string> lsStr)
        {
            StreamWriter fout = null;
            try
            {
                fout = new StreamWriter(fileName);
                foreach (string sbuf in lsStr)
                {
                    fout.Write(sbuf);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fout != null) fout.Close();
            }
            return lsStr;
        }

    }

}