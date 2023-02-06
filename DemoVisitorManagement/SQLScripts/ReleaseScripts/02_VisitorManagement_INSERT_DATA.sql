BEGIN TRANSACTION INSERT_DATA

USE VisitorManagement
GO

IF NOT EXISTS (SELECT 1 FROM Customers WHERE Id = 1903831)
BEGIN
	INSERT INTO Customers (CustomerName, Address, ContactNumber, Country)
		VALUES ('XYZ Pvt Ltd', '876, Golf Road, ABC', '+918989898989', 'India')
END
GO

IF NOT EXISTS (SELECT 1 FROM CustomerSites WHERE Id = 123211)
BEGIN
	INSERT INTO CustomerSites (CustomerId, Sitename)
		VALUES (1903831, 'Sitename 1')
	INSERT INTO CustomerSites (CustomerId, Sitename)
		VALUES (1903831, 'Sitename 2')
END
GO

IF NOT EXISTS (SELECT 1 FROM EntriesExits WHERE Id = 1)
BEGIN
	INSERT INTO EntriesExits (SiteId, Direction, GateNumber, Time)
		VALUES (123211, 'Entry', 1,'2022-01-22 08:20:24')
	INSERT INTO EntriesExits (SiteId, Direction, GateNumber, Time)
		VALUES (123211, 'Exit', 1, '2022-01-22 10:27:56')
	INSERT INTO EntriesExits (SiteId, Direction, GateNumber, Time)
		VALUES (123212, 'Entry', 1, '2022-01-23 06:02:44')
	INSERT INTO EntriesExits (SiteId, Direction, GateNumber, Time)
		VALUES (123212, 'Entry', 2, '2022-01-23 14:35:49')
END
GO

COMMIT TRANSACTION INSERT_DATA