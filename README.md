*******************************************************************
######################### RocketLauncher ##########################
*******************************************************************
___________________________________________________________________
	Folder Structure			|		Dependencies
___________________________________________________________________
[ ] : folder
 -	: file
===================================================================

[RocketLauncher]
	- Sln
	- Dockerfile
	[Src]
		- Console App			| SimpleInjector-4.0.11
		- Common Lib			| SimpleInjector-4.0.11, Newtonsoft.Json-10.0.3
		- Contract Lib
		- Business Lib
		- Inventory(DAL) Lib

	[Test]
		- Mstest Proj			| ExpectedObjects, Moq, Microsoft.NET.Test.sdk, 
								| MSTest.TestAdapter, MSTest.TestFramework


__________________________________________________________________	
Build, Publish & Run: dotnet commands
==================================================================
1. Navigate to root folder 'RocketLauncher'

2. dotnet restore

3. dotnet build

4. dotnet publish  <optional>

5. dotnet run

___________________________________________________________________
Build & Run: Docker 
===================================================================
1. sudo docker build -t <app-name> .

2. sudo docker run -a stdin -a stdout -i -t <app-name>


___________________________________________________________________
PS: Exclusive for NASA members only :p