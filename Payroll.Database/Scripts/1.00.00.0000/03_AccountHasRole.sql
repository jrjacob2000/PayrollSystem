USE [Payroll]
GO

/****** Object:  Table [dbo].[AccountHasRole]    Script Date: 12/13/2013 08:46:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountHasRole](
	[AccountId] [uniqueidentifier] NOT NULL,
	[RoleCode] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_AccountHasRole] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC,
	[RoleCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


