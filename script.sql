USE [master]
GO
/****** Object:  Database [BlogApp]    Script Date: 1.03.2020 15:24:46 ******/
CREATE DATABASE [BlogApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BlogApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlogApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BlogApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BlogApp] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlogApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogApp] SET RECOVERY FULL 
GO
ALTER DATABASE [BlogApp] SET  MULTI_USER 
GO
ALTER DATABASE [BlogApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogApp] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BlogApp', N'ON'
GO
ALTER DATABASE [BlogApp] SET QUERY_STORE = OFF
GO
USE [BlogApp]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 1.03.2020 15:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[About] [nvarchar](max) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 1.03.2020 15:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[ArticleTitle] [nvarchar](50) NULL,
	[ArticleContent] [nvarchar](max) NULL,
	[Views] [int] NULL,
	[PublishDate] [date] NULL,
	[Author] [int] NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleTag]    Script Date: 1.03.2020 15:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NULL,
	[TagId] [int] NULL,
 CONSTRAINT [PK_ArticleTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1.03.2020 15:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 1.03.2020 15:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[QuestionSubject] [nvarchar](50) NULL,
	[QuestionContent] [nvarchar](max) NULL,
	[QuestionDate] [date] NULL,
	[Mail] [nvarchar](100) NULL,
	[Name] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialMedia]    Script Date: 1.03.2020 15:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminId] [int] NULL,
	[LogoClass] [nvarchar](50) NULL,
	[Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_SocialMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 1.03.2020 15:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'C#')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Asp .Net Core')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'PHP')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'C++')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'Python')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'Siber')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([Id], [TagName]) VALUES (1, N'Inovasyon')
INSERT [dbo].[Tag] ([Id], [TagName]) VALUES (2, N'Teknoloji')
INSERT [dbo].[Tag] ([Id], [TagName]) VALUES (3, N'Yazilim')
INSERT [dbo].[Tag] ([Id], [TagName]) VALUES (4, N'Bilim')
INSERT [dbo].[Tag] ([Id], [TagName]) VALUES (5, N'Tasarim')
INSERT [dbo].[Tag] ([Id], [TagName]) VALUES (6, N'Katmanli')
INSERT [dbo].[Tag] ([Id], [TagName]) VALUES (7, N'PHP')
SET IDENTITY_INSERT [dbo].[Tag] OFF
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_Category]
GO
ALTER TABLE [dbo].[ArticleTag]  WITH CHECK ADD  CONSTRAINT [FK_ArticleTag_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleTag] CHECK CONSTRAINT [FK_ArticleTag_Article]
GO
ALTER TABLE [dbo].[ArticleTag]  WITH CHECK ADD  CONSTRAINT [FK_ArticleTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[ArticleTag] CHECK CONSTRAINT [FK_ArticleTag_Tag]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Category]
GO
ALTER TABLE [dbo].[SocialMedia]  WITH CHECK ADD  CONSTRAINT [FK_SocialMedia_Admin] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admin] ([Id])
GO
ALTER TABLE [dbo].[SocialMedia] CHECK CONSTRAINT [FK_SocialMedia_Admin]
GO
USE [master]
GO
ALTER DATABASE [BlogApp] SET  READ_WRITE 
GO
