-- Total Entry and exit count for each site

;WITH CTE_NumberOfVistis
AS
(
	SELECT
		Sitename
		,EntryCount = (SELECT COUNT(Id) FROM EntriesExits WHERE SiteId = CustomerSites.Id AND Direction = 'Entry')
		,ExitCount = (SELECT COUNT(Id) FROM EntriesExits WHERE SiteId = CustomerSites.Id AND Direction = 'Exit')
	FROM
		EntriesExits
	JOIN
		CustomerSites
		ON EntriesExits.SiteId = CustomerSites.Id
)
SELECT 
	Sitename
	,EntryCount
	,ExitCount
FROM 
	CTE_NumberOfVistis
GROUP BY Sitename, EntryCount, ExitCount


--For a certain time get the total visit count for each site 
--for each day if the input rage is in days 
--or each hour if the input range is in hours


DECLARE
	@FromTime DATETIME = '2022-01-22 01:01:01'
	,@ToTime DATETIME = '2022-01-23 00:00:01'

SELECT DATEDIFF(HOUR,@FromTime,@ToTime ) As [DifferenceInHours]

IF ( DATEDIFF(HOUR , @FromTime, @ToTime) >= 24)
BEGIN

WITH CTE_PartitionByDay
AS
(
SELECT
	NumberOfVisits = Count(EntriesExits.Id)
	,CustomerSites.Sitename
	,EntriesExits.Direction
	,VisitDate = CONVERT(DATE,EntriesExits.Time)
FROM
	EntriesExits
JOIN
	CustomerSites
	ON EntriesExits.SiteId = CustomerSites.Id
WHERE
	EntriesExits.Time BETWEEN @FromTime AND @ToTime
GROUP BY CONVERT(date,EntriesExits.Time), EntriesExits.Direction, CustomerSites.Sitename
)
SELECT
	Sitename 'SiteName'
	,[EntryCount] = IsNull([Entry],0)
	,[ExitCount] = IsNull([Exit],0)
	,[Time] = CONVERT(DATETIME, VisitDate)
FROM CTE_PartitionByDay
PIVOT 
(
	AVG (NumberOfVisits)
	FOR Direction
	IN 
	(
		[Entry]
		,[Exit]
	)
)AS PIVOT_Table

END

ELSE
BEGIN

WITH CTE_PartitionByDay
AS
(
SELECT
	NumberOfVisits = Count(EntriesExits.Id)
	,CustomerSites.Sitename
	,EntriesExits.Direction
	,VisitDate = CONVERT(DATE,EntriesExits.Time)
	,VisitHour = CAST(DATEPART(Hour, EntriesExits.Time) as varchar) + ':00'
FROM
	EntriesExits
JOIN
	CustomerSites
	ON EntriesExits.SiteId = CustomerSites.Id
WHERE
	EntriesExits.Time BETWEEN @FromTime AND @ToTime
GROUP BY CONVERT(date,EntriesExits.Time), DATEPART(HOUR,EntriesExits.Time), EntriesExits.Direction, CustomerSites.Sitename
)
SELECT
	Sitename 'SiteName'
	,[EntryCount] = IsNull([Entry],0)
	,[ExitCount] = IsNull([Exit],0)
	,[Time] = CAST(VisitDate as DATETIME) + CAST(VisitHour as DATETIME)
FROM CTE_PartitionByDay
PIVOT 
(
	AVG (NumberOfVisits)
	FOR Direction
	IN 
	(
		[Entry]
		,[Exit]
	)
)AS PIVOT_Table

END
