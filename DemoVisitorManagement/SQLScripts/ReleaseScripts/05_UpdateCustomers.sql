IF (OBJECT_ID('UpdateCustomers', 'P') IS NOT NULL)
BEGIN
	DROP PROCEDURE [dbo].[UpdateCustomers]
END
GO

IF TYPE_ID('Customer') IS NOT NULL
BEGIN
	DROP TYPE dbo.Customer
END
GO

CREATE TYPE Customer AS TABLE
(
	Id BIGINT NOT NULL
	,CustomerName NVARCHAR(50) NOT NULL
	,Address NVARCHAR(250) NOT NULL
	,ContactNumber NVARCHAR(16) NOT NULL
	,Country NVARCHAR(70) NOT NULL
)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateCustomers
(
	@Customers Customer READONLY
)
AS
BEGIN
	
SET NOCOUNT ON;

	UPDATE
		Customers
		SET 
			CustomerName = Customer.CustomerName
			,Address = Customer.Address
			,ContactNumber = Customer.ContactNumber
			,Country = Customer.Country
		FROM
			@Customers Customer
		WHERE
			Customers.Id = Customer.Id
END
GO