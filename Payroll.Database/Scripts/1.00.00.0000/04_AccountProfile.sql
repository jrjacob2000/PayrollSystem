USE [Payroll]
GO

/****** Object:  Table [dbo].[AccountProfile]    Script Date: 12/13/2013 08:46:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountProfile](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FullName] [nvarchar](767) NULL,
	[Title] [nvarchar](255) NULL,
	[JobTitle] [nvarchar](255) NULL,
	[IsMale] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_AccountProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


