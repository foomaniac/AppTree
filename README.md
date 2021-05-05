# AppTree
Application Registry and Dependency Tracker


#### EF Migrations

The application is EntityFramework Migrations enabled and the project that contains the migrations is SeeLive.Infrastructure.

To run the EF Migration commands you need to utilise the --startup-project arguement. 

Example using the VS 2019 Package Manager Console:

1) Select src\AppTree.Infrastructure in the 'Default project' window
1) cd to src\AppTree.Infrastructure
1) Run the example command below to create the database:

```
dotnet ef database update --startup-project ../AppTree
```

##### Adding Migrations

To add a migration, follow the steps above but instead run the command below:

```
dotnet ef migrations add _name_  --startup-project ../AppTree
````

# Build and Test
TODO: Describe and show how to build your code and run the tests. 
