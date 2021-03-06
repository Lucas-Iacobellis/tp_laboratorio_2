USE [master]
GO
/****** Object:  Database [SistemaDeVentas]    Script Date: 30/11/2020 09:54:54 ******/
CREATE DATABASE [SistemaDeVentas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaDeVentas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SistemaDeVentas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaDeVentas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SistemaDeVentas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SistemaDeVentas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaDeVentas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaDeVentas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaDeVentas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaDeVentas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaDeVentas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaDeVentas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SistemaDeVentas] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaDeVentas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaDeVentas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaDeVentas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaDeVentas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaDeVentas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaDeVentas] SET QUERY_STORE = OFF
GO
USE [SistemaDeVentas]
GO
/****** Object:  Table [dbo].[Celulares]    Script Date: 30/11/2020 09:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Celulares](
	[Nombre] [nvarchar](50) NOT NULL,
	[Precio] [float] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdProducto] [nvarchar](50) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[Pantalla] [nvarchar](50) NOT NULL,
	[Microprocesador] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Celulares] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 30/11/2020 09:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[DNI] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 30/11/2020 09:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[DNI] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teclados]    Script Date: 30/11/2020 09:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teclados](
	[Nombre] [nvarchar](50) NOT NULL,
	[Precio] [float] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdProducto] [nvarchar](50) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Teclados] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 30/11/2020 09:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[Nombre] [nvarchar](50) NOT NULL,
	[Precio] [float] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdProducto] [nvarchar](50) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[Pantalla] [nvarchar](50) NOT NULL,
	[Microprocesador] [nvarchar](50) NOT NULL,
	[IdRecord] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[IdRecord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Celulares] ([Nombre], [Precio], [Cantidad], [IdProducto], [Marca], [Pantalla], [Microprocesador]) VALUES (N'S8 Plus', 50000, 20, N'1', N'Samsung', N'5 pulgadas', N'Octa Core')
INSERT [dbo].[Celulares] ([Nombre], [Precio], [Cantidad], [IdProducto], [Marca], [Pantalla], [Microprocesador]) VALUES (N'S10 Plus', 80000, 22, N'2', N'Samsung', N'5 pulgadas', N'Octa Core')
GO
INSERT [dbo].[Clientes] ([Nombre], [Apellido], [Edad], [DNI], [IdCliente]) VALUES (N'Pablo', N'Ramirez', 30, 34756921, 1)
INSERT [dbo].[Clientes] ([Nombre], [Apellido], [Edad], [DNI], [IdCliente]) VALUES (N'Lautaro', N'Perez', 36, 33870923, 2)
GO
INSERT [dbo].[Empleados] ([Nombre], [Apellido], [Edad], [DNI], [IdEmpleado]) VALUES (N'Lucas', N'Gonzalez', 35, 32512790, 1)
INSERT [dbo].[Empleados] ([Nombre], [Apellido], [Edad], [DNI], [IdEmpleado]) VALUES (N'Nahuel', N'Benitez', 40, 32476904, 2)
GO
INSERT [dbo].[Teclados] ([Nombre], [Precio], [Cantidad], [IdProducto], [Marca], [Tipo]) VALUES (N'Teclado01', 300, 10, N'1', N'Genius', N'Estandar')
INSERT [dbo].[Teclados] ([Nombre], [Precio], [Cantidad], [IdProducto], [Marca], [Tipo]) VALUES (N'Teclado02', 400, 12, N'2', N'Razor', N'Gamer')
GO
USE [master]
GO
ALTER DATABASE [SistemaDeVentas] SET  READ_WRITE 
GO
