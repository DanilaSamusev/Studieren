USE [master]
GO
/****** Object:  Database [OstapenkoBBD]    Script Date: 24.12.2020 1:07:20 ******/
CREATE DATABASE [OstapenkoBBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OstapenkoBBD', FILENAME = N'D:\Programs\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\OstapenkoBBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OstapenkoBBD_log', FILENAME = N'D:\Programs\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\OstapenkoBBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OstapenkoBBD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OstapenkoBBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OstapenkoBBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OstapenkoBBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OstapenkoBBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OstapenkoBBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OstapenkoBBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET RECOVERY FULL 
GO
ALTER DATABASE [OstapenkoBBD] SET  MULTI_USER 
GO
ALTER DATABASE [OstapenkoBBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OstapenkoBBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OstapenkoBBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OstapenkoBBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OstapenkoBBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OstapenkoBBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OstapenkoBBD', N'ON'
GO
ALTER DATABASE [OstapenkoBBD] SET QUERY_STORE = OFF
GO
USE [OstapenkoBBD]
GO
/****** Object:  Table [dbo].[ВидыСпорта]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ВидыСпорта](
	[КодВидаСпорта] [int] IDENTITY(1,1) NOT NULL,
	[ИмяВидаСпорта] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодВидаСпорта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ГолосаПользователей]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ГолосаПользователей](
	[КодГолосаПользователя] [int] IDENTITY(1,1) NOT NULL,
	[ВыбранныйРезультатСобытия] [nvarchar](50) NOT NULL,
	[КодГолосования] [int] NOT NULL,
	[КодПользователя] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодГолосаПользователя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Голосования]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Голосования](
	[КодГолосования] [int] IDENTITY(1,1) NOT NULL,
	[КодСпортивногоСобытия] [int] NOT NULL,
	[КодПользователя] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодГолосования] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Команды]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Команды](
	[КодКоманды] [int] IDENTITY(1,1) NOT NULL,
	[ИмяКоманды] [nvarchar](100) NOT NULL,
	[КодВидаСпорта] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодКоманды] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[КомандыВСпортивномСобытии]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[КомандыВСпортивномСобытии](
	[КодКомандыВСпортивномСобытии] [int] IDENTITY(1,1) NOT NULL,
	[КодСпортивногоСобытия] [int] NOT NULL,
	[КодКоманды] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодКомандыВСпортивномСобытии] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[НовостныеЗаписи]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[НовостныеЗаписи](
	[КодНовостнойЗаписи] [int] IDENTITY(1,1) NOT NULL,
	[ИмяНовостнойЗаписи] [nvarchar](100) NOT NULL,
	[ТекстНовостнойЗаписи] [nvarchar](750) NOT NULL,
	[КодГолосования] [int] NULL,
	[КодПользователя] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[КодНовостнойЗаписи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ПерсональныеДанные]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ПерсональныеДанные](
	[КодПерсональныхДанных] [int] IDENTITY(1,1) NOT NULL,
	[ФИОПользователя] [nvarchar](100) NOT NULL,
	[НомерТелефонаПользователя] [nvarchar](50) NULL,
	[ПочтаПользователя] [nvarchar](50) NULL,
	[КодПользователя] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодПерсональныхДанных] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пользователи]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пользователи](
	[КодПользователя] [int] IDENTITY(1,1) NOT NULL,
	[ИмяПользователя] [nvarchar](50) NOT NULL,
	[ПарольПользователя] [nvarchar](50) NOT NULL,
	[КодРоли] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодПользователя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Роли]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Роли](
	[КодРоли] [int] IDENTITY(1,1) NOT NULL,
	[ИмяРоли] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодРоли] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[СпортивныеСобытия]    Script Date: 24.12.2020 1:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[СпортивныеСобытия](
	[КодСпортивногоСобытия] [int] IDENTITY(1,1) NOT NULL,
	[ИмяСпортивногоСобытия] [nvarchar](100) NOT NULL,
	[ДатаСпортивногоСобытия] [date] NOT NULL,
	[МестоСпортивногоСобытия] [nvarchar](50) NOT NULL,
	[РезультатСпортивногоСобытия] [nvarchar](50) NULL,
	[КодВидаСпорта] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[КодСпортивногоСобытия] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ГолосаПользователей]  WITH CHECK ADD FOREIGN KEY([КодГолосования])
REFERENCES [dbo].[Голосования] ([КодГолосования])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ГолосаПользователей]  WITH CHECK ADD FOREIGN KEY([КодПользователя])
REFERENCES [dbo].[Пользователи] ([КодПользователя])
GO
ALTER TABLE [dbo].[Голосования]  WITH CHECK ADD FOREIGN KEY([КодПользователя])
REFERENCES [dbo].[Пользователи] ([КодПользователя])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Голосования]  WITH CHECK ADD FOREIGN KEY([КодСпортивногоСобытия])
REFERENCES [dbo].[СпортивныеСобытия] ([КодСпортивногоСобытия])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Команды]  WITH CHECK ADD FOREIGN KEY([КодВидаСпорта])
REFERENCES [dbo].[ВидыСпорта] ([КодВидаСпорта])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[КомандыВСпортивномСобытии]  WITH CHECK ADD FOREIGN KEY([КодКоманды])
REFERENCES [dbo].[Команды] ([КодКоманды])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[КомандыВСпортивномСобытии]  WITH CHECK ADD FOREIGN KEY([КодСпортивногоСобытия])
REFERENCES [dbo].[СпортивныеСобытия] ([КодСпортивногоСобытия])
GO
ALTER TABLE [dbo].[НовостныеЗаписи]  WITH CHECK ADD FOREIGN KEY([КодГолосования])
REFERENCES [dbo].[Голосования] ([КодГолосования])
GO
ALTER TABLE [dbo].[НовостныеЗаписи]  WITH CHECK ADD FOREIGN KEY([КодПользователя])
REFERENCES [dbo].[Пользователи] ([КодПользователя])
GO
ALTER TABLE [dbo].[ПерсональныеДанные]  WITH CHECK ADD FOREIGN KEY([КодПользователя])
REFERENCES [dbo].[Пользователи] ([КодПользователя])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Пользователи]  WITH CHECK ADD FOREIGN KEY([КодРоли])
REFERENCES [dbo].[Роли] ([КодРоли])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[СпортивныеСобытия]  WITH CHECK ADD FOREIGN KEY([КодВидаСпорта])
REFERENCES [dbo].[ВидыСпорта] ([КодВидаСпорта])
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [OstapenkoBBD] SET  READ_WRITE 
GO
