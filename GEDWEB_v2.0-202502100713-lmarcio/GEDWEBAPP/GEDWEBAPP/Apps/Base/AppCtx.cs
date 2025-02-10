/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* AppCtx.cs
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

    public class AppCtx
    {
    //Private
        private string m_homeDir;
        //
        private string m_binDir;
        private string m_confDir;
        private string m_dataDir;
        private string m_docsDir;
        private string m_repositorioDir;
        private string m_templateDir;
        private string m_outputDir;
        //
        private string m_confFile;
        private string m_confFileDefault;
        //
        private string m_templateFile;

    //Public

        public AppCtx()
        {
            init();
        }

        /* Methodes */

        public void init()
        {
            m_homeDir = System.Environment.GetEnvironmentVariable(AppDefs.APP_HOME);

            if(m_homeDir == null)
                m_homeDir = AppDefs.CTX_HOMEDIR;

            m_binDir = m_homeDir + AppDefs.CTX_BINDIR;
            m_confDir = m_homeDir + AppDefs.CTX_CONFDIR;
            m_dataDir = m_homeDir + AppDefs.CTX_DATADIR;
            m_docsDir = m_homeDir + AppDefs.CTX_DOCSDIR;
            m_repositorioDir = m_homeDir + AppDefs.CTX_REPOSITORIODIR;
            m_templateDir = m_homeDir + AppDefs.CTX_TEMPLATESDIR;
            m_outputDir = m_homeDir + AppDefs.CTX_OUTPUTDIR;

            m_confFile = m_confDir + AppDefs.CTX_CONFFILE;
            m_confFileDefault = m_confDir + AppDefs.CTX_CONFFILEDEFAULT;

            m_templateFile = m_templateDir + AppDefs.CTX_TEMPLATEFILE;
        }

        /* Getters/Setters */

        public string HomeDir
        {
            get { return m_homeDir; }
        }

        public string BinDir
        {
            get { return m_binDir; }
        }

        public string ConfDir
        {
            get { return m_confDir; }
        }

        public string DataDir
        {
            get { return m_dataDir; }
        }

        public string DocsDir
        {
            get { return m_docsDir; }
        }

        public string RepositorioDir
        {
            get { return m_repositorioDir; }
        }

        public string TemplateDir
        {
            get { return m_templateDir; }
        }

        public string OutputDir
        {
            get { return m_outputDir; }
        }

        public string ConfFile
        {
            get { return m_confFile; }
        }

        public string ConfFileDefault
        {
            get { return m_confFileDefault; }
        }

        public string TemplateFile
        {
            get { return m_templateFile; }
        }

    }

}
