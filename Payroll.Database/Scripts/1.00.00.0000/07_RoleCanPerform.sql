USE [Payroll]
GO

/****** Object:  Table [dbo].[RoleCanPerform]    Script Date: 12/13/2013 08:51:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleCanPerform](
	[RoleCode] [nvarchar](150) NOT NULL,
	[OperationCode] [nvarchar](150) NOT NULL
) ON [PRIMARY]

GO



/****** Object:  Index [PK_RoleCanPerform]    Script Date: 01/12/2014 15:27:05 ******/
ALTER TABLE [dbo].[RoleCanPerform] ADD  CONSTRAINT [PK_RoleCanPerform] PRIMARY KEY CLUSTERED 
(
	[RoleCode] ASC,
	[OperationCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


