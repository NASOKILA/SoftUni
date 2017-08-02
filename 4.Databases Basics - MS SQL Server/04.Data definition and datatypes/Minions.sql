USE [Minions]
GO
/****** Object:  Table [dbo].[Minions]    Script Date: 02/08/2017 14:17:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Minions](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Age] [int] NULL,
	[TownsId] [int] NOT NULL,
 CONSTRAINT [PK_Minions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Towns]    Script Date: 02/08/2017 14:17:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Minions]  WITH CHECK ADD  CONSTRAINT [FK_Minions_Towns] FOREIGN KEY([TownsId])
REFERENCES [dbo].[Towns] ([Id])
GO
ALTER TABLE [dbo].[Minions] CHECK CONSTRAINT [FK_Minions_Towns]
GO
