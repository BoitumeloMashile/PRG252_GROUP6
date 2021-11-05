USE [master]
GO

/****** Object:  Database [BelgiumCampusStudents]    Script Date: 2021/11/05 15:53:14 ******/
CREATE DATABASE [BelgiumCampusStudents]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BelgiumCampusStudents', FILENAME = N'C:\Program Files\Microsoft SQL Server Express\MSSQL15.SQLEXPRESS\MSSQL\DATA\BelgiumCampusStudents.mdf' , SIZE = 512000KB , MAXSIZE = 2048000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'BelgiumCampusStudents_log', FILENAME = N'C:\Program Files\Microsoft SQL Server Express\MSSQL15.SQLEXPRESS\MSSQL\DATA\BelgiumCampusStudents_log.ldf' , SIZE = 512000KB , MAXSIZE = 2017280KB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

CREATE TABLE [dbo].[tbl_Modules](
	[ModuleCode] [varchar](10) NOT NULL,
	[ModuleName] [varchar](25) NOT NULL,
	[ModuleDescription] [varchar](50) NULL,
	[Links] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Modules] PRIMARY KEY CLUSTERED 
(
	[ModuleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[tbl_Students](
	[StudentNumber] [int] NOT NULL,
	[StudentName] [varchar](25) NOT NULL,
	[StudentSurname] [varchar](25) NOT NULL,
	[StudentImage] [image] NULL,
	[DOB] [datetime] NOT NULL,
	[Gender] [varchar](10) NULL,
	[Phone] [int] NULL,
	[Address] [varchar](30) NOT NULL,
	[ModuleCodes] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbl_Students] PRIMARY KEY CLUSTERED 
(
	[StudentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE PROCEDURE [dbo].[ProcUpdate] 
	@moduleCode varchar(10),
	@moduleName varchar(25),
	@moduleDescription varchar(50),
	@links varchar(50)
	
AS
BEGIN
	
	UPDATE tbl_Modules
	SET
	
	ModuleName=@moduleName,
	ModuleDescription=@moduleDescription,
	Links=@links
	WHERE
	ModuleCode=@moduleCode
END
GO


