

insert into dbo.Reference
select newid(),'ROLE',	'Administrator',	'Administrators',null,null
union
select newid(),'OPERATION',	'MANAGEREFERENCESSECURITY',	'Manage Reference Security',null,null
union
select newid(),'ROLE',	'EMPLOYEE',	'Employee',null,null
union
select newid(),'REFERENCE_TYPE',	'Role,',	'Role',null,null
union
select newid(),'REFERENCE_TYPE',	'Operation',	'Operation',null,null
