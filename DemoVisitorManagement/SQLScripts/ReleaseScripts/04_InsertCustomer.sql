IF (OBJECT_ID('InsertCustomers', 'P') IS NOT NULL)
BEGIN
	DROP PROCEDURE [dbo].[InsertCustomers]
END
GO

IF TYPE_ID('CustomerData') IS NOT NULL
BEGIN
	DROP TYPE dbo.CustomerData
END
GO

CREATE TYPE CustomerData AS TABLE
(
	CustomerName NVARCHAR(50) NOT NULL
	,Address NVARCHAR(250) NOT NULL
	,ContactNumber NVARCHAR(16) NOT NULL
	,Country NVARCHAR(70) NOT NULL
)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE InsertCustomers
(
	@Customers CustomerData READONLY
)
AS
BEGIN
	
SET NOCOUNT ON;

	INSERT INTO
		Customers
		(
			CustomerName
			,Address
			,ContactNumber
			,Country
		)
		SELECT
			CustomerName
			,Address
			,ContactNumber
			,Country
		FROM
			@Customers
END
GO
