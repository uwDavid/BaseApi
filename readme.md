# Formula One App

## Dotnet Commands

```
dotnet new sln -n FormulaOne
dotnet new webapi -n FormulaOne.Api
dotnet sln FormulaOne.sln add FormulaOne.Api/

dotnet new classlib -n FormulaOne.Entities
dotnet sln FormulaOne.sln add FormulaOne.Entities/

dotnet new classlib -n FormulaOne.DataService
dotnet sln FormulaOne.sln add FormulaOne.DataService/

dotnet add FormulaOne.Api reference FormulaOne.DataService
dotnet add FormulaOne.Api reference FormulaOne.Entities
dotnet add FormulaOne.DataService reference FormulaOne.Entities
```

**Install Packages in DataService**

```
cd FormulaOne.DataService
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

**Using Env.Json**

```
cat ./env.json | dotnet user-secrets set
```
