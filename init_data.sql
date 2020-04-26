/*
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