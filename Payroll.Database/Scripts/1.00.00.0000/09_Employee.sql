USE [Payroll]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 01/19/2014 21:43:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Employee](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeNumber] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[MiddleName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[Age] [int] NOT NULL,
	[Birthdate] [date] NOT NULL,
	[Sex] [char](1) NOT NULL,
	[CivilStatus] [nvarchar](50) NOT NULL,
	[HomePhone] [nvarchar](250) NULL,
	[MobilePhone] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[PresentHomeAddressId] [uniqueidentifier] NULL,
	[DepartmentCode] [nvarchar](50) NOT NULL,
	[PositionCode] [nvarchar](50) NOT NULL,
	[TaxStatusCode] [nvarchar](50) NOT NULL,
	[HireDate] [date] NOT NULL,
	[EmployementTypeCode] [nvarchar](50) NOT NULL,
	[SSSNumber] [int] NOT NULL,
	[TINNumber] [int] NOT NULL,
	[PagIbigNumber] [int] NULL,
	[PhilHealthNumber] [int] NULL,
	[SalaryRate] [nvarchar](50) NULL,
	[CurrentSalary] [decimal](18, 2) NOT NULL,
	[BankNameCode] [nvarchar](50) NOT NULL,
	[AccountNumber] [int] NULL,
	[EmployeeStatus] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Employee] UNIQUE NONCLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


