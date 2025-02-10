/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* Error.h
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 07/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

#ifndef __ERROR_H
#define __ERROR_H								(TCHAR*)"__ERROR_H"

/* ERROR MESSAGES
*/
#define ERR_CANTALLOCATEMEMORY                  "Can't allocate memory"
#define ERR_FILENOTFOUND                        "File not found"
#define ERR_CANTOPENFILE                        "Can't open file"
#define ERR_SEQUENCEVALUEOVERFLOW               "Sequence value overflow"
#define ERR_INVALIDUSERNAMEPASSWORD             "Invalid username password"
#define ERR_CURRENTUSERDONTHAVERIGHTS           "Current user don't have sufficient rights"
#define ERR_INVALIDTABLENAME                    "Invalid table name"
#define ERR_CANTFINDOBJECTID                    "Can't find object id"
#define ERR_CANTFINDKEY                         "Can't find key"
#define ERR_MAXNUMBERENTRIESREACHED             "Number maximum of entries reached"
#define ERR_CANTCREATESOCKET                    "Can't create socket"
#define ERR_CANTBINDSOCKET                      "Can't bind socket"
#define ERR_CANTLISTENPORT                      "Can't listen, port in use"
#define ERR_CANTCREATELISTNERTHREAD             "Can't create listening thread"
#define ERR_CANTSENDMESSAGE                     "Can't send message"
#define ERR_CANTCONNECTSOCKET                   "Can't open socket connection"
#define ERR_CANTRECVMESSAGE                     "Can't receive message"
#define ERR_CANTSETSOCKETOPT                    "Can't set socket options"
#define ERR_CANTMODULESTARTTHREAD               "Can't run module start thread"
#define ERR_CANTMODULEEXECUTETHREAD             "Can't run module execution thread"
#define ERR_CANTMODULETRAINTHREAD               "Can't run module trainning thread"
#define ERR_CANTMODULETRAINWITHMASKTHREAD       "Can't run module trainning with mask thread"
#define ERR_CANTMODULECLASSIFYTHREAD            "Can't run module classification thread"
#define ERR_CANTFINDREMOTEUNIT                  "Can't find remote unit"
#define ERR_CANTEXECDISKMANWRITETHREAD          "Can't execute disk manager write thread"
#define ERR_CANTCOMPLETEDISKMANWRITETHREAD      "Can't complete disk manager write thread"
#define ERR_CANTEXECDISKMANREADTHREAD           "Can't execute disk manager read thread"
#define ERR_CANTCOMPLETEDISKMANREADTHREAD       "Can't complete disk manager read thread"
#define ERR_CANTCREATEMUTEX                     "Can't create mutex (=%s)"
#define ERR_DISKMANCANTCREATETHREAD             "Can't create disk manager thread"
#define ERR_DISKMANTHREADDEADLOCK               "A deadlock was detected or thread specifies the calling thread"
#define ERR_DISKMANTHREADINVALID                "Thread is not a joinable thread or another thread is already waiting to join with this thread"
#define ERR_DISKMANTHREADNOTEXIST               "No thread with the ID thread could be found"
#define ERR_DISKMANTHREADUNKNOW                 "Unknow thread error"
#define ERR_CANTDISPATCHWRITETHREAD             "Can't dispatch write thread"
#define ERR_CANTDISPATCHREADTHREAD              "Can't dispatch read thread"
#define ERR_CANTFINDPATHOID                     "Can't find the path identifier"
#define ERR_CANTFINDSPATHOID                    "Can't find the path identifier in superblock"
#define ERR_CANTFINDFREETHREADENTRY             "Can't find free thread entry"
#define ERR_CANTLINKENTRY                       "Can't link entry"
#define ERR_CANTUNLINKENTRY                     "Can't unlink entry"
#define ERR_CANTLINKNULLENTRY                   "Can't link NULL entry"
#define ERR_CANTLINKENTRYOBJECTLINKED           "Can't relink object, already linked entry"
#define ERR_INVALIDENTRYKEYTYPE                 "Invalid entry key type"

/* ERROR FUNCTIONS
*/
void warnMsg(int debugLevel, const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage);

void warnMsgAndWaitForKey(int debugLevel, const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage);

void warnMsgIfNull(int debugLevel, const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage, void* data);

void errMsg(const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage);

void errMsgIfNull(const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage, void* data);

#endif
