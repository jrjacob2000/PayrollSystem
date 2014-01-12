USE [Payroll]
GO

/****** Object:  Table [dbo].[Reference]    Script Date: 12/13/2013 08:49:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reference](
	[Id] [uniqueidentifier] NOT NULL,
	[ReferenceTypeCode] [nvarchar](250) NOT NULL,
	[ReferenceCode] [nvarchar](250) NOT NULL,
	[ReferenceValue] [nvarchar](250) NOT NULL,
	[Sequence] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Reference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Reference]  WITH CHECK ADD  CONSTRAINT [FK_Reference_ReferenceType] FOREIGN KEY([ReferenceTypeCode])
REFERENCES [dbo].[ReferenceType] ([ReferenceTypeCode])
GO

ALTER TABLE [dbo].[Reference] CHECK CONSTRAINT [FK_Reference_ReferenceType]
GO


