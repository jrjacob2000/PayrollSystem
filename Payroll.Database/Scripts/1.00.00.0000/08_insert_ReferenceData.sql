
insert into dbo.ReferenceType
select 'Operation', 'Operation',0
union
select 'Role', 'Role',0
union
select 'CivilStatus', 'Civil Status',0
union
select 'Department', 'Department',0
union
select 'Position', 'Position',0
union
select 'TaxStatus', 'Tax Status',0
union
select 'EmployementType', 'Employement Type',0
union
select 'TaxStatus', 'Tax Status',0
union
select 'Bank', 'Bank',0
union 
select 'Country','Country',0
Go
select 'EmployeeStatus','Employee Status',0
Go

insert into dbo.Reference
select newid(),'ROLE',	'Administrator',	'Administrators',null,null
union
select newid(),'OPERATION',	'Operations.ManageReferencesSecurity',	'Manage Reference Security',null,null
union
select newid(),'ROLE',	'EMPLOYEE',	'Employee',null,null
union
select newid(),'REFERENCE_TYPE',	'Role,',	'Role',null,null
union
select newid(),'REFERENCE_TYPE',	'Operation',	'Operation',null,null
