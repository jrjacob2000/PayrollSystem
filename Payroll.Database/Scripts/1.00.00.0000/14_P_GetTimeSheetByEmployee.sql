
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE P_GetTimeSheetByEmployee 
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
	
	

	select t.id, t.EmployeeId, c.Period ReportedDate, t.DateTimeIn, t.DateTimeOut, t.IsDeleted
	from F_Calendar(@StartDate,@EndDate) C
	left join dbo.EmployeeTimeSheet t on c.Period = t.ReportedDate and t.employeeId = @EmployeeId and t.IsDeleted = 0
	 

END
GO


