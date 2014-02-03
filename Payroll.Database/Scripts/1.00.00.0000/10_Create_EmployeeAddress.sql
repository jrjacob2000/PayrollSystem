USE [Payroll]
GO

/****** Object:  Table [dbo].[EmployeeAddress]    Script Date: 01/21/2014 15:32:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeAddress](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[AddressTypeCode] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[CityMun] [nvarchar](250) NOT NULL,
	[ProvState] [nvarchar](250) NOT NULL,
	[CountryCode] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[IsDeleted] [bigint] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmployeeAddress]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAddress_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO

ALTER TABLE [dbo].[EmployeeAddress] CHECK CONSTRAINT [FK_EmployeeAddress_Employee]
GO

ALTER TABLE [dbo].[EmployeeAddress] ADD  CONSTRAINT [DF_EmployeeAddress_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

