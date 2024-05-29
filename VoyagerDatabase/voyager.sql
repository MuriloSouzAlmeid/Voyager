USE [master]
GO
/****** Object:  Database [Voyager]    Script Date: 29/05/2024 14:48:58 ******/
CREATE DATABASE [Voyager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Voyager', FILENAME = N'C:\Program Files\Microsoft SQL Server\serverlucca\MSSQL16.SERVERLUCCA\MSSQL\DATA\Voyager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Voyager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\serverlucca\MSSQL16.SERVERLUCCA\MSSQL\DATA\Voyager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Voyager] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Voyager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Voyager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Voyager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Voyager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Voyager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Voyager] SET ARITHABORT OFF 
GO
ALTER DATABASE [Voyager] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Voyager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Voyager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Voyager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Voyager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Voyager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Voyager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Voyager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Voyager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Voyager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Voyager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Voyager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Voyager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Voyager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Voyager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Voyager] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Voyager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Voyager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Voyager] SET  MULTI_USER 
GO
ALTER DATABASE [Voyager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Voyager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Voyager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Voyager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Voyager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Voyager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Voyager] SET QUERY_STORE = ON
GO
ALTER DATABASE [Voyager] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Voyager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Avaliacao]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avaliacao](
	[ID] [uniqueidentifier] NOT NULL,
	[IdPostagemViagem] [uniqueidentifier] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[StatusAvaliacao] [int] NULL,
 CONSTRAINT [PK_Avaliacao] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[ID] [uniqueidentifier] NOT NULL,
	[IdPostagemViagem] [uniqueidentifier] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[Comenario] [text] NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnderecosViagem]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnderecosViagem](
	[ID] [uniqueidentifier] NOT NULL,
	[IdViagem] [uniqueidentifier] NOT NULL,
	[Pais] [varchar](100) NULL,
	[Cidade] [varchar](200) NULL,
	[Logradouro] [varchar](255) NULL,
 CONSTRAINT [PK_EnderecosViagem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnderecoUsuario]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnderecoUsuario](
	[ID] [uniqueidentifier] NOT NULL,
	[Cep] [varchar](8) NULL,
	[Logradouro] [varchar](255) NULL,
	[Estado] [char](2) NULL,
	[Cidade] [varchar](255) NULL,
 CONSTRAINT [PK_EnderecoUsuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GaleriaImagem]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GaleriaImagem](
	[ID] [uniqueidentifier] NOT NULL,
	[IdPostagemViagem] [uniqueidentifier] NOT NULL,
	[Media] [text] NULL,
 CONSTRAINT [PK_GaleriaImagem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planejamento]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planejamento](
	[ID] [uniqueidentifier] NOT NULL,
	[Descricao] [text] NULL,
	[TiposAtividadeID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Planejamento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanejamentoAtividade]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanejamentoAtividade](
	[ID] [uniqueidentifier] NOT NULL,
	[IdPlanejamento] [uniqueidentifier] NOT NULL,
	[IdTipoAtividade] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PlanejamentoAtividade] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostagemViagem]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostagemViagem](
	[ID] [uniqueidentifier] NOT NULL,
	[IdViagem] [uniqueidentifier] NOT NULL,
	[Descricao] [text] NULL,
	[Titulo] [varchar](255) NULL,
 CONSTRAINT [PK_PostagemViagem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusViagem]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusViagem](
	[ID] [uniqueidentifier] NOT NULL,
	[Status] [varchar](100) NULL,
 CONSTRAINT [PK_StatusViagem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAtividade]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAtividade](
	[ID] [uniqueidentifier] NOT NULL,
	[TipoAtividade] [varchar](255) NULL,
 CONSTRAINT [PK_TipoAtividade] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoViagem]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoViagem](
	[ID] [uniqueidentifier] NOT NULL,
	[TipoViagem] [varchar](255) NULL,
 CONSTRAINT [PK_TipoViagem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Senha] [varchar](30) NOT NULL,
	[Foto] [text] NULL,
	[Bio] [text] NULL,
	[IdEnderecoUsuario] [uniqueidentifier] NOT NULL,
	[CodRecupSenha] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Viagem]    Script Date: 29/05/2024 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viagem](
	[ID] [uniqueidentifier] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[IdTipoViagem] [uniqueidentifier] NOT NULL,
	[IdPlanejamento] [uniqueidentifier] NOT NULL,
	[DataInicial] [datetime] NULL,
	[DataFinal] [datetime] NULL,
	[IdStatusViagem] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Viagem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Avaliacao_IdPostagemViagem]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Avaliacao_IdPostagemViagem] ON [dbo].[Avaliacao]
(
	[IdPostagemViagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Avaliacao_IdUsuario]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Avaliacao_IdUsuario] ON [dbo].[Avaliacao]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentario_IdPostagemViagem]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Comentario_IdPostagemViagem] ON [dbo].[Comentario]
(
	[IdPostagemViagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentario_IdUsuario]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Comentario_IdUsuario] ON [dbo].[Comentario]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EnderecosViagem_IdViagem]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_EnderecosViagem_IdViagem] ON [dbo].[EnderecosViagem]
(
	[IdViagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GaleriaImagem_IdPostagemViagem]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_GaleriaImagem_IdPostagemViagem] ON [dbo].[GaleriaImagem]
(
	[IdPostagemViagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Planejamento_TiposAtividadeID]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Planejamento_TiposAtividadeID] ON [dbo].[Planejamento]
(
	[TiposAtividadeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlanejamentoAtividade_IdPlanejamento]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_PlanejamentoAtividade_IdPlanejamento] ON [dbo].[PlanejamentoAtividade]
