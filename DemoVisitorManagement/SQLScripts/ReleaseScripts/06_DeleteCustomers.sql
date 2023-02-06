IF (OBJECT_ID('DeleteCustomers', 'P') IS NOT NULL)
BEGIN
	DROP PROCEDURE [dbo].[DeleteCustomers]
END
GO

IF TYPE_ID('CustomerIds') IS NOT NULL
BEGIN
	DROP TYPE dbo.CustomerIds
END
GO

CREATE TYPE CustomerIds AS TABLE
(
	Id BIGINT NOT NULL
)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DeleteCustomers
(
	@Customers CustomerIds READONLY
)
AS
BEGIN
	
SET NOCOUNT ON;

	DELETE FROM
		EntriesExits
	WHERE
		SiteId
		IN
		(
			SELECT
				Id
			FROM
				CustomerSites
			WHERE
				CustomerID IN
				(
				SELECT
					Id
				FROM
					@Customers
				)
		)

		DELETE FROM 
			CustomerSites
		WHERE
			CustomerID IN
			(
			SELECT
				Id
			FROM
				@Customers
			)

		DELETE FROM
			Customers
		WHERE
			Id IN
			(
			SELECT
				Id
			FROM
				@Customers
			)

END
GO