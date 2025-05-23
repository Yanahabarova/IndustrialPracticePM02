USE [master]
GO
/****** Object:  Database [DbLibrary]    Script Date: 11.04.2025 8:25:00 ******/
CREATE DATABASE [DbLibrary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DbLibrary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DbLibrary_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DbLibrary] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbLibrary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbLibrary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbLibrary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbLibrary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbLibrary] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbLibrary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbLibrary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbLibrary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbLibrary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbLibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbLibrary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbLibrary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbLibrary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbLibrary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbLibrary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbLibrary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbLibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbLibrary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbLibrary] SET RECOVERY FULL 
GO
ALTER DATABASE [DbLibrary] SET  MULTI_USER 
GO
ALTER DATABASE [DbLibrary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbLibrary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbLibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbLibrary] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbLibrary] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbLibrary] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DbLibrary', N'ON'
GO
ALTER DATABASE [DbLibrary] SET QUERY_STORE = ON
GO
ALTER DATABASE [DbLibrary] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DbLibrary]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 11.04.2025 8:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 11.04.2025 8:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cipher] [nvarchar](50) NOT NULL,
	[IdAuthor] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[YearOfPublication] [int] NULL,
	[NumberOfCopies] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistributingBooks]    Script Date: 11.04.2025 8:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistributingBooks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBook] [int] NOT NULL,
	[IdReader] [int] NOT NULL,
	[IssueDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
 CONSTRAINT [PK_DistributingBooks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Readers]    Script Date: 11.04.2025 8:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Readers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReadersCardNumber] [int] NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rearers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11.04.2025 8:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11.04.2025 8:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdReader] [int] NULL,
	[IdRole] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [Surname], [Name], [Patronymic]) VALUES (1, N'Остин', N'Джейн', NULL)
INSERT [dbo].[Authors] ([Id], [Surname], [Name], [Patronymic]) VALUES (2, N'Пушкин', N'Александр', N'Сергеевич')
INSERT [dbo].[Authors] ([Id], [Surname], [Name], [Patronymic]) VALUES (3, N'Достоевский', N'Федор', N'Михайлович')
INSERT [dbo].[Authors] ([Id], [Surname], [Name], [Patronymic]) VALUES (4, N'Толстой', N'Лев', N'Николаевич')
INSERT [dbo].[Authors] ([Id], [Surname], [Name], [Patronymic]) VALUES (6, N'Уайльд', N'Оскар', NULL)
INSERT [dbo].[Authors] ([Id], [Surname], [Name], [Patronymic]) VALUES (7, N'Булгаков', N'Михаил', N'Афанасьевич')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Cipher], [IdAuthor], [Name], [YearOfPublication], [NumberOfCopies]) VALUES (1, N'1.1 О1', 1, N'Гордость и предубеждение', 2015, 6)
INSERT [dbo].[Books] ([Id], [Cipher], [IdAuthor], [Name], [YearOfPublication], [NumberOfCopies]) VALUES (2, N'2.2 П12', 2, N'Евгений Онегин', 2014, 10)
INSERT [dbo].[Books] ([Id], [Cipher], [IdAuthor], [Name], [YearOfPublication], [NumberOfCopies]) VALUES (3, N'3.1 Д2', 3, N'Преступление и наказание', 2016, 7)
INSERT [dbo].[Books] ([Id], [Cipher], [IdAuthor], [Name], [YearOfPublication], [NumberOfCopies]) VALUES (4, N'4.6 Т3', 4, N'Анна Каренина', 2014, 7)
INSERT [dbo].[Books] ([Id], [Cipher], [IdAuthor], [Name], [YearOfPublication], [NumberOfCopies]) VALUES (7, N'5.1 У1', 6, N'Портрет Дориана Грея', 2017, 5)
INSERT [dbo].[Books] ([Id], [Cipher], [IdAuthor], [Name], [YearOfPublication], [NumberOfCopies]) VALUES (8, N'8.1 Б1', 7, N'Мастер и Маргарита', 2010, 5)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[DistributingBooks] ON 