(
	[IdPlanejamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlanejamentoAtividade_IdTipoAtividade]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_PlanejamentoAtividade_IdTipoAtividade] ON [dbo].[PlanejamentoAtividade]
(
	[IdTipoAtividade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PostagemViagem_IdViagem]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_PostagemViagem_IdViagem] ON [dbo].[PostagemViagem]
(
	[IdViagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuario_Email]    Script Date: 29/05/2024 14:48:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuario_Email] ON [dbo].[Usuario]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_IdEnderecoUsuario]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_IdEnderecoUsuario] ON [dbo].[Usuario]
(
	[IdEnderecoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Viagem_IdPlanejamento]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Viagem_IdPlanejamento] ON [dbo].[Viagem]
(
	[IdPlanejamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Viagem_IdStatusViagem]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Viagem_IdStatusViagem] ON [dbo].[Viagem]
(
	[IdStatusViagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Viagem_IdTipoViagem]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Viagem_IdTipoViagem] ON [dbo].[Viagem]
(
	[IdTipoViagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Viagem_IdUsuario]    Script Date: 29/05/2024 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Viagem_IdUsuario] ON [dbo].[Viagem]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_Avaliacao_PostagemViagem_IdPostagemViagem] FOREIGN KEY([IdPostagemViagem])
REFERENCES [dbo].[PostagemViagem] ([ID])
GO
ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK_Avaliacao_PostagemViagem_IdPostagemViagem]
GO
ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_Avaliacao_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK_Avaliacao_Usuario_IdUsuario]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_PostagemViagem_IdPostagemViagem] FOREIGN KEY([IdPostagemViagem])
REFERENCES [dbo].[PostagemViagem] ([ID])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_PostagemViagem_IdPostagemViagem]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Usuario_IdUsuario]
GO
ALTER TABLE [dbo].[EnderecosViagem]  WITH CHECK ADD  CONSTRAINT [FK_EnderecosViagem_Viagem_IdViagem] FOREIGN KEY([IdViagem])
REFERENCES [dbo].[Viagem] ([ID])
GO
ALTER TABLE [dbo].[EnderecosViagem] CHECK CONSTRAINT [FK_EnderecosViagem_Viagem_IdViagem]
GO
ALTER TABLE [dbo].[GaleriaImagem]  WITH CHECK ADD  CONSTRAINT [FK_GaleriaImagem_PostagemViagem_IdPostagemViagem] FOREIGN KEY([IdPostagemViagem])
REFERENCES [dbo].[PostagemViagem] ([ID])
GO
ALTER TABLE [dbo].[GaleriaImagem] CHECK CONSTRAINT [FK_GaleriaImagem_PostagemViagem_IdPostagemViagem]
GO
ALTER TABLE [dbo].[Planejamento]  WITH CHECK ADD  CONSTRAINT [FK_Planejamento_TipoAtividade_TiposAtividadeID] FOREIGN KEY([TiposAtividadeID])
REFERENCES [dbo].[TipoAtividade] ([ID])
GO
ALTER TABLE [dbo].[Planejamento] CHECK CONSTRAINT [FK_Planejamento_TipoAtividade_TiposAtividadeID]
GO
ALTER TABLE [dbo].[PlanejamentoAtividade]  WITH CHECK ADD  CONSTRAINT [FK_PlanejamentoAtividade_Planejamento_IdPlanejamento] FOREIGN KEY([IdPlanejamento])
REFERENCES [dbo].[Planejamento] ([ID])
GO
ALTER TABLE [dbo].[PlanejamentoAtividade] CHECK CONSTRAINT [FK_PlanejamentoAtividade_Planejamento_IdPlanejamento]
GO
ALTER TABLE [dbo].[PlanejamentoAtividade]  WITH CHECK ADD  CONSTRAINT [FK_PlanejamentoAtividade_TipoAtividade_IdTipoAtividade] FOREIGN KEY([IdTipoAtividade])
REFERENCES [dbo].[TipoAtividade] ([ID])
GO
ALTER TABLE [dbo].[PlanejamentoAtividade] CHECK CONSTRAINT [FK_PlanejamentoAtividade_TipoAtividade_IdTipoAtividade]
GO
ALTER TABLE [dbo].[PostagemViagem]  WITH CHECK ADD  CONSTRAINT [FK_PostagemViagem_Viagem_IdViagem] FOREIGN KEY([IdViagem])
REFERENCES [dbo].[Viagem] ([ID])
GO
ALTER TABLE [dbo].[PostagemViagem] CHECK CONSTRAINT [FK_PostagemViagem_Viagem_IdViagem]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_EnderecoUsuario_IdEnderecoUsuario] FOREIGN KEY([IdEnderecoUsuario])
REFERENCES [dbo].[EnderecoUsuario] ([ID])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_EnderecoUsuario_IdEnderecoUsuario]
GO
ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_Planejamento_IdPlanejamento] FOREIGN KEY([IdPlanejamento])
REFERENCES [dbo].[Planejamento] ([ID])
GO
ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_Planejamento_IdPlanejamento]
GO
ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_StatusViagem_IdStatusViagem] FOREIGN KEY([IdStatusViagem])
REFERENCES [dbo].[StatusViagem] ([ID])
GO
ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_StatusViagem_IdStatusViagem]
GO
ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_TipoViagem_IdTipoViagem] FOREIGN KEY([IdTipoViagem])
REFERENCES [dbo].[TipoViagem] ([ID])
GO
ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_TipoViagem_IdTipoViagem]
GO
ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_Usuario_IdUsuario]
GO
USE [master]
GO
ALTER DATABASE [Voyager] SET  READ_WRITE 
GO
