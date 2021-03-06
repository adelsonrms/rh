USE [tecnun]
GO
CREATE TABLE [RH].Anexo(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeDoArquivo] varchar(100) NULL,
	[Tipo] varchar(100) NULL,
	[Tamanho] int NULL,
	CaminhoOrigem varchar(255),
	NomeInterno varchar(255),
	DataArquivo datetime,
	Caminho varchar(1000) NULL,
	Conteudo varbinary(max) NULL,
	Notas varchar(max),
	DataUpload datetime default getdate(),
	UsuarioUpload varchar(100)

PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

GO
/****** Object:  Table [RH].[Cargo]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RH].[Cargo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[UsuarioInclusao] [nvarchar](100) NULL,
	[MomentoInclusao] [datetime] NULL,
	[UsuarioEdicao] [nvarchar](max) NULL,
	[MomentoEdicao] [datetime] NULL,
	[CBO] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [RH].[Contrato]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RH].[Contrato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataAdmissao] [varchar](50) NULL,
	[DataDemissao] [varchar](50) NULL,
	[IdModalidade] [int] NULL,
	[IdCargo] [int] NULL,
	[IdDepto] [int] NULL,
	[Salario] [real] NULL,
	[IdPerfil] [int] NULL,
	[IdFuncionario] [int] NULL,
	[ativo] [bit] NULL,
	[QtdDependentes] [int] NULL,
 CONSTRAINT [PK_TPA.Contrato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RH].[Departamento]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RH].[Departamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeDepartamento] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RH].[Documento]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RH].[Documento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFuncionario] [int] NOT NULL,
	[RG_Numero] [varchar](50) NULL,
	[RG_OrgaoEmissor] [varchar](50) NULL,
	[RG_UF] [varchar](50) NULL,
	[RG_DtEmissao] [varchar](50) NULL,
	[CPF] [varchar](50) NULL,
	[PIS] [varchar](50) NULL,
	[TituloEleitoral_Num] [varchar](50) NULL,
	[TituloEleitoral_Zona] [varchar](50) NULL,
	[CartHabilitacao_Numero] [varchar](50) NULL,
	[CartHabilitacao_Categoria] [char](1) NULL,
	[CartTrabalho_Num] [varchar](50) NULL,
	[CartTrabalho_Serie] [varchar](50) NULL,
	[CertNascimento_Livro] [varchar](50) NULL,
	[CBO] [varchar](50) NULL,
	[NomeDoPai] [varchar](128) NULL,
	[NomeDaMae] [varchar](128) NULL,
	[idEstadoCivil] [int] NULL,
	[Naturalidade] [varchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RH].[EstadoCivil]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RH].[EstadoCivil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RH].[FaixaCargo]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RH].[FaixaCargo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Faixa] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RH].[Modalidade]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RH].[Modalidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeModalidade] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RH].[NivelCargo]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RH].[NivelCargo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nivel] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TPA].[Funcionario]    Script Date: 08/08/2018 01:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TPA].[Funcionario](
	[Id] [int] NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Matricula] [nvarchar](max) NULL,
	[CPF] [nvarchar](max) NULL,
	[PIS] [nvarchar](max) NULL,
	[Telefone] [nvarchar](max) NULL,
	[Celular] [nvarchar](max) NULL,
	[EmailProfissional] [nvarchar](max) NULL,
	[EmailPessoal] [nvarchar](max) NULL,
	[Endereco] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](100) NULL,
	[MomentoInclusao] [datetime] NULL,
	[UsuarioEdicao] [nvarchar](max) NULL,
	[MomentoEdicao] [datetime] NULL,
	[CEP] [nvarchar](max) NULL,
	[Bairro] [nvarchar](max) NULL,
	[Cidade] [nvarchar](max) NULL,
	[Estado] [nvarchar](max) NULL,
	[DataNascimento] [varchar](50) NULL,
	[SexoID] [int] NOT NULL,
	[Contrato_Id] [int] NULL,
	[Idade] [nvarchar](max) NULL,
	[Ativo] [bit] NOT NULL,
	[Documento_Id] [int] NULL,
	[EstadoCivil_Id] [int] NULL,
 CONSTRAINT [PK_TPA.Funcionario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [RH].[Cargo] ON 

INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (1, N'Analista de Sistemas', NULL, NULL, NULL, NULL, N'2124-05')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (2, N'Analista de Sistemas Sênior', NULL, NULL, NULL, NULL, N'2124-05')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (3, N'Analista Programador Pleno', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (4, N'Analista Programador Sênior', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (5, N'Analista Programador VBA A0', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (6, N'Analista Programador VBA A1', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (7, N'Analista Programador VBA A2', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (8, N'Analista Programador VBA B2', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (9, N'Analista Programador VBA C1', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (10, N'Analista Programador VBA PL 1', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (11, N'Coordenador de Projetos', NULL, NULL, NULL, NULL, N'1423-30')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (12, N'Operador de Sistemas', NULL, NULL, NULL, NULL, N'3172-05')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (13, N'Operador de Sistemas .Net', NULL, NULL, NULL, NULL, N'3172-05')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (14, N'Operador de Sistemas VBA', NULL, NULL, NULL, NULL, N'3172-05')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (15, N'Operador de Sistemas VBA A0', NULL, NULL, NULL, NULL, N'3172-05')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (16, N'Operador de Sistemas VBA JR 0', NULL, NULL, NULL, NULL, N'3172-05')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (17, N'Programador VBA A2', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (18, N'Programador VBA B2', NULL, NULL, NULL, NULL, N'3171-10')
INSERT [RH].[Cargo] ([Id], [Nome], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CBO]) VALUES (19, N'Sócio-Proprietário', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [RH].[Cargo] OFF
SET IDENTITY_INSERT [RH].[Contrato] ON 

INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (3, N'01/04/2014', NULL, 4, 1, 6, 1549.4, 3, 2, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (4, N'01/08/2017', NULL, 1, 13, 6, 5350, 2, 1027, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (5, N'02/05/2016', NULL, 1, 5, 4, 1800, 7, 1016, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (6, N'01/08/2016', NULL, 1, 9, 4, 4511, 9, 12, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (7, NULL, NULL, 1, 0, 6, 0, 1, 1014, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (8, N'10/11/2014', NULL, 4, 12, 4, 1493, 3, 1017, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (9, N'01/04/2014', NULL, 4, 1, 5, 1549.4, 3, 4, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (10, N'02/05/2016', N'26/03/2018', 1, 14, 4, 1464, 4, 1018, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (11, N'04/01/2016', NULL, 1, 8, 4, 3533.15, 8, 1019, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (12, N'11/02/2016', NULL, 1, 15, 4, 1800, 5, 8, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (13, NULL, NULL, 2, 0, 7, 0, 0, 5, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (14, N'25/05/2018', NULL, 1, 16, 4, 1915, 0, 1029, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (15, N'01/07/2014', NULL, 1, 2, 7, 3875.66, 3, 9, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (16, N'02/01/2015', NULL, 1, 2, 4, 3875.66, 3, 1020, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (17, N'02/05/2016', NULL, 1, 14, 4, 1464, 5, 10, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (18, N'07/08/2017', NULL, 1, 12, 4, 1587, 0, 1026, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (19, N'01/09/2015', NULL, 1, 11, 7, 6100, 0, 1015, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (20, N'18/01/2016', NULL, 4, 1, 4, 1549.4, 6, 1021, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (21, N'18/01/2016', NULL, 1, 7, 4, 2450, 3, 1022, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (22, N'02/05/2016', NULL, 1, 17, 4, 2450, 6, 1028, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (23, N'17/07/2017', NULL, 1, 7, 4, 2552.7, 7, 1025, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (24, N'01/08/2016', NULL, 1, 15, 4, 1800, 4, 1023, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (25, NULL, NULL, 1, 0, 4, 0, 0, 1024, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (26, N'13/10/2015', NULL, 1, 3, 6, 5713.6, 2, 7, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (27, N'10/11/2014', NULL, 1, 4, 6, 8397.63, 3, 1, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (28, N'15/02/2016', NULL, 1, 5, 4, 1800, 4, 14, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (29, N'04/03/2013', NULL, 2, 19, 0, 0, 0, 3, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (30, NULL, NULL, 1, 0, 0, 0, 0, 6, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (31, N'01/09/2016', NULL, 1, 18, 0, 3533.15, 0, 13, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (32, N'04/06/2018', NULL, 1, 10, 0, 3504.75, 0, 1030, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (33, NULL, NULL, 1, 0, 0, 0, 0, 1031, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (34, NULL, NULL, 1, 0, 0, 0, 0, 1032, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (35, NULL, NULL, 1, 0, 0, 0, 0, 1033, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (36, NULL, NULL, 1, 0, 0, 0, 0, 1034, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (37, NULL, NULL, 1, 0, 0, 0, 0, 1035, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (38, NULL, NULL, 1, 0, 0, 0, 0, 1036, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (39, N'02/05/2016', NULL, 1, 5, 0, 1800, 0, 1037, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (40, N'01/09/2016', NULL, 1, 6, 0, 2130, 0, 1038, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (41, NULL, NULL, 1, 0, 0, 0, 0, 1039, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (42, NULL, NULL, 1, 0, 0, 0, 0, 1040, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (43, NULL, NULL, 1, 0, 0, 0, 0, 1041, 1, 0)
INSERT [RH].[Contrato] ([Id], [DataAdmissao], [DataDemissao], [IdModalidade], [IdCargo], [IdDepto], [Salario], [IdPerfil], [IdFuncionario], [ativo], [QtdDependentes]) VALUES (44, NULL, NULL, 1, 0, 0, 0, 0, 1042, 1, 0)
SET IDENTITY_INSERT [RH].[Contrato] OFF
SET IDENTITY_INSERT [RH].[Departamento] ON 

INSERT [RH].[Departamento] ([Id], [NomeDepartamento]) VALUES (1, N'Admistrativo')
INSERT [RH].[Departamento] ([Id], [NomeDepartamento]) VALUES (2, N'Desenvolvimento')
INSERT [RH].[Departamento] ([Id], [NomeDepartamento]) VALUES (3, N'Fiscal')
INSERT [RH].[Departamento] ([Id], [NomeDepartamento]) VALUES (4, N'Automação Office/VBA')
INSERT [RH].[Departamento] ([Id], [NomeDepartamento]) VALUES (5, N'Comercial')
INSERT [RH].[Departamento] ([Id], [NomeDepartamento]) VALUES (6, N'Desenvovimento .NET')
INSERT [RH].[Departamento] ([Id], [NomeDepartamento]) VALUES (7, N'Projetos')
SET IDENTITY_INSERT [RH].[Departamento] OFF
SET IDENTITY_INSERT [RH].[Documento] ON 

INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (6, 2, N'38.810.94-9', N'SSP', N'BA', N'38048', N'307.259.088-58', N'1.30185e+010', NULL, NULL, NULL, NULL, N'25043', N'00017 - PI', N'2', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (7, 1039, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'28', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (8, 1037, N'42.084.454-5', NULL, NULL, NULL, N'442.308.478-31', N'1.43023e+010', N'393050700108', N'273', NULL, NULL, N'57698', N'00390 - SP', N'19', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (9, 1043, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'6', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (10, 1027, N'45.182.014-9', NULL, NULL, NULL, N'216.895.678-21', NULL, N'299026120141', N'284', NULL, NULL, N'018596', N'00249 - SP', N'33', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (11, 1016, N'42.736.475-9', N'SSP', N'SP', N'20/10/2016', N'362.503.348-82', N'1.36515e+010', N'346469210108', N'280', NULL, NULL, N'1717', N'00337 - SP', N'21', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (12, 12, N'34.422.772-8', NULL, NULL, NULL, N'301.941.538.19', N'1.3226e+010', N'282859450141', N'255', NULL, NULL, N'002232', N'00247-SP', N'25', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (13, 1014, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'30', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (14, 1030, N'44.219.318-X', N'SSP', N'SP', NULL, N'342.716.298-20', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (15, 4, N'27.565.785-1', N'SSP', N'SP', N'04/06/1991', N'272.490.338-24', N'1.25011e+010', N'289738210116', N'374', NULL, NULL, N'73801', N'00183 - SP', N'3', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (16, 1017, N'26.583.268-8', N'SSP', N'SP', N'41914', N'279.725.788-00', N'1.26455e+010', N'276559210159', N'006', NULL, NULL, N'0029663', N'00236 - SP', N'7', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (17, 1018, N'50.859.423-6', N'SSP', N'SP', N'16/10/2015', N'484.276.968-84', N'1.56432e+010', NULL, NULL, NULL, NULL, N'19724', N'00422 - SP', N'20', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (18, 1036, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'13', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (19, 1019, N'38.138.073-7', N'SSP', N'SP', N'26/12/2002', N'437.212.268-36', N'1.54476e+010', N'399512410116', N'413', NULL, NULL, N'081261', N'00397 - SP', N'14', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (20, 3, N'26.867.841-8', NULL, NULL, NULL, N'250.978.958-94', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (21, 13, N'15.340.608-2', N'SSP', N'SP', N'42275', N'055.444.688-00', NULL, N'081906310159', N'375', NULL, NULL, N'024111', N'634 - SP', N'26', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (22, 8, N'49.206.807-0', NULL, NULL, NULL, N'419.430.818-24', N'1.38545e+010', N'362063520141', N'325', NULL, NULL, N'017042', N'00365 - SP', N'17', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (23, 5, N'22.076.976-X', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (24, 1029, N'43.999.209-6', N'SSP', N'SP', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (25, 9, N'36.061.171-0', N'SSP', N'SP', N'23/03/2009', N'406.642.048-64', N'1.90332e+010', N'362083820175', N'325', NULL, NULL, N'051684', N'00352 - SP', N'4', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (26, 1020, N'47.065.433-8', N'SSP', N'SP', N'19/01/2009', N'402.912.848-33', N'1.37642e+010', N'368368020159', N'258', NULL, NULL, N'63165', N'00350 - SP', N'9', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (27, 10, N'49.945.020-6', N'SSP', N'SP', N'15/08/2013', N'440.935.778-62', N'1.40873e+010', N'425699940132', N'354', NULL, NULL, N'7303', N'419 - SP', N'23', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (28, 1026, N'53.030.886-1', NULL, NULL, NULL, N'449.940.938-63', NULL, N'422732680116', N'303', NULL, NULL, N'031608', N'00422 - SP', N'34', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (29, 1044, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'29', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (30, 1015, N'40.238.076-9', N'SSP', N'SP', N'22/07/2015', N'325.146.608-90', N'1.36188e+010', N'301036270167', N'099', NULL, NULL, N'066135', N'269 - SP', N'10', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (31, 1021, N'22.019.519-5', NULL, NULL, NULL, N'132.433.328-69', N'1.23723e+010', N'264875980124', N'287', NULL, NULL, N'57808', N'00195 - SP', N'16', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (32, 1022, N'49.102.543-9', NULL, NULL, NULL, N'368.092.028-89', N'2.01402e+010', N'389561540116', N'417', NULL, NULL, N'018359', N'00383 - SP', N'15', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (33, 1028, N'21.524.588-7', N'Detran', N'RJ', N'22/06/2010', N'111.717.557-08', NULL, N'395714590116', N'264', NULL, NULL, N'49314', N'00380 - SP', N'22', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (34, 1025, N'43.889.546-0', NULL, NULL, NULL, N'337.429.828-18', NULL, N'337933760167', N'253', NULL, NULL, N'85405', N'00297 - SP', N'32', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (35, 1023, N'49.160.041-0', N'SSP', N'SP', N'43450', N'419.698.958-61', N'1.37985e+010', N'392149730175', N'422', NULL, NULL, N'021442', N'0403 - SP', N'24', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (36, 1034, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'11', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (37, 1038, N'43.662.558-1', NULL, NULL, NULL, N'364.767.108-85', NULL, N'325174370175', N'006', NULL, NULL, N'075096', N'00418 - SP', N'27', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (38, 1024, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'31', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (39, 7, N'27.143.270-6', NULL, NULL, NULL, N'318.376.178-56', N'1.30169e+010', N'312015950108', N'258', NULL, NULL, N'005455', N'252 - SP', N'12', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (40, 1031, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'5', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (41, 1, N'33.516.598-9', NULL, NULL, NULL, N'299.185.168-60', NULL, N'282704430141', N'253', NULL, NULL, N'99071', N'00256 - SP', N'8', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (42, 14, N'1387197053', N'SSP', N'PI', NULL, N'053.286.905-24', NULL, N'150337930507', N'056', NULL, NULL, N'3636397', N'00040 - BA', N'18', NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (43, 1033, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [RH].[Documento] ([Id], [IdFuncionario], [RG_Numero], [RG_OrgaoEmissor], [RG_UF], [RG_DtEmissao], [CPF], [PIS], [TituloEleitoral_Num], [TituloEleitoral_Zona], [CartHabilitacao_Numero], [CartHabilitacao_Categoria], [CartTrabalho_Num], [CartTrabalho_Serie], [CertNascimento_Livro], [CBO], [NomeDoPai], [NomeDaMae], [idEstadoCivil], [Naturalidade]) VALUES (44, 1042, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [RH].[Documento] OFF
SET IDENTITY_INSERT [RH].[EstadoCivil] ON 

INSERT [RH].[EstadoCivil] ([Id], [Nome]) VALUES (1, N'Solteiro')
INSERT [RH].[EstadoCivil] ([Id], [Nome]) VALUES (2, N'Casado')
INSERT [RH].[EstadoCivil] ([Id], [Nome]) VALUES (3, N'Desquitado')
INSERT [RH].[EstadoCivil] ([Id], [Nome]) VALUES (4, N'Divorciado')
SET IDENTITY_INSERT [RH].[EstadoCivil] OFF
SET IDENTITY_INSERT [RH].[FaixaCargo] ON 

INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (1, N'JUNIOR')
INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (2, N'PLENO')
INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (3, N'SENIOR')
INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (4, N'VBA A0')
INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (5, N'VBA A1')
INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (6, N'VBA A2')
INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (7, N'VBA B1')
INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (8, N'VBA B2')
INSERT [RH].[FaixaCargo] ([Id], [Faixa]) VALUES (9, N'VBA C1')
SET IDENTITY_INSERT [RH].[FaixaCargo] OFF
SET IDENTITY_INSERT [RH].[Modalidade] ON 

INSERT [RH].[Modalidade] ([Id], [NomeModalidade]) VALUES (1, N'CLT')
INSERT [RH].[Modalidade] ([Id], [NomeModalidade]) VALUES (2, N'PJ')
INSERT [RH].[Modalidade] ([Id], [NomeModalidade]) VALUES (3, N'Outro')
INSERT [RH].[Modalidade] ([Id], [NomeModalidade]) VALUES (4, N'CLT / PJ')
SET IDENTITY_INSERT [RH].[Modalidade] OFF
SET IDENTITY_INSERT [RH].[NivelCargo] ON 

INSERT [RH].[NivelCargo] ([Id], [Nivel]) VALUES (1, N'ESPECIALISTA')
INSERT [RH].[NivelCargo] ([Id], [Nivel]) VALUES (2, N'SENIOR')
INSERT [RH].[NivelCargo] ([Id], [Nivel]) VALUES (3, N'PLENO')
INSERT [RH].[NivelCargo] ([Id], [Nivel]) VALUES (4, N'JUNIOR')
SET IDENTITY_INSERT [RH].[NivelCargo] OFF
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1, N'VITOR LUIS RUBIO', N'0001', N'299.185.168-60', NULL, N'(11) 97992-4544', N'', N'vitor@tecnun.com.br', NULL, N'Travessa Amélia Brandão Neri, 24
Parque Maria Luisa, São Paulo - 03450-080', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Feb 14 1983 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (2, N'ADELSON ROSENDO MARQUES DA SILVA', NULL, NULL, NULL, N'(11) 3912-8020', N'(11) 96798-0117', N'adelson@tecnun.com.br', N'adelsons@gmail.com', N'Rua Lazaro Suave, 233, AP 106 Bloco B', NULL, NULL, NULL, NULL, N'06040470', N'Bussocaba City', N'Osasco', N'SP', N'Aug 14 1982 12:00AM', 0, NULL, NULL, 1, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (3, N'HENRIQUE MATIAS DE FREITAS OLIVEIRA', N'3', N'250.978.958-94', NULL, N'(11) 98800-8036', N'', N'henrique@tecnun.com.br', NULL, N'Av. Paulo Lincoln do Valle Potin, 266 - Ap. 28
Jaçanã, São Paulo, SP - 02273-010', NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, N'Sep 22 1976 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (4, N'FERNANDO ORTEGA CIPRIANO DE OLIVEIRA', N'0004', N'272.490.338-24', N'12501072903', N'(11) 99861-4670', N'+55 (11) 99861-4670', N'ortega@tecnun.com.br', NULL, N'Rua Cândido Fontoura, 575
Jardim Boa Vista, São Paulo - 05583-070', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Nov 22 1978 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (5, N'JEFFERSON ROCHA FIGUEROA DANTAS', N'0005', NULL, NULL, N'(11) 98982-1719', N'', N'jefferson@tecnun.com.br', NULL, N'Av. Edmundo Amaral, 3935 - Bloco 7 - Ap. 113
Piratininga, Osasco, SP - 06230-150', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Apr  4 1986 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (6, N'Sistema', N'6', NULL, NULL, NULL, NULL, N'usuario@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (7, N'ULISSES RIBEIRO DA SILVA', N'0007', N'318.376.178-56', N'13016867930', N'(11) 99886-9363', N'', N'ulisses@tecnun.com.br', NULL, N'Estrada das Lágrimas, 247 - Bl. 7 - Ap. 31
Ipiranga, Sâo Paulo, SP - 04232-000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Nov 30 1982 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (8, N'HUGO FRANCEZ VILARIM DE SOUZA', N'0008', N'419.430.818-24', N'13854525817', N'(11) 99438-0914', N'', N'hugo@tecnun.com.br', NULL, N'Rua Perry Sales, 219
Conj. Hab. Turística, São Paulo - 05164-130', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Apr 11 1993 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (9, N'JONATHAN ROCHA FIGUEROA DANTAS', N'0009', N'406.642.048-64', N'19033214078', N'(11) 98599-0527', N'', N'jonathan@tecnun.com.br', NULL, N'Rua Ambrósia do México, 296
Jardim Cidade Pirituba, São Paulo - 02945-040', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Feb 11 1993 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (10, N'LEANDRO DA PAZ LOPES', N'0010', N'440.935.778-62', N'14087329492', N'(11) 96329-0628', N'(11)96170-9571', N'leandro@tecnun.com.br', NULL, N'Rua das Margaridas, 181 
Ipês (Polvilho), Cajamar, SP – 07791-790', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'May 25 1997 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (12, N'EDUARDO DEL CHIARO AMANCIO', N'0012', N'301.941.538.19', N'13225972850', N'(11) 96688-0202', N'', N'eduardo@tecnun.com.br', NULL, N'Rua Dr. Bernardino Gomes, 143 - A
Vila Santista, São Paulo - 02560-000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Sep  3 1982 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (13, N'HIRLEI DE PAULA FILHO', N'13', N'055.444.688-00', NULL, N'(11) 99319-0561', N'', N'hirlei@tecnun.com.br', NULL, N'Rua Doutor Paulo Queiroz, 1718 - Casa 2
Jardim Nove de Julho, São Paulo - 03951-090', NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, N'Apr 16 1964 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (14, N'WELDER MARQUES DA COSTA', N'0014', N'053.286.905-24', NULL, N'(11) 97056-2506', N'', N'welder@tecnun.com.br', NULL, N'Rua José Adão, 58
Vila dos Palmares, São Paulo - 05273-110', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Apr  5 1995 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1014, N'ELISA DE FREITAS REIS PINTO DA CUNHA', N'1014', NULL, NULL, NULL, N'', N'elisa@tecnun.com.br', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1015, N'MILENE CELESTINO BISPO', N'1015', N'325.146.608-90', N'13618765850', N'(11) 96055-3966', N'', N'milene@tecnun.com.br', NULL, N'Rua Teodoro Sampaio, 1675 - Apto. 13
Pinheiros, São Paulo - 05405-150', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Jan 21 1984 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1016, N'EDSON JOSÉ DE FREITAS NETO', NULL, NULL, NULL, N'(11) 94211-2554', NULL, N'edson@tecnun.com.br', NULL, N'Rua Comercindo Antônio de Oliveira, 15Jardim Guanhembu, São Paulo – 04814-080', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Nov 19 1987 12:00AM', 0, NULL, NULL, 1, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1017, N'FERNANDO REIS COUTO FERNANDES', N'1017', N'279.725.788-00', N'12645516264', N'(11) 95302-7737', N'', N'fernando@tecnun.com.br', NULL, N'Alameda Casa Branca, 805 - Apto 92
Jardim Paulista, São Paulo - 01408-001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Feb 18 1979 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1018, N'GABRIEL ALVES SORIANO', N'1018', N'484.276.968-84', N'15643175235', N'(11) 97171-6098', N'', N'gabriel@tecnun.com.br', NULL, N'Rua Maria das Dores Lemos, 131 
Baronesa, Osasco – 06263-020', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Dec 28 1998 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1019, N'HENRIQUE KEN ITI HIROTA', N'1019', N'437.212.268-36', N'15447634354', N'(11) 94141-3959', N'', N'hirota@tecnun.com.br', NULL, N'Rua Eduardo Ferreira Franca, 898
Água Funda, São Paulo - 04157-000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Sep 10 1993 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1020, N'JULIUS KLAES MATHEUS', N'1020', N'402.912.848-33', N'13764205937', N'(11) 98137-1306', N'', N'julius@tecnun.com.br', NULL, N'Av. Piassanguaba, 1627
Planalto Paulista, São Paulo - 04060-002', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Sep 13 1990 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1021, N'PAULO CESAR DA SILVA', N'1021', N'132.433.328-69', N'12372313527', N'(11) 97471-5339', N'', N'paulo.gallo@tecnun.com.br', NULL, N'Rua Professora Isabel Ferreira da Silva, 227 Jardim Rubi, Mogi das Cruzes – Cep 08725-649', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Jul  7 1972 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1022, N'PAULO HENRIQUE GALLO', N'1022', N'368.092.028-89', N'20140173506', N'(11) 96526-6906', N'', N'paulo@tecnun.com.br', NULL, N'Rua Diogo de Sousa, 380 - Casa 3
Cidade Líder, São Paulo - 08285-330', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Sep 28 1992 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1023, N'RENAN SOUZA RODRIGUES', N'1023', N'419.698.958-61', N'13798466504', N'(11) 97988-9910', N'', N'renan@tecnun.com.br', NULL, N'Rua Ercole Roberti, 25 - Casa 2
Mandaqui, São Paulo, SP - 02434-020', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Sep 20 1992 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1024, N'THIAGO ALEIXO VIDAL BATISTA', N'1024', NULL, NULL, NULL, N'', N'thiago@tecnun.com.br', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1025, N'PHILLIP DA SILVA MOREIRA', N'1025', N'337.429.828-18', NULL, N'(11) 96620-6895', N'', N'philipp@tecnun.com.br', NULL, N'Rua Campos Maiorca, 13 - Casa B
Jardim Aricanduva, São Paulo, SP - 03456-030', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Aug 11 1986 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1026, N'LUCAS MAROPO RODRIGUES', N'1026', N'449.940.938-63', NULL, N'(11) 96603-5269', N'', N'lucas@tecnun.com.br', NULL, N'Rua Santa Luzia, 165
Santa Terezinha, São Paulo, SP - 06315-030', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Aug 13 1998 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1027, N'DANIEL XAVIER DA SILVA', N'1027', N'216.895.678-21', NULL, N'(11) 97115-8578', N'', N'daniel@tecnun.com.br', NULL, N'Rua dos Alpes, 2
Suísso, São Bernardo do Campo, SP - 09663-070', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Feb 18 1983 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1028, N'PEDRO HENRIQUE CAVERNAZ GUIMARÃES BASTOS EHLER', N'1028', N'111.717.557-08', NULL, N'(11) 96901-5536', N'', N'pedro@tecnun.com.br', NULL, N'Rua Cisplatina, 1071 - Fundos
Vila Pires, Santo André, SP - 09121-430', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Jun 12 1992 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1029, N'JONATHAN BARBOSA DA COSTA SILVA', N'1029', NULL, NULL, N'(11) 98453-7868', N'+55 11 98453-7868', N'jbarbosa@tecnun.com.br', NULL, N'Rua Jason Xavier de Barros, 255
Jardim das Oliveiras - São paulo, SP - 08122-080', N'jefferson@tecnun.com.br', CAST(N'2018-05-25T10:20:15.393' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, N'May 19 1994 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1030, N'ERIK MASSAO TAKIGAMI', N'1030', N'342.716.298-20', NULL, N'(11) 98421-7833', N'+55 11 98421-7833', N'erik@tecnun.com.br', NULL, N'Rua Sebastiano Mazzoni, 39, apto 53, bloco 2
Vila Moraes - São Paulo, SP - 04171-000', NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, N'Sep  9 1987 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1031, N'VINÍCIUS DE MORAIS MUSSATO', N'1031', NULL, NULL, NULL, N'', N'vinicius@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1032, N'Projetos', N'1032', NULL, NULL, N'', N'', N'projetos@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1033, N'CRISTINA', N'1033', NULL, NULL, NULL, N'', N'cristina@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1034, N'RENATO MENDES ALEGRETTI', N'1034', NULL, NULL, NULL, N'', N'renato@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1035, N'Sistema', N'1035', NULL, NULL, N'', N'', N'sistema@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1036, N'GILBERTO PEQUENO VIEGAS LOBO', N'1036', NULL, NULL, NULL, N'', N'gilberto@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1037, N'ANDRÉ RASCIO DINI', N'1037', N'442.308.478-31', N'14302290990', N'(13) 99177-8949', N'', N'andre@tecnun.com.br', NULL, N'Av. Conselheiro Nébias, 751 - Apto. 81
Boqueirão, Santos – 11045-003', NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, N'Oct 23 1993 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1038, N'RODRIGO HELOANI DE BRITO', N'1038', N'364.767.108-85', NULL, N'(11) 99864-2642', N'', N'rodrigo@tecnun.com.br', NULL, N'Rua Tenente Azevedo, 104 - 223A
Aclimação, São Paulo - 01528-020', NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, N'Apr 30 1987 12:00AM', 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1039, N'ANACLETO DE LIMA CORREIA MACIEL', N'1039', NULL, NULL, NULL, N'', N'anacleto@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1040, N'Mariana', N'1040', NULL, NULL, N'', N'', N'mariana@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1041, N'Relacionamento', N'1041', NULL, NULL, N'', N'', N'relacionamento@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
INSERT [TPA].[Funcionario] ([Id], [Nome], [Matricula], [CPF], [PIS], [Telefone], [Celular], [EmailProfissional], [EmailPessoal], [Endereco], [UsuarioInclusao], [MomentoInclusao], [UsuarioEdicao], [MomentoEdicao], [CEP], [Bairro], [Cidade], [Estado], [DataNascimento], [SexoID], [Contrato_Id], [Idade], [Ativo], [Documento_Id], [EstadoCivil_Id]) VALUES (1042, N'JOSE EDUARDO BATISTA', N'1042', NULL, NULL, NULL, N'+55 11 98235-1025', N'jeduardo@tecnun.com.br', NULL, NULL, NULL, CAST(N'2018-07-09T22:34:06.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
ALTER TABLE [RH].[Contrato] ADD  CONSTRAINT [DF__Contrato__IdFunc__3572E547]  DEFAULT ((0)) FOR [IdFuncionario]
GO
ALTER TABLE [RH].[Contrato] ADD  DEFAULT ((1)) FOR [ativo]
GO
ALTER TABLE [RH].[Funcionario] ADD  DEFAULT (getdate()) FOR [MomentoInclusao]
GO
ALTER TABLE [RH].[Funcionario] ADD  DEFAULT ((0)) FOR [SexoID]
GO
ALTER TABLE [RH].[Funcionario] ADD  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [TPA].[Funcionario] ADD  CONSTRAINT [DF__Funcionar__Momen__4B0D20AB]  DEFAULT (getdate()) FOR [MomentoInclusao]
GO
ALTER TABLE [TPA].[Funcionario] ADD  CONSTRAINT [DF__Funcionar__SexoI__5A4F643B]  DEFAULT ((0)) FOR [SexoID]
GO
ALTER TABLE [TPA].[Funcionario] ADD  CONSTRAINT [DF__Funcionar__Ativo__0F183235]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [TPA].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_TPA.Funcionario_TPA.Contrato_Contrato_Id] FOREIGN KEY([Contrato_Id])
REFERENCES [RH].[Contrato] ([Id])
GO
ALTER TABLE [TPA].[Funcionario] CHECK CONSTRAINT [FK_TPA.Funcionario_TPA.Contrato_Contrato_Id]
GO
ALTER TABLE [TPA].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_TPA.Funcionario_TPA.Usuario_Id] FOREIGN KEY([Id])
REFERENCES [TPA].[Usuario] ([Id])
GO
ALTER TABLE [TPA].[Funcionario] CHECK CONSTRAINT [FK_TPA.Funcionario_TPA.Usuario_Id]
GO