INSERT [dbo].[DistributingBooks] ([Id], [IdBook], [IdReader], [IssueDate], [ReturnDate]) VALUES (1, 1, 2, CAST(N'2025-03-03T00:00:00.000' AS DateTime), CAST(N'2025-03-17T00:00:00.000' AS DateTime))
INSERT [dbo].[DistributingBooks] ([Id], [IdBook], [IdReader], [IssueDate], [ReturnDate]) VALUES (2, 2, 1, CAST(N'2025-03-05T00:00:00.000' AS DateTime), CAST(N'2025-03-19T00:00:00.000' AS DateTime))
INSERT [dbo].[DistributingBooks] ([Id], [IdBook], [IdReader], [IssueDate], [ReturnDate]) VALUES (3, 3, 4, CAST(N'2025-03-06T00:00:00.000' AS DateTime), CAST(N'2025-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[DistributingBooks] ([Id], [IdBook], [IdReader], [IssueDate], [ReturnDate]) VALUES (4, 7, 5, CAST(N'2025-03-10T00:00:00.000' AS DateTime), CAST(N'2025-03-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DistributingBooks] ([Id], [IdBook], [IdReader], [IssueDate], [ReturnDate]) VALUES (5, 4, 6, CAST(N'2025-03-10T00:00:00.000' AS DateTime), CAST(N'2025-03-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DistributingBooks] ([Id], [IdBook], [IdReader], [IssueDate], [ReturnDate]) VALUES (8, 8, 1, CAST(N'2025-04-02T00:00:00.000' AS DateTime), CAST(N'2025-04-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DistributingBooks] ([Id], [IdBook], [IdReader], [IssueDate], [ReturnDate]) VALUES (9, 1, 6, CAST(N'2025-04-03T00:00:00.000' AS DateTime), CAST(N'2025-04-17T00:00:00.000' AS DateTime))
INSERT [dbo].[DistributingBooks] ([Id], [IdBook], [IdReader], [IssueDate], [ReturnDate]) VALUES (10, 2, 5, CAST(N'2025-04-04T00:00:00.000' AS DateTime), CAST(N'2025-04-18T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DistributingBooks] OFF
GO
SET IDENTITY_INSERT [dbo].[Readers] ON 

INSERT [dbo].[Readers] ([Id], [ReadersCardNumber], [Surname], [Name], [Patronymic]) VALUES (1, 3461, N'Комарова', N'Людмила', N'Алексеевна')
INSERT [dbo].[Readers] ([Id], [ReadersCardNumber], [Surname], [Name], [Patronymic]) VALUES (2, 3440, N'Белова', N'Дарья', N'Данииловна')
INSERT [dbo].[Readers] ([Id], [ReadersCardNumber], [Surname], [Name], [Patronymic]) VALUES (4, 5558, N'Пахомов', N'Ярослав', N'Семёнович')
INSERT [dbo].[Readers] ([Id], [ReadersCardNumber], [Surname], [Name], [Patronymic]) VALUES (5, 3812, N'Петров', N'Егор', N'Станиславович')
INSERT [dbo].[Readers] ([Id], [ReadersCardNumber], [Surname], [Name], [Patronymic]) VALUES (6, 3460, N'Кузнецова', N'Елизавета', N'Павловна')
SET IDENTITY_INSERT [dbo].[Readers] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Role]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (2, N'Читатель')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [IdReader], [IdRole], [Login], [Password]) VALUES (1, NULL, 1, N'admin', N'12345')
INSERT [dbo].[Users] ([Id], [IdReader], [IdRole], [Login], [Password]) VALUES (2, 1, 2, N'comarova', N'431215')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[Authors] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO
ALTER TABLE [dbo].[DistributingBooks]  WITH CHECK ADD  CONSTRAINT [FK_DistributingBooks_Books] FOREIGN KEY([IdBook])
REFERENCES [dbo].[Books] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DistributingBooks] CHECK CONSTRAINT [FK_DistributingBooks_Books]
GO
ALTER TABLE [dbo].[DistributingBooks]  WITH CHECK ADD  CONSTRAINT [FK_DistributingBooks_Readers] FOREIGN KEY([IdReader])
REFERENCES [dbo].[Readers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DistributingBooks] CHECK CONSTRAINT [FK_DistributingBooks_Readers]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Readers] FOREIGN KEY([IdReader])
REFERENCES [dbo].[Readers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Readers]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [DbLibrary] SET  READ_WRITE 
GO
