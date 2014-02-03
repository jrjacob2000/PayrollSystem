USE [Payroll]
GO

/****** Object:  Table [dbo].[EmployeeTimeSheet]    Script Date: 01/29/2014 08:14:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeTimeSheet](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[ReportedDate] [date] NOT NULL,
	[DateTimeIn] [datetime] NULL,
	[DateTimeOut] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TimeSheet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmployeeTimeSheet]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTimeSheet_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO

ALTER TABLE [dbo].[EmployeeTimeSheet] CHECK CONSTRAINT [FK_EmployeeTimeSheet_Employee]
GO

ALTER TABLE [dbo].[EmployeeTimeSheet] ADD  CONSTRAINT [DF_TimeSheet_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


