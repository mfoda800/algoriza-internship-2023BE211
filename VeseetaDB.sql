USE [master]
GO
/****** Object:  Database [Vezeeta]    Script Date: 09/12/2023 11:01:01 PM ******/
CREATE DATABASE [Vezeeta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vezeeta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Vezeeta.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Vezeeta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Vezeeta_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Vezeeta] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vezeeta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vezeeta] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vezeeta] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vezeeta] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vezeeta] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vezeeta] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vezeeta] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Vezeeta] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vezeeta] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vezeeta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vezeeta] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vezeeta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vezeeta] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vezeeta] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vezeeta] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vezeeta] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Vezeeta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vezeeta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vezeeta] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vezeeta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vezeeta] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vezeeta] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Vezeeta] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vezeeta] SET RECOVERY FULL 
GO
ALTER DATABASE [Vezeeta] SET  MULTI_USER 
GO
ALTER DATABASE [Vezeeta] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vezeeta] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vezeeta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vezeeta] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Vezeeta] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Vezeeta] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Vezeeta', N'ON'
GO
ALTER DATABASE [Vezeeta] SET QUERY_STORE = ON
GO
ALTER DATABASE [Vezeeta] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Vezeeta]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 09/12/2023 11:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscoundType]    Script Date: 09/12/2023 11:01:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscoundType](
	[ID] [int] NOT NULL,
	[discoundCode] [nvarchar](50) NULL,
	[discoundType] [nvarchar](50) NULL,
	[discoundPercent] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_DiscoundType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 09/12/2023 11:01:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[ID] [int] NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
	[Phone] [nvarchar](11) NULL,
	[SpecializeID] [int] NULL,
	[Gender] [bit] NULL,
	[dateOfBirth] [datetime] NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 09/12/2023 11:01:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[ID] [int] NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
	[Phone] [nvarchar](11) NULL,
	[Gender] [bit] NULL,
	[dateOfBirth] [datetime] NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 09/12/2023 11:01:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[ID] [int] NOT NULL,
	[DoctorID] [int] NULL,
	[PatientID] [int] NULL,
	[Date] [datetime] NULL,
	[price] [decimal](18, 2) NULL,
	[discoundCode] [nvarchar](50) NULL,
	[finalPrice] [decimal](18, 2) NULL,
	[Prescription] [nvarchar](max) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SettingStatus]    Script Date: 09/12/2023 11:01:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SettingStatus](
	[ID] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_SettingStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specializations]    Script Date: 09/12/2023 11:01:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specializations](
	[ID] [int] NOT NULL,
	[Specialize] [nvarchar](120) NULL,
 CONSTRAINT [PK_Specializations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/12/2023 11:01:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](150) NULL,
	[isAdmin] [bit] NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231209191825_InitialCreate', N'6.0.0')
GO
INSERT [dbo].[DiscoundType] ([ID], [discoundCode], [discoundType], [discoundPercent], [IsActive]) VALUES (1, N'AZX22', N'Normal Discount', CAST(10.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[DiscoundType] ([ID], [discoundCode], [discoundType], [discoundPercent], [IsActive]) VALUES (2, N'YNN', N'Medical Insurance', CAST(35.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[SettingStatus] ([ID], [Status]) VALUES (1, N'Pending')
INSERT [dbo].[SettingStatus] ([ID], [Status]) VALUES (2, N'Completed')
INSERT [dbo].[SettingStatus] ([ID], [Status]) VALUES (3, N'Cancelled')
GO
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (1, N'General medicine.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (2, N'Pediatrics.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (3, N'dentist.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (4, N'Heart Surgery.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (5, N'Psychiatry.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (6, N'Kidney disease.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (7, N'Gland diseases.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (8, N'Emergency Medicine.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (9, N'Brain surgery.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (10, N'Optical medicine.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (11, N'Veterinary Medicine.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (12, N'natural therapy.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (13, N'Medical tests.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (14, N'Marrow diseases.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (15, N'diabetes.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (16, N'skin diseases.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (17, N'Obstetrics and Gynecology.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (18, N'Internal medicine and gastroenterology.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (19, N'Bone, joint and cartilage medicine.')
INSERT [dbo].[Specializations] ([ID], [Specialize]) VALUES (20, N'Diseases of the ear, nose and throat.')
GO
INSERT [dbo].[Users] ([ID], [Name], [isAdmin], [Password]) VALUES (1, N'Admin', 1, N'12345678')
GO
/****** Object:  Index [IX_Doctors_SpecializeID]    Script Date: 09/12/2023 11:01:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Doctors_SpecializeID] ON [dbo].[Doctors]
(
	[SpecializeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Setting_DoctorID]    Script Date: 09/12/2023 11:01:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Setting_DoctorID] ON [dbo].[Setting]
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Setting_PatientID]    Script Date: 09/12/2023 11:01:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Setting_PatientID] ON [dbo].[Setting]
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Setting_Status]    Script Date: 09/12/2023 11:01:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Setting_Status] ON [dbo].[Setting]
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_Specializations] FOREIGN KEY([SpecializeID])
REFERENCES [dbo].[Specializations] ([ID])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_Specializations]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_Doctors] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctors] ([ID])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Setting_Doctors]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_Patients] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patients] ([ID])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Setting_Patients]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_SettingStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[SettingStatus] ([ID])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Setting_SettingStatus]
GO
USE [master]
GO
ALTER DATABASE [Vezeeta] SET  READ_WRITE 
GO
