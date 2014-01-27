
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
CREATE FUNCTION [dbo].[F_Calendar] (  
  @DateStart datetime,   
  @DateEnd datetime   
)  
RETURNS @return_variable TABLE (   
  Period  date  
)    
BEGIN  

    -------------------------------------
	--declare @DateStart datetime,@DateEnd datetime   
	--declare @return_variable TABLE (Period  date) 
	
	--set @DateStart = '1/20/2014' 
	--set @DateEnd = '1/27/2014' 
	  
    -------------------------------------
	declare @Increment int,  
			@PeriodValue nvarchar(50),@Date datetime, @NumberOfDays  int 
	  
	set @Date = @DateStart	 
	
	select @NumberOfDays =  DATEDIFF(day,@DateStart,@DateEnd)
	
	 
	SELECT @Increment = 1  	   
	  
	WHILE (@NumberOfDays <> 0)  
	BEGIN  
		 insert into @Return_Variable values ( @Date);  
		 select @Date = DATEADD(day, @Increment , @Date);  
	  
		 select @NumberOfDays = @NumberOfDays - @Increment; 
	END  
	--select * from @return_variable
RETURN;  
END  


