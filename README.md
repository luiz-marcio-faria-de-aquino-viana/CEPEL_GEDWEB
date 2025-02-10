GEDWEB v1.2.202502100249

Copyright(C) 2022 TLMV Consultoria e Sistemas EIRELI
Autor: Luiz Marcio Faria de Aquino Viana, Pos-D.Sc.
E-mail: luiz.marcio.viana@gmail.com
Telefone: +55-21-99983-7207

File: README.md
Data: 10/02/2025

1. MOTIVAÇÕES E OBJETIVOS:

GEDWEB: Teste de programação aplicado pela equipe de Recursos Humanos do CEPEL, para avaliar a capacidade técnica na contratação de programadores.

Motivações: 

Foram dois os motivos que me levaram a participar deste teste:

i) Estar concorrendo a uma vaga na equipe de desenvolvimento de softwares do CEPEL.

ii) Avaliar a minha capacidade em resolver problemas para a área de atuação na qual estou participando do processo seletivo.

2. PROJETO GEDWEB

2.1. Ambientação:

A empresa SecureDocs deseja um sistema web com autenticação de usuários, permitindo que usuários autenticados submetam seus arquivos de
texto, editem-nos e baixem quando desejarem. O sistema deve garantir a preservação da autenticidade dos arquivos submetidos, garantindo
segurança e integridade aos documentos armazenados. Um usuário poderá carregar o arquivo em um editor de texto comum para visualizar, ler e
compreender seu conteúdo. No entanto, caso o arquivo seja modificado, ao ser carregado no sistema, a adulteração será identificada e ele será
considerado inválido. Para garantir essa segurança, a SecureDocs deseja a implementação de um componente dedicado à edição e validação dos
arquivos de texto, assegurando sua autenticidade e integridade. Esse componente será utilizado pelo sistema web e, por razões comerciais e
estratégicas, a SecureDocs poderá vendê-lo separadamente. Isso permitirá que programas de terceiros realizem a validação e autenticação dos
arquivos de texto, expandindo sua aplicabilidade no mercado.

2.2. Desafio:

(a) Elaborar um planejamento, incluindo um cronograma de atividades a serem realizadas para a entrega dos produtos. O
planejamento deve seguir as regras específicas descritas na seção de entrega e garantir a viabilidade e eficiência na execução
das atividades.

(b) Elaborar um modelo de arquivo de texto que garanta autenticidade e integridade, assegurando que qualquer modificação seja
detectável. A entrega deste modelo deverá seguir as regras específicas descritas na seção de entrega.

(c) Desenvolver um sistema web baseado em ASP.NET C#, que inclua autenticação de usuários, gerenciamento de arquivos
(criação, submissão, edição e download). O sistema deve garantir a autenticidade e integridade dos arquivos por meio do
componente descrito no item 4.

(d) Desenvolver um componente em C/C++, em conformidade com o modelo de arquivo proposto no item 2, que valide arquivos
de texto, confirme sua autenticidade e permita sua edição, garantindo a integridade e validade dos arquivos.

(e) Para as entregas dos itens 3 e 4, devem ser realizados testes unitários e testes de integração.

(f) NÃO utilizar ferramentas de IA Generativas (ChatGpt, DeepSeek, Gemini, MetaIA, CoPilot e outras) neste desafio.

3. INTRODUÇÃO:

(a) A aplicacao GEDWEB foi desenvolvida usando somente os recursos existentes nas linguagens C/C++, C# .Net, ASPNET, HTML, CSS e JavaScript.
PROJETOS:
- GEDWEBAUTHCGI: Aplicação CGI, elaborada usando C/C++, para criação do arquivo texto com assinatura digital.
- GEDWEBAPP: Aplicação Web, elaborada usando C# .Net, ASPNET, HTML, CSS, JavaScript, para gerenciamento dos documentos.

