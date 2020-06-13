## Project: **Week 13 - Friday Code Review - API Development**
#### Author: **Christopher Huber**
## Goal: Develop an API (Animal Shelter)

### Github page: https://github.com/CHuber42/Week-6-8-Code-Review
#### Github repo: You're standing on it.
##### Copyright Christopher Huber, 2020

&nbsp;
     
&nbsp;
         
##### Build instructions/Installation: 

This project is built in C# 8.0 using .netcoreapp2.2 on a system running Ubuntu 18.04.
Dependencies are declared in the APIProject.csproj and other files.
.NetCoreApp 2.2 Framework is required.  

To install, simply clone (or download) this folder into a new directory, git bash to the root folder,
and run dotnet restore.  

To Build: After install, run "Dotnet build" to compile the program.  

To run: Navigate to the root folder in a terminal and enter "dotnet run".  

##### MySQL/Appsettings.json Setup Instructions:

1. In the root directory, create a file named "appsettings.json" and paste in the following:  
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[Your_Database_Name];uid=[YourMySQLLoginUser];pwd=[YourMySQLLoginPassword];"
  }
}

2. Open a terminal into the root project directory. Run "dotnet ef migrations add MyVersion" to create your database (If you have chosen a new one)  

3. Now run "Dotnet ef database update" to apply the changes to your personal database, which serves as the database for this app.  

##### Using the API via SwaggerGUI

With the program/API running(See: Instructions/Installations), open a browser and navigate to:  
localhost:5000/index.html  

This will present you with a graphical user interface (Swagger/Swashbuckle) that will allow you to 
interact with the API in a more intuitive setting.  

GET/POST/PUT(edit)/DELETE routes are still managed using the requirements outlined in the below section (API Queries).  

##### API Queries

To interact with this app & its database, API queries will be necessary. There are many free softwares for this, but I used Postman (https://www.postman.com/downloads/)  

The Database Schema for animals is :  
<ul>
<li>"Name": "string"</li>  
<li>"Age": "integer"</li>  
<li>"Breed": "string"</li>  
<li>"Species": "string"</li>  
<li>"Gender": "string"</li>  
</ul>

To see all animals, issue a GET request to http://localhost:5000/api/animals  


An animal can be deleted with a DELETE request to:  
http://localhost:5000/api/animals/[AnimalId]  

An animal can be created with a POST request to:
http://localhost:5000/api/animals  
With body contents of the following format:  
{  
  "Name": "string",    
  "Age": "integer",    
  "Breed": "string",    
  "Species": "string",    
  "Gender": "string"    
}  
 
A specific Animal's details can be viewed with a GET request to that animal's ID in the route:  
http://localhost:5000/api/animals/[id]  
Or, obviously, with a filtered GET request to the generic route, based on a known trait  
(Name, for example(See above))    

An Animal can have its details edited with a PUT request to:  
http://localhost:5000/api/animals/[id]  
AND must contain the fields specified in the CREATE route detailed above.  

##### Custom Search Filters

A filtered list of animals can be acquired according to a number of filters appended to the api/animals GET request:  

Age-based Filtering:  
Required: Age (an integer) and a "filter" string of either "less_than" or "greater_than" to filter based on age.  
Age-based filters are inclusive; {"filter": "greater_than", "Age": 3} will return animals greater than or equal to age 3.  
Example: http://localhost:5000/api/animals?age=3&filter=greater_than  

Breed-based Filtering:  
Required: "Breed": string.  
Example: http://localhost:5000/api/animals?breed=tabby  

Gender-based Filtering:  
Required: "Gender": string.  
Example: http://localhost:5000/api/animals?gender=female  

Name-based Filtering:  
Required: "Name": string.  
Example: http://localhost:5000/api/animals?name=rosa  

Species-based Filtering:  
Required: "Species": string.  
Example: http://localhost:5000/api/animals?species=cat    

Random Animal:   
Required: "filter"="random".  
Example: http://localhost:5000/api/animals?filter=random

Paged Results:  
Required: "Page": int; "PageLength: int.  
Example: http://localhost:5000/api/animals?page=0&pagelength=4    

##### Extra Features (Vaccines/Vaccines List)

Vaccines can be accessed in much the same way as animals, however, they only possess a database ID and  
correspoding description/name. This is merely "the database of possible vaccines that can be applied".  

An animal can have a vaccine added to its record via the AnimalVaccines route. This is merely a join table  
that connects the animals database to the vaccines database; entries are managed as relationships.  
When adding or deleting an entry, the Animal's database Id and the Vaccine's database Id are required;  
feel free to use the Get methods for the respective databases to ensure the correct record is entered.  

An animal's vaccine records are not accessible through the generic GET route (api/animals).  
To view vaccination records, please access the GET route specific to that animal's Id;  
Example: api/animals/{2}  


##### Development Description:


Your project will be reviewed on the following objectives:  
Application includes CRUD functionality and successfully returns responses to API calls.  

Application includes at least one of the further exploration objectives: authentication, versioning, pagination, Swagger documentation, or CORS.  

Application is well-documented, including specific documentation on further exploration.  

Commit history clearly shows eight hours of work.  

##### Development specs/Phases:

Phase 1: Build Framework (bypass 'dotnet new mvc' for better practice) (Done? YES)  

Phase 2: Populate Models (dbcontext and animal entity) (Done? YES)  

Phase 3: Add Controller scaffolding (empty routes) (Done? YES)  

Phase 4: Populate "Index/GetAll" Route (Done? YES)  

Phase 5: Populate "Create" Route (Done? YES)  

Phase 6: Populate "Put" Route (Done? YES)  

Phase 7: Populate "Delete" Route (Done? YES)  

Phase 8: Populate "Details/Get" Route (Done? YES)  

Phase 9: Pre-Migration Build to Confirm integrity of work (Done? YES)  

Phase 10: Add Initial Migration (Done? YES)  

Phase 11: Verify DB Functionality/Routes with Postman (Done? YES)  

Phase 12: Add filtering to DB responses in GetAll (Done? YES)

##### "Extra Exploration"

Phase 13: "Extra Exploration": Swagger (Done? YES)

RANDOM endroute that returns random Animal (Done? YES)  

Implement Pagination (Done? YES)  

Refine Age-Based Filtering for >= or <= options/params (Done? YES)    

Add many-to-many relationship with Vaccinations Database (Done? YES)  

##### _Contact_:

CHuber42.Gmail.com

##### _Copyright Christopher Huber 2020, all rights reserved._
