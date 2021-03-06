create database CMD
USE [CMD]
GO
/****** Object:  Table [dbo].[tblClient]    Script Date: 12/07/2017 16:18:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClient](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[web_page] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[tel] [varchar](50) NULL,
	[puesto] [varchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblContact]    Script Date: 12/07/2017 16:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblContact](
	[id_contact] [int] IDENTITY(1,1) NOT NULL,
	[id_client] [int] NULL,
	[name] [varchar](50) NULL,
	[first_name] [varchar](50) NULL,
	[web_address] [varchar](50) NULL,
	[tel] [varchar](50) NULL,
	[puesto] [varchar](50) NULL,
 CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED 
(
	[id_contact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLogin]    Script Date: 12/07/2017 16:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLogin](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Role] [varchar](255) NULL,
 CONSTRAINT [PK__tblUser__D2D1463715502E78] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblReunion]    Script Date: 12/07/2017 16:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblReunion](
	[id_reunion] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[fecha_y_hora] [datetime] NULL,
	[id_user] [int] NULL,
	[esVirtual] [bit] NULL,
	[id_client] [int] NULL,
 CONSTRAINT [PK_tblReunion] PRIMARY KEY CLUSTERED 
(
	[id_reunion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSupport_Tickets]    Script Date: 12/07/2017 16:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupport_Tickets](
	[id_Support_Tickets] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[detalle] [varchar](50) NULL,
	[id_user] [int] NULL,
	[id_client] [int] NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_tblSupport_Tickets] PRIMARY KEY CLUSTERED 
(
	[id_Support_Tickets] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblClient] ON 

INSERT [dbo].[tblClient] ([id_client], [name], [web_page], [direccion], [tel], [puesto]) VALUES (11, N'Juan Herrera', N'juician@hotmail.com', N'Valle Azul, San Lorenzo', N'77777777', N'Desarrolador')
INSERT [dbo].[tblClient] ([id_client], [name], [web_page], [direccion], [tel], [puesto]) VALUES (13, N'Michelle Ramírez', N'michelleramrezflores@gmail.com', N'Bajo Rodriguez', N'84002366', N'Desarrollador')
SET IDENTITY_INSERT [dbo].[tblClient] OFF
SET IDENTITY_INSERT [dbo].[tblContact] ON 

INSERT [dbo].[tblContact] ([id_contact], [id_client], [name], [first_name], [web_address], [tel], [puesto]) VALUES (7, 11, N'Lilliana', N'Flores', N'llliam@gmail.com', N'76767676', N'Desarrolador')
SET IDENTITY_INSERT [dbo].[tblContact] OFF
SET IDENTITY_INSERT [dbo].[tblLogin] ON 

INSERT [dbo].[tblLogin] ([id_user], [Username], [Password], [Role]) VALUES (2, N'Carol', N'12345', N'User')
INSERT [dbo].[tblLogin] ([id_user], [Username], [Password], [Role]) VALUES (3, N'Mitschi', N'12345', N'Admin')
SET IDENTITY_INSERT [dbo].[tblLogin] OFF
SET IDENTITY_INSERT [dbo].[tblReunion] ON 

INSERT [dbo].[tblReunion] ([id_reunion], [title], [fecha_y_hora], [id_user], [esVirtual], [id_client]) VALUES (6, N'mmmm', CAST(N'2017-07-13T00:00:00.000' AS DateTime), 2, 1, 11)
SET IDENTITY_INSERT [dbo].[tblReunion] OFF
SET IDENTITY_INSERT [dbo].[tblSupport_Tickets] ON 

INSERT [dbo].[tblSupport_Tickets] ([id_Support_Tickets], [title], [detalle], [id_user], [id_client], [estado]) VALUES (5, N'Computadora#3', N'Fuente de Poder', 2, 11, N'En Proceso')
SET IDENTITY_INSERT [dbo].[tblSupport_Tickets] OFF
