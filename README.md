*******************************************************************
						RocketLauncher 							
*******************************************************************
__________________________________________________________________	
Build, Publish & Run: dotnet commands
==================================================================
1. Navigate to root folder 'RocketLauncher'

2. dotnet restore

3. dotnet build

4. dotnet publish  <optional>

5. dotnet run

___________________________________________________________________
Build & Run: using Docker on local code
===================================================================
1. sudo docker build -t <app-name> .

2. sudo docker run -a stdin -a stdout -i -t <app-name>


___________________________________________________________________
Pull & Run: using Docker from docker hub
===================================================================
1. sudo docker pull rajesh563/rocketlauncher_prowareness

2. Run it in interaction mode as it is a console application
   sudo docker run -a stdin -a stdout -i -t rajesh563/rocketlauncher_prowareness
   
   
___________________________________________________________________
	Folder Structure			|		Dependencies
___________________________________________________________________
[ ] = folder
 -	= file
___________________________________________________________________

[RocketLauncher]
	- Sln
	- Dockerfile
	[Src]
		- Console App			| SimpleInjector/Microsoft.Extension.DependencyInjection, Microsoft.Extensions.Logging
		- Common Lib			| SimpleInjector/Microsoft.Extension.DependencyInjection, Newtonsoft.Json-10.0.3
		- Contract Lib
		- Business Lib
		- Inventory(DAL) Lib

	[Test]
		- Mstest Proj			| ExpectedObjects, Moq, Microsoft.NET.Test.sdk, 
								| MSTest.TestAdapter, MSTest.TestFramework


___________________________________________________________________
PS: Exclusive for NASA members only :p