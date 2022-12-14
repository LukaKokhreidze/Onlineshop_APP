USE [OnlMarket_DB]
GO
/****** Object:  Table [dbo].[Items_TB]    Script Date: 11/12/2022 8:44:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items_TB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[ItemPrice] [float] NOT NULL,
	[Count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail_TB]    Script Date: 11/12/2022 8:44:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail_TB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CUsername] [varchar](50) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_TB]    Script Date: 11/12/2022 8:44:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_TB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[MoneyOnAcc] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Items_TB] ON 

INSERT [dbo].[Items_TB] ([Id], [ItemName], [ItemPrice], [Count]) VALUES (1, N'asd', 500, 10)
SET IDENTITY_INSERT [dbo].[Items_TB] OFF
GO
SET IDENTITY_INSERT [dbo].[User_TB] ON 

INSERT [dbo].[User_TB] ([Id], [Username], [Password], [Name], [Surname], [MoneyOnAcc]) VALUES (1, N'asd', N'asd', N'luka', N'kokhreidze', 5000)
INSERT [dbo].[User_TB] ([Id], [Username], [Password], [Name], [Surname], [MoneyOnAcc]) VALUES (2, N'asd', N'ddd', N'asd', N'dsa', 5000)
INSERT [dbo].[User_TB] ([Id], [Username], [Password], [Name], [Surname], [MoneyOnAcc]) VALUES (3, N'dsa', N'dsa', N'asd', N'dsa', 5000)
SET IDENTITY_INSERT [dbo].[User_TB] OFF
GO