(b) Nao foram utilizadas bibliotecas externa, e o código da aplicação foi 100% desenvolvido por mim.
- Os arquivos utilitários Util.h/cpp e Error.h/cpp, que foram elaborados por mim para o projeto HORUS IMAGE SERVER v2.6, e adaptados para uso na aplicação GEDWEBAUTHCGI.

(c) As tabelas de dados são do tipo chave-valor em memória.

(d) Os objetos foram persistidos através da gravação de arquivo delimitado pelo caracter (^).
- O uso de armazenamento em arquivo de dados facilita a instalação e execução da aplicação.
- Nesta aplicação, poderia ser usado um banco de dados OLTP como o ORACLE, SQL Server, PostgreSQL ou MySQL, para armazenamento dos dados, efetuando o carregamento em memória ao iniciar a aplicação ou quando o dado for solicitado.

(e) O processo de criacao das tabelas foi realizado de forma manual, através da edição dos 3 (três) arquivos de dados da aplicação:

[HomeDir]\Data\TblUsuario.db
[HomeDir]\Data\TblDocumento.db
[HomeDir]\Data\TblDocumentoRevisao.db

(f) Diretorios:

	GEDWEB (Home) 	+- Appl			* localizacao do codigo fonte da aplicação GEDWEBAPP e GEDWEBAUTHCGI.
					+- Bin			* localizacao do arquivo binario da aplicação GEDWEBAUTHCGI.
					+- Conf			* localizacao do arquivo de configuracao: cepel_appconfig.xml
					+- Data			* diretório de persistencia das tabelas.
					+- Docs			* diretório de documentos.
					+- Repositorio	* diretório de armazenamento dos arquivos textos.
					+- Templates	* diretório de localização dos modelos de arquivo texto que irão receber a autenticacao digital.

4. ARQUITETURA DO PROJETO

4.1. PACOTES E CLASSES:

4.1.1. GEDWEBAUTHCGI

	+- All.h						- Importador de todos os arquivos de cabeçalho (.h) da aplicação.
	+- Defs.h						- Definição das constantes da aplicação.
	+- Error.h/cpp					- Definição das funções e mensagens de erro da aplicação.
	+- Util.h/cpp					- Definição de funções utilitárias para manipular cadeia de caracteres, alocar e copiar dados em memória, ler e escrever arquivos de dados, e etc.
	+- Ctx.h/cpp					- Contexto da aplicação (diretórios estáticos da aplicação).
	+- RequestData.h/cpp			- Value Object: Classe utilizada para armazenar os dados de requisição do servidor web (QueryString).
	+- TESTGEDWEBAUTHCGI.h/cpp		- Aplicação de teste, com execução através do console do Windows (CMD), para depuração da aplicação sem uso do servidor web.
	+- GEDWEBAUTHCGI.h/cpp			- Classe principal da aplicação, que possui o método estático main().

4.1.2. GEDWEBAPP

	+- Apps
	|	AppMain						- Classe principal da aplicação, que possui o método estático main().
	|	
	+- Apps.Base
	|	AppCtx						- Contexto da aplicação (diretórios estáticos da aplicação).
	|	AppDatabase					- Gerenciamento da persistência do dados das tabelas (saveAll/loadAll).
	|	AppDefs						- Definição das constantes da aplicação.
	|	AppError					- Processamento do registro de logs da aplicação e definição das mensagens de erro.
	|	AppUserAuth					- Autenticação e validados da sessão do usuário.
	|	AppUtil						- Funções utilitárias básicas para processamento de arquivos.
	|	
	+- Apps.Cmp
	|	CmdDocumentoRecord			- Classe para ordenação de listas de objetos do tipo DocumentoRecord.
	|	CmdDocumentoRevisaoRecord	- Classe para ordenação de listas de objetos do tipo DocumentoRevisaoRecord.
	|	CmpUsuarioRecord			- Classe para ordenação de listas de objetos do tipo UsuarioRecord.
	|	
	+- Apps.NoSql
	|	DocumentoNoSql				- Utility: Armazena os dados Documento usando Hashtable.
	|	DocumentoRevisaoNoSql		- Utility: Armazena os dados DocumentoRevisao usando Hashtable.
	|	UsuarioNoSql				- Utility: Armazena os dados Usuario usando Hashtable.
	|	
	+- Apps.Record
	|	DocumentoRecord				- Value Object: Armazena dados do tipo Documento.
	|	DocumentoRevisaoRecord		- Value Object: Armazena dados do tipo DocumentoRevisao.
	|	UsuarioRecord				- Value Object: Armazena dados do tipo Usuario.
	|	
	+- Apps.VO
	|	SessaoVO					- Value Object: Armazena dados do tipo Sessao.
	|	

