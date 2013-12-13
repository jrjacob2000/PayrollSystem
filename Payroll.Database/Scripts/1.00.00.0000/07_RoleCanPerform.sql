USE [Payroll]
GO

/****** Object:  Table [dbo].[RoleCanPerform]    Script Date: 12/13/2013 08:51:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleCanPerform](
	[RoleCode] [nvarchar](250) NOT NULL,
	[OperationCode] [nvarchar](250) NOT NULL
) ON [PRIMARY]

GO


