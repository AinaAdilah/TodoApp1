## Setup Instructions

###  Backend Setup

1. Open the solution in **Visual Studio**
2. Restore NuGet packages
3. Run the migration and update the database (if using EF Core):
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
4. Run the backend Ctrl+F5
	The browser will open this Default URL: https://localhost:7268/swagger/index.html

###  Frontend Setup

1. From your terminal, navigate to your todo-frontend folder
	cd todo-frontend
2. Install all dependencies
	npm install
3. Start the server
	npm start
4. Your browser will open the app at this url http://localhost:3000/

### Do Unit Test

1. From Visual Studio, Locate TodoApp1.Tests
2. Open Test Explorer, go to the top menu : Test > Test Explorer
3. Click "Run All" at top of Test Explorer. 
	You will see green checkmarks for passed test and cross red marks for any error