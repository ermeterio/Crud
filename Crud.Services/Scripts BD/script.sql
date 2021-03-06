USE [master]
GO
/****** Object:  Database [avaliacao]    Script Date: 18/03/2021 01:17:02 ******/
CREATE DATABASE [avaliacao]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'avaliacao', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\avaliacao.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'avaliacao_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\avaliacao_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [avaliacao] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [avaliacao].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [avaliacao] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [avaliacao] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [avaliacao] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [avaliacao] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [avaliacao] SET ARITHABORT OFF 
GO
ALTER DATABASE [avaliacao] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [avaliacao] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [avaliacao] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [avaliacao] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [avaliacao] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [avaliacao] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [avaliacao] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [avaliacao] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [avaliacao] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [avaliacao] SET  DISABLE_BROKER 
GO
ALTER DATABASE [avaliacao] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [avaliacao] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [avaliacao] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [avaliacao] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [avaliacao] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [avaliacao] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [avaliacao] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [avaliacao] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [avaliacao] SET  MULTI_USER 
GO
ALTER DATABASE [avaliacao] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [avaliacao] SET DB_CHAINING OFF 
GO
ALTER DATABASE [avaliacao] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [avaliacao] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [avaliacao] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [avaliacao] SET QUERY_STORE = OFF
GO
USE [avaliacao]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 18/03/2021 01:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 18/03/2021 01:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NULL,
	[precoVenda] [decimal](10, 2) NULL,
	[descricao] [varchar](300) NULL,
	[imagem] [varchar](max) NULL,
	[idcategoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Categoria] FOREIGN KEY([id])
REFERENCES [dbo].[Categoria] ([id])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Categoria]
GO
/****** Object:  StoredProcedure [dbo].[sp_categoriaSel]    Script Date: 18/03/2021 01:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Carvalho
-- Create date: 15/03/2021
-- Description:	Procedure de listagem de categoria
-- =============================================
CREATE PROCEDURE [dbo].[sp_categoriaSel]
	-- Add the parameters for the stored procedure here
	@int_idCategoria int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if ISNULL(@int_idCategoria,0) > 0
		SELECT id, nome from Categoria where id = @int_idCategoria
	else
		SELECT id, nome from Categoria
END
GO
/****** Object:  StoredProcedure [dbo].[sp_produtoSel]    Script Date: 18/03/2021 01:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Carvalho
-- Create date: 15/03/2021
-- Description:	Procedure de retorno de produtos
-- =============================================
CREATE PROCEDURE [dbo].[sp_produtoSel]
	-- Add the parameters for the stored procedure here
	@int_idproduto int = null,
	@str_nome varchar(100) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @cmd nvarchar(100) = ' select id, nome, precoVenda, descricao, idcategoria, imagem from produto where 1= 1 '
		
	if ISNULL(@int_idproduto,0) > 0
		set @cmd += ' and id = ' + CONVERT(varchar, @int_idproduto) 
	
	if ISNULL(@str_nome, '') != ''
		set @cmd += ' and nome like ''%' + @str_nome + '%'''

   EXECUTE AS LOGIN = 'sa';
   EXEC sys.sp_executesql
		  @cmd
END
GO
USE [master]
GO
ALTER DATABASE [avaliacao] SET  READ_WRITE 
GO
