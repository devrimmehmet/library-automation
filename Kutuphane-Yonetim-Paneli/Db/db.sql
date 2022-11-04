USE [master]
GO
/****** Object:  Database [Library]    Script Date: 4.11.2022 23:45:12 ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kutuphane', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kutuphane.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kutuphane_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kutuphane_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY FULL 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Library] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Library', N'ON'
GO
ALTER DATABASE [Library] SET QUERY_STORE = OFF
GO
USE [Library]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameSurname] [nvarchar](100) NOT NULL,
	[Information] [nvarchar](1500) NULL,
	[DeletedState] [bit] NULL,
 CONSTRAINT [PK_Yazarlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookComments]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookComments](
	[Book_ID] [int] NOT NULL,
	[Member_ID] [int] NOT NULL,
	[Ratings] [float] NOT NULL,
	[Comments] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Author_ID] [int] NOT NULL,
	[PublicationYear] [int] NOT NULL,
	[NumberOfPages] [smallint] NULL,
	[Language_ID] [int] NULL,
	[Publisher_ID] [int] NOT NULL,
	[Description] [ntext] NULL,
	[State] [bit] NOT NULL,
	[ShelfNumber] [nvarchar](50) NOT NULL,
	[Category_ID] [int] NOT NULL,
	[Photo] [image] NULL,
	[DeletedState] [bit] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DeletedState] [bit] NOT NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Phone] [varchar](11) NOT NULL,
	[IdentityNumber] [varchar](11) NOT NULL,
	[Gender] [nvarchar](20) NULL,
	[BirthDate] [smalldatetime] NULL,
	[Permission_ID] [tinyint] NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[DeletedState] [bit] NOT NULL,
	[DeletedInfo] [text] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedEmployeeID] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](20) NOT NULL,
	[DeletedState] [bit] NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](20) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[Phone] [varchar](11) NOT NULL,
	[IdentityNumber] [varchar](11) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Member_State_ID] [tinyint] NOT NULL,
	[MemberDate] [datetime] NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[DeletedState] [bit] NOT NULL,
	[DeletedInfo] [text] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedEmployeeID] [int] NULL,
 CONSTRAINT [PK_Uyeler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberStates]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberStates](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[MemberState] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Uyelik_Durumu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Permission] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [varchar](11) NULL,
	[Mail] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[DeletedState] [bit] NOT NULL,
 CONSTRAINT [PK_YayınEvleri] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RequestType_ID] [tinyint] NOT NULL,
	[Request] [text] NOT NULL,
	[RequestNote] [nvarchar](200) NULL,
	[RequestState] [bit] NOT NULL,
	[Member_ID] [int] NOT NULL,
 CONSTRAINT [PK_Talepler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestTypes]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestTypes](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[RequestType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Talep_Turu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Member_ID] [int] NOT NULL,
	[EntrustedEmployee_ID] [int] NOT NULL,
	[ReturnEmployee_ID] [int] NULL,
	[Book_ID] [int] NOT NULL,
	[TransactionsDate] [datetime] NOT NULL,
	[BookDepositDate] [datetime] NOT NULL,
	[BookReturnDate] [datetime] NULL,
	[TransactionNote] [text] NULL,
	[TransactionState] [bit] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([ID], [NameSurname], [Information], [DeletedState]) VALUES (19, N'George Orwell', N'Eric Arthur Blair veya daha bilinen takma adıyla George Orwell 20. yüzyıl İngiliz edebiyatının önde gelen kalemleri arasında yer alan İngiliz romancı, gazeteci ve eleştirmen. En çok, dünyaca ünlü Bin Dokuz Yüz Seksen Dört adlı romanı ve bu romanda yarattığı Big Brother kavramı ile tanınır.', 0)
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([ID], [Name], [Author_ID], [PublicationYear], [NumberOfPages], [Language_ID], [Publisher_ID], [Description], [State], [ShelfNumber], [Category_ID], [Photo], [DeletedState]) VALUES (2, N'Hayvan Çiftliği', 19, 2022, 152, 1, 5, N'Fazla çalıştırılan ve kötü muamele gören hayvanlar bir gün toplanıp yaşadıkları çiftliği ele geçirirler. Sonunda söz sahibi olmuşlardır, çiftlikte daha adil ve eşit bir toplum oluşturmaya kararlıdırla', 1, N'A001', 19, NULL, 0)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (1, N'Anı', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (2, N'Anlatı', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (3, N'Araştırma-İnceleme', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (4, N'Bilim', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (5, N'Biyografi', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (6, N'Çizgi Roman
', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (7, N'Deneme', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (8, N'Edebiyat', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (9, N'Eğitim', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (10, N'Felsefe', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (11, N'Gençlik', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (12, N'Gezi', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (13, N'Hikaye', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (14, N'Hobi', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (15, N'İnceleme', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (16, N'İş Ekonomi - Hukuk
', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (17, N'Kişisel Gelişim
', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (18, N'Konuşmalar', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (19, N'Masal', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (20, N'Mektup', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (21, N'Mizah', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (22, N'Öykü', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (23, N'Polisiye', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (24, N'Psikoloji', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (25, N'Resimli Öykü
', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (26, N'Roman', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (27, N'Sağlık', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (28, N'Sanat - Tasarım
', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (29, N'Sanat - Müzik
', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (30, N'Sinema Tarihi
', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (31, N'Söyleşi', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (32, N'Şiir', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (33, N'Tarih', 0)
INSERT [dbo].[Categories] ([ID], [Name], [DeletedState]) VALUES (34, N'Yemek Kitapları
', 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([ID], [Name], [Surname], [Phone], [IdentityNumber], [Gender], [BirthDate], [Permission_ID], [Mail], [Password], [DeletedState], [DeletedInfo], [DeletedDate], [DeletedEmployeeID]) VALUES (1, N'Devrim Mehmet', N'Pattabanoğlu', N'05438194976', N'11111111111', N'Erkek', CAST(N'1993-08-20T00:00:00' AS SmallDateTime), 1, N'devrimmehmet@gmail.com', N'123456', 0, NULL, NULL, NULL)
INSERT [dbo].[Employees] ([ID], [Name], [Surname], [Phone], [IdentityNumber], [Gender], [BirthDate], [Permission_ID], [Mail], [Password], [DeletedState], [DeletedInfo], [DeletedDate], [DeletedEmployeeID]) VALUES (11, N'Devrim Mehmet', N'Pattabanoğlu', N'05438194976', N'22222222222', N'Erkek', CAST(N'1993-08-20T00:00:00' AS SmallDateTime), 1, N'devrimmehmet@gmail.com', N'123456', 0, N'ç', CAST(N'2022-11-04T22:28:07.000' AS DateTime), 11)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([ID], [Language], [DeletedState]) VALUES (1, N'Türkçe', 0)
INSERT [dbo].[Languages] ([ID], [Language], [DeletedState]) VALUES (2, N'Rusça', 0)
INSERT [dbo].[Languages] ([ID], [Language], [DeletedState]) VALUES (3, N'İngilizce', 0)
INSERT [dbo].[Languages] ([ID], [Language], [DeletedState]) VALUES (4, N'Almanca', 0)
INSERT [dbo].[Languages] ([ID], [Language], [DeletedState]) VALUES (5, N'Fransızca', 0)
INSERT [dbo].[Languages] ([ID], [Language], [DeletedState]) VALUES (7, N'İtalyanca', 0)
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([ID], [Name], [Surname], [Gender], [BirthDate], [Phone], [IdentityNumber], [Mail], [Address], [Member_State_ID], [MemberDate], [Password], [DeletedState], [DeletedInfo], [DeletedDate], [DeletedEmployeeID]) VALUES (70, N'Devrim Mehmet', N'Pattabanoğlu', N'Erkek', CAST(N'2007-11-04T00:00:00.0000000' AS DateTime2), N'05438194976', N'22222222222', N'devrimmehmet@gmail.com', N'Ahiçelebi Mah.
Esen Sok.
No:4
Devrekani / Kastamonu', 1, CAST(N'2022-11-04T19:17:50.393' AS DateTime), N'2007', 0, NULL, NULL, NULL)
INSERT [dbo].[Members] ([ID], [Name], [Surname], [Gender], [BirthDate], [Phone], [IdentityNumber], [Mail], [Address], [Member_State_ID], [MemberDate], [Password], [DeletedState], [DeletedInfo], [DeletedDate], [DeletedEmployeeID]) VALUES (71, N'Erhan', N'Topçu', N'Erkek', CAST(N'2007-11-03T00:00:00.0000000' AS DateTime2), N'33333333333', N'32222222222', N'erhan.topcu@gmail.com', N'Yasa Caddesi. Adres: Osmanağa Mah. Yasa Cad. No:18 Kadıköy / İstanbul (Asya)', 1, CAST(N'2022-11-04T19:26:57.790' AS DateTime), N'2007', 0, NULL, NULL, NULL)
INSERT [dbo].[Members] ([ID], [Name], [Surname], [Gender], [BirthDate], [Phone], [IdentityNumber], [Mail], [Address], [Member_State_ID], [MemberDate], [Password], [DeletedState], [DeletedInfo], [DeletedDate], [DeletedEmployeeID]) VALUES (72, N'dscsd', N'sdfsf', N'Kadın', CAST(N'2007-11-04T00:00:00.0000000' AS DateTime2), N'33333333333', N'22222222227', N'@.', N'asd', 2, CAST(N'2022-11-04T19:27:23.547' AS DateTime), N'2007', 0, N'Üye Kaydını Sildirmek İstedi.', CAST(N'2022-11-04T21:52:21.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberStates] ON 

INSERT [dbo].[MemberStates] ([ID], [MemberState]) VALUES (1, N'Aktif')
INSERT [dbo].[MemberStates] ([ID], [MemberState]) VALUES (2, N'Pasif')
INSERT [dbo].[MemberStates] ([ID], [MemberState]) VALUES (3, N'Cezalı')
SET IDENTITY_INSERT [dbo].[MemberStates] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([ID], [Permission]) VALUES (1, N'Çalışan')
INSERT [dbo].[Permissions] ([ID], [Permission]) VALUES (3, N'Gönüllü')
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (1, N'Yapı Kredi Yayınları', N'02122524700', N'iletisim@ykykultur.com.tr', N'İstiklal Caddesi No: 161 34433, Beyoğlu / İstanbul', 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (2, N'KAPRA YAYINCILIK', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (3, N'TÜBİTAK YAYINLARI', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (4, N'KARBON KİTAPLAR', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (5, N'Can Yayınları', N'02122525988', N'yayinevi@canyayinlari.com', N'Iz Plaza Giz Maslak, Eski Büyükdere
Cad. No:9 Kat:8
Sarıyer / İstanbul', 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (6, N'CAN ÇOCUK YAYINLARI', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (7, N'GÜNIŞIĞI KİTAPLIĞI', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (8, N'KRONİK KİTAP', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (9, N'PEGASUS YAYINLARI', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (10, N'HAYY KİTAP', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (11, N'İTHAKİ YAYINLARI', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (12, N'DOĞAN KİTAP', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (13, N'TİMAŞ ÇOCUK YAYINLARI', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (14, N'DOMİNGO YAYINEVİ', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (15, N'TÜRKİYE İŞ BANKASI KÜLTÜR YAYINLARI', NULL, NULL, NULL, 0)
INSERT [dbo].[Publishers] ([ID], [Name], [Phone], [Mail], [Address], [DeletedState]) VALUES (16, N'TURKUVAZ KİTAP', NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[RequestTypes] ON 

INSERT [dbo].[RequestTypes] ([ID], [RequestType]) VALUES (1, N'Kitap İsteği')
INSERT [dbo].[RequestTypes] ([ID], [RequestType]) VALUES (2, N'Öneri')
INSERT [dbo].[RequestTypes] ([ID], [RequestType]) VALUES (3, N'Şikayet')
INSERT [dbo].[RequestTypes] ([ID], [RequestType]) VALUES (4, N'Bilgi Güncelleme Talebi')
INSERT [dbo].[RequestTypes] ([ID], [RequestType]) VALUES (5, N'Diğer')
SET IDENTITY_INSERT [dbo].[RequestTypes] OFF
GO
ALTER TABLE [dbo].[Authors] ADD  CONSTRAINT [DF_Authors_DeletedState]  DEFAULT ((0)) FOR [DeletedState]
GO
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_Books_State]  DEFAULT ((1)) FOR [State]
GO
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_Books_DeletedState]  DEFAULT ((0)) FOR [DeletedState]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_DeletedState]  DEFAULT ((0)) FOR [DeletedState]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_DeletedState]  DEFAULT ((0)) FOR [DeletedState]
GO
ALTER TABLE [dbo].[Languages] ADD  CONSTRAINT [DF_Languages_DeletedState]  DEFAULT ((0)) FOR [DeletedState]
GO
ALTER TABLE [dbo].[Members] ADD  CONSTRAINT [DF_Members_Member_State_ID]  DEFAULT ((1)) FOR [Member_State_ID]
GO
ALTER TABLE [dbo].[Members] ADD  CONSTRAINT [DF_Members_MemberDate]  DEFAULT (getdate()) FOR [MemberDate]
GO
ALTER TABLE [dbo].[Members] ADD  CONSTRAINT [DF_Members_DeletedState]  DEFAULT ((0)) FOR [DeletedState]
GO
ALTER TABLE [dbo].[Publishers] ADD  CONSTRAINT [DF_Publishers_DeletedState]  DEFAULT ((0)) FOR [DeletedState]
GO
ALTER TABLE [dbo].[BookComments]  WITH CHECK ADD  CONSTRAINT [FK_BookComments_Books] FOREIGN KEY([Book_ID])
REFERENCES [dbo].[Books] ([ID])
GO
ALTER TABLE [dbo].[BookComments] CHECK CONSTRAINT [FK_BookComments_Books]
GO
ALTER TABLE [dbo].[BookComments]  WITH CHECK ADD  CONSTRAINT [FK_BookComments_Members] FOREIGN KEY([Member_ID])
REFERENCES [dbo].[Members] ([ID])
GO
ALTER TABLE [dbo].[BookComments] CHECK CONSTRAINT [FK_BookComments_Members]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([Author_ID])
REFERENCES [dbo].[Authors] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Languages] FOREIGN KEY([Language_ID])
REFERENCES [dbo].[Languages] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Languages]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers] FOREIGN KEY([Publisher_ID])
REFERENCES [dbo].[Publishers] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Permissions] FOREIGN KEY([Permission_ID])
REFERENCES [dbo].[Permissions] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Permissions]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_MemberStates] FOREIGN KEY([Member_State_ID])
REFERENCES [dbo].[MemberStates] ([ID])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_MemberStates]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Members] FOREIGN KEY([Member_ID])
REFERENCES [dbo].[Members] ([ID])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Members]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_RequestTypes] FOREIGN KEY([RequestType_ID])
REFERENCES [dbo].[RequestTypes] ([ID])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_RequestTypes]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Books] FOREIGN KEY([Book_ID])
REFERENCES [dbo].[Books] ([ID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Books]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Employees] FOREIGN KEY([EntrustedEmployee_ID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Employees]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Employees1] FOREIGN KEY([ReturnEmployee_ID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Employees1]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Employees2] FOREIGN KEY([EntrustedEmployee_ID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Employees2]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Members] FOREIGN KEY([Member_ID])
REFERENCES [dbo].[Members] ([ID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Members]
GO
/****** Object:  StoredProcedure [dbo].[AddAuthors]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[AddAuthors]
(
   
     @NameSurname nvarchar(100),
	 @Information nvarchar(MAX)
   
)
as
insert into Authors (NameSurname,Information) values(@NameSurname,@Information)
GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddBook]
(
   
     @Name nvarchar(100),
     @Author_ID int,
	 @PublicationYear int,
	 @NumberOfPages smallint,
	 @Language_ID tinyint,
	 @Publisher_ID int,
	 @Description ntext,
	 @State bit,
	 @ShelfNumber nvarchar(50),
	 @Category_ID tinyint,
	 @Photo image
   
)
as
insert into Books  (Name,Author_ID,PublicationYear,NumberOfPages,Language_ID,Publisher_ID,Description,State,ShelfNumber,Category_ID) values(@Name,@Author_ID,@PublicationYear,@NumberOfPages,@Language_ID,@Publisher_ID,@Description,1,@ShelfNumber,@Category_ID)
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromAuthors]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteFromAuthors]
(
  @ID int
)
as
Update Authors set DeletedState=1 where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromBooks]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteFromBooks]
(
  @ID int
)
as
Update Books set DeletedState=1 where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromCategories]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteFromCategories]
(
  @ID int
)
as
Update Categories set DeletedState=1 where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromEmployees]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteFromEmployees]
(
  @ID int,
  @DeletedInfo text,
  @DeletedDate datetime,
  @DeletedEmployeeID int
)
as
update Employees set DeletedState=1, DeletedDate=@DeletedDate, DeletedInfo=@DeletedInfo,DeletedEmployeeID=@DeletedEmployeeID where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromLanguages]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteFromLanguages]
(
  @ID int
)
as
Update Languages set DeletedState=1 where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromMemberRequestTypes]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteFromMemberRequestTypes]
(
  @ID int
)
as
delete RequestTypes where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromMembers]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteFromMembers]
(
  @ID int,
  @DeletedInfo text,
  @DeletedDate datetime,
  @DeletedEmployeeID int
)
as
Update Members set DeletedState=1, DeletedDate=@DeletedDate, DeletedInfo=@DeletedInfo,DeletedEmployeeID=@DeletedEmployeeID where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromMemberStates]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteFromMemberStates]
(
  @ID int
)
as
delete MemberStates where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromPermissions]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteFromPermissions]
(
  @ID int
)
as
delete Permissions where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromPublishers]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteFromPublishers]
(
  @ID int
)
as
Update Publishers set DeletedState=1 where ID=@ID 
GO
/****** Object:  StoredProcedure [dbo].[FindAuthor]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FindAuthor]
(
   
     @NameSurname nvarchar(100)
   
)
as
SELECT * FROM Authors where NameSurname= @NameSurname
GO
/****** Object:  StoredProcedure [dbo].[FindCategory]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[FindCategory]
(
   
     @Name nvarchar(50)
   
)
as
SELECT * FROM Categories where Name= @Name and DeletedState=0
GO
/****** Object:  StoredProcedure [dbo].[FindPublisher]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FindPublisher]
(
     @Name nvarchar(50) 
)
as
SELECT * FROM Publishers where Name=@Name and DeletedState=0
GO
/****** Object:  StoredProcedure [dbo].[FindPublisherForUpdate]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FindPublisherForUpdate]
(
	 @ID int,
     @Name nvarchar(50) 
)
as
SELECT * FROM Publishers where Name=@Name and DeletedState=0 and ID!=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromAuthors]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromAuthors]
(
     @ID int,
     @NameSurname nvarchar(100),
     @Information nvarchar(Max)
   
)
as
update Authors set NameSurname=@NameSurname,Information=@Information where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromBooks]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateFromBooks]
(
     @ID int,
     @Name nvarchar(100),
     @Author_ID int,
	 @PublicationYear int,
	 @NumberOfPages smallint,
	 @Language_ID tinyint,
	 @Publisher_ID int,
	 @Description ntext,
	 @State bit,
	 @ShelfNumber nvarchar(50),
	 @Category_ID tinyint
	 
   
)
as
Update Books set Name=@Name,Author_ID=@Author_ID,PublicationYear=@PublicationYear,NumberOfPages=@NumberOfPages,Language_ID=@Language_ID,Publisher_ID=@Publisher_ID,Description=@Description,State=@State,ShelfNumber=@ShelfNumber,Category_ID=@Category_ID where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromCategories]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromCategories]
(
     @ID int,
     @Name nvarchar(50)
   
)
as
update Categories set Name=@Name where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromDateTransactions]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromDateTransactions]
(
     @ID int,
     @BookDepositDate datetime,
	 @TransactionNote text
   
)
as
Update Transactions set BookDepositDate=@BookDepositDate,TransactionNote=@TransactionNote where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromEmployees]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UpdateFromEmployees]
(
     @ID int,
     @Name nvarchar(50),
     @Surname nvarchar(50),
     @Gender nvarchar(20),
	 @BirthDate datetime2(7),
	 @Phone varchar(11),
	
	 @Mail nvarchar(50),
	 
	 @Permission_ID tinyint,
	 
	 @Password nvarchar(50)
)
as
update Employees set Name=@Name,Surname=@Surname, Gender=@Gender,BirthDate=@BirthDate,Phone=@Phone,Mail=@Mail,Permission_ID=@Permission_ID,Password=@Password where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromLanguages]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromLanguages]
(
     @ID int,
     @Language nvarchar(20)
   
)
as
update Languages set Language=@Language where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromMembers]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromMembers]
(
     @ID int,
     @Name nvarchar(50),
     @Surname nvarchar(50),
     @Gender nvarchar(20),
	 @BirthDate datetime2(7),
	 @Phone varchar(11),
	
	 @Mail nvarchar(50),
	 @Address nvarchar(200),
	 @Member_State_ID tinyint,
	 
	 @Password nvarchar(50)
)
as
update Members set Name=@Name,Surname=@Surname, Gender=@Gender,BirthDate=@BirthDate,Phone=@Phone,Mail=@Mail,Address=@Address,Member_State_ID=@Member_State_ID,Password=@Password where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromMembersForMember]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromMembersForMember]
(
     @ID int,
     @Name nvarchar(50),
     @Surname nvarchar(50),
     @Gender nvarchar(20),
	 @BirthDate datetime2(7),
	 @Phone varchar(11),
	 @Mail nvarchar(50),
	 @Address nvarchar(200),
	 @Password nvarchar(50)
)
as
update Members set Name=@Name,Surname=@Surname, Gender=@Gender,BirthDate=@BirthDate,Phone=@Phone,Mail=@Mail,Address=@Address,Password=@Password where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromMemberStates]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromMemberStates]
(
     @ID int,
     @MemberState nvarchar(50)
    
   
)
as
update MemberStates set MemberState=@MemberState where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromPermissions]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromPermissions]
(
     @ID int,
     @Permission nvarchar(50)
     
)
as
update Permissions set Permission=@Permission where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromPublishers]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromPublishers]
(
     @ID int,
     @Name nvarchar(50),
	 @Phone varchar(11),
	 @Mail nvarchar(50),
	 @Adress nvarchar(200)
)
as
update Publishers set Name=@Name,Phone=@Phone,Mail=@Mail,Address=@Adress where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromRequestTypes]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromRequestTypes]
(
     @ID int,
     @RequestType nvarchar(50)
    
   
)
as
update RequestTypes set RequestType=@RequestType where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateFromTransactions]    Script Date: 4.11.2022 23:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFromTransactions]
(
     @ID int,
     @ReturnEmployee_ID int,
     @BookReturnDate datetime,
	 @TransactionNote text
   
)
as
Update Transactions set ReturnEmployee_ID= @ReturnEmployee_ID, BookReturnDate=@BookReturnDate,TransactionNote=@TransactionNote,TransactionState=1 where ID=@ID
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
