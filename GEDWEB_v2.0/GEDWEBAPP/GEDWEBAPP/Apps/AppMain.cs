/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* AppMain.cs
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

using GEDWEBAPP.Apps.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps
{

    public class AppMain
    {
    //Private Static
        private static AppMain gApp;

    //Private
        private AppCtx m_ctx;

        private AppDatabase m_db;

    //Public

        public AppMain()
        {
            AppMain.gApp = this;

            init();
        }

        /* Methodes */

        public void init()
        {
            m_ctx = new AppCtx();

            m_db = new AppDatabase();
            m_db.loadAll();

            //TODO:
        }

        /* CREATE */

        public static void start()
        {
            if(AppMain.gApp == null) {
                new AppMain();
            }
        }

        public static void stop()
        {
            /* nothing todo! */
        }

        /* Getters/Setters */

        public static AppMain getApp()
        {
            return AppMain.gApp;
        }

        public AppCtx getCtx()
        {
            return m_ctx;
        }

        public AppDatabase getDatabase() 
        {
            return m_db;
        }

    }

}