5. APIs USADAS NO PROJETO

* Nao foram utilizadas bibliotecas externa, e o código da aplicação foi 100% desenvolvido por mim.

6. PROCESSAMENTO DO MÓDULO DE AUTENTICAÇÃO DO DOCUMENTO TEXTO: 

6.1. REQUISIÇÃO:

	http://[nome_servidor]:[porta_servidor]/GEDWEB/GEDWEBAUTHCGI.exe?
		txtDocumentoRevisaoId=2100010&
		txtDocumentoId=1100001&
		txtDocumentoNome=GALAX_--_FUNDAMENTOS_DE_COMPUTADORES_DIGITAIS&
		txtDocumentoNomeArquivo=GALAX.MAC&
		txtDocumentoDescricao=Jogo_Desenvolvido_100_porcento_em_Assembler_Z80_para_a_Disciplina_de_Fundamentos_de_Computadores_Digitais_do_Professor_Orlando_UERJ&
		txtDocumentoData=20250207_2040&
		txtDocumentoRevisaoData=20250207_2058&
		txtAutorId=9100001&
		txtAutorNome=Luiz_Marcio_Faria_de_Aquino_Viana&
		txtAutorFormacao=Engenheiro_Eletricista_com_Enfase_em_Engenharia_de_Sistemas_e_Computacao&
		txtAutorEmail=luiz.marcio.viana_AT_gmail.com&
		txtAutorTelefone=021999837207&
		txtUsuarioId=8100001&
		txtUsuarioNome=Luiz_Marcio_Faria_de_Aquino_Viana&
		txtUsuarioEmail=luiz.marcio.viana_AT_gmail.com&
		txtUsuarioTelefone=021999837207&
		txtArquivoDados=2100010-GEDWEB-GALAX_MAC.dat&
		txtArquivoSaida=output-202502080757123456.xml&
	
6.2. RESPOSTA:

