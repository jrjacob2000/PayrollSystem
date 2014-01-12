USE [Payroll]
GO

/****** Object:  Table [dbo].[ReferenceType]    Script Date: 12/13/2013 08:50:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReferenceType](
	[ReferenceTypeCode] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ReferenceType] PRIMARY KEY CLUSTERED 
(
	[ReferenceTypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


