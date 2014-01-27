use payroll
go  
  
CREATE FUNCTION dbo.F_GetFirstDayOfWeek (  
  @pInputDate datetime  
)  
RETURNS datetime  
BEGIN  
declare @OutputDate datetime  
  
SET @pInputDate = CONVERT(VARCHAR(10), @pInputDate, 111)  
-- Get the first day of the week (Sunday)  
SET @OutputDate = DATEADD(DD, 1 - DATEPART(DW, @pInputDate),@pInputDate)  
-- Get the Monday  
SET @OutputDate = DATEADD (DD, 1, @OutputDate)  
  
RETURN @OutputDate   
  
END  
