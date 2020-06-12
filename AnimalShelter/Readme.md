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

##### API Queries

To interact with this app & its database, API queries will be necessary. There are many free softwares for this, but I used Postman (https://www.postman.com/downloads/)  

To see all reviews, issue a get request to http://localhost:5000/api/reviews  
Current custom-sorts for queries utilize the "filter" field. EG:  

GET http://localhost:5000/api/reviews?filter=number_of_ratings  
returns reviews sorted highest-rated to lowest-rated by total number of reviews  

GET http://localhost:5000/api/reviews?filter=overall_ratings  
returns reviews sorted highest-rated to lowest-rated by average rating   

GET http://localhost:5000/api/reviews?filter=random  
returns a random review   

POSTs to the database can be done utilizing POST to api/reviews.  

Edits and deletes are qualified; unless the given username in the PUT or DELETE commands match the given review ID, it will fail.  Example:

DELETE http://localhost:5000/api/reviews/[id] | AND | "name" in body as username, to succesfully delete.  

PUT http://localhost:5000/api/reviews/[id] | AND | { "City": "X", "Country": "Y", "username": "Z", "rating": 0.0}   




##### Development Description:


Your project will be reviewed on the following objectives:  
Application includes CRUD functionality and successfully returns responses to API calls.  

Application includes at least one of the further exploration objectives: authentication, versioning, pagination, Swagger documentation, or CORS.  

Application is well-documented, including specific documentation on further exploration.  

Commit history clearly shows eight hours of work.  

##### Development specs/Phases:

Phase 1: Build Framework (bypass 'dotnet new mvc' for better practice) (Done? YES)  

Phase 2: Populate Models (dbcontext and animal entity) (Done? NO)  

Phase 3: Add Controller scaffolding (empty routes) (Done? NO)  

Phase 4: Populate "Index/Get" Route (Done? NO)  

Phase 5: Populate "Create" Route (Done? NO)  

Phase 6: Populate "Put" Route (Done? NO)  

Phase 7: Populate "Delete" Route (Done? NO)  

Phase 8: Populate "Details/Get" Route (Done? NO)  

Phase 9: Pre-Migration Build to Confirm integrity of work (Done? NO)  

Phase 10: Add Initial Migration (Done? NO)  

Phase 11: Verify DB Functionality/Routes with Postman (Done/ NO)  

Phase 12: "Extra Exploration": Swagger (TBD)


##### _Contact_:

CHuber42.Gmail.com

##### _Copyright Christopher Huber 2020, all rights reserved._
