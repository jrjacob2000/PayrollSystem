USE [Payroll]
GO
/****** Object:  StoredProcedure [dbo].[P_GetTimeSheetByEmployee]    Script Date: 01/30/2014 17:51:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[P_GetTimeSheetByEmployee] 
	@EmployeeId uniqueidentifier,
	@StartDate date,
	@EndDate	date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--declare @StartDate date, @EndDate date

	--set  @StartDate = dbo.ufn_GetFirstDayOfWeek('1/22/2014')
	--set  @EndDate = DATEADD(DAY, 7,@StartDate)
	

	select t.id, 
		t.EmployeeId, 
		c.Period ReportedDate, 
		t.DateTimeIn, 
		t.DateTimeOut, 
		t.IsDeleted,
		case when id is null then 
			case when DATENAME(weekday, c.Period ) = 'Saturday' or DATENAME(weekday, c.Period ) = 'Sunday' then DATENAME(weekday, c.Period )
			else 
				case when c.Period < CONVERT(date, getdate()) then 'Absent' else '' end
			end
		else '' end Remarks
	from F_Calendar(@StartDate,@EndDate) C
	left join dbo.EmployeeTimeSheet t on c.Period = t.ReportedDate and t.employeeId = @EmployeeId and t.IsDeleted = 0



END



