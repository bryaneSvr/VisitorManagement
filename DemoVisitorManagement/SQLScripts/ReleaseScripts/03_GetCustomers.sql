IF (OBJECT_ID('GetCustomers', 'P') IS NOT NULL)
BEGIN
	DROP PROCEDURE [dbo].[GetCustomers]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetCustomers
(
	@CustomerName NVARCHAR(50)
)
AS
BEGIN
	
SET NOCOUNT ON;

	SELECT
		Id
		,CustomerName
		,Address
		,ContactNumber
		,Country
	FROM
		Customers
	WHERE
		CustomerName LIKE '%' + LTRIM(RTRIM(@CustomerName)) + '%'
END
GO
