/*
USE [master]
GO

/****** Object:  Database [Adler]    Script Date: 26.04.2020 17:01:13 ******/
CREATE DATABASE [Adler]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Adler', FILENAME = N'C:\Users\kop\Adler.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Adler_log', FILENAME = N'C:\Users\kop\Adler_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Adler].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Adler] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Adler] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Adler] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Adler] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Adler] SET ARITHABORT OFF 
GO

ALTER DATABASE [Adler] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Adler] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Adler] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Adler] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Adler] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Adler] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Adler] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Adler] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Adler] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Adler] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Adler] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Adler] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Adler] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Adler] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Adler] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Adler] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Adler] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Adler] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Adler] SET  MULTI_USER 
GO

ALTER DATABASE [Adler] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Adler] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Adler] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Adler] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Adler] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Adler] SET QUERY_STORE = OFF
GO

USE [Adler]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [Adler] SET  READ_WRITE 
GO






USE [Adler]
GO
/****** Object:  Table [dbo].[tblMovie]    Script Date: 26.04.2020 16:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMovie](
	[pkTblMovie] [int] IDENTITY(1,1) NOT NULL,
	[sName] [nvarchar](100) NOT NULL,
	[nYear] [int] NULL,
	[sDuration] [nvarchar](10) NULL,
 CONSTRAINT [PK_tblMovie] PRIMARY KEY CLUSTERED 
(
	[pkTblMovie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblMovie] ON 
GO
INSERT [dbo].[tblMovie] ([pkTblMovie], [sName], [nYear], [sDuration]) VALUES (1, N'Transformers', 2004, N'2:32:00')
GO
INSERT [dbo].[tblMovie] ([pkTblMovie], [sName], [nYear], [sDuration]) VALUES (2, N'Ironman', 2006, N'1:58:00')
GO
INSERT [dbo].[tblMovie] ([pkTblMovie], [sName], [nYear], [sDuration]) VALUES (3, N'S certy nejsou zerty', 1983, N'1:30:00')
GO
SET IDENTITY_INSERT [dbo].[tblMovie] OFF
GO
*/