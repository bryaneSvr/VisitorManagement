# DemoVisitorManagement

Prerequisite
1. dotNet Framework 4.7.2 - https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472
2. SQLServer 2019 - https://www.microsoft.com/en-in/sql-server/sql-server-downloads
3. SQL Server Management Studio 2018 - https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
4. Visual Studio 2022 -  https://visualstudio.microsoft.com/vs/community/
5. Any Browser - (Google Crome recommended)

Steps to Launch the site:
1. Download the codebase from the git repository : https://github.com/bryaneSvr/VisitorManagement
2. Create a database named "VisitorManagement", using SSMS and run the Release Scripts in order from 01 to 06 which is present under SQLScripts : https://github.com/bryaneSvr/VisitorManagement/tree/master/DemoVisitorManagement/SQLScripts/ReleaseScripts 
3. After running the database scripts using SSMS (Prerequisite - 2) and add the SQL server name to the data source of VisitorRepository in web.config
example : <add name="VisitorRepository" connectionString="Server=MYSQLSERVER;Database=VisitorManagement;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
4. Open the VisitorManagement.sln In Visual Studio 
5. Set the following configurations in tool bar
	a. Solution Configuration : Debug or Release
	b. Solution Platform : Any CPU
	c. Profiles : IIS Express

That's it. Launch the application (ctrl+F5) from Visual Studio 2022 and it should work!

Look into the https://localhost:44320/Help for API endpoint and Request JSON contents to be provided

Notes:
1. Have provided some sample API request here for a quick walk through : https://github.com/bryaneSvr/VisitorManagement/tree/master/Resources
