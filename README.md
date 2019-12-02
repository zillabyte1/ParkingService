# ParkingService




Blazor Application

Parking Service Application
dfPark is a Visual Studio 2019 solution comprised of three projects:
	BlazorApp	- .NET Core 3.0 Blazor Application (Client)

	ParkingData	- Shared Data Model

	ParkingService	- .NET Core 3.0 WebAPI Service (Service)

	 	ReadMe.docx – THIS FILE

README.md – GitHub Readme
		

Application Requirements
The solutions utilizes the latest .NET Core technologies which may require additional downloads. Visual Studio needs to be updated in order to run the .NET Core 3.0 libraries.
Visual Studio 2019
	https://visualstudio.microsoft.com/downloads/

	https://dotnet.microsoft.com/download/visual-studio-sdks

	https://docs.microsoft.com/en-us/visualstudio/install/update-visual-studio?view=vs-2019

		

.NET Core 3.0
	Latest release of .NET Core Framework	
	dotnet-sdk-3.0.101-win-x64.exe	
	https://dotnet.microsoft.com/download/dotnet-core/3.0

		

User Requirements
	Internet Information Services must be installed with full Administrative Privileges to create and configure websites and perform local host* file changes.	
	* Administrator Rights required. The changes only affect local host and pose no security risk. These settings allow host headers to work with IIS and mimic a true production environment.	
		

 
Setup
Internet Information Services
	Two websites are required: dfpark.com and dfparkapi.com	
	 	Any host name can be used for sites
	Application Pools	
	 	The application pool  .NET CLR Version uses “No Managed Code” fpr .NET Core applications. 
	Host Headers	
	 	Use same host names in previous step
	Host file	
	 	C:\Windows\System32\drivers\etc

		
	 	127.0.0.1       dfpark.com
127.0.0.1       dfparkapi.com
		

 
MS SQL Server
	Create a database called parkdb	Any database can be used as long as it is referenced in “DefaultConnection” setting of the appsettings.json configuration file.
	 	
	
ParkingData - Data path: dfpark\ParkingData\Data	
	 	If you cannot attach the included database file you can recreate the database from the scripts located in the ParkingData / Data folder.
	createdatabase.sql	
	dbo.ParkingLog.Table.sql	
	dbo.ParkingLot.Table.sql	
	dbo.Users.sql	
	parkdb.mdf	
	parkdb_log.ldf	
		

Applications
BlazorApp 
	The BlazorApp Api connection is found in the appsettings.json file, “ConnectionStrings” section, “ApiUrl” property. The “ApiUrl” value is mapped to a valid url to the ParkService web api. In our example the api is located at “http://dfparkapi.com”. The BlazorApp does not need a direct connection to the database. The example below includes both connections need by each service.
	
	The settings should be changed in the development file and the published file.	
	\appsettings.json	
	\bin\netcoreapp3.0\publish\appsettings.json	
	 	
		
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=[SERVER];Initial Catalog=[DATABASE];Persist Security Info=True;User ID=parkuser; Password=test123",
    "ApiUrl": "http://dfparkapi.com"
  },
	[DATABASE] is the MS SQL server you will connect to. Credentials must match your environment.	

ParkingData 
	No special configuration changes are needed.
Source files define the data structure to be used across applications.
The MS SQL database parkdb.mdf resides in this folder.	
		

ParkingService 
	The ParkingService Database connection is found in the appsettings.json file, “ConnectionStrings” section, “DefaultConnection” property. The “DefaultConnection” value is mapped to a valid database connection that is used for the web api. In our example the “DefaultConnection” is 

"Data Source=[SERVER];Initial Catalog=[DATABASE];Persist Security Info=True;User ID=parkuser; Password=test123"

Only the ParkingService needs a direct connection to the database. 
The settings should be changed in the development file and the published file.	
	\appsettings.json	
	\bin\netcoreapp3.0\publish\appsettings.json	
		

	
	
Run without Recompiling
Set the proper settings in the “appsettings.json” file: BlazorApp “ApiUrl” and ParkService “DefaultConnection”.
IIS Website Configuration
	dfpark.com	
	Set the location path to the published directory on your hard drive	
	 	
	dfparkapi.com	
	Set the location path to the published directory on your hard drive	
	 	
		
		