<?xml version='1.0' ?>
<CEPEL_GEDWEB>
<CEPEL_DocumentoCompleto><CEPEL_Metadados>
	<CEPEL_Documento>
		<CEPEL_DocumentoRevisaoId>31000015</CEPEL_DocumentoRevisaoId>
		<CEPEL_DocumentoId>21000002</CEPEL_DocumentoId>			
		<CEPEL_DocumentoNome>SPEED_RACER_--_FUNDAMENTOS_DE_COMPUTADORES_DIGITAIS</CEPEL_DocumentoNome>
		<CEPEL_DocumentoNomeArquivo>SPEED.MAC</CEPEL_DocumentoNomeArquivo>
		<CEPEL_DocumentoDescricao>Jogo_Desenvolvido_100_porcento_em_Assembler_Z80_para_a_Disciplina_de_Fundamentos_de_Computadores_Digitais_do_Professor_Orlando_UERJ</CEPEL_DocumentoDescricao>
		<CEPEL_DocumentoData>2025-02-08+18h32</CEPEL_DocumentoData>
		<CEPEL_DocumentoRevisaoData>2025-02-08+18h47</CEPEL_DocumentoRevisaoData>
	</CEPEL_Documento>
	<CEPEL_Autor>
		<CEPEL_AutorId>1100001</CEPEL_AutorId>
		<CEPEL_AutorNome>Luiz_Marcio_Faria_de_Aquino_Viana</CEPEL_AutorNome>
		<CEPEL_AutorFormacao>Engenheiro_Eletricista_com_Enfase_em_Engenharia_de_Sistemas_e_Computacao</CEPEL_AutorFormacao>
		<CEPEL_AutorEmail>luiz.marcio.viana_AT_gmail.com</CEPEL_AutorEmail>
		<CEPEL_AutorTelefone>21999837207</CEPEL_AutorTelefone>
	</CEPEL_Autor>
	<CEPEL_UsuarioDownload>
		<CEPEL_UsuarioId>1100001</CEPEL_UsuarioId>
		<CEPEL_UsuarioNome>Luiz_Marcio_Faria_de_Aquino_Viana</CEPEL_UsuarioNome>
		<CEPEL_UsuarioEmail>luiz.marcio.viana_AT_gmail.com</CEPEL_UsuarioEmail>
		<CEPEL_UsuarioTelefone>21999837207</CEPEL_UsuarioTelefone>
	</CEPEL_UsuarioDownload>
</CEPEL_Metadados>
<CEPEL_Data><![CDATA[
TITLE	">>>>>SPEED>RACER> - FUNDAMENTOS DE COMPUTADORES DIGITAIS"

		ASEG
		.Z80

;
; --- declaracao das constantes
;

BDOS		EQU	005

INICPM		EQU	00h
RDKEY		EQU	06h
PRNSTR		EQU	09h

NULL		EQU	00h

;
; --- rotina de abertura e inicializacao
;

		ORG	0100h

Inicio:		LD	SP, stack + 255
		LD	C, PRNSTR
		LD	DE, dispClr
		CALL	BDOS
		LD	DE, dispLogo
		CALL	BDOS
		LD	DE, dispMess
		CALL	BDOS 
Loop1:		CALL	GetKey
		CP	NULL
		JR	Z, Loop1

		CALL	IniScore
		CALL	StartVar
		CALL	StartScr
		CALL	PutGrid
		CALL	PutCar

;
; --- declaracao da area de variaveis HEAP do sistema
;

varCar:		DS	1
varScore:	DS	3
varGrid:	DS	42
varRn1:		DB	00h, 00h
varCrash:	DS	1

;
; --- declaracao da area de buffer do display
;

		ORG	0E00h

buffDisp:	DS	256

;
; --- declaracao da area de stack
;

		ORG	0F00h

stack:		DS	256

		END

]]></CEPEL_Data>
</CEPEL_DocumentoCompleto>
<CEPEL_Signature><![CDATA[356253649ld]]></CEPEL_Signature>
</CEPEL_GEDWEB>

7. PONTOS DE ENTRADA DAS APLICAÇÕES

7.1. PÁGINA DE ACESSO DA APLICAÇÃO GEDWEB

	http://[nome_servidor]:[porta_servidor]/[appl_aspnet]/index.htm

	ou
	
	http://[nome_servidor]:[porta_servidor]/[appl_aspnet]/FrmLogin.aspx

7.2. PÁGINA TESTE DO MODULO GEDWEBAUTHCGI (CGI)

	http://[nome_servidor]:[porta_servidor]/GEDWEB/index.htm

8. DUVIDAS:

(a) Duvidas ou sugestoes entre em contato por e-mail ou telefone.

	Luiz Marcio Faria de Aquino Viana, Pós-D.Sc.
	Engenheiro Eletricista
	Ênfase em Engenharia de Sistemas e Computação
	CPF: 024.723.347-10
	RG: 08855128-8 IFP-RJ
	Registro: 2000103581 CREA-RJ
	E-mail: luiz.marcio.viana@gmail.com
	Tel: +55-21-99983-7207
